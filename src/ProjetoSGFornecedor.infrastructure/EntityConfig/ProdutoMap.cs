using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSGFornecedor.infrastructure.EntityConfig
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder) //Configuração de Fornecedor
        {


            builder.HasKey(c => c.IdProduto); //Chave Primaria

            //Relacionamento com a tabela Imagem
                builder
                .HasMany(c => c.Imagens) //Hasmany: tem muitos contatos
                .WithOne(c => c.Produto) // WithOn: A imagem tem apenas um produto
                .HasForeignKey(c => c.IdProduto) //HasForeignKey: Chave Estrangeira
                .HasPrincipalKey(c => c.IdProduto); //HasPricipalKey: Chave Principal

            //builder
            //.HasOne(x => x.Categoria) //Associação de 1/1 Fornecedor tem 1 Endereco e Endereco tem 1 Fornecedor
            //.WithOne(x => x.Produto)
            //.HasForeignKey<Categoria>(x => x.IdProduto) //Chave Estrangeira
            //.OnDelete(DeleteBehavior.Restrict); //Não permitir delegação em cascata


        }
    }
}
