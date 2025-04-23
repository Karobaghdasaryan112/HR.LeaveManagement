using AutoMapper;
using FluentValidation;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using HR.LeaveManagment.Domain.Entities;


namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, ICommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IValidator<CreateLeaveAllocationDto> _validator;
        private ICommandResponse _commandResponse;
        private IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(
            IValidator<CreateLeaveAllocationDto> validator,
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper,
            ICommandResponse commandResponse)
        {
            _validator = validator;
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _commandResponse = commandResponse;
        }

        public async Task<ICommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.LeaveAllocationDto, cancellationToken);

            BaseCommandResponse BaseCommandResponse = default;
            if (!validationResult.IsValid)
            {
                BaseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Creation Filed",
                    false,
                    request.LeaveAllocationDto.Id,
                    validationResult.Errors.Select(q => q.ErrorMessage).ToList());
            }
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);

            leaveAllocation = await _leaveAllocationRepository.AddAsync(leaveAllocation);

            BaseCommandResponse = _commandResponse.CreateCommandResponse(
                "Creation Successful",
                true,
                leaveAllocation.Id,
                default);

            return BaseCommandResponse;
        }
    }
}
