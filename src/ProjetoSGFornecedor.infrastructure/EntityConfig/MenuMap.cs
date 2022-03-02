using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSGFornecedor.infrastructure.EntityConfig
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder
                .HasMany(x => x.SubMenu) //Hasmany: tem muitos SubMenu
                .WithOne() // WithOn: O telefone tem apenas um Menu
                .HasForeignKey(x => x.MenuId);//HasForeignKey: Chave Estrangeira
        }
    }
}
