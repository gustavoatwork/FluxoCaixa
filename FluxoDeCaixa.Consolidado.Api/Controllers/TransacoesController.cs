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
    public class TransacoesController : ApiController
    {
        private readonly IHistoricoTransacoesService _historicoTransacoesService;

        public TransacoesController(IHistoricoTransacoesService historicoTransacoesService)
        {
            _historicoTransacoesService = historicoTransacoesService;
        }

        [HttpPost]
        public async Task<IActionResult> Gravar([FromBody] HistoricoTransacaoRequestDTO request)
        {
            try
            {
                await _historicoTransacoesService.GravarHistoricoTransacoes(request);
                return Ok(BaseResponse("Historico transação gravada com sucesso"));

            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e, false, $"HistoricoTransacao - {e.Message}"));
            }
        }

    }
}
