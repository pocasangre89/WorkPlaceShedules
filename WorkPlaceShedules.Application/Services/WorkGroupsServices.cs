using AutoMapper;
using WorkPlaceShedules.Application.Model.WorkGroups;
using WorkPlaceShedules.Application.Model.WorkPlaces;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;

namespace WorkPlaceShedules.Application.Services
{
    public class WorkGroupsServices
    {
        private readonly IWorkGroupsRepository _workPlacesRepository;
        private readonly IMapper _mapper;
        public WorkGroupsServices(IWorkGroupsRepository workPlacesRepository, IMapper mapper)
        {
            _workPlacesRepository = workPlacesRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<WorkGroupsResponseModel>> GetAll()
        {
            var WorkEntities = await _workPlacesRepository.GetAllAsync();

            var WorkGroupsResponseModel = _mapper.Map<IEnumerable<WorkGroupsResponseModel>>(WorkEntities);

            return WorkGroupsResponseModel;
        }


        public WorkGroupsResponseModel GetById(int id)
        {
            var WorkEntities = _workPlacesRepository.GetByIdAsync(id);

            var WorkGroupsResponseModel = _mapper.Map<WorkGroupsResponseModel>(WorkEntities);

            return WorkGroupsResponseModel;
        }

        public async Task Add(WorkGroupsRequestModel entity)
        {
            var WorkGroupsResponseModel = _mapper.Map<WorkGroupsEntity>(entity);
            await _workPlacesRepository.AddAsync(WorkGroupsResponseModel);
        }

        public async Task Update(WorkGroupsRequestModel entity, int id)
        {
            WorkGroupsEntity WorkEntities = _workPlacesRepository.GetByIdAsync(id) ?? throw new Exception("El grupo no existe");

            var WorkGroups = _mapper.Map(entity, WorkEntities);
            await _workPlacesRepository.UpdateAsync(WorkGroups);
        }

        public async Task Delete(int id)
        {
            await _workPlacesRepository.DeleteAsync(id);
        }
    }
}
