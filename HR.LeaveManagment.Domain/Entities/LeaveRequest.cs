using HR.LeaveManagment.Domain.Common;
using System.Text.Json.Serialization;

namespace HR.LeaveManagment.Domain.Entities
{
    public class LeaveRequest : BaseDomainEntity
    {
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime? DateActioned { get; set; }
        public string RequestComments { get; set; }
        public bool Approved { get; set; }
        public bool Canceled { get; set; }
        public string RequestingEmployeeId { get; set; }
    }
}
