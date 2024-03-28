using WorkPlaceShedules.Application.Model.WorkGroups;

namespace WorkPlaceShedules.Application.Services.Interfaces
{
    public interface IWorkGroupsService
    {
        Task<IEnumerable<WorkGroupsResponseModel>> GetAll();
        WorkGroupsResponseModel GetById(int id);
        Task Add(WorkGroupsRequestModel entity);
        Task Update(WorkGroupsRequestModel entity, int id);
        Task Delete(int id);
    }
}
