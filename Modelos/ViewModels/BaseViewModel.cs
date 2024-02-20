using Flunt.Notifications;
using GestaoProdutos.Aplicacao.Dto;
using System.Collections.Generic;

namespace GestaoProdutos.Modelos.ViewModels
{
    public class BaseViewModel<T>
    {
        public BaseViewModel() { }
        public BaseViewModel(T valor)
        {
            Resultado = valor;
            Sucesso = true;
        }

        public BaseViewModel(IReadOnlyCollection<Notification> notifications)
        {
            Erros = notifications;
            Sucesso = false;
        }

        public BaseViewModel(T valor, Paginacao paginacao)
        {
            Resultado = valor;
            Sucesso = true;
            Paginacao = paginacao;
        }

        public T Resultado { get; set; }
        public bool Sucesso { get; set; }
        public Paginacao Paginacao { get; set; }
        public IEnumerable<Notification> Erros { get; set; } = null;
    }
}
