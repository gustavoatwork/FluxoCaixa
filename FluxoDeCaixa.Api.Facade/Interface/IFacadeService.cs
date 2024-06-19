using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Facade.Interface
{
    internal interface IFacadeService
    {
        Task<string> Get(string path, string payload, string serviceName);
        Task<string> Post(string path, object payload, string serviceName);
    }
}
