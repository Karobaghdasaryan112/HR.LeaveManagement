using HR.LeaveManagment.Application.Contracts.Identity;
using HR.LeaveManagment.Application.Models.Identity.Auth;
using HR.LeaveManagment.Application.Models.Identity.Registration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            var response = await _authService.LoginAsync(request);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Registration([FromBody] RegistrationRequest registrationRequest)
        {
            var response = await _authService.RegisterAsync(registrationRequest);

            return Ok(response);
        }
    }
}
