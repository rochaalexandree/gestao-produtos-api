using GestaoProdutos.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Infraestrutura.Repositorio
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Task AdicionarAsync(Produto produto, CancellationToken cancellationToken);

        Task<IEnumerable<Produto>> ObterTodosAsync(string descricaoProduto, string nomeFornecedor, int? codigoFornecedor, bool? ativo, int pagina, int quantidadePorPagina, CancellationToken cancellationToken);

        Task<Produto> ObterPorCodigoAsync(int codigo, CancellationToken cancellationToken);

        void Atualizar(Produto produto);
    }
}
