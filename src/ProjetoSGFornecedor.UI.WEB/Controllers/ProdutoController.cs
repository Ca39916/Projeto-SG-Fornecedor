using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoSGFornecedor.UI.WEB.ViewModels;
using SGFornecedor.applicationCore.Entity;
using SGFornecedor.applicationCore.Interfaces.Services;
using System.Collections.Generic;
using System;

namespace ProjetoSGFornecedor.UI.WEB.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produto;//Criando a variavel _Produto
        private readonly ICategoriaService _categoria;//Criando a variavel _Categoria
        private readonly IMapper _mapper; //Criando a variavel _mapper 

        public ProdutoController(IProdutoService produtoServices, IMapper mapper, ICategoriaService categoria)//CONSTRUTOR
        {
            _produto = produtoServices;  //Contrutor Carrega a variavel com todos os metodos do produto
            _mapper = mapper; //Contrutor Carrega a variavel com as configurações do AutoMapper
            _categoria = categoria; //Contrutor Carrega a variavel com as configurações da Categoria
        }
        public IActionResult Index() //Index é uma tela Principal
        {
            var listaProdutos = _produto.obterTodos();//Cria lista com todos os forncedores cadastrados no BD
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(listaProdutos));//Vai abrir a tela index com a lista de fornecedores
        }

        [HttpPost]
        public IActionResult NovoProduto(ProdutoViewModel viewModel)//Metodo de cadastro do novo fornecedor
        {
            if (!ModelState.IsValid) //Valida os dados preenchidos de acordo com as regras da classe caso tenha
                return View(viewModel);//permanece com os dados preenchidos pelo usuario

            viewModel.InsertDate = DateTime.Now;//Preenche automatico data e hora 
            viewModel.UpdateDate = DateTime.Now;//Preenche automatico data e hora 

            var model = _mapper.Map<Produto>(viewModel); //mapper é um conversor 

            _produto.Adicionar(model);//chama o serviço que grava no BD            

            return RedirectToAction("Index");//Se o cadastro for valido ele abre a tela Index
        }

        public IActionResult NovoProduto()
        {
            ProdutoViewModel model = new ProdutoViewModel();

            var categorias = _categoria.obterTodos();

            ViewBag.ListaCategorias = categorias;

            return View(model);

        }

        public IActionResult ConfirmarExcluir(ProdutoViewModel viewModel)//Metodo de ConfirmarExcluir
        {

            var Produto = _produto.ObterPorId(viewModel.IdProduto);//chama o serviço que grava no BD

            var model = _mapper.Map<ProdutoViewModel>(Produto); //mapper é um conversor 

            return View(model);//Se o cadastro for valido ele abre a tela ConfirmarExcluir
        }

        [HttpPost]
        public IActionResult Excluir(ProdutoViewModel viewModel)//Metodo de ConfirmarExcluir
        {
            var model = _mapper.Map<Produto>(viewModel); //mapper é um conversor 

            _produto.Remover(model);//chama o serviço que grava no BD           

            return RedirectToAction("Index");//Redireciona pra tela Index
        }


        public IActionResult EditarProduto(ProdutoViewModel viewModel)//Metodo de Editar
        {
            var Produto = _produto.ObterPorId(viewModel.IdProduto);//chama o serviço que grava no BD

            var model = _mapper.Map<ProdutoViewModel>(Produto); //mapper é um conversor 

            return View(model);//Se o cadastro for valido ele abre a tela Index
        }

        [HttpPost]
        public IActionResult Editar(ProdutoViewModel viewModel)//Metodo de Editar
        {
            var model = _mapper.Map<Produto>(viewModel); //mapper é um conversor 

            _produto.Atualizar(model);//chama o serviço que grava no BD           

            return RedirectToAction("Index");//Volta pra tela Index
        }

        public IActionResult Detalhes(ProdutoViewModel viewModel)//Metodo de Editar
        {
            var Produto = _produto.ObterPorId(viewModel.IdProduto);//Busca os dados do Produto por Id

            var model = _mapper.Map<ProdutoViewModel>(Produto); //mapper é um conversor 

            return View(model);//ele abre a tela de Detalhes do Produto
        }

        
    }
}
