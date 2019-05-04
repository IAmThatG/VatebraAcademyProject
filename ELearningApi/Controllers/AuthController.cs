using System;
using System.Threading.Tasks;
using ELearnngApp.Domain.ApiRequestModels;
using ELearnngApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ELearningApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest signUpRequest)
        {
            if (ModelState.IsValid)
            {
                bool isRegistered = false;
                try
                {
                    isRegistered = await _authService.SignUp(signUpRequest);
                    if (isRegistered)
                    {
                        return Ok("User created successfully");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("System error occured", ex);
                    return StatusCode(500);
                }
            }
            return BadRequest("Request is not valid");
        }
    }
}
