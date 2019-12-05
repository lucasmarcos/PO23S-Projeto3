using System.Windows;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3
{
	public partial class App : Application
	{
		public App()
		{
			var con = new Conexao();
			var daoCliente = new DAOCliente(con);
			var daoProduto = new DAOProduto(con);
			var daoNota = new DAONota(con);

			var empresa = new Empresa();
			empresa.Nome = "Valve";
			empresa.Rua = "Rua Goiás, 92";
			empresa.UF = "PR";
			empresa.Bairro = "Centro";
			empresa.CEP = "85660-000";
			empresa.Cidade = "Dois Vizinhos";
			empresa.CNPJ = "12345678910";
			empresa.Telefone = "+1 (49) 0000-9999";
		}
	}
}
