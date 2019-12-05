using System;

using Avalonia;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3
{
	public class Projeto3
	{
		private static JanelaImprimir janelaImprimir;
		private static JanelaCliente janelaCliente;

		public static void Main(string[] args)
		{
			Console.WriteLine("inicio");
			Console.WriteLine("configurando avalonia");
			var builder = AppBuilder.Configure<App>().UsePlatformDetect();
			builder.Start(Inicio, args);
		}

		private static void Inicio(Application app, string[] args)
		{
			Console.WriteLine("conectando ao banco");
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

			Console.WriteLine("exibindo tela principal");
			var janelaPrincipal = new JanelaPrincipal();

			var janelaNotas = new JanelaNotas();
			var janelaProduto = new JanelaProduto();

			Projeto3.janelaCliente = new JanelaCliente();
			Projeto3.janelaImprimir = new JanelaImprimir();

			app.Run(janelaPrincipal);
		}

		public static void mostarCliente()
		{
			Projeto3.janelaCliente.Show();
		}

		public static void mostarNotaFiscal()
		{
			Projeto3.janelaImprimir.Show();
		}
	}
}
