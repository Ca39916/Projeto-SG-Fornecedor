using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSGFornecedor.UI.WEB.ViewModels;
using SGFornecedor.applicationCore.Entity;
using SGFornecedor.applicationCore.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using ClosedXML.Excel;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using SGFornecedor.applicationCore.Services;
using X.PagedList;

namespace ProjetoSGFornecedor.UI.WEB.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _Fornecedor;//Criando a variavel _Fornecedor
        private readonly IMapper _mapper; //Criando a variavel _mapper 

        public FornecedorController(IFornecedorService fornecedorServices, IMapper mapper)//CONSTRUTOR
        {
            _Fornecedor = fornecedorServices;  //Contrutor Carrega a variavel com todos os metodos do fornecedor
            _mapper = mapper; //Contrutor Carrega a variavel com as configurações do AutoMapper
        }

        //public  IActionResult Index(int pageSize = 10, int pageIndex = 1, string query = null)
        //Index é uma tela Principal

        //var result = _Paginacao.(pageSize, pageIndex, query);
        //TempData["Size"] = pageSize;
        //TempData["Query"] = query;

        //return View(await _Fornecedor.ObterTodos().ToPagedListAsync(numeroPagina, itensPorPagina));

       
        public IActionResult Index(string query = null/*int? pagina*/)
        {
            
            if (query!= null)
            {
                var pesquisa = _Fornecedor.Buscar(x => x.Email.email == query);
                var model = _mapper.Map<IEnumerable<FornecedorViewModel>>(pesquisa);
                return View(model);
            }
            else
            {
                var listaFornecedoresFisico = _Fornecedor.ObterTodosFisico();//Cria lista com todos os forncedores cadastrados no BD
                var listaFornecedoresJuridico = _Fornecedor.ObterTodosJuridico();//Cria lista com todos os forncedores cadastrados no BD
                var modelF = _mapper.Map<IEnumerable<FornecedorViewModel>>(listaFornecedoresFisico);
                var modelJ = _mapper.Map<IEnumerable<FornecedorViewModel>>(listaFornecedoresJuridico);
                var model = modelF.Concat(modelJ);
                return View(model);
            }
            //Variaveis para controle da paginação
            //const int itensPorPagina = 5;
            //int numeroPagina = (pagina ?? 1);
           
            //return View(model.ToPagedListAsync(numeroPagina, itensPorPagina));//Vai abrir a tela index com a lista de fornecedores
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult NovoFornecedorFisico(FornecedorViewModel viewModel)//Metodo de cadastro do novo fornecedor
        {
            if (!ModelState.IsValid) //Valida os dados preenchidos de acordo com as regras da classe caso tenha
                return View(viewModel);//permanece com os dados preenchidos pelo usuario

            viewModel.InsertDate = DateTime.Now;//Preenche automatico data e hora 
            viewModel.UpdateDate = DateTime.Now;//Preenche automatico data e hora 

            var model = _mapper.Map<FornecedorFisico>(viewModel); //mapper é um conversor 

            FornecedorFisico validacao = new FornecedorFisico();//criando um objeto do tipo FornecedorFisico 

            var Erros = validacao.ValidaFornecedor(model);// armazena na variavel erros o retorno da validaçao caso o usuario tenha digitado dados invalidos 

            if (Erros.Any())//Se tiver dados invalidos entra nesse if 
            {
                foreach(var erro in Erros)//Armazena no ModelState todos os erros de validaçao para depois exibir na tela.
                {
                    ModelState.AddModelError(erro.Key,erro.Value);
                }
                return View(viewModel);//exibe msg de erro na tela 
            }

            var fornecedor = _Fornecedor.AdicionarFisico(model);//chama o serviço que grava no BD (já grava automaticamente o Endereço, o Email e os Telefones nas suas respectivas tabelas)

            return RedirectToAction("Index");//Se o cadastro for valido ele abre a tela Index

        }

        [Authorize]
        public IActionResult NovoFornecedorFisico()
        {
            FornecedorViewModel model = new FornecedorViewModel();

            // Cria lista de 3 telefones em branco para o usuário preencher na tela
            model.Telefones.Add(new Telefone());
            model.Telefones.Add(new Telefone());
            model.Telefones.Add(new Telefone());

            return View(model);
        }

        [Authorize]
        public IActionResult ConfirmarExcluirFisico(FornecedorViewModel viewModel)//Metodo de ConfirmarExcluir
        {       
                       
            var Fornecedor = _Fornecedor.ObterPorId(viewModel.FornecedorId);//chama o serviço que grava no BD

            var model = _mapper.Map<FornecedorViewModel>(Fornecedor); //mapper é um conversor 

            if (string.IsNullOrEmpty(model.Cpf))//Verifica se o fornecedor é fisico ou juridico nos Botao edit,detalhe e excluir
                return RedirectToAction("ConfirmarExcluirJuridico", viewModel);

            return View(model);//Se o cadastro for valido ele abre a tela ConfirmarExcluir
        }

        [Authorize]
        [HttpPost]
        public IActionResult ExcluirFisico(FornecedorViewModel viewModel)//Metodo de ConfirmarExcluir
        {
            var model = _mapper.Map<FornecedorFisico>(_Fornecedor.ObterPorId(viewModel.FornecedorId)); //mapper é um conversor 

            model.Telefones = _Fornecedor.BuscarTelefones(x => x.FornecedorId == viewModel.FornecedorId);//Busca lista de Telefones pelo ID do Fornecedor

            model.Endereco = _Fornecedor.BuscarEndereco(x => x.FornecedorId == viewModel.FornecedorId);//Busca Endereço pelo ID do Fornecedor

            model.Email = _Fornecedor.BuscarEmail(x => x.FornecedorId == viewModel.FornecedorId);//Busca Email pelo ID do Fornecedor

            //Exclui o Fornecedor
            _Fornecedor.RemoverFisico(model);//chama o serviço que grava no BD
                                             
            //Exclui os Telefones
            _Fornecedor.RemoverTelefones(model.Telefones.ToList());

            return RedirectToAction("Index");//Redireciona pra tela Index
        }

        [Authorize]
        public IActionResult EditarFornecedorFisico(FornecedorViewModel viewModel)//Metodo de Editar
        {
            var Fornecedor = _Fornecedor.ObterPorId(viewModel.FornecedorId);//chama o serviço que grava no BD

            var model = _mapper.Map<FornecedorViewModel>(Fornecedor); //mapper é um conversor
                                                                      //
            if (string.IsNullOrEmpty(model.Cpf))//Verifica se o fornecedor é fisico ou juridico nos Botao edit,detalhe e excluir
                return RedirectToAction("EditarFornecedorJuridico", viewModel);

            model.Telefones = _Fornecedor.BuscarTelefones(x => x.FornecedorId == viewModel.FornecedorId);//Busca lista de Telefones pelo ID do Fornecedor

            model.Endereco = _Fornecedor.BuscarEndereco(x => x.FornecedorId == viewModel.FornecedorId);//Busca Endereço pelo ID do Fornecedor

            model.Email = _Fornecedor.BuscarEmail(x => x.FornecedorId == viewModel.FornecedorId);//Busca Email pelo ID do Fornecedor

            return View(model);//Se o cadastro for valido ele abre a tela Index
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditarFisico(FornecedorViewModel viewModel)//Metodo de Editar
        {
            var model = _mapper.Map<FornecedorFisico>(viewModel); //mapper é um conversor

            _Fornecedor.AtualizarFisico(model); // Atualiza dados do Fornecedor


            FornecedorFisico validacao = new FornecedorFisico();//criando um objeto do tipo FornecedorFisico 

            var Erros = validacao.ValidaFornecedor(model);// armazena na variavel erros o retorno da validaçao caso o usuario tenha digitado dados invalidos 

            if (Erros.Any())//Se tiver dados invalidos entra nesse if 
            {
                foreach (var erro in Erros)//Armazena no ModelState todos os erros de validaçao para depois exibir na tela.
                {
                    ModelState.AddModelError(erro.Key, erro.Value);
                }
                return View(viewModel);//exibe msg de erro na tela 
            } 

            _Fornecedor.AtualizarEndereco(model.Endereco); // Atualiza dados do Endereco
            _Fornecedor.AtualizarEmail(model.Email); // Atualiza dados do Email
            _Fornecedor.AtualizarTelefones(model.Telefones.ToList()); // Atualiza dados dos Telefones   

            return RedirectToAction("Index");//Volta pra tela Index
        }


        public IActionResult DetalhesFisico(FornecedorViewModel viewModel)//Metodo de Editar
        {
            var Fornecedor = _Fornecedor.ObterPorId(viewModel.FornecedorId);//Busca os dados do fornecedor por Id

            var model = _mapper.Map<FornecedorViewModel>(Fornecedor); //mapper é um conversor 

            if (string.IsNullOrEmpty(model.Cpf))//Verifica se o fornecedor é fisico ou juridico nos Botao edit,detalhe e excluir
                return RedirectToAction("DetalhesJuridico", viewModel);

            model.Telefones = _Fornecedor.BuscarTelefones(x => x.FornecedorId == viewModel.FornecedorId);//Busca lista de Telefones pelo ID do Fornecedor

            model.Endereco = _Fornecedor.BuscarEndereco(x => x.FornecedorId == viewModel.FornecedorId);//Busca Endereço pelo ID do Fornecedor

            model.Email = _Fornecedor.BuscarEmail(x => x.FornecedorId == viewModel.FornecedorId);//Busca Email pelo ID do Fornecedor

            return View(model);//ele abre a tela de Detalhes do Forncedor
        }


        //Juridico
        [Authorize]
        [HttpPost]// O POST RECEBE OS DADOS PREENCHIDO PELO USUARIO DA TELA
        public IActionResult NovoFornecedorJuridico(FornecedorViewModel viewModel)//Metodo de cadastro do novo fornecedor
        {
            if (!ModelState.IsValid) //Valida os dados preenchidos de acordo com as regras da classe caso tenha
                return View(viewModel);//permanece com os dados preenchidos pelo usuario

            viewModel.InsertDate = DateTime.Now;//Preenche automatico data e hora 
            viewModel.UpdateDate = DateTime.Now;//Preenche automatico data e hora 

            var model = _mapper.Map<FornecedorJuridico>(viewModel); //mapper é um conversor 

            _Fornecedor.AdicionarJuridico(model);//chama o serviço que grava no BD


            FornecedorJuridico validacao = new FornecedorJuridico();//criando um objeto do tipo FornecedorFisico 

            var Erros = validacao.ValidaFornecedor(model);// armazena na variavel erros o retorno da validaçao caso o usuario tenha digitado dados invalidos 

            if (Erros.Any())//Se tiver dados invalidos entra nesse if 
            {
                foreach (var erro in Erros)//Armazena no ModelState todos os erros de validaçao para depois exibir na tela.
                {
                    ModelState.AddModelError(erro.Key, erro.Value);
                }
                return View(viewModel);//exibe msg de erro na tela 
            }

            return RedirectToAction("Index");//Se o cadastro for valido ele abre a tela Index
        }

        [Authorize]
        public IActionResult NovoFornecedorJuridico()
        {
            FornecedorViewModel model = new FornecedorViewModel();

            // Cria lista de 3 telefones em branco para o usuário preencher na tela
            model.Telefones.Add(new Telefone());
            model.Telefones.Add(new Telefone());
            model.Telefones.Add(new Telefone());

            return View(model);
        }

        [Authorize]
        public IActionResult ConfirmarExcluirJuridico(FornecedorViewModel viewModel)//Metodo de ConfirmarExcluir
        {

            var Fornecedor = _Fornecedor.ObterPorId(viewModel.FornecedorId);//chama o serviço que grava no BD

            var model = _mapper.Map<FornecedorViewModel>(Fornecedor); //mapper é um conversor 
                        
            return View(model);//Se o cadastro for valido ele abre a tela ConfirmarExcluir
        }

        [Authorize]
        [HttpPost]
        public IActionResult ExcluirJuridico(FornecedorViewModel viewModel)//Metodo de ConfirmarExcluir
        {
            var model = _mapper.Map<FornecedorJuridico>(_Fornecedor.ObterPorId(viewModel.FornecedorId)); //mapper é um conversor 

            model.Telefones = _Fornecedor.BuscarTelefones(x => x.FornecedorId == viewModel.FornecedorId);//Busca lista de Telefones pelo ID do Fornecedor

            model.Endereco = _Fornecedor.BuscarEndereco(x => x.FornecedorId == viewModel.FornecedorId);//Busca Endereço pelo ID do Fornecedor

            model.Email = _Fornecedor.BuscarEmail(x => x.FornecedorId == viewModel.FornecedorId);//Busca Email pelo ID do Fornecedor

            //Exclui o Fornecedor
            _Fornecedor.RemoverJuridico(model);//chama o serviço que grava no BD

            //Exclui os Telefones
            _Fornecedor.RemoverTelefones(model.Telefones.ToList());

            return RedirectToAction("Index");//Redireciona pra tela Index
        }

        [Authorize]
        public IActionResult EditarFornecedorJuridico(FornecedorViewModel viewModel)//Metodo de Editar
        {
            var Fornecedor = _Fornecedor.ObterPorId(viewModel.FornecedorId);//chama o serviço que grava no BD

            var model = _mapper.Map<FornecedorViewModel>(Fornecedor); //mapper é um conversor 
           
            model.Telefones = _Fornecedor.BuscarTelefones(x => x.FornecedorId == viewModel.FornecedorId);//Busca lista de Telefones pelo ID do Fornecedor

            model.Endereco = _Fornecedor.BuscarEndereco(x => x.FornecedorId == viewModel.FornecedorId);//Busca Endereço pelo ID do Fornecedor

            model.Email = _Fornecedor.BuscarEmail(x => x.FornecedorId == viewModel.FornecedorId);//Busca Email pelo ID do Fornecedor

            return View(model);//Se o cadastro for valido ele abre a tela Index
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditarJuridico(FornecedorViewModel viewModel)//Metodo de Editar
        {
            var model = _mapper.Map<FornecedorJuridico>(viewModel); //mapper é um conversor 

            _Fornecedor.AtualizarJuridico(model); // Atualiza dados do Fornecedor


            FornecedorJuridico validacao = new FornecedorJuridico();//criando um objeto do tipo FornecedorFisico 

            var Erros = validacao.ValidaFornecedor(model);// armazena na variavel erros o retorno da validaçao caso o usuario tenha digitado dados invalidos 

            if (Erros.Any())//Se tiver dados invalidos entra nesse if 
            {
                foreach (var erro in Erros)//Armazena no ModelState todos os erros de validaçao para depois exibir na tela.
                {
                    ModelState.AddModelError(erro.Key, erro.Value);
                }
                return View(viewModel);//exibe msg de erro na tela 
            }

            _Fornecedor.AtualizarEndereco(model.Endereco); // Atualiza dados do Endereco
            _Fornecedor.AtualizarEmail(model.Email); // Atualiza dados do Email
            _Fornecedor.AtualizarTelefones(model.Telefones.ToList()); // Atualiza dados dos Telefones    

            return RedirectToAction("Index");//Volta pra tela Index
        }

        public IActionResult DetalhesJuridico(FornecedorViewModel viewModel)//Metodo de Editar
        {
            var Fornecedor = _Fornecedor.ObterPorId(viewModel.FornecedorId);//Busca os dados do fornecedor por Id

            var model = _mapper.Map<FornecedorViewModel>(Fornecedor); //mapper é um conversor 

            model.Telefones = _Fornecedor.BuscarTelefones(x => x.FornecedorId == viewModel.FornecedorId);//Busca lista de Telefones pelo ID do Fornecedor

            model.Endereco = _Fornecedor.BuscarEndereco(x => x.FornecedorId == viewModel.FornecedorId);//Busca Endereço pelo ID do Fornecedor

            model.Email = _Fornecedor.BuscarEmail(x => x.FornecedorId == viewModel.FornecedorId);//Busca Email pelo ID do Fornecedor

            return View(model);//ele abre a tela de Detalhes do Forncedor
        }

        public ActionResult RelatorioFornecedorProduto()
        {
            var relatorio = _Fornecedor.RelatorioFornecedorProduto();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("FornecedoresProdutos");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Fornecedor";
                worksheet.Cell(currentRow, 2).Value = "Produto";
                worksheet.Cell(currentRow, 3).Value = "Preco";
                worksheet.Cell(currentRow, 4).Value = "Custo";
                worksheet.Cell(currentRow, 5).Value = "Barras";

                foreach (var item in relatorio)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.FornecedorId;
                    worksheet.Cell(currentRow, 2).Value = item.Nome;
                    worksheet.Cell(currentRow, 3).Value = item.PrecoVenda;
                    worksheet.Cell(currentRow, 4).Value = item.PrecoCompra;
                    worksheet.Cell(currentRow, 5).Value = item.CodigoBarras;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "RelatorioFornecedoProduto.xlsx");
                }
            }
        }
    }
}
