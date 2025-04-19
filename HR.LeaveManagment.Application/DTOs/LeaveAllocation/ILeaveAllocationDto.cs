

namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation
{
    public interface ILeaveAllocationDto
    {
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public int NumberOfDays { get; set; }
    }
}
