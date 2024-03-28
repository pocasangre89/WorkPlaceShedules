using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;
using WorkPlaceShedules.Infraestructure.Data;

namespace WorkPlaceShedules.Infraestructure.Repositories
{
    public class WorkPlacesRepository : GenericRepository<WorkPlacesEntity>, IWorkPlacesRepository
    {
        public WorkPlacesRepository(DataContext context) : base(context)
        {

        }
    }
}
