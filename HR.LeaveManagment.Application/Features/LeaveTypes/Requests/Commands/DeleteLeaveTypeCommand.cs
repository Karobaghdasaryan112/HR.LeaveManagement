using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
