using SGFornecedor.applicationCore.Entity;
using SGFornecedor.applicationCore.Interfaces.Repository;
using SGFornecedor.applicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGFornecedor.applicationCore.Services
{
    public class CategoriaServices : Service<Categoria> , ICategoriaService
    {
        protected readonly ICategoriaRepository _categoriaService;

        public CategoriaServices(ICategoriaRepository categoriaService) : base(categoriaService)//Método construtor
        {
            _categoriaService = categoriaService;
        }
        public Categoria Adicionar(Categoria entity)
        {
            //Regra de negocio 
            return _categoriaService.Adicionar(entity);
        }

        public void Atualizar(Categoria entity)
        {
            _categoriaService.Atualizar(entity);
        }

        public IEnumerable<Categoria> Buscar(Expression<Func<Categoria, bool>> predicado)
        {
            return _categoriaService.Buscar(predicado);
        }

        public Categoria ObterPorId(Guid id)
        {
            return _categoriaService.ObterPorId(id);
        }

        public IEnumerable<Categoria> obterTodos()
        {
            return _categoriaService.obterTodos();
        }

        public void Remover(Categoria entity)
        {
            _categoriaService.Remover(entity);
        }
    }
}
