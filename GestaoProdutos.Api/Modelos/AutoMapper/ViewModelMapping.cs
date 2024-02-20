using AutoMapper;
using GestaoProdutos.Aplicacao;
using GestaoProdutos.Aplicacao.Dto;
using GestaoProdutos.Dominio.Entidades;
using GestaoProdutos.Modelos.Requests;
using GestaoProdutos.Modelos.ViewModels;

namespace GestaoProdutos.Modelos.AutoMapper
{
    public static class ViewModelMapping
    {
        public static void ConfigurarViewModel(this Profile profile)
        {

            profile.CreateMap(typeof(Resposta<>), typeof(BaseViewModel<>))
                .IncludeAllDerived();

            profile.CreateMap<Produto, ProdutoViewModel>()
                .IncludeAllDerived();

            profile.CreateMap<Fornecedor, FornecedorViewModel>()
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj.Numero))
                .IncludeAllDerived();
        }
    }
}
