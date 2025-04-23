using HR.LeaveManagment.Domain.Entities;

namespace HR.LeaveManagment.Application.Contracts.Persistance
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}
