using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceShedules.Application.Model.WorkPlaceShedules;
using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Application.Services.Interfaces
{
    public interface IUserWorkPlaceShedulesServices
    {
        Task<IEnumerable<UserWorkPlaceShedulesResponseModel>> GetAll();
        UserWorkPlaceShedulesResponseModel GetById(int id);
        Task<int> Add(UserWorkPlaceShedulesRequestModel entity);
        Task Update(UserWorkPlaceShedulesRequestModel entity);
        Task Delete(int id);
    }
}
