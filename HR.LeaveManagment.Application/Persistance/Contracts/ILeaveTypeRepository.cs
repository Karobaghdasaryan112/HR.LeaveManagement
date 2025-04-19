using HR.LeaveManagment.Domain;

namespace HR.LeaveManagment.Application.Persistance.Contracts
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<LeaveType> GetLeaveTypeWithDetails(int id);
        Task<List<LeaveType>> GetLeaveTypesWithDetails();
    }
}
