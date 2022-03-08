using System;
using System.Collections.Generic;
using SGFornecedor.applicationCore.Entity;

namespace ProjetoSGFornecedor.UI.WEB.ViewModels
{
    public class FormecedorProdutoViewModel
    {
        //Fornecedor
        public Guid FornecedorId { get; set; }
        public string NomeFantasia { get; set; }

        //Produto
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCompra { get; set; }

    }
}
