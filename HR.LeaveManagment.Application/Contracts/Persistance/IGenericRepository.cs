namespace HR.LeaveManagment.Application.Contracts.Persistance
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> Exists(int id);
    }
}

