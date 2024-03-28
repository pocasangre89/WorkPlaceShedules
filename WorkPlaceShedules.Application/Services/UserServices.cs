using AutoMapper;
using WorkPlaceShedules.Application.Model.Users;
using WorkPlaceShedules.Application.Services.Interfaces;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;
using WorkPlaceShedules.Infraestructure.Repositories;

namespace WorkPlaceShedules.Application.Services
{
    public class UserServices : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly IJWTService _jwtService;
        public UserServices(IUsersRepository usersRepository, IMapper mapper, IJWTService jwtService)
        {
            _usersRepository = usersRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UsersResponseModel>> GetAll()
        {
            var UsersEntity = await _usersRepository.GetAllAsync();

            var UsersResponseModel = _mapper.Map<IEnumerable<UsersResponseModel>>(UsersEntity);

            return UsersResponseModel;
        }


        public UsersResponseModel GetById(int id)
        {
            var usersEntity = _usersRepository.GetByIdAsync(id);

            var usersResponseModel = _mapper.Map<UsersResponseModel>(usersEntity);

            return usersResponseModel;
        }

        public async Task Add(UsersRequestModel entity)
        {
            var usersResponseModel = _mapper.Map<UsersEntity>(entity);
            await _usersRepository.AddAsync(usersResponseModel);
        }

        public async Task Update(UsersRequestModel entity, int id)
        {
            UsersEntity usersEntity = _usersRepository.GetByIdAsync(id) ?? throw new Exception("El usuario no existe");

            var usersRequestModel = _mapper.Map(entity, usersEntity);
            await _usersRepository.UpdateAsync(usersRequestModel);
        }

        public async Task Delete(int id)
        {
            await _usersRepository.DeleteAsync(id);
        }




        public async Task<string> Login(LoginRequestModel request)
        {
            var loginSuccess = _usersRepository.Login(request.Email, request.Password);

            if (loginSuccess) { return _jwtService.GenerateToken(request.Email); }

            return "Ha ocurrido un error al intentar logearse";

        }
    }
}
