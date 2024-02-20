using AutoMapper;
using GestaoProdutos.Aplicacao.Dto;
using GestaoProdutos.Modelos.Requests;

namespace GestaoProdutos.Modelos.AutoMapper
{
    public static class RequestMapping
    {
        public static void ConfigurarFiltroRequest(this Profile profile)
        {
            profile.CreateMap<PaginacaoRequest, Paginacao>()
                .ConstructUsing(src => new Paginacao(src.Pagina, src.QuantidadePorPagina))
                .IncludeAllDerived();

            profile.CreateMap<FiltroProdutoRequest, FiltroProdutoDto>()
                .IncludeAllDerived();

        }
    }
}
