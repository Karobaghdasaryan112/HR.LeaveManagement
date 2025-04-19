using HR.LeaveManagment.Application.DTOs.Common;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApproval : BaseDto
    {
        public bool Approved { get; set; }
    }
}
