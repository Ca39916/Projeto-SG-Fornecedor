using Microsoft.EntityFrameworkCore;
using ProjetoSGFornecedor.infrastructure.Data;
using SGFornecedor.applicationCore.Entity;
using SGFornecedor.applicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProjetoSGFornecedor.infrastructure.Repository
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(FornecedorContext dbContext) : base(dbContext)
        {
 
        }

        public FornecedorFisico AdicionarFisico(FornecedorFisico entity)
        {
            _dbContext.Set<FornecedorFisico>().Add(entity);
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
            return (entity); //entity entidade
        }

        public void AtualizarFisico(FornecedorFisico entity)
        {

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados

        }

        public IEnumerable<FornecedorFisico> BuscarFisico(Expression<Func<FornecedorFisico, bool>> predicado)
        {
            return _dbContext.Set<FornecedorFisico>().Where(predicado).AsEnumerable();
        }

        public object ObterPorId(Guid id)
        {
            var fornecedor = _dbContext.Set<Fornecedor>().Find(id);
            return fornecedor;
        }

        public IEnumerable<FornecedorFisico> ObterTodosFisico()
        {
            return _dbContext.Set<FornecedorFisico>().AsEnumerable();
        }

        public void RemoverFisico(FornecedorFisico entity)
        {
            _dbContext.Set<FornecedorFisico>().Remove(entity);
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }




        public FornecedorJuridico AdicionarJuridico(FornecedorJuridico entity)
        {
            _dbContext.Set<FornecedorJuridico>().Add(entity);
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
            return (entity); //entity entidade
        }

        public void AtualizarJuridico(FornecedorJuridico entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }

        public IEnumerable<FornecedorJuridico> BuscarJuridico(Expression<Func<FornecedorJuridico, bool>> predicado)
        {
            return _dbContext.Set<FornecedorJuridico>().Where(predicado).AsEnumerable();
        }

        public FornecedorJuridico ObterPorIdJuridico(Guid id)
        {
            return _dbContext.Set<FornecedorJuridico>().Find(id);
        }

        public IEnumerable<FornecedorJuridico> ObterTodosJuridico()
        {
            return _dbContext.Set<FornecedorJuridico>().AsEnumerable();
        }

        public void RemoverJuridico(FornecedorJuridico entity)
        {
            _dbContext.Set<FornecedorJuridico>().Remove(entity);
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }

        public List<Telefone> BuscarTelefones(Expression<Func<Telefone, bool>> predicado)
        {
            return _dbContext.Set<Telefone>().Where(predicado).ToList();
        }

        public Endereco BuscarEndereco(Expression<Func<Endereco, bool>> predicado)
        {
            return _dbContext.Set<Endereco>().Where(predicado).FirstOrDefault();
        }

        public Email BuscarEmail(Expression<Func<Email, bool>> predicado)
        {
            return _dbContext.Set<Email>().Where(predicado).FirstOrDefault();
        }

        public void AtualizarTelefones(List<Telefone> lista)
        {
            foreach(Telefone item in lista)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }            

            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            _dbContext.Entry(endereco).State = EntityState.Modified;
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }

        public void AtualizarEmail(Email email)
        {
            _dbContext.Entry(email).State = EntityState.Modified;
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }

        public void RemoverEndereco(Endereco entity)
        {
            _dbContext.Set<Endereco>().Remove(entity);
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }

        public void RemoverEmail(Email entity)
        {
            _dbContext.Set<Email>().Remove(entity);
            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }

        public void RemoverTelefones(List<Telefone> lista)
        {
            foreach (Telefone item in lista)
            {
                _dbContext.Set<Telefone>().Remove(item);
            }

            _dbContext.SaveChanges(); //SaveChanges Metodo para salvar dados
        }
    }
}
