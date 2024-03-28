using WorkPlaceShedules.Application.Model.Users;

namespace WorkPlaceShedules.Application.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UsersResponseModel>> GetAll();
        UsersResponseModel GetById(int id);
        Task Add(UsersRequestModel entity);
        Task Update(UsersRequestModel entity, int id);
        Task Delete(int id);
        Task<string> Login(LoginRequestModel request);
    }
}
