using System;

namespace Projeto3.Model
{
	public class Cliente
	{
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string CEP { get; set; }
		public string Cidade { get; set; }
		public string Telefone { get; set; }
		public string UF { get; set; }

		public void Debug()
		{
			Console.WriteLine("cliente:{Codigo}|{Nome}|{CPF}|{Endereco}|{Bairro}|{CEP}|{Cidade}|{Telefone}|{UF}");
		}

		public Boolean Validar()
		{
			if (string.IsNullOrWhiteSpace(Nome))     return false;
			if (string.IsNullOrWhiteSpace(CPF))      return false;
			if (string.IsNullOrWhiteSpace(Endereco)) return false;
			if (string.IsNullOrWhiteSpace(Bairro))   return false;
			if (string.IsNullOrWhiteSpace(CEP))      return false;
			if (string.IsNullOrWhiteSpace(Cidade))   return false;
			if (string.IsNullOrWhiteSpace(Telefone)) return false;
			if (string.IsNullOrWhiteSpace(UF))       return false;

			return true;
		}
	}
}
