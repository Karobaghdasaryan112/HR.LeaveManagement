
using HR.LeaveManagment.Domain.Common;

namespace HR.LeaveManagment.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int NumberOFDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int LeaveTypeId { get; set; }    
        public int Period { get; set; } 

    }
}
