

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest
{
    public interface ILeaveRequestDto
    {
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
