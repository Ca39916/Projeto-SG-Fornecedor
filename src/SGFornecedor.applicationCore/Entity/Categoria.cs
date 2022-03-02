using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class Categoria
    {
        [Key]
        public Guid IdCategoria { get; set; }
        public bool Active { get; set; }
        public string Nome { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        //public Produto Produto { get; set; }

        //public Guid IdProduto { get; set; } // Chave estrangeira


        public List<Produto> Produto { get; set; } = new List<Produto>();

        public Categoria()//Contrutor
        {

        }


    }

}
