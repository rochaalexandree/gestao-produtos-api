using GestaoProdutos.Aplicacao.Dto;
using GestaoProdutos.Dominio.Entidades;
using GestaoProdutos.Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Aplicacao.Servicos
{
    public class ProdutoServico : Servico<Guid>, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<Resposta<Guid>> AdicionarProdutoAsync(ProdutoDto produtoDto, CancellationToken cancellationToken)
        {
            var produto = new Produto(produtoDto.Descricao, produtoDto.Ativo, produtoDto.DataFabricacao, produtoDto.DataValidade, produtoDto.FornecedorId);

            if (!produto.IsValid)
                return new Resposta<Guid>(produto.Notifications);
            
            await _produtoRepositorio.AdicionarAsync(produto, cancellationToken);

            var resultado = await PersistirDados(_produtoRepositorio.UnidadeDeTrabalho);

            if (!resultado.Sucesso)
                return new Resposta<Guid>(resultado.Erros);

            return new Resposta<Guid>(produto.Id);
        }

        public async Task<Resposta<Guid>> ExcluirProdutoAsync(int codigo, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepositorio.ObterPorCodigoAsync(codigo, cancellationToken);

            produto.Desativar();

            _produtoRepositorio.Atualizar(produto);

            var resultado = await PersistirDados(_produtoRepositorio.UnidadeDeTrabalho);

            if (!resultado.Sucesso)
                return new Resposta<Guid>(resultado.Erros);

            return new Resposta<Guid>(produto.Id);
        }

        public async Task<Resposta<IEnumerable<object>>> ListarProdutosAsync(FiltroProdutoDto filtroDto, CancellationToken cancellationToken)
        {
            var paginacao = new Paginacao(filtroDto.Pagina, filtroDto.QuantidadePorPagina);
            var retorno = await _produtoRepositorio.ObterTodosAsync(filtroDto.Descricao, filtroDto.nomeFornecedor, filtroDto.codigoFornecedor, filtroDto.Ativo, filtroDto.Pagina, filtroDto.QuantidadePorPagina, cancellationToken);
            return new Resposta<IEnumerable<object>>(retorno, paginacao);
        }

        public async Task<Resposta<object>> ObterProdutoPorCodigoAsync(int codigo, CancellationToken cancellationToken)
        {
            return new Resposta<object>(await _produtoRepositorio.ObterPorCodigoAsync(codigo, cancellationToken));
        }

        public async Task<Resposta<Guid>> AtualizarProdutoAsync(int codigo, ProdutoDto produtoDto, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepositorio.ObterPorCodigoAsync(codigo, cancellationToken);

            produto.AtualizarProduto(produtoDto.Descricao, produtoDto.DataFabricacao, produtoDto.DataValidade, produtoDto.FornecedorId ?? produto.FornecedorId);

            if (!produto.IsValid)
                return new Resposta<Guid>(produto.Notifications);

            _produtoRepositorio.Atualizar(produto);

            var resultado = await PersistirDados(_produtoRepositorio.UnidadeDeTrabalho);

            if (!resultado.Sucesso)
                return new Resposta<Guid>(resultado.Erros);

            return new Resposta<Guid>(produto.Id);
        }
    }
}
