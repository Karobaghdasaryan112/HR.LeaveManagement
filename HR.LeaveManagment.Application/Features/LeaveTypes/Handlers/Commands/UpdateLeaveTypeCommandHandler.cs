using AutoMapper;
using FluentValidation;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using HR.LeaveManagment.Domain.Entities;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, ICommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private IValidator<UpdateLeaveTypeDto> _validator;
        private ICommandResponse _commandResponse;

        public UpdateLeaveTypeCommandHandler(
            ICommandResponse commandResponse,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper,
            IValidator<UpdateLeaveTypeDto> validator)
        {
            _commandResponse = commandResponse;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<ICommandResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse baseCommandResponse = default;
            var ValidationResult = await _validator.ValidateAsync(request.UpdateLeaveTypeDto, cancellationToken);

            if (!ValidationResult.IsValid)
            {
                baseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Leave Type update failed",
                    false,
                    request.UpdateLeaveTypeDto.Id,
                    ValidationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var updatedLeaveType = _mapper.Map<LeaveType>(request.UpdateLeaveTypeDto);

            await _leaveTypeRepository.UpdateAsync(updatedLeaveType);

            baseCommandResponse = _commandResponse.CreateCommandResponse(
                "Leave Type updated successfully",
                true,
                request.UpdateLeaveTypeDto.Id,
                default);

            return baseCommandResponse;
        }
    }
}
