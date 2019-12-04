using System;

namespace Projeto3.Model {
	public class Cliente {
		public UInt64 codigo { get; set; }
		public String nome { get; set; }
    	public String cpf { get; set; }
    	public String endereco { get; set; }
    	public String bairro { get; set; }
    	public String cep { get; set; }
    	public String cidade { get; set; }
    	public String telefone { get; set; }
    	public String uf { get; set; }
	}
}