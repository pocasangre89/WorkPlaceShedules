using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceShedules.Application.Model.WorkPlaces;
using WorkPlaceShedules.Application.Profiles;
using WorkPlaceShedules.Application.Services;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Infraestructure.Data;
using WorkPlaceShedules.Infraestructure.Repositories;

namespace WorkPlaceShedules.Api.Tests.Services.WorkPlaces
{
    public class GetAllWorkplacesServiceTests
    {
        [Fact]
        public async Task When_NoExistsWorkPlace_Expected_ResultSuccess()
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

            WorkPlacesRepository repo = new(context);

            WorkPlacesService sut = new(repo, mapper);


            // Act

            var result = await sut.GetAll();

            // Assert

            Assert.Empty(result);

        }

        [Fact]
        public async Task When_ExistsWorkPlace_Expected_ResultSuccess()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            DataContext context = new(options);

            // Configurar AutoMapper
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WorkPlacesEntity, WorkPlacesResponseModel>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            WorkPlacesEntity workPlaces = new()
            {
                WorkPlaceId = 1,
                WorkPlaceName = "Test",
                WorkPlaceNumber = 1,
                WorkPlaceCode = "Test", 
                IsActive = true,
                Creator = "Test"

            };
            context.Add(workPlaces);
            context.SaveChanges();

            WorkPlacesRepository repo = new(context);

            WorkPlacesService sut = new(repo, mapper);

            // Act

            var result = await sut.GetAll();

            // Assert

            Assert.NotEmpty(result);
        }
    }
}
