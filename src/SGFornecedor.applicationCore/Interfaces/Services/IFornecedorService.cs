using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGFornecedor.applicationCore.Interfaces.Services
{
    public interface IFornecedorService : IService<Fornecedor>
    {
        Fornecedor Adicionar(Fornecedor entity);
        void Atualizar(Fornecedor entity);
        IEnumerable<Fornecedor> ObterTodos();
        //Fornecedor ObterPorId(Guid id);
        IEnumerable<Fornecedor> Buscar(Expression<Func<Fornecedor, bool>> predicado);
        void Remover(Fornecedor entity);


        FornecedorFisico AdicionarFisico(FornecedorFisico entity);
        void AtualizarFisico(FornecedorFisico entity);
        //FornecedorFisico ObterPorIdFisico(Guid id);
        object ObterPorId(Guid id);

        IEnumerable<FornecedorFisico> ObterTodosFisico();        
        IEnumerable<FornecedorFisico> BuscarFisico(Expression<Func<FornecedorFisico, bool>> predicado);
        void RemoverFisico(FornecedorFisico entity);


        FornecedorJuridico AdicionarJuridico(FornecedorJuridico entity);
        void AtualizarJuridico(FornecedorJuridico entity);
        IEnumerable<FornecedorJuridico> BuscarJuridico(Expression<Func<FornecedorJuridico, bool>> predicado);
        IEnumerable<FornecedorJuridico> ObterTodosJuridico();
        FornecedorJuridico ObterPorIdJuridico(Guid id);
        
        void RemoverJuridico(FornecedorJuridico entity);

        List<Telefone> BuscarTelefones(Expression<Func<Telefone, bool>> predicado);

        Endereco BuscarEndereco(Expression<Func<Endereco, bool>> predicado);
        Email BuscarEmail(Expression<Func<Email, bool>> predicado);

        void AtualizarTelefones(List<Telefone> lista);
        void AtualizarEndereco(Endereco endereco);
        void AtualizarEmail(Email email);

        void RemoverEndereco(Endereco entity);
        void RemoverEmail(Email entity);
        void RemoverTelefones(List<Telefone> lista);
    }
}
