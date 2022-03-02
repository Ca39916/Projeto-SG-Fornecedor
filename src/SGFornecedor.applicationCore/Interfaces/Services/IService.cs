using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace SGFornecedor.applicationCore.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        IEnumerable<TEntity> obterTodos();
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado);
        void Remover(TEntity entity);

       
    }
}
