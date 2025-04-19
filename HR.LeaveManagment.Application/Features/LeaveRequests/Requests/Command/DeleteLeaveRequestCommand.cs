using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command
{
    public class DeleteLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
