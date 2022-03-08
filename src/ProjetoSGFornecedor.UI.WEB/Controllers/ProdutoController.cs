using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoSGFornecedor.UI.WEB.ViewModels;
using SGFornecedor.applicationCore.Entity;
using SGFornecedor.applicationCore.Interfaces.Services;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoSGFornecedor.UI.WEB.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produto;//Criando a variavel _Produto
        private readonly ICategoriaService _categoria;//Criando a variavel _Categoria
        private readonly IFornecedorService _fornecedor;//Criando a variavel _fornecedor
        private readonly IMapper _mapper; //Criando a variavel _mapper 

        public ProdutoController(IProdutoService produtoServices, IMapper mapper, ICategoriaService categoria, IFornecedorService fornecedor)//CONSTRUTOR
        {
            _produto = produtoServices;  //Contrutor Carrega a variavel com todos os metodos do produto
            _mapper = mapper; //Contrutor Carrega a variavel com as configurações do AutoMapper
            _categoria = categoria; //Contrutor Carrega a variavel com as configurações da Categoria
            _fornecedor = fornecedor; //Contrutor Carrega a variavel com as configurações do Fornecedor
        }
        public IActionResult Index() //Index é uma tela Principal
        {
            var listaProdutos = _produto.obterTodos();//Cria lista com todos os forncedores cadastrados no BD
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(listaProdutos));//Vai abrir a tela index com a lista de fornecedores
        }

        [Authorize]
        [HttpPost]
        public IActionResult NovoProduto(ProdutoViewModel viewModel)//Metodo de cadastro do novo fornecedor
        {
            if (!ModelState.IsValid) //Valida os dados preenchidos de acordo com as regras da classe caso tenha
                return View(viewModel);//permanece com os dados preenchidos pelo usuario

            viewModel.InsertDate = DateTime.Now;//Preenche automatico data e hora 
            viewModel.UpdateDate = DateTime.Now;//Preenche automatico data e hora 

            var model = _mapper.Map<Produto>(viewModel); //mapper é um conversor 

            model.Imagens.Add(new Imagem
            {
                CaminhoDaImagem = viewModel.Imagem,
                InsertDate = DateTime.Now,//Preenche automatico data e hora 
                UpdateDate = DateTime.Now//Preenche automatico data e hora 

            });

            _produto.Adicionar(model);//chama o serviço que grava no BD            

            return RedirectToAction("Index");//Se o cadastro for valido ele abre a tela Index
        }

        [Authorize]
        public IActionResult NovoProduto()
        {
            ProdutoViewModel model = new ProdutoViewModel();

            var categorias = _categoria.obterTodos();

            var fornecedores = _fornecedor.obterTodos();

            ViewBag.ListaCategorias = categorias;

            ViewBag.ListaFornecedores = fornecedores;

            return View(model);

        }

        [Authorize]
        public IActionResult ConfirmarExcluir(ProdutoViewModel viewModel)//Metodo de ConfirmarExcluir
        {

            var Produto = _produto.ObterPorId(viewModel.IdProduto);//chama o serviço que grava no BD

            var model = _mapper.Map<ProdutoViewModel>(Produto); //mapper é um conversor 

            return View(model);//Se o cadastro for valido ele abre a tela ConfirmarExcluir
        }

        [Authorize]
        [HttpPost]
        public IActionResult Excluir(ProdutoViewModel viewModel)//Metodo de ConfirmarExcluir
        {
            var model = _mapper.Map<Produto>(viewModel); //mapper é um conversor 

            _produto.Remover(model);//chama o serviço que grava no BD           

            return RedirectToAction("Index");//Redireciona pra tela Index
        }

        [Authorize]
        public IActionResult EditarProduto(ProdutoViewModel viewModel)//Metodo de Editar
        {
            var Produto = _produto.ObterPorId(viewModel.IdProduto);//chama o serviço que grava no BD

            Produto.Imagens = _produto.BuscarImagens(x => x.IdProduto == viewModel.IdProduto);//Busca lista de Imagens pelo ID do Produto

            var model = _mapper.Map<ProdutoViewModel>(Produto); //mapper é um conversor 

            model.Imagem = Produto.Imagens[0].CaminhoDaImagem;

            var categorias = _categoria.obterTodos();

            var fornecedores = _fornecedor.obterTodos();

            ViewBag.ListaCategorias = categorias;

            ViewBag.ListaFornecedores = fornecedores;

            return View(model);//Se o cadastro for valido ele abre a tela Index
        }

        [Authorize]
        [HttpPost]
        public IActionResult Editar(ProdutoViewModel viewModel)//Metodo de Editar
        {
            var model = _mapper.Map<Produto>(viewModel); //mapper é um conversor 

            model.Imagens = _produto.BuscarImagens(x => x.IdProduto == viewModel.IdProduto);//Busca lista de Imagens pelo ID do Produto

            model.Imagens[0].UpdateDate = DateTime.Now;
            model.Imagens[0].CaminhoDaImagem = viewModel.Imagem;

            _produto.Atualizar(model);//chama o serviço que grava no BD           

            return RedirectToAction("Index");//Volta pra tela Index
        }

        
        public IActionResult Detalhes(ProdutoViewModel viewModel)//Metodo de Editar
        {
            var Produto = _produto.ObterPorId(viewModel.IdProduto);//Busca os dados do Produto por Id

            var model = _mapper.Map<ProdutoViewModel>(Produto); //mapper é um conversor 

            var categorias = _categoria.obterTodos();

            var fornecedores = _fornecedor.obterTodos();

            ViewBag.ListaCategorias = categorias;

            ViewBag.ListaFornecedores = fornecedores;

            model.Imagens = _produto.BuscarImagens(x => x.IdProduto == viewModel.IdProduto);//Busca Endereço pelo ID do Fornecedor

            return View(model);//ele abre a tela de Detalhes do Produto
        }

        
    }
}
