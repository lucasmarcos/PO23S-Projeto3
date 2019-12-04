using System;

namespace Projeto3.Model {
	public class Cliente {
		public UInt64 Codigo { get; set; }
		public String Nome { get; set; }
    	public String CPF { get; set; }
    	public String Endereco { get; set; }
    	public String Bairro { get; set; }
    	public String CEP { get; set; }
    	public String Cidade { get; set; }
    	public String Telefone { get; set; }
    	public String UF { get; set; }
	}
}