using SGFornecedor.applicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGFornecedor.applicationCore.Interfaces.Repository
{
    //A class IFornecedorRepository existe para adicionar algo específico,porem ela erda tudo da classe  IRepository

    public interface IFornecedorRepository : IRepository<Fornecedor>
    {

        //FORNECEDOR FISICO

        FornecedorFisico AdicionarFisico(FornecedorFisico entity);

        void AtualizarFisico(FornecedorFisico entity);

        IEnumerable<FornecedorFisico> BuscarFisico(Expression<Func<FornecedorFisico, bool>> predicado);

        //FornecedorFisico ObterPorIdFisico(Guid id);

        IEnumerable<FornecedorFisico> ObterTodosFisico();
        object ObterPorId(Guid id);

        void RemoverFisico(FornecedorFisico entity);


        //FORNECEDOR jURIDICO
        FornecedorJuridico AdicionarJuridico(FornecedorJuridico entity);

        void AtualizarJuridico(FornecedorJuridico entity);

        IEnumerable<FornecedorJuridico> BuscarJuridico(Expression<Func<FornecedorJuridico, bool>> predicado);

        FornecedorJuridico ObterPorIdJuridico(Guid id);

        IEnumerable<FornecedorJuridico> ObterTodosJuridico();

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
