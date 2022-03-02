using Microsoft.EntityFrameworkCore;
using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using ProjetoSGFornecedor.infrastructure;
using ProjetoSGFornecedor.infrastructure.EntityConfig;

namespace ProjetoSGFornecedor.infrastructure.Data
{
    public class FornecedorContext : DbContext
    {

        public FornecedorContext(DbContextOptions<FornecedorContext> options) : base(options) //Construdor
        {

        }
        // Vinculo da classe com a tabela do BD
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<FornecedorFisico> FornecedoresFisicos { get; set; }
        public DbSet<FornecedorJuridico> FornecedoresJuridico { get; set; }
        public DbSet<Telefone>  Telefones { get; set; }
        public DbSet<Email> emails  { get; set; }
        public DbSet<Endereco> enderecos { get; set;}
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Categoria> categorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)//Responsavel pela configuração do EntityFramework
        {
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedor");
            //modelBuilder.Entity<FornecedorFisico>().ToTable("FornecedorFisico");
            //modelBuilder.Entity<FornecedorJuridico>().ToTable("FornecedorJuridico");
            modelBuilder.Entity<Telefone>().ToTable("Telefone");
            modelBuilder.Entity<Email>().ToTable("Email");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new TelefoneMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());



        }
    }
}
