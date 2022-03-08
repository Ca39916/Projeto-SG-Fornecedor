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
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoria;//Criando a variavel _Categoria
        private readonly IMapper _mapper; //Criando a variavel _mapper 

        public CategoriaController(ICategoriaService categoriaServices, IMapper mapper)//CONSTRUTOR
        {
            _categoria = categoriaServices;  //Contrutor Carrega a variavel com todos os metodos do produto
            _mapper = mapper; //Contrutor Carrega a variavel com as configurações do AutoMapper

        }
        public IActionResult Index() //Index é uma tela Principal
        {
            var listaCategoria = _categoria.obterTodos();//Cria lista com todos os forncedores cadastrados no BD

            var model = _mapper.Map<IEnumerable<CategoriaViewModel>>(listaCategoria);

            return View(model);//Vai abrir a tela index com a lista de fornecedores
        }

        [Authorize]
        [HttpPost]
        public IActionResult NovaCategoria(CategoriaViewModel viewModel)//Metodo de cadastro do novo fornecedor
        {
            if (!ModelState.IsValid) //Valida os dados preenchidos de acordo com as regras da classe caso tenha
                return View(viewModel);//permanece com os dados preenchidos pelo usuario

            //Categoria novaCategoria = new Categoria();
            //novaCategoria.Nome = viewModel.Nome;
            //novaCategoria.Active = viewModel.Active;
            //novaCategoria.InsertDate = DateTime.Now;//Preenche automatico data e hora 
            //novaCategoria.UpdateDate = DateTime.Now;//Preenche automatico data e hora 

            viewModel.InsertDate = DateTime.Now;//Preenche automatico data e hora 
            viewModel.UpdateDate = DateTime.Now;//Preenche automatico data e hora 

            var model = _mapper.Map<Categoria>(viewModel); //mapper é um conversor 

            _categoria.Adicionar(model);//chama o serviço que grava no BD

            return RedirectToAction("Index");//Se o cadastro for valido ele abre a tela Index
        }

        [Authorize]
        public IActionResult NovaCategoria()
        {
            return View();

        }

        [Authorize]
        public IActionResult ConfirmarExcluir(CategoriaViewModel viewModel)//Metodo de ConfirmarExcluir
        {

            var Categoria = _categoria.ObterPorId(viewModel.IdCategoria);//chama o serviço que grava no BD

            var model = _mapper.Map<CategoriaViewModel>(Categoria); //mapper é um conversor 

            return View(model);//Se o cadastro for valido ele abre a tela ConfirmarExcluir
        }

        [Authorize]
        [HttpPost]
        public IActionResult Excluir(CategoriaViewModel viewModel)//Metodo de ConfirmarExcluir
        {
            var model = _mapper.Map<Categoria>(viewModel); //mapper é um conversor 

            _categoria.Remover(model);//chama o serviço que grava no BD           

            return RedirectToAction("Index");//Redireciona pra tela Index
        }


        [Authorize]
        public IActionResult EditarCategoria(CategoriaViewModel viewModel)//Metodo de Editar
        {
            var Categoria = _categoria.ObterPorId(viewModel.IdCategoria);//chama o serviço que grava no BD

            var model = _mapper.Map<CategoriaViewModel>(Categoria); //mapper é um conversor 

            return View(model);//Se o cadastro for valido ele abre a tela Index
        }

        [Authorize]
        [HttpPost]
        public IActionResult Editar(CategoriaViewModel viewModel)//Metodo de Editar
        {
            var Categoria = _categoria.ObterPorId(viewModel.IdCategoria); //Busca a Categoria pelo ID

            Categoria.UpdateDate = DateTime.Now; //Atualiza a data e hora 
            Categoria.Nome = viewModel.Nome; // Atualiza o Nome da Categoria com o que o usuário digitou na tela
            Categoria.Active = viewModel.Active; // Atualiza o Active com o que o usuário digitou na tela

            //var model = _mapper.Map<Categoria>(Categoria); //Converte a variável no formato da Entidade Categoria

            _categoria.Atualizar(Categoria);// Grava as alterações no Banco de Dados          

            return RedirectToAction("Index");//Volta pra tela Index
        }


        public IActionResult Detalhes(CategoriaViewModel viewModel)//Metodo de Editar
        {
            var Categoria = _categoria.ObterPorId(viewModel.IdCategoria);//Busca os dados do Produto por Id

            var model = _mapper.Map<CategoriaViewModel>(Categoria); //mapper é um conversor 

            return View(model);//ele abre a tela de Detalhes do Produto
        }
    }
}
