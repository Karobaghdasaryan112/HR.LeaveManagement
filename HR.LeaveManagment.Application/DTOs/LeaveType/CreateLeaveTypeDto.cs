
using HR.LeaveManagment.Application.DTOs.Common;

namespace HR.LeaveManagment.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDto : BaseDto,ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
