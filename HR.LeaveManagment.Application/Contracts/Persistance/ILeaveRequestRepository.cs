using HR.LeaveManagment.Domain.Entities;

namespace HR.LeaveManagment.Application.Contracts.Persistance
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(int Id);
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool approvalStatus);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);
    }
}
