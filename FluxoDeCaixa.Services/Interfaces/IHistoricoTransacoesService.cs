using FluxoDeCaixa.Domain.Models.Lancamentos;
using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.Interfaces
{
    public interface IHistoricoTransacoesService
    {
        Task GravarHistoricoTransacoes(HistoricoTransacaoRequestDTO transacao);
    }
}
