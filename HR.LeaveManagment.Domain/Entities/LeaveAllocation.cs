using HR.LeaveManagment.Domain.Common;

namespace HR.LeaveManagment.Domain.Entities
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int NumberOFDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; } = null!;
        public int Period { get; set; }

    }
}
