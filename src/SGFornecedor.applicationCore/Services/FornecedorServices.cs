using SGFornecedor.applicationCore.Entity;
using SGFornecedor.applicationCore.Interfaces.Repository;
using SGFornecedor.applicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGFornecedor.applicationCore.Services
{
    public class FornecedorServices : Service<Fornecedor>, IFornecedorService
    {
        protected readonly IFornecedorRepository _fornecedorService;

        public FornecedorServices(IFornecedorRepository fornecedorService) : base(fornecedorService)//Método construtor
        {
            _fornecedorService = fornecedorService;
        }

        public Fornecedor Adicionar(Fornecedor entity)
        {
            //Regra de negocio 
            return _fornecedorService.Adicionar(entity);
        }

        public void Atualizar(Fornecedor entity)
        {
            _fornecedorService.Atualizar(entity);
        }

        public IEnumerable<Fornecedor> Buscar(Expression<Func<Fornecedor, bool>> predicado)
        {
            return _fornecedorService.Buscar(predicado);
        }

        //public Fornecedor ObterPorId(Guid id)
        //{
        //    return _fornecedorService.ObterPorId(id);
        //}

        public IEnumerable<Fornecedor> ObterTodos()
        {
            return _fornecedorService.obterTodos();
        }

        public void Remover(Fornecedor entity)
        {
            _fornecedorService.Remover(entity);
        }


        //FORNECEDOR FISICO

        public FornecedorFisico AdicionarFisico(FornecedorFisico entity)
        {
            //Regra de negocio 
            return _fornecedorService.AdicionarFisico(entity);
        }

        public void AtualizarFisico(FornecedorFisico entity)
        {
            _fornecedorService.AtualizarFisico(entity);
        }

        public IEnumerable<FornecedorFisico> BuscarFisico(Expression<Func<FornecedorFisico, bool>> predicado)
        {
            return _fornecedorService.BuscarFisico(predicado);
        }

        //public FornecedorFisico ObterPorIdFisico(Guid id)
        //{
        //    return _fornecedorService.ObterPorIdFisico(id);
        //}

        public object ObterPorId(Guid id)
        {
            return _fornecedorService.ObterPorId(id);
        }

        public IEnumerable<FornecedorFisico> ObterTodosFisico()
        {
            return (IEnumerable<FornecedorFisico>) _fornecedorService.ObterTodosFisico();
        }

        public void RemoverFisico(FornecedorFisico entity)
        {
            _fornecedorService.RemoverFisico(entity);
        }


        //FORNECEDOR JURIDICO
        public FornecedorJuridico AdicionarJuridico(FornecedorJuridico entity)
        {

            return _fornecedorService.AdicionarJuridico(entity);
        }

        public void AtualizarJuridico(FornecedorJuridico entity)
        {
            _fornecedorService.AtualizarJuridico(entity);
        }

        public IEnumerable<FornecedorJuridico> BuscarJuridico(Expression<Func<FornecedorJuridico, bool>> predicado)
        {
            return _fornecedorService.BuscarJuridico(predicado);
        }

        public FornecedorJuridico ObterPorIdJuridico(Guid id)
        {
            return _fornecedorService.ObterPorIdJuridico(id);
        }        

        public IEnumerable<FornecedorJuridico> ObterTodosJuridico()
        {
            return (IEnumerable<FornecedorJuridico>)_fornecedorService.ObterTodosJuridico();
        }

        public void RemoverJuridico(FornecedorJuridico entity)
        {
            _fornecedorService.RemoverJuridico(entity);
        }

        public List<Telefone> BuscarTelefones(Expression<Func<Telefone, bool>> predicado)
        {
            return _fornecedorService.BuscarTelefones(predicado);
        }

        public Endereco BuscarEndereco(Expression<Func<Endereco, bool>> predicado)
        {
            return _fornecedorService.BuscarEndereco(predicado);
        }
        public Email BuscarEmail(Expression<Func<Email, bool>> predicado)
        {
            return _fornecedorService.BuscarEmail(predicado);
        }

        public void AtualizarTelefones(List<Telefone> lista)
        {
            _fornecedorService.AtualizarTelefones(lista);
        }
        public void AtualizarEndereco(Endereco endereco)
        {
            _fornecedorService.AtualizarEndereco(endereco);
        }
        public void AtualizarEmail(Email email)
        {
            _fornecedorService.AtualizarEmail(email);
        }


        public void RemoverEndereco(Endereco entity)
        {
            _fornecedorService.RemoverEndereco(entity);
        }
        public void RemoverEmail(Email entity)
        {
            _fornecedorService.RemoverEmail(entity);
        }
        public void RemoverTelefones(List<Telefone> lista)
        {
            _fornecedorService.RemoverTelefones(lista);
        }
    }
}

