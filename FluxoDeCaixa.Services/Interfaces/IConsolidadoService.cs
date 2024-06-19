using FluxoDeCaixa.Domain.Models.Consolidado;
using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.Interfaces
{
    public interface IConsolidadoService
    {
        Task<CaixaConsolidado> MontarCaixaConsolidado(MensagemConsolidadoRequestDTO request);
        void EnviarMensagemConsolidado(MensagemConsolidadoRequestDTO request);
        Task GravarCaixaConsolidado(CaixaConsolidado caixaConsolidado);
        Task<CaixaConsolidado> BuscarCaixaConsolidado(BuscarCaixaConsolidadoRequestDTO request);
    }
}
