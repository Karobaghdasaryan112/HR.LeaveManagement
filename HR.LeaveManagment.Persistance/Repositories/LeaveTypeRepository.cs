using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagment.Persistance.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private LeaveManagementDbContext _dbContext;
        public LeaveTypeRepository(LeaveManagementDbContext LeaveManagementDbContext) : base(LeaveManagementDbContext)
        {
            _dbContext = LeaveManagementDbContext;
        }

        public async Task<List<LeaveType>> GetLeaveTypesWithDetails()
        {
            return  await _dbContext.LeaveTypes.ToListAsync();
        }

        public Task<LeaveType> GetLeaveTypeWithDetails(int id)
        {
            return _dbContext.LeaveTypes
                .FirstAsync(q => q.Id == id);
        }
    }
}
