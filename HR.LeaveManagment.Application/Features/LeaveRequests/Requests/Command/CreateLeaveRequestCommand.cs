using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Responses;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command
{
    public class CreateLeaveRequestCommand : IRequest<ICommandResponse>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}
