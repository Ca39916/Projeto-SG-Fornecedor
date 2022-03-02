using Microsoft.EntityFrameworkCore;
using ProjetoSGFornecedor.infrastructure.Data;
using SGFornecedor.applicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace ProjetoSGFornecedor.infrastructure.Repository
{
    // A classe EFRepository faz a implementação do Contrato da IRepository 
    // Classe EFRepository contem os dados basicos como add, atualizar e etc...
    //Classe base 
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class //RepositoryBase usa a interface do IRepository 
    {

        protected FornecedorContext _dbContext;

        public RepositoryBase(FornecedorContext dbContext) //Construtor
        {
            _dbContext = dbContext;
        }

        public TEntity Adicionar(TEntity entity) // virtual = pode ser sobrescrito (Polimorfismo)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
            return(entity); //entity entidade
        }

        
        public void Atualizar(TEntity entity) // virtual = pode ser sobrescrito (Polimorfismo)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado) //Apenas busca uma informação
        {
            return _dbContext.Set<TEntity>().Where(predicado).AsEnumerable();
        }

        public TEntity ObterPorId(Guid id) // virtual = pode ser sobrescrito (Polimorfismo)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> obterTodos()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public void Remover(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }
    }
}
