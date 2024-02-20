using System.Threading.Tasks;

namespace GestaoProdutos.Infraestrutura.Contextos
{
    public interface IUnidadeDeTrabalho
    {
        Task<bool> Commit();
    }
}
