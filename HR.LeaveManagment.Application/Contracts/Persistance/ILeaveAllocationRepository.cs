using HR.LeaveManagment.Domain.Entities;

namespace HR.LeaveManagment.Application.Contracts.Persistance
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();

        Task<bool> AllocationExists(string UserId, int leaveTypeId, int period);

        Task<bool> AddAllocations(List<LeaveAllocation> leaveAllocations);

        Task<LeaveAllocation> GetUserAllocatrions(string userId, int LeaveTypeId);

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);
    }
}
