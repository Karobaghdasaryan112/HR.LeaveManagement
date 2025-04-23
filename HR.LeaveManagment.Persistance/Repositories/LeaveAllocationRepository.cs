using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagment.Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext LeaveManagementDbContext) : base(LeaveManagementDbContext)
        {
            _dbContext = LeaveManagementDbContext;
        }
        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
           return await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            return await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstAsync(q => q.Id == id);
        }
    }
}
