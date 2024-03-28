using WorkPlaceShedules.Domain.Repositories;
using WorkPlaceShedules.Infraestructure.Data;

namespace WorkPlaceShedules.Infraestructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch(Exception ex) {
                string aa = "";
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByIdAsync(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public  async Task UpdateAsync(T entity)
        {
             _context.Set<T>().Update(entity);
        }
    }
}
