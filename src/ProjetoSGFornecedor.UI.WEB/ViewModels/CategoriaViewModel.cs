using System;
using System.Collections.Generic;
using SGFornecedor.applicationCore.Entity;

namespace ProjetoSGFornecedor.UI.WEB.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid IdCategoria { get; set; }
        public bool Active { get; set; }
        public string Nome { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public List<Produto> Produto { get; set; } = new List<Produto>();

    }
}
