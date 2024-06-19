using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Models.Consolidado
{
    [BsonIgnoreExtraElements]
    public class CaixaConsolidado
    {
        public Guid MessageId { get; set; }
        public Guid CaixaId { get; set; }
        public string NomeCaixa { get; set; }
        public decimal ValorConsolidado { get; set; }
        public List<CaixaTransacoes> Transacoes { get; set; }
        public DateTime DataRefInicial { get; set; }
        public DateTime DataRefFinal { get; set; }
        public DateTime DataConsolidado { get; set; }
    }
}
