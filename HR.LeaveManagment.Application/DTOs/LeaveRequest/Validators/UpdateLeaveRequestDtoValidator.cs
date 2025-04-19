

using FluentValidation;
using HR.LeaveManagment.Application.Persistance.Contracts;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));

            RuleFor(l => l.Id)
                .NotNull()
                .WithMessage("{PropertyName} must be present")
                .NotEmpty()
                .WithMessage("{PropertyName} must be present")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");
        }
    }
}
