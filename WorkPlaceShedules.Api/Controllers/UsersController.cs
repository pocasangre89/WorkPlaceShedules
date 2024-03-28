using Microsoft.AspNetCore.Mvc;
using WorkPlaceShedules.Application.Model.Users;
using WorkPlaceShedules.Application.Services.Interfaces;

namespace WorkPlaceShedules.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAll();
            return(Ok(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var users = _usersService.GetById(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UsersRequestModel entity)
        {
           await _usersService.Add(entity);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UsersRequestModel entity, int id)
        {
            await _usersService.Update(entity, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _usersService.Delete(id);
            return Ok();
        }
    }
}
