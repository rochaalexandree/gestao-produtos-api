using GestaoProdutos.Dominio.Entidades;
using System;
using Xunit;
using FluentAssertions;
using System.Linq;
namespace GestaoProdutos.Teste
{
    public class ProdutoTeste
    {
        [Fact(DisplayName = "Instanciar novo produto valido")]
        public void Produto_InstaciarNovoProduto_DeveEstarValido()
        {
            var produto = new Produto("Produto teste", true, DateTime.Now, DateTime.Now.AddMonths(1), Guid.NewGuid());

            produto.Should().NotBeNull();
            produto.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "Instanciar novo produto invalido com notification da data de fabricacao")]
        public void Produto_InstaciarNovoProduto_DeveEstarInvalidoComNotificationDeDataDeFabricacao()
        {
            var produto = new Produto("Produto teste", true, DateTime.Now.AddMinutes(1), DateTime.Now, Guid.NewGuid());

            produto.Should().NotBeNull();
            produto.IsValid.Should().BeFalse();
            produto.Notifications.Should().NotBeEmpty();
            produto.Notifications.First().Message.Should().Be("A data de fabricação não pode ser maior ou igual a data de validade.");
        }

        [Fact(DisplayName = "Alterar data de validade do produto com uma data menor que a de fabricacao")]
        public void Produto_AlterarDataDeValidade_DeveEstarInvalidoComNotificationDeDataDeValidade()
        {
            //Arrange
            var produto = new Produto("Produto teste", true, DateTime.Now, DateTime.Now.AddMonths(1), Guid.NewGuid());
            
            //Act
            produto.AlterarDataValidade(DateTime.Now.AddMonths(-2));
            
            //Assert
            produto.Should().NotBeNull();
            produto.IsValid.Should().BeFalse();
            produto.Notifications.Should().NotBeEmpty();
            produto.Notifications.First().Message.Should().Be("A data de fabricação não pode ser maior ou igual a data de validade.");
        }
    }
}
