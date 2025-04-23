using AutoMapper;
using MediatR;
using FluentValidation;
using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using HR.LeaveManagment.Application.Contracts.Infrastructure;
using HR.LeaveManagment.Application.Models;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, ICommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IValidator<CreateLeaveRequestDto> _validator;
        private ICommandResponse _commandResponse;
        private IEmailSender _emailSender;
        private IMapper _mapper;

        public CreateLeaveRequestCommandHandler(
            IEmailSender emailSender,
            IValidator<CreateLeaveRequestDto> validator,
            ILeaveRequestRepository leaveRequestRepository,
            ICommandResponse commandResponse,
            IMapper mapper)
        {
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

            if (!validationResult.IsValid)
            {
                baseCommandResponse = _commandResponse.CreateCommandResponse(
                      "Leave request creation failed",
                     false,
                     request.CreateLeaveRequestDto.Id,
                    validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var LeaveRequest = _mapper.Map<Domain.Entities.LeaveRequest>(request.CreateLeaveRequestDto);

            LeaveRequest = await _leaveRequestRepository.AddAsync(LeaveRequest);

            baseCommandResponse = _commandResponse.CreateCommandResponse(
                "Leave request created successfully",
                true,
                LeaveRequest.Id,
                default);

            var email = new Email(
                to: "employee@org.com",
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
