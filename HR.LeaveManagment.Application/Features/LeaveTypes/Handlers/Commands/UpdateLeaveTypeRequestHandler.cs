using AutoMapper;
using FluentValidation;
using HR.LeaveManagment.Application.CustomExcpetions;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagment.Application.Persistance.Contracts;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeRequestHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private IValidator<UpdateLeaveTypeDto> _validator;

        public UpdateLeaveTypeRequestHandler(
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper,
            IValidator<UpdateLeaveTypeDto> validator)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var ValidationResult = await _validator.ValidateAsync(request.UpdateLeaveTypeDto, cancellationToken);

            if (!ValidationResult.IsValid)
                throw new CustomValidationException(ValidationResult);

            var updatedLeaveType = _mapper.Map<Domain.LeaveType>(request);

            await _leaveTypeRepository.UpdateAsync(updatedLeaveType);

            return Unit.Value;
        }
    }
}
