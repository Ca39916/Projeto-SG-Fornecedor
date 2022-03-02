using SGFornecedor.applicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFornecedor.applicationCore.Entity
{
    public class FornecedorJuridico : Fornecedor
    {
		private readonly IFornecedorService _Fornecedor;//Criando a variavel _Fornecedor
		public FornecedorJuridico()
        {

        }

        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataAbertura { get; set; }

        public Dictionary<string,string> ValidaFornecedor(FornecedorJuridico ValiFornecedor)
        {

            Dictionary<string,string> valida = new Dictionary<string,string>();


            if (string.IsNullOrEmpty(ValiFornecedor.NomeFantasia)) //IsNullOrEmpty verifica se o campo é nulo ou esta em branco
            {
                valida.Add("NomeFantasia", "NOME FANTASIA OBRIGATÓRIO");

            }
			else // Se o Nome Fantasia NÃO estiver em branco, verificar se existe outro cadastro com o mesmo Nome Fantasia no banco de dados
			{
				var Fornecedor = _Fornecedor.BuscarJuridico(x => x.NomeFantasia == ValiFornecedor.NomeFantasia);
				if (Fornecedor != null)
				{
					valida.Add("BuscarJuridico", "NOME FANTASIA JÁ CADASTRADO");
				}
			}

            if (string.IsNullOrEmpty(ValiFornecedor.NomeEmpresa)) //IsNullOrEmpty verifica se o campo é nulo ou esta em branco
            {
                valida.Add("NomeEmpresa", "NOME EMPRESA  OBRIGATÓRIO");

            }

            if (string.IsNullOrEmpty(ValiFornecedor.Cnpj)) //IsNullOrEmpty verifica se o campo é nulo ou esta em branco
            {
                valida.Add("Cnpj", "CNPJ OBRIGATÓRIO");

            }
            else // Se o CNPJ NÃO estiver em branco, verificar se existe outro cadastro com o mesmo CNPJ no banco de dados
            {
				// Verifica se existe outro cadastro com o mesmo CNPJ
				var Fornecedor = _Fornecedor.BuscarJuridico(x => x.Cnpj == ValiFornecedor.Cnpj);
				if (Fornecedor != null)
				{
					valida.Add("Cnpj", "CPF JÁ CADASTRADO");
				}

				// Verifica se o CPNJ é válido
				if (!ValidaCnpj(ValiFornecedor.Cnpj))
				{
					valida.Add("Cnpj", "CNPJ INVÁLIDO");
				}
			}

			return valida;

		}

		public static bool ValidaCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}

	}
}
