using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Facade.DTO
{
    public class CaixasDTO
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}
