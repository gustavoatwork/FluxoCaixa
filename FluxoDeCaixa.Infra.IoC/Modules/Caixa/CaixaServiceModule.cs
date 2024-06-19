using FluxoDeCaixa.Domain.Services.Caixa;
using FluxoDeCaixa.Domain.Services.TokenJWT;
using FluxoDeCaixa.Services.Auth;
using FluxoDeCaixa.Services.Caixa;
using FluxoDeCaixa.Services.Interfaces;
using FluxoDeCaixa.Services.Lancamentos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.IoC.Modules.Caixa
{
    public static class CaixaServiceModule
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<TokenService>();
            service.AddScoped<SaldoCaixaService>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<ICaixaService, CaixaService>();
            service.AddScoped<ILancamentoService, LancamentoService>();
        }
    }
}