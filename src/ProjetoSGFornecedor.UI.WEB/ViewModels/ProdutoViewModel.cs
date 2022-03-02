using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;

namespace ProjetoSGFornecedor.UI.WEB.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public int QuantidadeEstoque { get; set; }
        public bool Active { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCompra { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Categoria Categoria { get; set; } = new Categoria(); // Produto pode ter apenas 1 Categoria 

        public List<Imagem> Imagens { get; set; } = new List<Imagem>();// Coleção de imagem
    }
}
