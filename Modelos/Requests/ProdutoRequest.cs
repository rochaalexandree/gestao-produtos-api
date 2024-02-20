using System;

namespace GestaoProdutos.Modelos.Requests
{
    public class ProdutoRequest
    {
        public string Descricao { get; set; } = null;
        public bool? Ativo { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public Guid? FornecedorId { get; set; }
    }
}
