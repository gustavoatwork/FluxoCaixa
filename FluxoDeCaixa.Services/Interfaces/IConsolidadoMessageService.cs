using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.Interfaces
{
    public interface IConsolidadoMessageService
    {
        public void Send<T>(T message);
    }
}
