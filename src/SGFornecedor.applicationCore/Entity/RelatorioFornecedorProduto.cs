using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class RelatorioFornecedorProduto
    {
        public Guid FornecedorId { get; set; }
        public string NomeFantasia { get; set; }

        //Produto
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCompra { get; set; }
    }
}
