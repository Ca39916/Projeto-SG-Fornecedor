using SGFornecedor.applicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SGFornecedor.applicationCore.Interfaces.Repository;


namespace SGFornecedor.applicationCore.Entity
{
    public class FornecedorFisico : Fornecedor
    {
		private readonly IFornecedorService _Fornecedor;//Criando a variavel _Fornecedor

		public FornecedorFisico()
		{
			
		}

		public string NomeCompleto { get;  set; }
        public string NomeFantasia { get;  set; }
        public string Cpf { get;  set; }
        public DateTime DataNascimento { get;  set; }

        public Dictionary<string, string> ValidaFornecedor(FornecedorFisico ValiFornecedor)
        {
			Dictionary<string,string> valida = new Dictionary<string,string>();
			
			//Valida Data Nascimento
			if (CalculaIdade(ValiFornecedor.DataNascimento) < 18) //Se Cpf for invalido entra no if
			{
				valida.Add("DataNascimento", "USUARIO MENOR DE 18 ANOS");

			}

			//Valida Nome Fantasia
			if (string.IsNullOrEmpty(ValiFornecedor.NomeFantasia)) //IsNullOrEmpty verifica se o campo é nulo ou esta em branco
			{
				valida.Add("NomeFantasia", "NOME FANTASIA OBRIGATÓRIO");

			}
            else // Se o Nome Fantasia NÃO estiver em branco, verificar se existe outro cadastro com o mesmo Nome Fantasia no banco de dados
            {
                //var Fornecedor2 = _Fornecedor.BuscarFisico(x => x.NomeFantasia == ValiFornecedor.NomeFantasia);
                //if (Fornecedor2 != null)
                //{
                //    valida.Add("NomeFantasia", "NOME FANTASIA JÁ CADASTRADO");
                //}
            }

			//Valida Nome Completo
			if (string.IsNullOrEmpty(ValiFornecedor.NomeCompleto)) //IsNullOrEmpty verifica se o campo é nulo ou esta em branco
			{
				valida.Add("NomeCompleto", "NOME COMPLETO  OBRIGATÓRIO");

			}
			
			if (string.IsNullOrEmpty(ValiFornecedor.Cpf)) //IsNullOrEmpty verifica se o campo é nulo ou esta em branco
			{
				valida.Add("Cpf", "CPF OBRIGATÓRIO");

			}
            else // Se o CPF NÃO estiver em branco, verificar se existe outro cadastro com o mesmo CPF no banco de dados
            {
                ////Valida se já existe outro cadastro com o mesmo CPF
                //var Fornecedor = _Fornecedor.BuscarFisico(x => x.Cpf == ValiFornecedor.Cpf);
                //if (Fornecedor != null)
                //{
                //    valida.Add("Cpf", "CPF JÁ CADASTRADO");
                //}


                //Valida CPF
                if (!ValidaCpf(ValiFornecedor.Cpf)) //Se Cpf for invalido entra no if
                {
                    valida.Add("Cpf", "CPF INVÁLIDO");

                }
            }

            return valida; 
			          
        }
		public static bool ValidaCpf(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}

		//Valida se é maior de 18 anos
		private static int CalculaIdade(DateTime DataNascimento)
        {
			int Idade = DateTime.Now.Year - DataNascimento.Year;
			if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            {
				Idade = Idade - 1;
            }
			return Idade;

		}
	}
}








