using FluxoDeCaixa.Domain.Models.Lancamentos;
using FluxoDeCaixa.Infra.Infrastructure.Api;
using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.Consolidado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Consolidado")]
    public class ConsolidadoController : ApiController
    {

        private readonly IConsolidadoService _consolidadoService;
        public ConsolidadoController(
            IConsolidadoService consolidadoService)
        {
            _consolidadoService = consolidadoService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] MensagemConsolidadoRequestDTO request)
        {
            try
            {
                _consolidadoService.EnviarMensagemConsolidado(request);
                return Ok(BaseResponse("Mensagem enviada com sucesso"));

            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e, false, $"Consolidado - {e.Message}"));
            }
        }

        [HttpPost("buscar")]
        public async Task<IActionResult> BuscarCaixaConsolidado([FromBody] BuscarCaixaConsolidadoRequestDTO request)
        {
            try
            {
                var result = await _consolidadoService.BuscarCaixaConsolidado(request);
                return Ok(BaseResponse(result));

            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e, false, $"Consolidado - {e.Message}"));
            }
        }
    }
}
