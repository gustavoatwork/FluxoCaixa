using FluxoDeCaixa.Domain.Enum;
using MongoDB.Bson.Serialization.Attributes;


namespace FluxoDeCaixa.Domain.Models.Consolidado
{
    [BsonIgnoreExtraElements]
    public class HistoricoTransacoes
    {
        public Guid Id { get; set; }
        public Guid CaixaId { get; set; }
        public string NomeCaixa { get; set; }
        public Guid TransacoesId { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamentoEnum TipoLancamentoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string DataHoraCadastro { get; set; }
    }
}
