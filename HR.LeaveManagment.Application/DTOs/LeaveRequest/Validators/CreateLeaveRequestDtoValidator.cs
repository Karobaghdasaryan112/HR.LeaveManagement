
using FluentValidation;
using HR.LeaveManagment.Application.Persistance.Contracts;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveRequestRepository)
        {
            _leaveTypeRepository = leaveRequestRepository;

            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));

            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} Is Required")
                .NotNull()
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");
        }
    }
}
