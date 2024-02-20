using GestaoProdutos.Aplicacao.Dto;
using GestaoProdutos.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace GestaoProdutos.Aplicacao.Servicos
{
    public interface IProdutoServico
    {
        Task<Resposta<Guid>> AdicionarProdutoAsync(ProdutoDto produtoDto, CancellationToken cancellationToken);

        Task<Resposta<Guid>> ExcluirProdutoAsync(int codigo, CancellationToken cancellationToken);

        Task<Resposta<IEnumerable<object>>> ListarProdutosAsync(FiltroProdutoDto filtroDto, CancellationToken cancellationToken);

        Task<Resposta<object>> ObterProdutoPorCodigoAsync(int codigo, CancellationToken cancellationToken);

        Task<Resposta<Guid>> AtualizarProdutoAsync(ProdutoDto produtoDto, CancellationToken cancellationToken);
    }
}
