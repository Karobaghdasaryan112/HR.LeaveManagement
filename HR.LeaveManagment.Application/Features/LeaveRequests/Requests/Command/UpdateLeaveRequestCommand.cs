

using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Responses;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command
{
    public class UpdateLeaveRequestCommand : IRequest<ICommandResponse>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto UpdateLeaveRequestDto { get; set; }

        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }
    }
}
