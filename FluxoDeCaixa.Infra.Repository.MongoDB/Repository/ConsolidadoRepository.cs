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
    public class ConsolidadoRepository : MongoBaseRepository, IConsolidadoRepository
    {
        private readonly string _collectioName = "CaixaConsolidado";
        public ConsolidadoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<CaixaConsolidado> BuscarCaixaConsolidado(Guid MessageId, Guid CaixaId)
        {
            var collection = _db.GetCollection<CaixaConsolidado>(_collectioName);
            if (collection == null) return null;

            var result = collection.Find(x => x.MessageId == MessageId && x.CaixaId == CaixaId);

            return await result.FirstOrDefaultAsync();
        }

        public async Task SalvarConsolidado(CaixaConsolidado caixaConsolidado)
        {
            var collection = _db.GetCollection<CaixaConsolidado>(_collectioName);
            if (collection == null) return;

            await collection.InsertOneAsync(caixaConsolidado);
        }
    }
}
