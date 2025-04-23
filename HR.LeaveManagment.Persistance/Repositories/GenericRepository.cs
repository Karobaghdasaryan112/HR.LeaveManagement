using HR.LeaveManagment.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagment.Persistance.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly LeaveManagementDbContext _dbContext;
        public GenericRepository(LeaveManagementDbContext LeaveManagementDbContext)
        {
            _dbContext = LeaveManagementDbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return  await GetAsync(id) != default;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
