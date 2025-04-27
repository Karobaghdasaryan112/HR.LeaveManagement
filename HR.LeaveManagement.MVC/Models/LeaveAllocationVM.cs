using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.MVC.Models
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }
        [DisplayName("Number Of Days")]
        public int NumberOfDays { get; set; }

        public DateTime DataCreated { get; set; }
        public int Period { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
    public class CreateLeaveAllocationVM
    {
        public int LeaveTypeId { get; set; }
    }
    public class  UpdateLeaveAllocationVM
    {
        public int Id { get; set; }
        [Display(Name = "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Enter Valid Number")]
        public int NumberOfDays { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
    }
    public class ViewLeaveAllocationVM
    {
        public string EmployeeId { get; set; }
        public List<LeaveAllocationVM> LeaveAllocationVMs { get; set; }
    }
}