using AutoMapper;
using WorkPlaceShedules.Application.Model.WorkPlaceShedules;
using WorkPlaceShedules.Application.Services.Interfaces;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;
using WorkPlaceShedules.Infraestructure.Repositories;

namespace WorkPlaceShedules.Application.Services
{
    public class UserWorkPlaceShedulesServices : IUserWorkPlaceShedulesServices
    {
        private readonly IUserWorkPlaceShedulesRepository _userWorkPlaceShedules;
        private readonly IMapper _mapper;
        public UserWorkPlaceShedulesServices(IUserWorkPlaceShedulesRepository userWorkPlaceShedules, IMapper mapper)
        {
            _userWorkPlaceShedules = userWorkPlaceShedules;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UserWorkPlaceShedulesResponseModel>> GetAll()
        {
            var userWorkPlaceShedules = await _userWorkPlaceShedules.GetAllAsync();

            var userWorkPlaceShedulesResponse = _mapper.Map<IEnumerable<UserWorkPlaceShedulesResponseModel>>(userWorkPlaceShedules);

            return userWorkPlaceShedulesResponse;
        }


        public UserWorkPlaceShedulesResponseModel GetById(int id)
        {
            var userWorkPlaceShedules = _userWorkPlaceShedules.GetByIdAsync(id);

            var userWorkPlaceShedulesResponse = _mapper.Map<UserWorkPlaceShedulesResponseModel>(userWorkPlaceShedules);

            return userWorkPlaceShedulesResponse;
        }

        public async Task Add(UserWorkPlaceShedulesRequestModel entity)
        {
            var userWorkPlaceShedulesResponse = _mapper.Map<UserWorkPlaceShedulesEntity>(entity);
            await _userWorkPlaceShedules.AddAsync(userWorkPlaceShedulesResponse);
            await _userWorkPlaceShedules.SaveChangesAsync();

        }

        public async Task Update(UserWorkPlaceShedulesRequestModel entity)
        {
            UserWorkPlaceShedulesEntity userWorkPlaceShedulesResponse = _userWorkPlaceShedules.GetByIdAsync(entity.WorkPlaceId) ?? throw new Exception("Error en la data");

            var userWorkPlaceShedules = _mapper.Map(entity, userWorkPlaceShedulesResponse);
            await _userWorkPlaceShedules.UpdateAsync(userWorkPlaceShedules);
            await _userWorkPlaceShedules.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            await _userWorkPlaceShedules.DeleteAsync(id);
            await _userWorkPlaceShedules.SaveChangesAsync();

        }
    }
}
