using System;
using System.Collections.Generic;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class Telefone
    {
        public Guid TelefoneId { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid FornecedorId { get; set; }  //Chave Estrangeira

        public Fornecedor Fornecedor { get; set; } // telefone só pode ter um Fornecedor
    }
}
