using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SGFornecedor.applicationCore.Entity;

namespace ProjetoSGFornecedor.infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FornecedorContext context)
        {
            //if (context.Fornecedores.Any()) // Se tiver algum cliente cadastrado ele entra nesse if.  Any faz parte do pacote do Linq 
            //{
            //    return;
            //}

            //var fornecedores = new Fornecedor[]
            //{
                //new Fornecedor {
                    
                //    Active = true,
                //    InsertDate = DateTime.Now,
                //    UpdateDate = DateTime.Now,

                //}
            //};
        }
    }
}
