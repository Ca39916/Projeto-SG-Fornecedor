using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGFornecedor.applicationCore.Interfaces.Services
{
    public interface IProdutoService : IService<Produto>
    {
        Produto Adicionar(Produto entity);
        void Atualizar(Produto entity);
        IEnumerable<Produto> obterTodos();
        Produto ObterPorId(Guid id);
        IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> predicado);
        void Remover(Produto entity);
    }
}
