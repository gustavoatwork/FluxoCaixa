using FluxoDeCaixa.Api.Facade.DTO;
using FluxoDeCaixa.Api.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Caixa.Api.Test.Factories
{
    public class ConsolidadoFacadeFactory 
    {
        public static BaseReponseDTO GravarHistoricoTransacao(TransacoesDTO transacao)
        {
            return new BaseReponseDTO()
            {
                Data = "Historico gravado com sucesso",
                IsSuccess = true
            };
        }
    }
}
