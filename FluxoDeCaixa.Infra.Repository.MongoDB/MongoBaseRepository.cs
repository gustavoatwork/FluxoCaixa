using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FluxoDeCaixa.Infra.Repository.MongoDB
{
    public abstract class MongoBaseRepository
    {
        protected readonly IMongoDatabase _db;

        public MongoBaseRepository(IConfiguration configuration)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration.GetConnectionString("MongoDB")));
            var client = new MongoClient(settings);
            _db = client.GetDatabase(configuration.GetSection("MongoDbName").Value);
        }

    }
}
