using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Domain.Models.Caixa;
using FluxoDeCaixa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.Caixa
{
    public class CaixaService : ICaixaService
    {

        private readonly ICaixaRepository _caixaRepository;

        public CaixaService(ICaixaRepository caixaRepository)
        {
            _caixaRepository = caixaRepository;
        }

        public async Task<Caixas> GetCaixa()
        {
            try
            {
                var result = await _caixaRepository.GetCaixa();

                return result;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao retornar caixa");
            }
        }

        public async Task<decimal> GetSaldoCaixa(Guid IdCaixa)
        {
            try
            {
                var result = await _caixaRepository.SaldoCaixa(IdCaixa);

                return result;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao retornar saldo do caixa");
            }
        }
    }
}
