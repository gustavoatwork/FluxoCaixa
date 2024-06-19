using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Facade.DTO
{
    public class BaseReponseDTO
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public object Data { get; set; }
    }
}
