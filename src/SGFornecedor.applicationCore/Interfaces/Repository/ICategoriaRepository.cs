using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFornecedor.applicationCore.Interfaces.Repository
{
    //A class IFornecedorRepository existe para adicionar algo específico,porem ela erda tudo da classe  IRepository

    public interface ICategoriaRepository : IRepository<Categoria>
    {
    }
}
