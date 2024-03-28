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

        public WorkGroupsController(IWorkGroupsService WorkGroupsService)
        {
            _workGroupsService = WorkGroupsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkGroups()
        {
            var WorkGroups = await _workGroupsService.GetAll();
            return(Ok(WorkGroups));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkGroupsById(int id)
        {
            var WorkGroups = _workGroupsService.GetById(id);
            return Ok(WorkGroups);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkGroups([FromBody] WorkGroupsRequestModel entity)
        {
           await _workGroupsService.Add(entity);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkGroups([FromBody] WorkGroupsRequestModel entity, int id)
        {
            await _workGroupsService.Update(entity, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkGroups(int id)
        {
            await _workGroupsService.Delete(id);
            return Ok();
        }
    }
}
