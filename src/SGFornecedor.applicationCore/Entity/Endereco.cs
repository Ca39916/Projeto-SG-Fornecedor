using System;
using System.Collections.Generic;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class Endereco
    {
        public Guid EnderecoId { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Fornecedor Fornecedor { get; set; }
        public Guid FornecedorId { get; set; } //Chave Estrangeira

        public Endereco()
        {

        }




    }
}
