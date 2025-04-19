using HR.LeaveManagment.Application.DTOs.LeaveType;
using MediatR;


namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}
