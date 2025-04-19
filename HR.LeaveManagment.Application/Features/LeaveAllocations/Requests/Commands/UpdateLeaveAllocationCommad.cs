

using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommad : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
