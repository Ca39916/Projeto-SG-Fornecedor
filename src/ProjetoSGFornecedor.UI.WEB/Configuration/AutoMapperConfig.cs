using AutoMapper;
using ProjetoSGFornecedor.UI.WEB.ViewModels;
using SGFornecedor.applicationCore.Entity;

namespace ProjetoSGFornecedor.UI.WEB.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<FornecedorViewModel, Fornecedor>().ReverseMap();
            CreateMap<FornecedorViewModel, FornecedorFisico>().ReverseMap();
            CreateMap<FornecedorViewModel, FornecedorJuridico>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
            CreateMap<CategoriaViewModel, Categoria>().ReverseMap();
        }
    }
}
