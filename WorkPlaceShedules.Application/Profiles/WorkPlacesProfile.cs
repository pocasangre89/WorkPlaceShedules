using AutoMapper;
using WorkPlaceShedules.Application.Model.WorkPlaces;
using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Application.Profiles
{
    public class WorkPlacesProfile : Profile
    {
        public WorkPlacesProfile()
        {
            CreateMap<WorkPlacesEntity, WorkPlacesResponseModel>().ReverseMap();
            CreateMap<WorkPlacesRequestModel, WorkPlacesEntity>().ReverseMap();
        }
    }
}
