using SGFornecedor.applicationCore.Entity;
using ProjetoSGFornecedor.infrastructure.Data;
using SGFornecedor.applicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSGFornecedor.infrastructure.Repository
{   
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(FornecedorContext dbContext) : base(dbContext)
        {
        }
    }
}
