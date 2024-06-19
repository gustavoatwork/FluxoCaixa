using FluxoDeCaixa.Infra.Infrastructure.Api;
using FluxoDeCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.Caixa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Auth()
        {
            try
            {
                var token = _authService.GetToken();

                return Ok(BaseResponse(token));
            }
            catch (Exception e)
            {

                return BadRequest($"Auth - {e.Message}");
            }

        }
    }
}
