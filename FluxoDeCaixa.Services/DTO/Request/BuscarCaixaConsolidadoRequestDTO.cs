using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.DTO.Request
{
    public class BuscarCaixaConsolidadoRequestDTO
    {
        public Guid MessageId { get; set; }
        public Guid CaixaId { get; set; }
    }
}
