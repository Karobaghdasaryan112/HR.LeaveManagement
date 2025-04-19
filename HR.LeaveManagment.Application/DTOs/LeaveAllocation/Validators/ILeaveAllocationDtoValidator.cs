using FluentValidation;
using HR.LeaveManagment.Application.Persistance.Contracts;

namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation.Validators
{
    public class LeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private ILeaveTypeRepository _leaveTypeRepository;
        public LeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} Is Required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(p => p.Period)
                .NotEmpty().WithMessage("{PropertyName} Is Required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");


            RuleFor(p => p.LeaveTypeId)
                .NotEmpty().WithMessage("{PropertyName} Is Required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, cancellation) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return leaveTypeExists;
                }).WithMessage("{PropertyName} does not exist");

        }
    }
}
