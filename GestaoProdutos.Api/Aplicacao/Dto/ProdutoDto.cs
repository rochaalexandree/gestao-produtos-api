using System;

namespace GestaoProdutos.Aplicacao.Dto
{
    public class ProdutoDto
    {
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public Guid? FornecedorId { get; set; }
    }
}
