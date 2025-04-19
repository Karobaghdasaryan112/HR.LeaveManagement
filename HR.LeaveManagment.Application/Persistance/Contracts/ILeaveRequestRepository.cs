using HR.LeaveManagment.Domain;


namespace HR.LeaveManagment.Application.Persistance.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(int Id);
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool approvalStatus);
    }
}
