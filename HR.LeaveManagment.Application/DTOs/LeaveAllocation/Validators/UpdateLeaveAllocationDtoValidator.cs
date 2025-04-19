

using FluentValidation;
using HR.LeaveManagment.Application.Persistance.Contracts;

namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} Is Required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, cancellation) =>
                {
                    var leaveAllocationExists = await _leaveTypeRepository.Exists(id);
                    return leaveAllocationExists;
                }).WithMessage("{PropertyName} does not exist");



        }
    }
}
