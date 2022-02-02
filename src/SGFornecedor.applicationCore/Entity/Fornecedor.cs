using System;
using System.Collections.Generic;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
