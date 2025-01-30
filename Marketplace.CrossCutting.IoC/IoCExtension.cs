using Marketplace.Domain.Repositories;
using Marketplace.Domain.Services;
using Marketplace.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.CrossCutting.IoC
{
    public static class IoCExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<UnidadeFederativaService>();
            services.AddScoped<TransacaoService>();
            services.AddScoped<TransacaoTransferenciaService>();
            services.AddScoped<TransferenciaService>();
            services.AddScoped<TipoTransferenciaService>();
            services.AddScoped<OperacaoService>();
            services.AddScoped<MovimentacaoService>();
            services.AddScoped<EnderecoService>();
            services.AddScoped<ContatoService>();
            services.AddScoped<ContatoEnderecoService>();
            services.AddScoped<ContaService>();
            services.AddScoped<CidadeService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnidadeFederativaRepository, UnidadeFederativaRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<ITransacaoTransferenciaRepository, TransacaoTransferenciaRepository>();
            services.AddScoped<ITransferenciaRepository, TransferecniaRepository>();
            services.AddScoped<ITipoTransferenciaRepository, TipoTransferenciaRepository>();
            services.AddScoped<IOperacaoRepository, OperacaoRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IContatoEnderecoRepository, ContatoEnderecoRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
        }
    }
}
