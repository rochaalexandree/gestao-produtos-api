using GestaoProdutos.Dominio.Entidades;
using System;
using Xunit;
using FluentAssertions;
using System.Linq;
namespace GestaoProdutos.Teste
{
    public class FornecedorTeste
    {
        [Fact(DisplayName = "Instanciar novo Fornecedor valido")]
        public void Fornecedor_InstaciarNovoFornecedor_DeveEstarValido()
        {
            var produto = new Fornecedor("Fornecedor teste", "Descricao do fornecedor", "97120859000176");

            produto.Should().NotBeNull();
            produto.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "Instanciar novo Fornecedor invalido com notification de limite de caracteres")]
        public void Fornecedor_InstaciarNovoFornecedor_DeveEstarInvalidoComNotificationDeLimitacaoDeCaracteres()
        {
            var nome = "Fornecedor teste";

            for (int i = 0; i < 16; i++)
            {
                nome += nome;
            }

            var produto = new Fornecedor(nome, "Descricao do fornecedor", "97120859000176");

            produto.Should().NotBeNull();
            produto.IsValid.Should().BeFalse();
            produto.Notifications.Should().NotBeEmpty();
            produto.Notifications.First().Message.Should().Be("Limite máximo de 250 caracteres excedido.");
        }
    }
}
