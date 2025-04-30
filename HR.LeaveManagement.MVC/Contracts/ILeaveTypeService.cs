using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypesAsync();
        Task<LeaveTypeVM> GetLeaveTypeDetailsAsync(int Id);
        Task<Response<int>> CreateLeaveTypeAsync(CreateLeaveTypeVM model);
        Task<Response<int>> UpdateLeaveTypeAsync(int Id,LeaveTypeVM leaveTypeVM);
        Task<Response<int>> DeleteLeaveTypeAsync(int Id);
    }
}
