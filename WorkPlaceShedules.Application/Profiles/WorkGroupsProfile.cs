using AutoMapper;
using WorkPlaceShedules.Application.Model.WorkGroups;
using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Application.Profiles
{
    public class WorkGroupsProfile : Profile
    {
        public WorkGroupsProfile()
        {
            CreateMap<WorkGroupsEntity, WorkGroupsResponseModel>().ReverseMap();
            CreateMap<WorkGroupsRequestModel, WorkGroupsEntity>().ReverseMap();
        }
    }
}
