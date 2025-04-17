using HR.LeaveManagment.Application.DTOs.Common;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDto : BaseDto
    {
        public int LeaveTypeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool Approved { get; set; }
        public bool Canceled { get; set; }
    }
}
