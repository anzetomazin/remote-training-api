using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteTrainingApi.Authentication;
using System;
using System.Threading.Tasks;

namespace RemoteTrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;

        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}

                var result = await _authRepo.Login(loginModel);
                if (result.Item1)
                {
                    return Ok(new { token = result.Item2 });
                }

                return Unauthorized(/*new ErrorHandlerModel("Napačno uporabniško ime ali geslo", HttpStatusCode.Unauthorized)*/);
            }
            catch (Exception e)
            {
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Register([FromBody] RegisterModel userRegistrationModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _authRepo.Register(userRegistrationModel);
                if (result == false)
                {
                    return BadRequest();
                }

                return Created("/auth/login", result);
            }
            catch (Exception e)
            {
                return BadRequest(e/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}
