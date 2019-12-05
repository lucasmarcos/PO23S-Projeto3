using System;

namespace Projeto3.Model {
	public class Empresa {
		public String Nome { get; set; }
		public String CNPJ { get; set; }
		public String Rua { get; set; }
		public String Bairro { get; set; }
		public String CEP { get; set; }
		public String Cidade { get; set; }
		public String UF { get; set; }
		public String Telefone { get; set; }
		
		public void debug() {
			Console.WriteLine($"empresa:{Nome}|{CNPJ}|{Rua}|{Bairro}|{CEP}|{Cidade}|{Telefone}|{UF}");
		}
	}
}
