using System;
using System.Threading.Tasks;
using ELearningApi.CustomFilters;
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

        [HttpPost("SignUp")]
        [ModelValidation]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest signUpRequest)
        {
            bool isRegistered = false;
            try
            {
                //check if user exists
                

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
            return StatusCode(422, "Failed to create user");
        }

        [HttpPost("SignIn")]
        [ModelValidation]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest signInRequest)
        {
            bool isSignedIn = false;
            try
            {
                isSignedIn = await _authService.SignIn(signInRequest);
                if (!isSignedIn) return BadRequest("Invalid Credentials");
            }
            catch (Exception ex)
            {
                _logger.LogError("System error occured", ex);
                return StatusCode(500);
            }
            return Ok("sign-in successful");
        }

        [HttpGet("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _authService.SignOut();
            return Ok("Your session has ended");
        }
    }
}
