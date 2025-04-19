

using HR.LeaveManagment.Application.DTOs.Common;

namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto : BaseDto,ILeaveAllocationDto
    {
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public int NumberOfDays { get; set; }
    }
}
