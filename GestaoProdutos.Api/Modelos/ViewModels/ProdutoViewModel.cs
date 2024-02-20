using System;

namespace GestaoProdutos.Modelos.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }
    }

    public class FornecedorViewModel
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
    }
}
