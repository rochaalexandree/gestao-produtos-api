using Flunt.Validations;
using GestaoProdutos.Dominio.ObjetosDeValor;

namespace GestaoProdutos.Dominio.Entidades
{
    public class Fornecedor : Entidade, IRaizAgregacao
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Cnpj Cnpj { get; set; }

        protected Fornecedor() { }

        public Fornecedor(string nome, string Descricao, string cnpj)
        {

        }

        public Fornecedor AlterarNome(string nome, bool novo)
        {
            if (!novo && nome.Equals(Nome))
                return this;

            Nome = nome;

            AddNotifications(new Contract<Fornecedor>().Requires().IsLowerOrEqualsThan(Nome.Length, 200, nameof(Nome), "Limite máximo de 200 caracteres excedido."));

            Modificada = true;

            return this;
        }

        public Fornecedor AlterarDescricao(string descricao, bool novo)
        {
            if (!novo && descricao.Equals(Descricao))
                return this;

            Descricao = descricao;

            AddNotifications(new Contract<Fornecedor>().Requires().IsLowerOrEqualsThan(Descricao.Length, 500, nameof(Descricao), "Limite máximo de 500 caracteres excedido."));

            Modificada = true;

            return this;
        }

        public Fornecedor AlterarCnpj(string cnpj, bool novo)
        {
            if (!novo && cnpj.Equals(Cnpj))
                return this;

            Cnpj = cnpj;

            Modificada = true;

            return this;
        }
    }
}
