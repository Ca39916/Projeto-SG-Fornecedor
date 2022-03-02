using System;
using System.Collections.Generic;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class Email
    {
        public Guid EmailId { get; set; }
        public string email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid FornecedorId { get; set; } //Chave Estrangeira

        public Fornecedor Fornecedor { get; set; }
    }
}
