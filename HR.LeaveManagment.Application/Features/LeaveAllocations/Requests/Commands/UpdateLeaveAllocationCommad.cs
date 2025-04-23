

using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.Responses;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommad : IRequest<ICommandResponse>
    {
        public UpdateLeaveAllocationDto UpdateLeaveAllocationDto { get; set; }
    }
}
