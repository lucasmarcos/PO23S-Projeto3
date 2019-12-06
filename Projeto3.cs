using System;

using Avalonia;

using Projeto3.DAO;
using Projeto3.Model;
using Projeto3.View;

namespace Projeto3
{
	public static class Projeto3
	{
		private static DAOCliente _daoCliente;
		private static DAOProduto _daoProduto;
		private static DAONota _daoNota;

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
			_daoCliente = new DAOCliente(con);
			_daoProduto = new DAOProduto(con);
			_daoNota = new DAONota(con);

			Console.WriteLine("exibindo tela principal");
			var janelaPrincipal = new JanelaPrincipal();
			app.Run(janelaPrincipal);
		}

		public static void MostarCliente()
		{
			var janelaCliente = new JanelaCliente(_daoCliente);
			janelaCliente.Show();
		}

		public static void MostarProduto()
		{
			var janelaProduto = new JanelaProduto(_daoProduto);
			janelaProduto.Show();
		}

		public static void MostarNotaFiscal()
		{
			var empresa = new Empresa();
			empresa.Nome = "Valve";
			empresa.Rua = "Rua Goiás, 92";
			empresa.UF = "PR";
			empresa.Bairro = "Centro";
			empresa.CEP = "85660-000";
			empresa.Cidade = "Dois Vizinhos";
			empresa.CNPJ = "12345678910";
			empresa.Telefone = "+1 (49) 0000-9999";

			var nota = _daoNota.buscar(100);
			nota.Empresa = empresa;

			nota.Debug();
			var janelaImprimir = new JanelaImprimir(nota);
			janelaImprimir.Show();
		}
	}
}
