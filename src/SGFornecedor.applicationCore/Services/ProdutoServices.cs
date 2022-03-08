using SGFornecedor.applicationCore.Entity;
using SGFornecedor.applicationCore.Interfaces.Repository;
using SGFornecedor.applicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGFornecedor.applicationCore.Services
{
    public class ProdutoServices : Service<Produto> , IProdutoService
    {
        protected readonly IProdutoRepository _produtoService;

        public ProdutoServices(IProdutoRepository produtoService) : base(produtoService)//Método construtor
        {
            _produtoService = produtoService;
        }
        public Produto Adicionar(Produto entity)
        {
            //Regra de negocio 
            return _produtoService.Adicionar(entity);
        }

        public void Atualizar(Produto entity)
        {
            _produtoService.Atualizar(entity);
        }

        public IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> predicado)
        {
            return _produtoService.Buscar(predicado);
        }

        public Produto ObterPorId(Guid id)
        {
            return _produtoService.ObterPorId(id);
        }

        public IEnumerable<Produto> obterTodos()
        {
            return _produtoService.obterTodos();
        }

        public void Remover(Produto entity)
        {
            _produtoService.Remover(entity);
        }

        public List<Imagem> BuscarImagens(Expression<Func<Imagem, bool>> predicado)
        {
            return _produtoService.BuscarImagens(predicado);
        }
    }
}
