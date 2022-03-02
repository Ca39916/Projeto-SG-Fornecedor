using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSGFornecedor.infrastructure.EntityConfig
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            //builder
            //   .HasOne(c => c.Fornecedor) // HasOne:Telefone tem apenas um Fornecedor
            //   .WithMany(c => c.Telefones) // WithMany: Fornecedor tem muitos Telefones
            //   .HasForeignKey(c => c.FornecedorId) //HasForeignKey: Chave Estrangeira
            //   .HasPrincipalKey(c => c.FornecedorId) //HasPricipalKey: Chave Principal
            //   .OnDelete(DeleteBehavior.Restrict); //Não permitir delegação em cascata
        }
    }
}
