using ProjetoSGFornecedor.infrastructure.Data;
using SGFornecedor.applicationCore.Entity;
using SGFornecedor.applicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSGFornecedor.infrastructure.Repository
{
    public class TelefoneRepository : RepositoryBase<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(FornecedorContext dbContext) : base(dbContext)
        {
        }
    }
}
