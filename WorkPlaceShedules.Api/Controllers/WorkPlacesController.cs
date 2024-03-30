using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkPlaceShedules.Application.Model.WorkPlaces;
using WorkPlaceShedules.Application.Services.Interfaces;

namespace WorkPlaceShedules.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPlacesController : ControllerBase
    {
        private readonly IWorkPlacesService _workPlacesService;
        private readonly ILogger<WorkPlacesController> _logger;

        public WorkPlacesController(IWorkPlacesService workPlacesService, ILogger<WorkPlacesController> logger)
        {
            _workPlacesService = workPlacesService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllworkPlaces()
        {
            var workPlaces = await _workPlacesService.GetAll();
            _logger.LogInformation("Se obtuvieron todos los espacios de trabajo");
            return (Ok(workPlaces));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetWorkPlacesById(int id)
        {
            var workPlaces = _workPlacesService.GetById(id);
            _logger.LogInformation("Se obtuvo el espacio de trabajo " + id);
            return Ok(workPlaces);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddWorkPlaces([FromBody] WorkPlacesRequestModel entity)
        {
           await _workPlacesService.Add(entity);
            _logger.LogInformation("Se agrego un espacio de trabajo");
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateWorkPlaces")]
        public async Task<IActionResult> UpdateWorkPlaces([FromBody] WorkPlacesRequestModel entity)
        {
            await _workPlacesService.Update(entity);
            _logger.LogInformation("Se actualizo el espacio de trabajo " + entity.WorkPlaceId);
            return Ok(entity);
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteWorkPlaces")]
        public async Task<IActionResult> DeleteWorkPlaces(int id)
        {
            await _workPlacesService.Delete(id);

            _logger.LogInformation("Se elimino el espacio de trabajo " + id);
            return Ok(1);
        }
    }
}
