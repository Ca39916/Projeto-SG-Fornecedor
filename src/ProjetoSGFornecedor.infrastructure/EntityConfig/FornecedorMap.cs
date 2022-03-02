using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSGFornecedor.infrastructure.EntityConfig
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder) //Configuração de Fornecedor
        {


            builder.HasKey(c => c.FornecedorId); //Chave Primaria

            //Relacionamento com o tabela Telefones
                builder
                .HasMany(c => c.Telefones) //Hasmany: tem muitos contatos
                .WithOne(c => c.Fornecedor) // WithOn: O telefone tem apenas um forncedor 
                .HasForeignKey(c => c.FornecedorId) //HasForeignKey: Chave Estrangeira
                .HasPrincipalKey(c => c.FornecedorId)
                .OnDelete(DeleteBehavior.Cascade); //HasPricipalKey: Chave Principal

            builder.HasOne(x => x.Endereco) //Associação de 1/1 Fornecedor tem 1 Endereco e Endereco tem 1 Fornecedor
                .WithOne(x => x.Fornecedor)
                .HasForeignKey<Endereco>(x => x.FornecedorId) //Chave Estrangeira
                .OnDelete(DeleteBehavior.Cascade); //Não permitir delegação em cascata

            builder.HasOne(y => y.Email) //Associação de 1/1 Fornecedor tem 1 Endereco e Endereco tem 1 Fornecedor
                .WithOne(y => y.Fornecedor)
                .HasForeignKey<Email>(y => y.FornecedorId) //Chave Estrangeira
                .OnDelete(DeleteBehavior.Cascade); //Não permitir delegação em cascata

        }
    }
}
