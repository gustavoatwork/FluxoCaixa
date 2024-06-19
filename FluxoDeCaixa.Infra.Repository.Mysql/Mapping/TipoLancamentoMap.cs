using FluxoDeCaixa.Domain.Models.Lancamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.Repository.Mysql.Mapping
{
    internal class TipoLancamentoMap : IEntityTypeConfiguration<TipoLancamento>
    {
        public void Configure(EntityTypeBuilder<TipoLancamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Descricao).HasMaxLength(70).IsRequired(true);
            builder.Property(x => x.Ativo).HasDefaultValue(true).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
        }
    }
}
