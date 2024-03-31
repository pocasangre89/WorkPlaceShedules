using WorkPlaceShedules.Domain.Entities;
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

        public async Task<int> AddShedule(T entity)
        {
            // Obtener la fecha del registro que queremos agregar
            var fechaRegistro = (DateTime)entity.GetType().GetProperty("Schedule").GetValue(entity);
            int UserId = (int)entity.GetType().GetProperty("UserId").GetValue(entity);

            // Verificar si ya existe un registro con la misma fecha en la base de datos
            var registroExistente = _context.Set<UserWorkPlaceShedulesEntity>().FirstOrDefault(x => x.Schedule.Date == fechaRegistro.Date && x.UserId == UserId);

            if (registroExistente == null)
            {
                // Si no existe un registro con la misma fecha, agregamos el nuevo registro al contexto
                _context.Set<T>().Add(entity);
                return 1;
            }
            else
            {
                // Si ya existe un registro con la misma fecha, puedes manejar la situación de acuerdo a tus necesidades
                return 0;
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
