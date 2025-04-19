using HR.LeaveManagment.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public UpdateLeaveTypeDto UpdateLeaveTypeDto { get; set; }
    }
}
