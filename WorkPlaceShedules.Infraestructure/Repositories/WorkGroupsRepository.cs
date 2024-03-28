using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;
using WorkPlaceShedules.Infraestructure.Data;

namespace WorkPlaceShedules.Infraestructure.Repositories
{
    public class WorkGroupsRepository : GenericRepository<WorkGroupsEntity>, IWorkGroupsRepository
    {
        public WorkGroupsRepository(DataContext context) : base(context)
        {

        }
    }
}
