using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;
using WorkPlaceShedules.Infraestructure.Data;

namespace WorkPlaceShedules.Infraestructure.Repositories
{
    public class UsersRepository : GenericRepository<UsersEntity>, IUsersRepository
    {
        public UsersRepository(DataContext context) : base(context) 
        { 

        }
    }
}
