
using FluentValidation;
using HR.LeaveManagment.Application.Contracts.Persistance;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveRequestRepository)
        {
            _leaveTypeRepository = leaveRequestRepository;

            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));

        }
    }
}
