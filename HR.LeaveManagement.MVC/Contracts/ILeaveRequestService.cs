using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface ILeaveRequestService
    {
        Task<EmpoleeLeaveRequestViewVM> GetUserLeaveRequests();
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
        Task DeleteLeaveRequest(int id);
        Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM leaveRequestVM);
        Task ApproveLeaveRequest(int id, bool approved);
        Task<LeaveRequestVM> GetLeaveRequest(int id);
    }
}
