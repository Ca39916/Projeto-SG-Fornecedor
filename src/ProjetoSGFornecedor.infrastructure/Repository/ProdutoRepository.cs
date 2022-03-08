using SGFornecedor.applicationCore.Entity;
using ProjetoSGFornecedor.infrastructure.Data;
using SGFornecedor.applicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace ProjetoSGFornecedor.infrastructure.Repository
{   
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(FornecedorContext dbContext) : base(dbContext)
        {
        }

        public List<Imagem> BuscarImagens(Expression<Func<Imagem, bool>> predicado)
        {
            return _dbContext.Set<Imagem>().Where(predicado).ToList();
        }
    }
}
