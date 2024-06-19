
using FluxoDeCaixa.Infra.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FluxoDeCaixa.Infra.Infrastructure.Api
{
    public class ApiController : ControllerBase
    {
        protected BaseResponse BaseResponse(object data, bool success = true, string error = null)
        {
            return new BaseResponse(data, success, error);
        }

    }
}
