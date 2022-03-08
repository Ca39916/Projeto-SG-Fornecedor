using System;
using System.Collections.Generic;
using System.Text;
using SGFornecedor.applicationCore.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SGFornecedor.applicationCore.Interfaces.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        List<Imagem> BuscarImagens(Expression<Func<Imagem, bool>> predicado);
    }
}
