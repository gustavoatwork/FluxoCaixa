using FluxoDeCaixa.Api.Facade.DTO;
using FluxoDeCaixa.Api.Facade.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Facade.Consolidado
{
    internal class ConsolidadoFacade : IConsolidadoFacade
    {
        private readonly IFacadeService _facadeService;
        private const string _serviceName = "Consolidado";

        public ConsolidadoFacade(IFacadeService facadeService)
        {
            _facadeService = facadeService;
        }

        public async Task<BaseReponseDTO> GravarHistoricoTransacao(TransacoesDTO transacao)
        {
            var payload = transacao;
            var url = "api/transacoes";
            string response = await _facadeService.Post(url, payload, _serviceName);
            return JsonConvert.DeserializeObject<BaseReponseDTO>(response);
        }
    }
}
