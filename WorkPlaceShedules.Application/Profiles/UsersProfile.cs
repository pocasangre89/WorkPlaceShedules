using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceShedules.Application.Model.Users;
using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Application.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UsersEntity, UsersResponseModel>().ReverseMap();
            CreateMap<UsersRequestModel, UsersEntity>().ReverseMap();
        }
    }
}
