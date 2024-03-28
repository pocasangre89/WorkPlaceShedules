using WorkPlaceShedules.Application.Model.WorkPlaces;

namespace WorkPlaceShedules.Application.Services.Interfaces
{
    public interface IWorkPlacesService
    {
        Task<IEnumerable<WorkPlacesResponseModel>> GetAll();
        WorkPlacesResponseModel GetById(int id);
        Task Add(WorkPlacesRequestModel entity);
        Task Update(WorkPlacesRequestModel entity, int id);
        Task Delete(int id);
    }
}
