using System;
using System.Collections.Generic;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class Menu
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? MenuId { get; set; } //Chave Estrangeira

        public ICollection<Menu> SubMenu { get; set; } // Coleção de Telefone
    }
}
