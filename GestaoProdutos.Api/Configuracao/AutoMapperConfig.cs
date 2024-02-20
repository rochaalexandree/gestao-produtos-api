using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoProdutos.Configuracao
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection RegistrarMapeamentoAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.ShouldMapProperty = pi => pi.GetMethod != null && (pi.GetMethod.IsPublic || pi.GetMethod.IsAssembly);
            }, typeof(AplicacaoProfile).Assembly);

            return services;
        }
    }
}
