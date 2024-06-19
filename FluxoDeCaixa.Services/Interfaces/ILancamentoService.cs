using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.Interfaces
{
    public interface ILancamentoService
    {
        Task GravarTransacao(TransacoesRequestDTO transacao);
        Task<LancamentoResponseDTO> GetLancamentos(Guid caixaId);
    }
}
