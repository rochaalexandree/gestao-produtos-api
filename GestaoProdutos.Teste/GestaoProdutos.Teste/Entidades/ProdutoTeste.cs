using GestaoProdutos.Dominio.Entidades;
using System;
using Xunit;

namespace GestaoProdutos.Teste
{
    public class ProdutoTeste
    {
        [Fact(DisplayName = "Instanciar novo produto valido")]
        public void Produto_InstaciarNovoProduto_DeveEstarValido()
        {
            var produto = new Produto("Produto teste", true, DateTime.Now, DateTime.Now.AddMonths(1), Guid.NewGuid());


        }
    }
}
