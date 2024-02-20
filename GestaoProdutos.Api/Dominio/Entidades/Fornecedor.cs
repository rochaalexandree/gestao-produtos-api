using Flunt.Validations;
using GestaoProdutos.Dominio.ObjetosDeValor;
using System.Collections.Generic;

namespace GestaoProdutos.Dominio.Entidades
{
    public class Fornecedor : Entidade, IRaizAgregacao
    {
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Cnpj Cnpj { get; private set; }

        private readonly List<Produto> _produtos;
        public IReadOnlyCollection<Produto> Produtos => _produtos;

        protected Fornecedor() { }

        public Fornecedor(string nome, string descricao, string cnpj)
        {
            AlterarNome(nome, true);
            AlterarDescricao(descricao, true);
            AlterarCnpj(cnpj, true);
        }

        public Fornecedor AlterarNome(string nome, bool novo)
        {
            if (!novo && nome.Equals(Nome))
                return this;

            Nome = nome;

            AddNotifications(new Contract<Fornecedor>().Requires().IsLowerOrEqualsThan(Nome.Length, 200, nameof(Nome), "Limite máximo de 250 caracteres excedido."));

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
