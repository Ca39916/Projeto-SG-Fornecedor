using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class Produto
    {
        public Produto()
        {
        }

        [Key]
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public int QuantidadeEstoque { get; set; }
        public bool Active { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCompra { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Categoria Categoria { get; set; } // Produto pode ter apenas 1 Categoria 

        public ICollection<Imagem> Imagens { get; set; } // Coleção de imagem

        public List<string> ValidaProduto(Produto ValiProduto)
        {
            List<string> valida = new List<string>();

            if (string.IsNullOrEmpty(ValiProduto.Nome)) //IsNullOrEmpty verifica se o campo é nulo ou esta em branco
            {
                valida.Add("NOME OBRIGATÓRIO");

            }

            if (string.IsNullOrEmpty(ValiProduto.CodigoBarras)) //IsNullOrEmpty verifica se o campo é nulo ou esta em branco
            {
                valida.Add("CÓDIGO DE BARRAS OBRIGATÓRIO");

            }

            if (ValiProduto.QuantidadeEstoque < 0)
            {
                valida.Add("QUANTIDADE DE ESTOQUE OBRIGATÓRIO");

            }

            if (ValiProduto.PrecoVenda < 0)
            {
                valida.Add("PREÇO DE VENDA OBRIGATÓRIO");

            }

            if (ValiProduto.PrecoCompra < 0)
            {
                valida.Add("PREÇO DE COMPRA OBRIGATÓRIO");

            }

            if (string.IsNullOrEmpty(ValiProduto.Categoria.IdCategoria.ToString())) //IsNullOrEmpty verifica se o campo é nulo ou esta em branco
            {
                valida.Add("CATEGORIA OBRIGATÓRIO");

            }
            return valida;
        }



    }
} 








   
    


