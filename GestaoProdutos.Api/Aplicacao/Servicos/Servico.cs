using Flunt.Notifications;
using GestaoProdutos.Aplicacao.Dto;
using GestaoProdutos.Infraestrutura.Contextos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.Aplicacao.Servicos
{
    public class Servico<T>
    {
        public bool Sucesso { get; set; }
        public IEnumerable<Notification> Erros { get; set; } = new List<Notification>();

        protected void AdicionarErro(string mensagem)
        {
            Erros?.ToList().Add(new Notification(string.Empty, mensagem));
        }
        protected async Task<Servico<T>> PersistirDados(IUnidadeDeTrabalho uow)
        {
            if (!await uow.Commit()) AdicionarErro("Erro ao persistir os dados.");

            Sucesso = !Erros.Any();
            return this;
        }
    }
}
