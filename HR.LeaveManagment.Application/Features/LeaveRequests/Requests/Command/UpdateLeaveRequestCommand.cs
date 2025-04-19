

using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto UpdateLeaveRequestDto { get; set; }

        public ChangeLeaveRequestApproval ChangeLeaveRequestApprovalDto { get; set; }
    }
}
