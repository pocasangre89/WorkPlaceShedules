using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WorkPlaceShedules.Application.Model.Users;
using WorkPlaceShedules.Application.Services;
using WorkPlaceShedules.Application.Services.Interfaces;

namespace WorkPlaceShedules.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsersService _userService;

        public LoginController(IUsersService serService)
        {
            _userService = serService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestModel loginRequest)
        {
            var response = _userService.Login(loginRequest);
            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }


    }
}
