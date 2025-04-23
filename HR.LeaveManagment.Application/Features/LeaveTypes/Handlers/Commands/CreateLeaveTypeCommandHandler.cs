using AutoMapper;
using MediatR;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistance;
using FluentValidation;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Responses;
using HR.LeaveManagment.Domain.Entities;


namespace HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, ICommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveRequestRepository;
        private IMapper _mapper;
        private ICommandResponse _commandResponse;
        private readonly IValidator<CreateLeaveTypeDto> _validator;
        public CreateLeaveTypeCommandHandler(
            ICommandResponse commandResponse,
            IValidator<CreateLeaveTypeDto> validator,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _commandResponse = commandResponse;
            _leaveRequestRepository = leaveTypeRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<ICommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse BaseCommandResponse = default;
            var ValidatorResult = await _validator.ValidateAsync(request.CreateLeaveTypeDto, cancellationToken);
            if (!ValidatorResult.IsValid)
            {
                BaseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Creation Failed",
                    false,
                    request.CreateLeaveTypeDto.Id,
                    ValidatorResult.Errors.Select(q => q.ErrorMessage).ToList());
            }

            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);

            leaveType = await _leaveRequestRepository.AddAsync(leaveType);

            BaseCommandResponse = _commandResponse.CreateCommandResponse(
                "Creation Successful",
                true,
                leaveType.Id,
                default);

            return BaseCommandResponse;
        }
    }
}
