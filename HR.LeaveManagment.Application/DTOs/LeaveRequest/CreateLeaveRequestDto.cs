

using HR.LeaveManagment.Application.DTOs.Common;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest
{
    public class CreateLeaveRequestDto : BaseDto, ILeaveRequestDto
    {
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestComments { get; set; }
    }
}
