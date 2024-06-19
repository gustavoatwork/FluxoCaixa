using FluxoDeCaixa.Domain.Interfaces.Repository;
using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Domain.Models.Caixa;
using FluxoDeCaixa.Infra.Repository.Mysql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.Repository.Mysql.Repository
{
    public class CaixaRepository : ICaixaRepository
    {
        private readonly CaixaContext _context;

        public CaixaRepository(CaixaContext context)
        {
            _context = context;
        }

        public async Task Salvar(Caixas caixa)
        {
            if (caixa.Id == Guid.Empty)
            {
                caixa.DataCadastro = DateTime.Now;
                _context.Entry(caixa).State = EntityState.Added;
            }
            else
            {
                var result = _context.Caixas.Where(x => x.Id == caixa.Id);
                if (result != null)
                {
                    _context.Entry(caixa).State = EntityState.Modified;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Caixas> GetCaixa()
        {
            var result = await _context.Caixas.FirstOrDefaultAsync();

            return result;


        }

        public async Task<decimal> SaldoCaixa(Guid caixaId)
        {
            var result = await _context.Caixas.Where(x => x.Id == caixaId)
                .FirstOrDefaultAsync();
            if (result == null) return 0;
            return result.Saldo;
        }
    }
}
