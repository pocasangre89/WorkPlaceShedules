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
        private readonly    ILogger<UsersController> _logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAll();
            _logger.LogInformation("Se obtuvieron todos los usuarios");
            return(Ok(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var users = _usersService.GetById(id);
            _logger.LogInformation("Se obtuvo el usuario "+id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UsersRequestModel entity)
        {
           await _usersService.Add(entity);
            _logger.LogInformation("Se agrego usuario");
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UsersRequestModel entity, int id)
        {
            await _usersService.Update(entity, id);
            _logger.LogInformation("Se actualizo el usuario "+id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _usersService.Delete(id);
            _logger.LogInformation("Se elimino el usuario " + id);
            return Ok();
        }
    }
}
