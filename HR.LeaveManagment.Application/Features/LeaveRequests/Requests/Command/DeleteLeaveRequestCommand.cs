using HR.LeaveManagment.Application.Responses;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command
{
    public class DeleteLeaveRequestCommand : IRequest<ICommandResponse>
    {
        public int Id { get; set; }
    }
}
