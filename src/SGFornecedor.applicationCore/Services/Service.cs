using System;
using SGFornecedor.applicationCore.Entity;
using SGFornecedor.applicationCore.Interfaces.Repository;
using SGFornecedor.applicationCore.Services;
using SGFornecedor.applicationCore.Interfaces.Services;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace SGFornecedor.applicationCore.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> service)
        {
            _repository = service;
        }

        public void Adicionar(TEntity obj)
        {
            _repository.Adicionar(obj);
        }

        public TEntity ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> obterTodos()
        {
            return _repository.obterTodos();
        }

        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return _repository.Buscar(predicado);
        }

        public void Remover(TEntity obj)
        {
            _repository.Remover(obj);
        }

  
    }

}
