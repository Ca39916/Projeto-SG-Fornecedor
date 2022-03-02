using System;
using System.Collections.Generic;
using SGFornecedor.applicationCore.Entity;

namespace ProjetoSGFornecedor.UI.WEB.ViewModels
{
    public class FornecedorViewModel
    {
        public Guid FornecedorId { get; set; }
        public bool Active { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        //Físico
        public string NomeCompleto { get; set; }
        public string NomeFantasia { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        //Jurídico
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataAbertura { get; set; }

        public Endereco Endereco { get; set; } = new Endereco();

        public List<Telefone> Telefones { get; set; } = new List<Telefone>();// Coleção de Telefone

        public Email Email { get; set; } = new Email();
    }
}
