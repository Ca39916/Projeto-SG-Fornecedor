using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGFornecedor.applicationCore.Entity
{
    public class Imagem
    {
        
        [Key]
        public Guid IdImagem { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CaminhoDaImagem { get; set; }
        public Produto Produto { get; set; } // Uma imagem pode ter apenas um produto
        public Guid IdProduto { get; set; }  //Chave Estrangeira

        public Imagem()//Contrutor
        {

        }

    }
}
