using HR.LeaveManagment.Application.DTOs.LeaveType;
using MediatR;


namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
       public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
    }
}
