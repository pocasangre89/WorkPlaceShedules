using AutoMapper;
using WorkPlaceShedules.Application.Model.Users;
using WorkPlaceShedules.Application.Model.WorkPlaces;
using WorkPlaceShedules.Application.Services.Interfaces;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;

namespace WorkPlaceShedules.Application.Services
{
    public class WorkPlacesService : IWorkPlacesService
    {
        private readonly IWorkPlacesRepository _workPlacesRepository;
        private readonly IMapper _mapper;
        public WorkPlacesService(IWorkPlacesRepository workPlacesRepository, IMapper mapper)
        {
            _workPlacesRepository = workPlacesRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<WorkPlacesResponseModel>> GetAll()
        {
            var WorkEntities = await _workPlacesRepository.GetAllAsync();

            var WorkPlacesResponseModel = _mapper.Map<IEnumerable<WorkPlacesResponseModel>>(WorkEntities);

            return WorkPlacesResponseModel;
        }


        public WorkPlacesResponseModel GetById(int id)
        {
            var WorkEntities = _workPlacesRepository.GetByIdAsync(id);

            var WorkPlacesResponseModel = _mapper.Map<WorkPlacesResponseModel>(WorkEntities);

            return WorkPlacesResponseModel;
        }

        public async Task Add(WorkPlacesRequestModel entity)
        {
            var WorkPlacesResponseModel = _mapper.Map<WorkPlacesEntity>(entity);
            await _workPlacesRepository.AddAsync(WorkPlacesResponseModel);
        }

        public async Task Update(WorkPlacesRequestModel entity, int id)
        {
            WorkPlacesEntity WorkEntities = _workPlacesRepository.GetByIdAsync(id) ?? throw new Exception("El usuario no existe");

            var usersRequestModel = _mapper.Map(entity, WorkEntities);
            await _workPlacesRepository.UpdateAsync(usersRequestModel);
        }

        public async Task Delete(int id)
        {
            await _workPlacesRepository.DeleteAsync(id);
        }
    }
}
