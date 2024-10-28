using AuthAPI.Models.DTO;
using AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDTO _responseDTO;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _responseDTO = new();
        }   

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO registrationRequestDTO)
        {
            var errormessage = await _authService.Register(registrationRequestDTO);
            if (!string.IsNullOrEmpty(errormessage))
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = errormessage;
                return BadRequest(_responseDTO);
            }
            return Ok(_responseDTO);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            var loginResponse = await _authService.Login(loginRequest);
            if (loginResponse.User == null)
            {
                _responseDTO.IsSuccess = false ;
                _responseDTO.Message = "UserName or Password is incorrect";
                return BadRequest(_responseDTO);
            }
            _responseDTO.Result = loginResponse;
            return Ok(_responseDTO);

        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO registrationRequest)
        {
            var assignRoleSuccessful = await _authService.AssignRole(registrationRequest.Email, registrationRequest.RoleName.ToUpper());
            if (!assignRoleSuccessful)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = "Error Encountered in Role Assignment";
                return BadRequest(_responseDTO);
            }
            return Ok(_responseDTO);
        }
    }
}
