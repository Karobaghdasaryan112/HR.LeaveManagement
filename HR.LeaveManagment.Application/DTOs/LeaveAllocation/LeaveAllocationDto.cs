using HR.LeaveManagement.MVC.Services.Base;
using HR.LeaveManagment.Application.DTOs.Common;
using HR.LeaveManagment.Application.Models.Identity;

namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOFDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public Models.Identity.Employee Employee { get; set; }
        public string EmployeeId { get; set; }
    }
}
