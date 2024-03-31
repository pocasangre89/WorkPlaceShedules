using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkPlaceShedules.Application.Model.Users;
using WorkPlaceShedules.Application.Model.WorkPlaceShedules;
using WorkPlaceShedules.Application.Services.Interfaces;

namespace WorkPlaceShedules.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersWorkPlaceShedulesController : ControllerBase
    {
        private readonly IUserWorkPlaceShedulesServices _userWorkPlaceShedules;
        private readonly ILogger<UsersWorkPlaceShedulesController> _logger;

        public UsersWorkPlaceShedulesController(IUserWorkPlaceShedulesServices userWorkPlaceShedules, ILogger<UsersWorkPlaceShedulesController> logger)
        {
            _userWorkPlaceShedules = userWorkPlaceShedules;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUserWorkPlaceShedules()
        {
            var userWorkPlaceShedules = await _userWorkPlaceShedules.GetAll();
            _logger.LogInformation("Se obtuvieron todos los usuarios por espacios de trabajo");
            return (Ok(userWorkPlaceShedules));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetuserWorkPlaceShedulesById(int id)
        {
            var userWorkPlaceShedules = _userWorkPlaceShedules.GetById(id);
            _logger.LogInformation("Se obtuvo el espacio de trabajo de usuario" + id);
            return Ok(userWorkPlaceShedules);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserWorkPlaceShedules([FromBody] UserWorkPlaceShedulesRequestModel entity)
        {
           int respData = await _userWorkPlaceShedules.Add(entity);
            _logger.LogInformation("Se agrego un espacio de trabajo de usuario");
            return Ok(respData);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUserWorkPlaceShedules([FromBody] UserWorkPlaceShedulesRequestModel entity)
        {
            await _userWorkPlaceShedules.Update(entity);
            _logger.LogInformation("Se actualizo el espacio de trabajo de usuario" + entity.UserWorkPlaceScheduleId);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUserWorkPlaceShedules(int id)
        {
            await _userWorkPlaceShedules.Delete(id);
            _logger.LogInformation("Se elimino el espacio de trabajo de usuario " + id);
            return Ok();
        }
    }
}
