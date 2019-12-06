using System;

namespace Projeto3.Model
{
	public class Cliente
	{
		public Int32 Codigo { get; set; }
		public String Nome { get; set; }
		public String CPF { get; set; }
		public String Endereco { get; set; }
		public String Bairro { get; set; }
		public String CEP { get; set; }
		public String Cidade { get; set; }
		public String Telefone { get; set; }
		public String UF { get; set; }

		public void Debug()
		{
			Console.WriteLine($"cliente:{Codigo}|{Nome}|{CPF}|{Endereco}|{Bairro}|{CEP}|{Cidade}|{Telefone}|{UF}");
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
