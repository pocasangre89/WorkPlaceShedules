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

        public WorkPlaceShedulesController(IUserWorkPlaceShedulesServices userWorkPlaceShedules)
        {
            _userWorkPlaceShedules = userWorkPlaceShedules;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserWorkPlaceShedules()
        {
            var userWorkPlaceShedules = await _userWorkPlaceShedules.GetAll();
            return(Ok(userWorkPlaceShedules));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetuserWorkPlaceShedulesById(int id)
        {
            var userWorkPlaceShedules = _userWorkPlaceShedules.GetById(id);
            return Ok(userWorkPlaceShedules);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserWorkPlaceShedules([FromBody] UserWorkPlaceShedulesRequestModel entity)
        {
           await _userWorkPlaceShedules.Add(entity);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserWorkPlaceShedules([FromBody] UserWorkPlaceShedulesRequestModel entity, int id)
        {
            await _userWorkPlaceShedules.Update(entity, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserWorkPlaceShedules(int id)
        {
            await _userWorkPlaceShedules.Delete(id);
            return Ok();
        }
    }
}
