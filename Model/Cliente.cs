using System;

namespace Projeto3.Model
{
	public class Cliente
	{
		public Int32  Codigo { get; set; }
		public String Nome { get; set; }
		public String CPF { get; set; }
		public String Endereco { get; set; }
		public String Bairro { get; set; }
		public String CEP { get; set; }
		public String Cidade { get; set; }
		public String Telefone { get; set; }
		public String UF { get; set; }

		public void debug()
		{
			Console.WriteLine($"cliente:{Codigo}|{Nome}|{CPF}|{Endereco}|{Bairro}|{CEP}|{Cidade}|{Telefone}|{UF}");
		}
	}
}
