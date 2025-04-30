using AutoMapper;
using MediatR;
using FluentValidation;
using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using HR.LeaveManagment.Application.Contracts.Infrastructure;
using HR.LeaveManagment.Application.Models;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, ICommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IValidator<CreateLeaveRequestDto> _validator;
        private IHttpContextAccessor _httpContextAccessor;
        private ICommandResponse _commandResponse;
        private IEmailSender _emailSender;
        private IMapper _mapper;

        public CreateLeaveRequestCommandHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IHttpContextAccessor httpContextAccessor,
            IEmailSender emailSender,
            IValidator<CreateLeaveRequestDto> validator,
            ILeaveRequestRepository leaveRequestRepository,
            ICommandResponse commandResponse,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _httpContextAccessor = httpContextAccessor;
            _leaveRequestRepository = leaveRequestRepository;
            _validator = validator;
            _commandResponse = commandResponse;
            _emailSender = emailSender;
            _mapper = mapper;
        }
        public async Task<ICommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse baseCommandResponse = default;

            var validationResult = await _validator.ValidateAsync(request.CreateLeaveRequestDto, cancellationToken);
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "uid")?.Value;
            var allocation = await _leaveAllocationRepository.GetUserAllocatrions(userId,
                request.CreateLeaveRequestDto.LeaveTypeId);
            var dayRequested = (int)(request.CreateLeaveRequestDto.EndDate - request.CreateLeaveRequestDto.StartDate).TotalDays;

            if(dayRequested > allocation.NumberOFDays)
            {
                baseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Leave request creation failed",
                    false,
                    request.CreateLeaveRequestDto.Id,
                    new List<string> { "You do not have enough leave days" });

                return baseCommandResponse;
            }
            if (!validationResult.IsValid)
            {
                baseCommandResponse = _commandResponse.CreateCommandResponse(
                      "Leave request creation failed",
                     false,
                     request.CreateLeaveRequestDto.Id,
                    validationResult.Errors.Select(x => x.ErrorMessage).ToList());

                return baseCommandResponse;
            }

            var LeaveRequest = _mapper.Map<Domain.Entities.LeaveRequest>(request.CreateLeaveRequestDto);
            LeaveRequest.RequestingEmployeeId = userId;
            LeaveRequest = await _leaveRequestRepository.AddAsync(LeaveRequest);

            baseCommandResponse = _commandResponse.CreateCommandResponse(
                "Leave request created successfully",
                true,
                LeaveRequest.Id,
                default);

            var emailAddress = _httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(cl =>
                    cl.Type == JwtRegisteredClaimNames.Email ||
                    cl.Type == ClaimTypes.Email)?.Value;

            var email = new Email(
                to: emailAddress,
                subject: "Leave Request Submitted",
                body: $"Your Leave Request for " +
                $"{request.CreateLeaveRequestDto.StartDate} to " +
                $"{request.CreateLeaveRequestDto.EndDate}");

            try
            {
                await _emailSender.SendEmailAsync(email);
            }
            catch(Exception ex)
            {
                // Log the exception
            }


            return baseCommandResponse;
        }
    }
}
