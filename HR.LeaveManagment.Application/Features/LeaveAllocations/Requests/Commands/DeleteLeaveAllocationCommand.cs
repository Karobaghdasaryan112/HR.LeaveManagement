using HR.LeaveManagment.Application.Responses;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class DeleteLeaveAllocationCommand : IRequest<ICommandResponse>
    {
        public int Id  { get; set; }
    }
}
