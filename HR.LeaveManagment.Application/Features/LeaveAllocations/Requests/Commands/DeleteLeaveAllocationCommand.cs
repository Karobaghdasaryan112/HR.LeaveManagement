using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id  { get; set; }
    }
}
