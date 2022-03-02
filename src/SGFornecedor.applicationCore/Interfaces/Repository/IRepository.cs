using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGFornecedor.applicationCore.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class //TEntity é um tipo generico que especifica que so acessa class
    {
        //Contrato
        TEntity Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        IEnumerable<TEntity> obterTodos();
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado);
        void Remover(TEntity entity);

        //TEntity AdicionarFisico(TEntity entity);
        //void AtualizarFisico(TEntity entity);
        //IEnumerable<TEntity> obterTodosFisico();
        //TEntity ObterPorIdFisico(Guid id);
        //IEnumerable<TEntity> BuscarFisico(Expression<Func<TEntity, bool>> predicado);
        //void RemoverFisico(TEntity entity);

        //TEntity AdicionarJuridico(TEntity entity);
        //void AtualizarJuridico(TEntity entity);
        //IEnumerable<TEntity> obterTodosJuridico();
        //TEntity ObterPorIdJuridico(Guid id);
        //IEnumerable<TEntity> BuscarJuridico(Expression<Func<TEntity, bool>> predicado);
        //void RemoverJuridico(TEntity entity);
    }
}
