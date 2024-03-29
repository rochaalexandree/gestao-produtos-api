using GestaoProdutos.Dominio.Entidades;
using System;
using Xunit;
using FluentAssertions;
using System.Linq;
using Moq;
using GestaoProdutos.Aplicacao.Servicos;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using GestaoProdutos.Infraestrutura.Repositorio;
using System.Threading.Tasks;
using GestaoProdutos.Aplicacao.Dto;
using System.Threading;
using GestaoProdutos.Infraestrutura.Contextos;
using Microsoft.OpenApi.Any;

namespace GestaoProdutos.Teste
{
    public class ProdutoServicoTeste
    {
        [Fact(DisplayName = "Adicionar produto valido Async")]
        public async Task Produto_AdicionarNovoProduto_DeveRetornarSucesso()
        {
            //Arrange
            var produtoRepositorio = new Mock<IProdutoRepositorio>();
            var unidadeDeTrabalho = new Mock<IUnidadeDeTrabalho>();
            
            unidadeDeTrabalho.Setup(u => u.Commit()).Returns(Task.FromResult(true));
            produtoRepositorio.Setup(p => p.UnidadeDeTrabalho).Returns(unidadeDeTrabalho.Object);

            var produtoServico = new ProdutoServico(produtoRepositorio.Object);

            var produtoDto = new ProdutoDto
            {
                Ativo = true,
                Descricao = "Produto de teste",
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(1),
            };

            //Act
            var resultado = await produtoServico.AdicionarProdutoAsync(produtoDto, CancellationToken.None);

            //Assert
            resultado.Sucesso.Should().BeTrue();
            resultado.Resultado.Should().NotBeEmpty();
            resultado.Erros.Should().BeEmpty();
        }

        [Fact(DisplayName = "Atualizar produto valido Async")]
        public async Task Produto_AtualizarProduto_DeveRetornarSucesso()
        {
            //Arrange
            var produtoRepositorio = new Mock<IProdutoRepositorio>();
            var unidadeDeTrabalho = new Mock<IUnidadeDeTrabalho>();

            unidadeDeTrabalho.Setup(u => u.Commit()).Returns(Task.FromResult(true));
            produtoRepositorio.Setup(p => p.UnidadeDeTrabalho).Returns(unidadeDeTrabalho.Object);
            
            var produto = new Produto("Produto teste", true, DateTime.Now, DateTime.Now.AddMonths(1), Guid.NewGuid());
            
            produtoRepositorio
                .Setup(p => p.ObterPorCodigoAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(produto));

            var produtoServico = new ProdutoServico(produtoRepositorio.Object);

            var produtoDto = new ProdutoDto
            {
                Ativo = true,
                Descricao = "Produto de teste",
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(1),
            };

            //Act
            var resultado = await produtoServico.AtualizarProdutoAsync(1, produtoDto, CancellationToken.None);

            //Assert
            resultado.Sucesso.Should().BeTrue();
            resultado.Resultado.Should().NotBeEmpty();
            resultado.Erros.Should().BeEmpty();
        }
    }
}
