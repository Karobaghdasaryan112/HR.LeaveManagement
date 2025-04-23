using FluentValidation;
using HR.LeaveManagment.Application.Contracts.Persistance;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository; 

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveRequestRepository)
        {
            _leaveTypeRepository = leaveRequestRepository;

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{PropertyName} Is Required")
                .NotNull()
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be less than {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .NotEmpty().WithMessage("{PropertyName} Is Required")
                .NotNull()
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

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
