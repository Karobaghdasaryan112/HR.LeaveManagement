using FluentValidation;
using HR.LeaveManagment.Application.Contracts.Persistance;

namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;


            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than zero")
                .MustAsync(async (id, token) => await _leaveTypeRepository.Exists(id) != null)
                .WithMessage("{PropertyName} does not exist");

        }
    }
}
