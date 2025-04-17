using HR.LeaveManagment.Domain;


namespace HR.LeaveManagment.Application.Persistance.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsByEmployee(string employeeId);
        Task<List<LeaveRequest>> GetLeaveRequestsByEmployeeAndType(string employeeId, int leaveTypeId);
    }
}
