using FluxoDeCaixa.Domain.Models.Caixa;
using FluxoDeCaixa.Domain.Models.Lancamentos;
using FluxoDeCaixa.Infra.Repository.Mysql.Mapping;
using FluxoDeCaixa.Infra.Repository.Mysql.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.Repository.Mysql.Context
{
    //dotnet ef --startup-project ../FluexoDeCaixa.Caixa.Api/ database update
    public class CaixaContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public CaixaContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.AutoTransactionsEnabled = true;
            ChangeTracker.AutoDetectChangesEnabled = true;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            ChangeTracker.LazyLoadingEnabled = false;
            Database.Migrate();
        }

        #region Models DbSet
        public DbSet<Caixas> Caixas { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }
        public DbSet<TipoLancamento> TipoLancamentos { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CaixaMap());
            modelBuilder.ApplyConfiguration(new TransacoesMap());
            modelBuilder.ApplyConfiguration(new TipoLancamentoMap());

            modelBuilder.Entity<Caixas>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Transacoes>().HasIndex(x => x.Id).IsUnique();

            InitialSeed.Seed(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("FluxoCaixa");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

    }
}
