using GestaoProdutos.Dominio.Entidades;
using GestaoProdutos.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public async Task<Produto> ObterPorCodigo(int codigo)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public async Task<IEnumerable<Produto>> ObterTodos(string descricaoProduto, string nomeFornecedor, int codigoFornecedor, int pagina = 1, int quantidadePorPagina = 10)
        {
            var query = _context.Produtos.Include(p => p.Fornecedor).AsQueryable();

            if (!string.IsNullOrEmpty(descricaoProduto))
                query.Where(p => p.Descricao.Contains(descricaoProduto));

            if (!string.IsNullOrEmpty(nomeFornecedor))
                query.Where(p => p.Fornecedor.Nome.Contains(nomeFornecedor));

            if (codigoFornecedor > 0)
                query.Where(p => p.Fornecedor.Codigo == codigoFornecedor);


            if (pagina > 1)
            {
                var quantidadeASerPulada = (pagina - 1) * quantidadePorPagina;

                query.Skip(quantidadeASerPulada);
            }

            query.Take(quantidadePorPagina);

            return await query.ToListAsync();
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
