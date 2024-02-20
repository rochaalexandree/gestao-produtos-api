using GestaoProdutos.Dominio.Entidades;
using GestaoProdutos.Infraestrutura.Contextos;
using System;

namespace GestaoProdutos.Infraestrutura.Repositorio
{
    public interface IRepositorio<T> : IDisposable where T : IRaizAgregacao
    {
        IUnidadeDeTrabalho UnidadeDeTrabalho { get; }
    }
}
