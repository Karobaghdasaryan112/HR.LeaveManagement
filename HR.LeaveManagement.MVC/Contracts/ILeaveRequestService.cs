using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface ILeaveRequestService
    {
        Task<EmpoleeLeaveRequestViewVM> GetLeaveRequests();
        Task<LeaveRequestVM> GetLeaveRequestWitrhDetails(int Id);
        Task<Response<int>> UpdateLeaveRequest(int Id, LeaveRequestVM leaveRequestVM);
        Task DeleteLeaveRequest(int id);
        Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM leaveRequestVM);
    }
}
