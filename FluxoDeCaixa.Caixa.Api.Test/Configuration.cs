using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Caixa.Api.Test
{
    public static class Configuration
    {
        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
            return builder.Build();
        }
    }
}
