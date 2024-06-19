using FluxoDeCaixa.Api.Facade.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Facade.Interface
{
    public interface IConsolidadoFacade
    {
        Task<BaseReponseDTO> GravarHistoricoTransacao(TransacoesDTO transacao);

    }
}
