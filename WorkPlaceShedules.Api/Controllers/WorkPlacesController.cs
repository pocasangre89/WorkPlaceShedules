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

        public WorkPlacesController(IWorkPlacesService workPlacesService)
        {
            _workPlacesService = workPlacesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllworkPlaces()
        {
            var workPlaces = await _workPlacesService.GetAll();
            return(Ok(workPlaces));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkPlacesById(int id)
        {
            var workPlaces = _workPlacesService.GetById(id);
            return Ok(workPlaces);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkPlaces([FromBody] WorkPlacesRequestModel entity)
        {
           await _workPlacesService.Add(entity);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkPlaces([FromBody] WorkPlacesRequestModel entity, int id)
        {
            await _workPlacesService.Update(entity, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkPlaces(int id)
        {
            await _workPlacesService.Delete(id);
            return Ok();
        }
    }
}
