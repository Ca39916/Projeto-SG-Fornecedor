using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class  Fornecedor
    {
        public Fornecedor() //Construtor
        {

        }
        [Key]
        public Guid FornecedorId { get; set; }
        public bool Active { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Endereco Endereco { get; set; } // Um fornecedor pode ter apenas um endereco

        public Email Email { get; set; } // Um fornecedor pode ter apenas um endereco

        public  ICollection<Telefone> Telefones { get; set; } // Coleção de Telefone

        //public Telefone Telefone1 { get; set; } = new Telefone();

        //public Telefone Telefone2 { get; set; } = new Telefone();

        //public Telefone Telefone3 { get; set; } = new Telefone();





    }
}
