using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkPlaceShedules.Application.Model.WorkPlaces;
using WorkPlaceShedules.Application.Services;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Infraestructure.Data;
using WorkPlaceShedules.Infraestructure.Repositories;

namespace WorkPlaceShedules.Api.Tests.Services.WorkPlaces
{
    public class DeleteWorkplacesServiceTests
    {
        [Fact]
        public async Task When_DeleteWorkPlace_Expected_ResultSuccess()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            DataContext context = new(options);

            // Configurar AutoMapper
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WorkPlacesRequestModel, WorkPlacesEntity>();
                cfg.CreateMap<WorkPlacesEntity, WorkPlacesResponseModel>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();


            WorkPlacesRepository repo = new(context);

            WorkPlacesService sut = new(repo, mapper);

            WorkPlacesRequestModel requestModel = new WorkPlacesRequestModel()
            {
                WorkPlaceName = "name",
                WorkPlaceCode = "code",
                WorkPlaceNumber = 1,
                IsActive = false,
            };

            // Act

            await sut.Add(requestModel);
            var result = await sut.GetAll();

            // Assert

            Assert.NotEmpty(result);

            // Act
            await sut.Delete(1);
            result = await sut.GetAll();

            // Assert
            Assert.Empty(result);



        }
    }
}
