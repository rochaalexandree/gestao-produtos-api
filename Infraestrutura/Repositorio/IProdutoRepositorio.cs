using GestaoProdutos.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoProdutos.Infraestrutura.Repositorio
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        void Adicionar(Produto produto);

        Task<IEnumerable<Produto>> ObterTodos(string descricaoProduto, string nomeFornecedor, int codigoFornecedor, int pagina = 1, int quantidadePorPagina = 10);

        Task<Produto> ObterPorCodigo(int codigo);

        void Atualizar(Produto produto);
    }
}
