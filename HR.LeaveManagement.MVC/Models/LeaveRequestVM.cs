using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.MVC.Models
{
    public class LeaveRequestVM : CreateLeaveRequestVM
    {
        public int Id { get; set; }
        [Display(Name = "Date Requested")]
        public DateTime DataRequested { get; set; }
        [Display(Name = "Date Actioned")]
        public DateTime DataActioned { get; set; }
        [Display(Name = "Approval State")]
        public bool Approved { get; set; }
        [Display(Name = "Approval State")]
        public bool Canceled { get; set; }
        public LeaveTypeVM LeaveType{ get; set; } 
        public EmployeeVM Employee { get; set; } 
    }
    public class CreateLeaveRequestVM
    {
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartedDate { get; set; }
        [Required]
        [DisplayName("End Date")]
        public DateTime EndTime { get; set; }

        public SelectList LeaveTypes { get; set; }
        [Display(Name = "Leave Type")]
        [Required]
        public int LeaveTypeId { get; set; }
        [DisplayName("Comments")]
        [MaxLength(300, ErrorMessage = "Maximum length is 250 characters")]
        public string RequestComments { get; set; } = string.Empty;
    }

    public class AdminLeaveRequestViewVM
    {
        public int TotalRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int PendingRequests { get; set; }
        public int RejectedRequests { get; set; }
        public List<LeaveRequestVM> leaveRequestVMs { get; set; }
    }

    public class EmpoleeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> leaveAllocationVMs { get; set; }
        public List<LeaveRequestVM> leaveRequestVMs { get; set; }
    }

}