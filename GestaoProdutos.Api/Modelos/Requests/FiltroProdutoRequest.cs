using System;
using System.Globalization;

namespace GestaoProdutos.Modelos.Requests
{
    public class FiltroProdutoRequest : PaginacaoRequest
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
