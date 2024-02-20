using System;

namespace GestaoProdutos.Aplicacao.Dto
{
    public class FiltroProdutoDto : Paginacao
    {
        public Guid? Id { get; set; }
        public string Descricao { get; set; } = null;
        public bool? Ativo { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? codigoFornecedor { get; set; }
        public string nomeFornecedor { get; set; } = null;
    }
}
