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

        public async Task<bool> AddAllocations(List<LeaveAllocation> leaveAllocations)
        {
            await _dbContext.LeaveAllocations.AddRangeAsync(leaveAllocations);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AllocationExists(string UserId, int leaveTypeId, int period)
        {
            return await _dbContext.LeaveAllocations
                .AnyAsync(q => q.EmployeeId == UserId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
           return await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocations = await _dbContext.LeaveAllocations.Where(q => q.EmployeeId == userId)
               .Include(q => q.LeaveType)
               .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetUserAllocatrions(string userId, int LeaveTypeId)
        {
           return await _dbContext.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == LeaveTypeId);
        }
    }
}
