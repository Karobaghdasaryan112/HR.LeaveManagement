using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
