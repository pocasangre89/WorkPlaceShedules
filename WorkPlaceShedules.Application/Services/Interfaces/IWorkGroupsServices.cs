using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceShedules.Application.Model.WorkGroups;
using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Application.Services.Interfaces
{
    public interface IWorkGroupsServices
    {
        Task<IEnumerable<WorkGroupsResponseModel>> GetAll();
        WorkGroupsResponseModel GetById(int id);
        Task Add(WorkGroupsRequestModel entity);
        Task Update(WorkGroupsRequestModel entity, int id);
        Task Delete(int id);
    }
}
