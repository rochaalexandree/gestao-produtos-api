using Flunt.Validations;
using System;

namespace GestaoProdutos.Dominio.Entidades
{
    public class Produto : Entidade, IRaizAgregacao
    {
        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public Guid? FornecedorId { get; private set; }

        public Fornecedor Fornecedor { get; private set; }

        protected Produto() { }

        public Produto(string descricao, bool ativo, DateTime dataFabricacao, DateTime dataValidade, Guid? fornecedorId) 
        {
            AlterarDescricao(descricao, true);
            
            if (ativo)
                Ativar();
            else
                Desativar();
            
            AlterarDataValidade(dataValidade, true);
            AlterarDataFabricacao(dataFabricacao, true);
            AlterarFornecedor(fornecedorId, true);
        }

        public Produto AlterarDescricao(string descricao, bool novo = false)
        {
            if (!novo && descricao.Equals(Descricao))
                return this;

            Descricao = descricao;

            AddNotifications(new Contract<Produto>().Requires().IsLowerOrEqualsThan(Descricao.Length, 500, nameof(Descricao), "Limite máximo de 500 caracteres excedido."));

            Modificada = true;

            return this;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public Produto AlterarDataFabricacao(DateTime dataFabricacao, bool novo = false)
        {
            if (!novo && dataFabricacao.Equals(DataFabricacao))
                return this;

            DataFabricacao = dataFabricacao;

            AddNotifications(new Contract<Produto>().IsLowerThan(DataFabricacao, DataValidade, nameof(DataFabricacao), "A data de fabricação não pode ser maior ou igual a data de validade."));

            Modificada = true;

            return this;
        }
        
        public Produto AlterarDataValidade(DateTime dataValidade, bool novo = false)
        {
            if (!novo && dataValidade.Equals(DataValidade))
                return this;

            DataValidade = dataValidade;

            AddNotifications(new Contract<Produto>().IsGreaterThan(DataValidade, DataFabricacao, nameof(DataValidade), "A data de fabricação não pode ser maior ou igual a data de validade."));

            Modificada = true;

            return this;
        }

        public Produto AlterarFornecedor(Guid? fornecedorId, bool novo = false)
        {
            if (!novo && fornecedorId.Equals(FornecedorId))
                return this;

            FornecedorId = fornecedorId;

            Modificada = true;

            return this;
        }

        public Produto AtualizarProduto(string descricao, DateTime dataFabricacao, DateTime dataValidade, Guid? fornecedorId)
        {
            AlterarDescricao(descricao);
            AlterarDataFabricacao(dataFabricacao);
            AlterarDataValidade(dataValidade);
            AlterarFornecedor(fornecedorId);

            return this;
        }
    }
}
