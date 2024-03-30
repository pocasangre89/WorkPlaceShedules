using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkPlaceShedules.Application.Model.WorkGroups;
using WorkPlaceShedules.Application.Services;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Infraestructure.Data;
using WorkPlaceShedules.Infraestructure.Repositories;

namespace WorkPlaceShedules.Api.Tests.Services.WorkGroups
{
    public class DeleteWorkGroupsServiceTests
    {
        [Fact]
        public async Task When_DeleteWorkGroups_Expected_ResultSuccess()
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

            WorkGroupsRequestModel requestModel = new WorkGroupsRequestModel()
            {
                GroupName = "Name",
                GroupDescription = "Description",
                IsActive = true,
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
