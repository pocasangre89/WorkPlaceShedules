using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkPlaceShedules.Application.Model.WorkGroups;
using WorkPlaceShedules.Application.Services.Interfaces;

namespace WorkPlaceShedules.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkGroupsController : ControllerBase
    {
        private readonly IWorkGroupsService _workGroupsService;
        private readonly ILogger<WorkGroupsController> _logger;

        public WorkGroupsController(IWorkGroupsService WorkGroupsService, ILogger<WorkGroupsController> logger)
        {
            _workGroupsService = WorkGroupsService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllWorkGroups()
        {
            var WorkGroups = await _workGroupsService.GetAll();
            _logger.LogInformation("Se obtuvieron todos los grupos de trabajo");
            return (Ok(WorkGroups));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetWorkGroupsById(int id)
        {
            var WorkGroups = _workGroupsService.GetById(id);
            _logger.LogInformation("Se obtuvo el grupo de trabajo " + id);
            return Ok(WorkGroups);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddWorkGroups([FromBody] WorkGroupsRequestModel entity)
        {
           await _workGroupsService.Add(entity);
            _logger.LogInformation("Se agrego un grupo de trabajo");
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateWorkGroups")]
        public async Task<IActionResult> UpdateWorkGroups([FromBody] WorkGroupsRequestModel entity)
        {
            await _workGroupsService.Update(entity);
            _logger.LogInformation("Se actualizo el grupo de trabajo " + entity.GroupId);
            return Ok(entity);
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteWorkGroups")]
        public async Task<IActionResult> DeleteWorkGroups(int id)
        {
            await _workGroupsService.Delete(id);
            _logger.LogInformation("Se elimino el grupo de trabajo " + id);
            return Ok(1);
        }
    }
}
