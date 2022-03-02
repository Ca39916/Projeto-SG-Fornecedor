using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSGFornecedor.infrastructure.EntityConfig
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder) //Configuração de Fornecedor
        {


            //builder.HasKey(c => c.IdCategoria); //Chave Primaria

            ////Relacionamento com a tabela Imagem
            //    builder
            //    .HasMany(c => c.Produto) //Hasmany: tem muitos contatos
            //    .WithOne(c => c.Categoria) // WithOn: A imagem tem apenas um produto
            //    .HasForeignKey(c => c.IdProduto) //HasForeignKey: Chave Estrangeira
            //    .HasPrincipalKey(c => c.IdCategoria); //HasPricipalKey: Chave Principal




        }
    }
}
