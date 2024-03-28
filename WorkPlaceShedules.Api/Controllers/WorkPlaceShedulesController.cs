using Microsoft.AspNetCore.Mvc;
using WorkPlaceShedules.Application.Model.Users;
using WorkPlaceShedules.Application.Model.WorkPlaceShedules;
using WorkPlaceShedules.Application.Services.Interfaces;

namespace WorkPlaceShedules.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPlaceShedulesController : ControllerBase
    {
        private readonly IUserWorkPlaceShedulesServices _userWorkPlaceShedules;
        private readonly ILogger<WorkPlaceShedulesController> _logger;

        public WorkPlaceShedulesController(IUserWorkPlaceShedulesServices userWorkPlaceShedules, ILogger<WorkPlaceShedulesController> logger)
        {
            _userWorkPlaceShedules = userWorkPlaceShedules;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserWorkPlaceShedules()
        {
            var userWorkPlaceShedules = await _userWorkPlaceShedules.GetAll();
            _logger.LogInformation("Se obtuvieron todos los uasuario por espacios de trabajo");
            return (Ok(userWorkPlaceShedules));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetuserWorkPlaceShedulesById(int id)
        {
            var userWorkPlaceShedules = _userWorkPlaceShedules.GetById(id);
            _logger.LogInformation("Se obtuvo el espacio de trabajo de usuario" + id);
            return Ok(userWorkPlaceShedules);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserWorkPlaceShedules([FromBody] UserWorkPlaceShedulesRequestModel entity)
        {
           await _userWorkPlaceShedules.Add(entity);
            _logger.LogInformation("Se agrego un espacio de trabajo de usuario");
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserWorkPlaceShedules([FromBody] UserWorkPlaceShedulesRequestModel entity, int id)
        {
            await _userWorkPlaceShedules.Update(entity, id);
            _logger.LogInformation("Se actualizo el espacio de trabajo de usuario" + id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserWorkPlaceShedules(int id)
        {
            await _userWorkPlaceShedules.Delete(id);
            _logger.LogInformation("Se elimino el espacio de trabajo de usuario " + id);
            return Ok();
        }
    }
}
