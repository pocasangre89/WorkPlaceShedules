using AutoMapper;
using WorkPlaceShedules.Application.Model.WorkPlaceShedules;
using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Application.Profiles
{
    public class UserWorkPlaceShedulesProfile : Profile
    {
        public UserWorkPlaceShedulesProfile()
        {
            CreateMap<UserWorkPlaceShedulesEntity, UserWorkPlaceShedulesResponseModel>().ReverseMap();
            CreateMap<UserWorkPlaceShedulesRequestModel, UserWorkPlaceShedulesEntity>().ReverseMap();
        }
    }
}
