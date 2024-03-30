using AutoMapper;
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
            await _workPlacesRepository.SaveChangesAsync();

        }

        public async Task Update(WorkPlacesRequestModel entity)
        {
            WorkPlacesEntity WorkEntities = _workPlacesRepository.GetByIdAsync(entity.WorkPlaceId) ?? throw new Exception("El Lugar no existe");

            var workPlacesRequestModel = _mapper.Map(entity, WorkEntities);
            await _workPlacesRepository.UpdateAsync(workPlacesRequestModel);
            await _workPlacesRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _workPlacesRepository.DeleteAsync(id);
            await _workPlacesRepository.SaveChangesAsync();
        }
    }
}
