using AutoMapper;
using FluxoDeCaixa.Api.Facade.DTO;
using FluxoDeCaixa.Domain.Models.Consolidado;
using FluxoDeCaixa.Domain.Models.Lancamentos;
using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.DTO.Response;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDeCaixa.Infra.Infrastructure.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void Register(IServiceCollection service)
        {
            var config = new MapperConfiguration(cfg =>
            {
                Lancamento(cfg);
                HistoricoTransacoes(cfg);
                Transacoes(cfg);
            });

            IMapper mapper = config.CreateMapper();

            service.AddSingleton(mapper);

        }

        private static void HistoricoTransacoes(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<HistoricoTransacaoRequestDTO, HistoricoTransacoes>()
                .ForMember(x => x.NomeCaixa, x => x.MapFrom(x => x.Caixas.Nome))
                .ForMember(x => x.TipoLancamentoId, x => x.MapFrom(x => x.TipoLancamentoId))
                .ForMember(x => x.TransacoesId, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.DataCadastro, x => x.MapFrom(x => x.DataCadastro));

        }
        private static void Lancamento(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Transacoes, TransacoesResponseDTO>()
                .ForMember(x => x.TipoLancamento, x => x.MapFrom(x => x.TipoLancamentoId));
        }

        private static void Transacoes(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Transacoes, TransacoesDTO>()
                .ForMember(x => x.Caixas, x => x.MapFrom(x => x.Caixas == null ? null : new CaixasDTO()
                {
                    Id = x.CaixaId,
                    Nome = x.Caixas.Nome,
                    Saldo = x.Caixas.Saldo,
                    Ativo = x.Caixas.Ativo,
                    DataAtualizacao = x.Caixas.DataAtualizacao,
                    DataCadastro = x.Caixas.DataCadastro
                }));
        }
    }
}
