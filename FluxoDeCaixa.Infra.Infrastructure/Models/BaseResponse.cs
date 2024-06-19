
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.Infrastructure.Models
{
    public class BaseResponse : IActionResult
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public object Data { get; set; }

        public BaseResponse(object data, bool success, string error)
        {
            Errors = new List<string>();
            Data = data;
            IsSuccess = success;

            if (!success && data is Exception exception)
            {
                Data = BaseResponseException(exception);
            }

            if (error != null)
            {
                Errors.Add(error);
            }
        }


        private object BaseResponseException(Exception data)
        {
            return new
            {
                data.Message
            };
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
