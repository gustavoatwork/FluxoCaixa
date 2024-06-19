using FluxoDeCaixa.Domain.Models.Caixa;
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
    public class TransacoesMap : IEntityTypeConfiguration<Transacoes>
    {
        public void Configure(EntityTypeBuilder<Transacoes> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CaixaId).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(150).IsRequired(false);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.TipoLancamentoId).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();

            builder.HasOne(x => x.Caixas).WithMany().HasForeignKey(x => x.CaixaId);
            builder.HasOne(x => x.TipoLancamento).WithMany().HasForeignKey(x => x.TipoLancamentoId);

        }
    }
}
