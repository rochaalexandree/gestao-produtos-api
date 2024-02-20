using AutoMapper;
using GestaoProdutos.Modelos.AutoMapper;

namespace GestaoProdutos.Configuracao
{
    public class AplicacaoProfile : Profile
    {
        public AplicacaoProfile()
        {
            this.ConfigurarFiltroRequest();
            this.ConfigurarViewModel();
        }
    }
}
