using GestaoProdutos.Aplicacao.Servicos;
using GestaoProdutos.Infraestrutura.Contextos;
using GestaoProdutos.Infraestrutura.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace GestaoProdutos.Configuracao
{
    public static class InjecaoDeDependenciaConfiguracao
    {
        public static void RegistrarServicos(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            //services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<IProdutoServico, ProdutoServico>();

            services.AddScoped<AppContext>();
        }
    }
}
