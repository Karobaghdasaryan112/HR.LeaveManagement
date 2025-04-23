using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Responses;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<ICommandResponse>
    {
        public UpdateLeaveTypeDto UpdateLeaveTypeDto { get; set; }
    }
}
