using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
