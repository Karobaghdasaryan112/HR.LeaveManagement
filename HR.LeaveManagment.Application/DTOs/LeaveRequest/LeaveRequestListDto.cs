

using HR.LeaveManagment.Application.DTOs.Common;
using HR.LeaveManagment.Application.DTOs.LeaveType;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; } 
        public DateTime DataRequested { get; set; }
        public bool Approved { get; set; }
    }
}
