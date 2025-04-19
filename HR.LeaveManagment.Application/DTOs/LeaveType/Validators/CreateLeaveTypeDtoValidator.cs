using FluentValidation;
using HR.LeaveManagment.Application.Persistance.Contracts;

namespace HR.LeaveManagment.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} Is Required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");
        }
    }
}
