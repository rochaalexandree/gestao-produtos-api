using Flunt.Validations;
using System;

namespace GestaoProdutos.Dominio.Entidades
{
    public class Produto : Entidade, IRaizAgregacao
    {
        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime? DataFabricacao { get; private set; }
        public DateTime? DataValidade { get; private set; }
        public Guid? FornecedorId { get; private set; }

        protected Produto() { }

        public Produto(string descricao, bool ativo, DateTime? dataFabricacao, DateTime? dataValidade, Guid? fornecedorId) 
        {
            AlterarDescricao(descricao, true);
            
            if (ativo)
                Ativar();
            else
                Desativar();
            
            AlterarDataFabricacao(dataFabricacao, true);
            AlterarDataValidade(dataValidade, true);
            AlterarFornecedor(fornecedorId, true);
        }

        public Produto AlterarDescricao(string descricao, bool novo = false)
        {
            if (!novo && descricao.Equals(Descricao))
                return this;

            Descricao = descricao;

            AddNotifications(new Contract<Produto>().Requires().IsLowerOrEqualsThan(Descricao.Length, 200, nameof(Descricao), "Limite máximo de 200 caracteres excedido."));

            Modificada = true;

            return this;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public Produto AlterarDataFabricacao(DateTime? dataFabricacao, bool novo)
        {
            if (!novo && dataFabricacao.Equals(DataFabricacao))
                return this;

            DataFabricacao = dataFabricacao;

            Modificada = true;

            return this;
        }
        
        public Produto AlterarDataValidade(DateTime? dataValidade, bool novo)
        {
            if (!novo && dataValidade.Equals(DataValidade))
                return this;

            DataValidade = dataValidade;

            Modificada = true;

            return this;
        }

        public Produto AlterarFornecedor(Guid? fornecedorId, bool novo)
        {
            if (!novo && fornecedorId.Equals(FornecedorId))
                return this;

            FornecedorId = fornecedorId;

            Modificada = true;

            return this;
        }
    }
}
