using FluxoDeCaixa.Infra.Infrastructure.Api;
using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.Caixa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Caixa")]
    public class LancamentosController : ApiController
    {
        private readonly ILancamentoService _lancamentoService;
        public LancamentosController(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransacoesRequestDTO request)
        {
            try
            {
                await _lancamentoService.GravarTransacao(request);
                return Ok(BaseResponse("Transação gravada com sucesso"));

            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e, false, $"Transação - {e.Message}"));
            }
        }

        [HttpGet("{caixaId}")]
        public async Task<IActionResult> Get([FromRoute] Guid caixaId)
        {
            try
            {
                var result = await _lancamentoService.GetLancamentos(caixaId);
                return Ok(BaseResponse(result));

            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e, false, $"Lancamentos - {e.Message}"));
            }
        }
    }
}
