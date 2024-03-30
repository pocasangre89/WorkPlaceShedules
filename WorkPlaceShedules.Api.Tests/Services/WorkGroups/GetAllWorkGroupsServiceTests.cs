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
    public class GetAllWorkGroupsServiceTests
    {
        [Fact]
        public async Task When_NoExistsWorkGroups_Expected_ResultSuccess()
        {

            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            DataContext context = new(options);

                // Configurar AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WorkGroupsProfile>(); 
            });
            IMapper mapper = mapperConfig.CreateMapper();

            WorkGroupsRepository repo = new(context);

            WorkGroupsServices sut = new(repo, mapper);


            // Act

            var result = await sut.GetAll();

            // Assert

            Assert.Empty(result);

        }

        [Fact]
        public async Task When_ExistsWorkGroups_Expected_ResultSuccess()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            DataContext context = new(options);

            // Configurar AutoMapper
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WorkGroupsEntity, WorkGroupsResponseModel>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            WorkGroupsEntity entity = new()
            {
                GroupId = 1,
                GroupName = "Test",
                GroupDescription = "Test",
                IsActive = true,
                Creator = "Test"

            };
            context.Add(entity);
            context.SaveChanges();

            WorkGroupsRepository repo = new(context);

            WorkGroupsServices sut = new(repo, mapper);

            // Act

            var result = await sut.GetAll();

            // Assert

            Assert.NotEmpty(result);
        }
    }
}
