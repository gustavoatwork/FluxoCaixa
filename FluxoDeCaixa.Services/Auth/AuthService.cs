using FluxoDeCaixa.Domain.Services.TokenJWT;
using FluxoDeCaixa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly TokenService _tokenService;
        public AuthService(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public string GetToken()
        {
            var result = _tokenService.GenerateToken();

            return result;
        }
    }
}
