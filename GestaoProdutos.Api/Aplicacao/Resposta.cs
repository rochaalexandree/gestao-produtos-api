using Flunt.Notifications;
using GestaoProdutos.Aplicacao.Dto;
using GestaoProdutos.Infraestrutura.Contextos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.Aplicacao
{
    public class Resposta<T>
    {
        public Resposta() { }
        public Resposta(T valor)
        {
            Resultado = valor;
            Sucesso = true;
        }

        public Resposta(IReadOnlyCollection<Notification> notifications)
        {
            Erros = notifications;
            Sucesso = false;
        }

        public Resposta(T valor, Paginacao paginacao)
        {
            Resultado = valor;
            Sucesso = true;
            Paginacao = paginacao;
        }

        public T Resultado { get; set; }
        public bool Sucesso { get; set; }
        public Paginacao Paginacao { get; set; }
        public IEnumerable<Notification> Erros { get; set; } = new List<Notification>();

        protected void AdicionarErro(string mensagem)
        {
            Erros?.ToList().Add(new Notification(string.Empty, mensagem));
        }
        protected async Task<Resposta<T>> PersistirDados(IUnidadeDeTrabalho uow)
        {
            if (!await uow.Commit()) AdicionarErro("Erro ao persistir os dados.");

            Sucesso = !Erros.Any();
            return this;
        }
    }
}
