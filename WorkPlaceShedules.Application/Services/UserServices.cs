﻿using AutoMapper;
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
            usersResponseModel.Password = "Password123";
            await _usersRepository.AddAsync(usersResponseModel);
            await _usersRepository.SaveChangesAsync();
        }

        public async Task Update(UsersRequestModel entity)
        {
            UsersEntity usersEntity = _usersRepository.GetByIdAsync(entity.UserId) ?? throw new Exception("El usuario no existe");

            var usersRequestModel = _mapper.Map(entity, usersEntity);
            await _usersRepository.UpdateAsync(usersRequestModel);
            await _usersRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _usersRepository.DeleteAsync(id);
            await _usersRepository.SaveChangesAsync();
        }




        public async Task<string> Login(LoginRequestModel request)
        {
            var loginSuccess = _usersRepository.Login(request.Email, request.Password);

            if (loginSuccess) { return _jwtService.GenerateToken(request.Email); }

            return null;

        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
