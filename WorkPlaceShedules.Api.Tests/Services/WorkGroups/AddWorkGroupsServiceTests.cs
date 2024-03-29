using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceShedules.Application.Model.WorkGroups;
using WorkPlaceShedules.Application.Profiles;
using WorkPlaceShedules.Application.Services;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Infraestructure.Data;
using WorkPlaceShedules.Infraestructure.Repositories;

namespace WorkPlaceShedules.Api.Tests.Services.WorkGroups
{
    public class AddWorkGroupsServiceTests
    {
        [Fact]
        public async Task When_AddWorkGroups_Expected_ResultSuccess()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            DataContext context = new(options);

            // Configurar AutoMapper
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WorkGroupsRequestModel, WorkGroupsEntity>();
                cfg.CreateMap<WorkGroupsEntity, WorkGroupsResponseModel>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();


            WorkGroupsRepository repo = new(context);

            WorkGroupsServices sut = new(repo, mapper);

            WorkGroupsRequestModel requestModel = new ()
            {
                GroupName="Name",
                GroupDescription=  "Description",
                IsActive=true,
            };

            // Act

            await sut.Add(requestModel);
            var result = await sut.GetAll();

            // Assert

            Assert.NotEmpty(result);
        }


        //[Theory]
        //[InlineData("","",1,true)]
        //[InlineData("", "", 2, true)]
        //[InlineData("", "", 3, true)]
        //[InlineData("", "", 4, true)]
        //public async Task When_InvalidRequest_Expected_ReturnError(string name, string code,int number, bool isActive)
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<DataContext>()
        //    .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //    .Options;
        //    DataContext context = new(options);

        //    // Configurar AutoMapper
        //    MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<WorkPlacesRequestModel, WorkPlacesEntity>();
        //        cfg.CreateMap<WorkPlacesEntity, WorkPlacesResponseModel>();
        //    });

        //    IMapper mapper = mapperConfiguration.CreateMapper();


        //    WorkPlacesRepository repo = new(context);

        //    WorkPlacesService sut = new(repo, mapper);

        //    WorkPlacesRequestModel requestModel = new WorkPlacesRequestModel()
        //    {
        //        WorkPlaceName = name,
        //        WorkPlaceCode = code,
        //        WorkPlaceNumber = number,
        //        IsActive = isActive,
        //    };

        //    // Act

        //    await sut.Add(requestModel);
        //    var result = await sut.GetAll();

        //    // Assert

        //    Assert.Empty(result);
        //}


    }
}
