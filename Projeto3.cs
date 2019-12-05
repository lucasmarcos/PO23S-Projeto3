using System;

using Avalonia;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3
{
	public class Projeto3
	{
		private static DAOCliente daoCliente;
		private static DAOProduto daoProduto;
		private static DAONota daoNota;

		public static void Main(string[] args)
		{
			Console.WriteLine("configurando avalonia");
			var builder = AppBuilder.Configure<App>().UsePlatformDetect();
			builder.Start(Inicio, args);
		}

		private static void Inicio(Application app, string[] args)
		{
			Console.WriteLine("conectando ao banco");
			var con = new Conexao();
			Projeto3.daoCliente = new DAOCliente(con);
			Projeto3.daoProduto = new DAOProduto(con);
			Projeto3.daoNota = new DAONota(con);

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
			app.Run(janelaPrincipal);
		}

		public static void mostarCliente()
		{
			var janelaCliente = new JanelaCliente(daoCliente);
			janelaCliente.Show();
		}

		public static void mostarNotaFiscal()
		{
			var janelaImprimir = new JanelaImprimir();
			janelaImprimir.Show();
		}
	}
}
