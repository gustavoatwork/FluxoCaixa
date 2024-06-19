using FluxoDeCaixa.Caixa.Api.Controllers;
using FluxoDeCaixa.Domain.Services.TokenJWT;
using FluxoDeCaixa.Infra.Infrastructure.Models;
using FluxoDeCaixa.Services.Auth;
using FluxoDeCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;

namespace FluxoDeCaixa.Caixa.Api.Test
{
    public class AuthControllerTest
    {

        AuthController _controller;
        IAuthService _authService;
        public AuthControllerTest()
        {
            var tokenService = new TokenService(Configuration.GetConfiguration());
            _authService = new AuthService(tokenService);
            _controller = new AuthController(_authService);
        }

        [Fact]
        public void Auth()
        {
            var result = _controller.Auth();
            var resultType = result as OkObjectResult;
            var resultToken = resultType.Value as BaseResponse;

            Assert.NotNull(resultType);
            Assert.IsType<BaseResponse>(resultToken);
            Assert.Equal(resultToken.Data, resultToken.Data);



        }
    }
}