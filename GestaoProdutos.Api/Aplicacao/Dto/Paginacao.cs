namespace GestaoProdutos.Aplicacao.Dto
{
    public class Paginacao
    {
        public int Pagina { get; set; } = 1;
        public int QuantidadePorPagina { get; set; } = 10;

        public Paginacao(int pagina, int quantidadePorPagina)
        {
            Pagina = pagina;
            QuantidadePorPagina = quantidadePorPagina;
        }
        public Paginacao()
        {
            
        }
    }
}
