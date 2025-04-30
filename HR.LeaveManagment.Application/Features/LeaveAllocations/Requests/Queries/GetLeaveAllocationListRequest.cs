using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
        public bool IsLoggedInUser;
    }
}
