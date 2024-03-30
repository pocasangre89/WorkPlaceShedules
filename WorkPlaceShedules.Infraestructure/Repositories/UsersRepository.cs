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
        public UsersEntity GetByEmail(string email)
        {
            return this._context.Users.FirstOrDefault(x => x.Email.Equals(email));
        }


        public bool Login(string email, string password)
        {
            UsersEntity user = GetByEmail(email) ?? throw new Exception("El usuario no existe");

            if (!user.Password.Equals(password))
            {
                throw new Exception("Contraseña incorrecta");
            }
            return true;
        }

        //public Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
