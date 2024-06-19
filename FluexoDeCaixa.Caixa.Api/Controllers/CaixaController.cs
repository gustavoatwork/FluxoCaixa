using FluxoDeCaixa.Infra.Infrastructure.Api;
using FluxoDeCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.Caixa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Caixa")]
    public class CaixaController : ApiController
    {

        private readonly ICaixaService _caixaService;

        public CaixaController(ICaixaService caixaService)
        {
            _caixaService = caixaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await _caixaService.GetCaixa();

                return Ok(BaseResponse(result));
            }
            catch (Exception e)
            {
                return BadRequest(BaseResponse(e, false, $"Caixa - {e.Message}"));
            }

        }

        [HttpGet("saldo/{idCaixa}")]
        public async Task<IActionResult> GetSaldo(Guid idCaixa)
        {
            try
            {
                var result = await _caixaService.GetSaldoCaixa(idCaixa);

                return Ok(BaseResponse(result));
            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e, false, $"Caixa - {e.Message}"));
            }

        }
    }
}
