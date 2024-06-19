using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Facade
{
    internal static class Configuration
    {

        internal static Uri GetBaseAddress(string serviceName)
        {
            switch (serviceName)
            {
                case "Consolidado":
                    return new Uri("https://localhost:7032/");
                default:
                    return new Uri("");
            }
        }
    }
}
