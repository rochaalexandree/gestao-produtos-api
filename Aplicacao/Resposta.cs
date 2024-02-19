using Flunt.Notifications;
using GestaoProdutos.Infraestrutura.Contextos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GestaoProdutos.Aplicacao
{
    public class Resposta<T> : Notifiable<Notification>
    {
        public Resposta() { }
        public Resposta(T valor)
        {
            Resultado = valor;
            Sucesso = IsValid;
        }

        public Resposta(IReadOnlyCollection<Notification> notifications)
        {
            AddNotifications(notifications);
            Sucesso = IsValid;
        }

        public T Resultado { get; set; }
        public bool Sucesso { get; set; }

        protected void AdicionarErro(string mensagem)
        {
            AddNotification(string.Empty, mensagem);
        }
        protected async Task<Resposta<T>> PersistirDados(IUnidadeDeTrabalho uow)
        {
            if (!await uow.Commit()) AdicionarErro("Erro ao persistir os dados.");

            return this;
        }
    }
}
