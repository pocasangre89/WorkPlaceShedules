namespace WorkPlaceShedules.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        T GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        Task<int> AddShedule(T entity);
        //Task<T> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
