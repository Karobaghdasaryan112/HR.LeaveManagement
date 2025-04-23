using FluentValidation;

namespace HR.LeaveManagment.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                          .NotEmpty().WithMessage("{PropertyName} Is Required")
                          .NotNull()
                          .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} Is Required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}");

        }
    }
}
