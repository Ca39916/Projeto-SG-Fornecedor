using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGFornecedor.applicationCore.Interfaces.Services
{
    public interface ICategoriaService : IService<Categoria>
    {
        Categoria Adicionar(Categoria entity);
        void Atualizar(Categoria entity);
        IEnumerable<Categoria> obterTodos();
        Categoria ObterPorId(Guid id);
        IEnumerable<Categoria> Buscar(Expression<Func<Categoria, bool>> predicado);
        void Remover(Categoria entity);
    }
}
