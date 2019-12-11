using System;

namespace Projeto3.Model
{
	public class Empresa
	{
		public string Nome { get; set; }
		public string CNPJ { get; set; }
		public string Rua { get; set; }
		public string Bairro { get; set; }
		public string CEP { get; set; }
		public string Cidade { get; set; }
		public string UF { get; set; }
		public string Telefone { get; set; }

		public void Debug()
		{
			Console.WriteLine("empresa:{Nome}|{CNPJ}|{Rua}|{Bairro}|{CEP}|{Cidade}|{Telefone}|{UF}");
		}
	}
}
