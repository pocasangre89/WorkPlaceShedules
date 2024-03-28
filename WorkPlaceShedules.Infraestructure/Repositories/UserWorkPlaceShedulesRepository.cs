using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;
using WorkPlaceShedules.Infraestructure.Data;

namespace WorkPlaceShedules.Infraestructure.Repositories
{
    public class UserWorkPlaceShedulesRepository : GenericRepository<UserWorkPlaceShedulesEntity>, IUserWorkPlaceShedulesRepository
    {
        public UserWorkPlaceShedulesRepository(DataContext context) : base(context)
        {

        }
    }
}
