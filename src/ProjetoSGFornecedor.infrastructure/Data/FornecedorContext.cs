using Microsoft.EntityFrameworkCore;
using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSGFornecedor.infrastructure.Data
{
    public class FornecedorContext : DbContext
    {
        public FornecedorContext(DbContextOptions<FornecedorContext> options) : base(options) //Construdor
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//Responsavel pela configuração do EntityFramework
        {
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedor"); 
        }
    }
}
