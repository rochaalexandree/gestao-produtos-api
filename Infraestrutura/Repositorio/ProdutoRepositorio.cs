using GestaoProdutos.Dominio.Entidades;
using GestaoProdutos.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Infraestrutura.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AppContext _context;

        public ProdutoRepositorio(AppContext context)
        {
            _context = context;
        }
        public IUnidadeDeTrabalho UnidadeDeTrabalho => _context;

        public async Task AdicionarAsync(Produto produto, CancellationToken cancellationToken)
        {
            await _context.Produtos.AddAsync(produto, cancellationToken);
        }

        public async Task<Produto> ObterPorCodigoAsync(int codigo, CancellationToken cancellationToken)
        {
            return await _context.Produtos.Include(p => p.Fornecedor).FirstOrDefaultAsync(p => p.Codigo == codigo, cancellationToken);
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync(string descricaoProduto, string nomeFornecedor, int? codigoFornecedor, bool? ativo, int pagina, int quantidadePorPagina, CancellationToken cancellationToken)
        {
            var query = _context.Produtos.AsNoTracking().Include(p => p.Fornecedor).AsQueryable();

            if (!string.IsNullOrEmpty(descricaoProduto))
                query.Where(p => p.Descricao.Contains(descricaoProduto));

            if (!string.IsNullOrEmpty(nomeFornecedor))
                query.Where(p => p.Fornecedor.Nome.Contains(nomeFornecedor));

            if (codigoFornecedor.HasValue)
                query.Where(p => p.Fornecedor.Codigo == codigoFornecedor.Value);

            if (ativo.HasValue)
                query.Where(p => p.Ativo == ativo.Value);

            if (pagina > 1)
            {
                var quantidadeASerPulada = (pagina - 1) * quantidadePorPagina;

                query.Skip(quantidadeASerPulada);
            }

            query.Take(quantidadePorPagina);

            return await query.ToListAsync(cancellationToken);
        }

        public void Atualizar(Produto produto)
        {
            _context.Update(produto);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
