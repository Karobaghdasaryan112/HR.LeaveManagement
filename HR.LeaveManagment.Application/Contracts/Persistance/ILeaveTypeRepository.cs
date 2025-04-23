using HR.LeaveManagment.Domain.Entities;

namespace HR.LeaveManagment.Application.Contracts.Persistance
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<LeaveType> GetLeaveTypeWithDetails(int id);
        Task<List<LeaveType>> GetLeaveTypesWithDetails();
    }
}
