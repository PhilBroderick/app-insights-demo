using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth.Interfaces;
using auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private readonly ILogger _log;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _log = logger;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest model)
        {
            _log.LogInformation("Login endpoint called.");
            var response = _authService.Login(model);

            if (response is null)
            {
                _log.LogWarning("Incorrect username or password entered.");
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }

    }
}
