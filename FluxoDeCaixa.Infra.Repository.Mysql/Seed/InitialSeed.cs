using FluxoDeCaixa.Domain.Models.Caixa;
using FluxoDeCaixa.Domain.Models.Lancamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.Repository.Mysql.Seed
{
    public static class InitialSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Caixas>().HasData(
                new Caixas() { Id = Guid.NewGuid(), Nome = "Caixa1", Ativo = true, DataCadastro = DateTime.Now, Saldo = 0 }
                );

            builder.Entity<TipoLancamento>().HasData(
                   new TipoLancamento { Id = 1, Descricao = "Crédito", Ativo = true, DataCadastro = DateTime.Now },
                   new TipoLancamento { Id = 2, Descricao = "Débito", Ativo = true, DataCadastro = DateTime.Now }
                );
        }
    }
}
