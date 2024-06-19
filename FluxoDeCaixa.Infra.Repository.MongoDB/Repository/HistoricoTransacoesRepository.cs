using FluxoDeCaixa.Domain.Interfaces.Repository.Consolidado;
using FluxoDeCaixa.Domain.Models.Consolidado;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.Repository.MongoDB.Repository
{
    public class HistoricoTransacoesRepository : MongoBaseRepository, IHistoricoTransacoesRepository
    {
        private readonly string _collectioName = "HistoricoTransacoes";
        public HistoricoTransacoesRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<List<HistoricoTransacoes>> GetHistoricoTransacoes(Guid CaixaId, DateTime dataInicial, DateTime dataFinal)
        {
            var collection = _db.GetCollection<HistoricoTransacoes>(_collectioName);
            if (collection == null) return null;

            var result = collection.Find(x => x.CaixaId == CaixaId && (x.DataCadastro >= dataInicial.ToUniversalTime() && x.DataCadastro <= dataFinal.ToUniversalTime()));

            return await result.ToListAsync();
        }

        public async Task SalvarHistoricoTransacoes(HistoricoTransacoes historicoTransacoes)
        {
            var collection = _db.GetCollection<HistoricoTransacoes>(_collectioName);
            if (collection == null) return;

            await collection.InsertOneAsync(historicoTransacoes);
        }
    }
}
