using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WorkPlaceShedules.Application.Services;
using WorkPlaceShedules.Application.Services.Interfaces;
using WorkPlaceShedules.Domain.Repositories;
using WorkPlaceShedules.Infraestructure.Data;
using WorkPlaceShedules.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IUsersRepository), typeof(UsersRepository));
builder.Services.AddScoped(typeof(IUserWorkPlaceShedulesRepository), typeof(UserWorkPlaceShedulesRepository));
builder.Services.AddScoped(typeof(IWorkGroupsRepository), typeof(WorkGroupsRepository));
builder.Services.AddScoped(typeof(IWorkPlacesRepository), typeof(WorkPlacesRepository));

builder.Services.AddScoped(typeof(IUsersService), typeof(UserServices));
builder.Services.AddScoped(typeof(IUserWorkPlaceShedulesServices), typeof(UserWorkPlaceShedulesServices));
builder.Services.AddScoped(typeof(IWorkGroupsService), typeof(WorkGroupsServices));
builder.Services.AddScoped(typeof(IWorkPlacesService), typeof(WorkPlacesService));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
