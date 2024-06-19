using FluxoDeCaixa.Domain.Models.Caixa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.Repository.Mysql.Mapping
{
    public class CaixaMap : IEntityTypeConfiguration<Caixas>
    {
        public void Configure(EntityTypeBuilder<Caixas> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Ativo).HasDefaultValue(true).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
        }
    }
}
