using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagment.Persistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveRequestRepository(LeaveManagementDbContext LeaveManagementDbContext) : base(LeaveManagementDbContext)
        {
            _dbContext = LeaveManagementDbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;  
             await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequestWithDetials =
                await _dbContext.LeaveRequests
                      .Include(q => q.LeaveType)
                      .ToListAsync();

            return leaveRequestWithDetials;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int Id)
        {

            return
                await _dbContext.LeaveRequests.
                Include(q => q.LeaveType).
                FirstAsync(q => q.Id == Id);
        }
    }
}
