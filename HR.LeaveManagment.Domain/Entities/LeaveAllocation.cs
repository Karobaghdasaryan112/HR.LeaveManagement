using HR.LeaveManagment.Domain.Common;

namespace HR.LeaveManagment.Domain.Entities
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int NumberOFDays { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public int Period { get; set; }
        public string EmployeeId { get; set; } = null!;

    }
}
