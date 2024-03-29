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
        private readonly ILogger<LoginController> _logger;

        public LoginController(IUsersService serService, ILogger<LoginController> logger)
        {
            _userService = serService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestModel loginRequest)
        {
            var response = _userService.Login(loginRequest);
            if (response == null || response.Exception!=null)
            {
                return BadRequest(new { message = ""+response.Exception.InnerException.Message });
            }
            _logger.LogInformation("El usuario "+loginRequest.Email+" inicio sesión");
            return Ok(response);
        }


    }
}
