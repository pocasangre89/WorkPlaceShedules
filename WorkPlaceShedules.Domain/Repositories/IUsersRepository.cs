using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Domain.Repositories
{
    public interface IUsersRepository : IGenericRepository<UsersEntity>
    {
        bool Login(string username, string password);
        UsersEntity GetByEmail(string username);
        //Task SaveChangesAsync();
    }
}
