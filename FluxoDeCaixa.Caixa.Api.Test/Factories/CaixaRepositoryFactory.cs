using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Domain.Models.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Caixa.Api.Test.Factories
{
    public class CaixaRepositoryFactory
    {
        public static Caixas GetCaixa()
        {
            var result = new Caixas();

            result = new Caixas()
            {
                Id = new Guid("5c4a3177-785e-44c0-b21b-fc54ddb64976"),
                Nome = "Caixa1",
                Ativo = true,
                Saldo = 20,
                DataCadastro = DateTime.Now

            };

            return result;

        }

        public static decimal SaldoCaixa(Guid caixaId)
        {
            return 25;
        }

        public static void Salvar(Caixas caixa)
        {
            var caixas = new List<Caixas>();

            caixas.Add(caixa);

        }
    }
}
