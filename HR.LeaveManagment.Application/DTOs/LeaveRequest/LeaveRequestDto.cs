using HR.LeaveManagment.Application.DTOs.Common;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Models.Identity;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDto : BaseDto
    {
        public int LeaveTypeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime? DateActioned { get; set; }
        public string RequestComments { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
        public Employee Employee { get; set; }
        public string RequestingEmployeeId { get; set; }
    }
}
