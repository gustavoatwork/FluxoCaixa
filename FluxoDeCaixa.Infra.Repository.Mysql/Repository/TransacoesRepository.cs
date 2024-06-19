using FluxoDeCaixa.Domain.Interfaces.Repository;
using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Domain.Models.Caixa;
using FluxoDeCaixa.Domain.Models.Lancamentos;
using FluxoDeCaixa.Infra.Repository.Mysql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.Repository.Mysql.Repository
{
    public class TransacoesRepository : ITransacoesRepository
    {
        private readonly CaixaContext _context;
        public TransacoesRepository(CaixaContext context)
        {
            _context = context;
        }

        public async Task<List<Transacoes>> BuscarTransacoes(Guid caixaId)
        {
            var result = await _context.Transacoes.Include(x => x.Caixas)
                                .Where(x => x.CaixaId == caixaId).ToListAsync();

            return result;
        }

        public async Task<Transacoes> Salvar(Transacoes transacao)
        {
            _context.Entry(transacao).State = EntityState.Added;
            var result = await _context.Transacoes.AddAsync(transacao);

            _context.SaveChanges();

            return result.Entity;
        }
    }
}
