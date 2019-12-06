using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;
using Projeto3.Model;
using Projeto3.View;

namespace Projeto3
{
	public class App : Application
	{
		private static Conexao _con;
		private static DAOCliente _daoCliente;
		private static DAOProduto _daoProduto;
		private static DAONota    _daoNota;

		public override void Initialize()
		{
			_con = new Conexao();
			_daoCliente = new DAOCliente(_con);
			_daoProduto = new DAOProduto(_con);
			_daoNota    = new DAONota(_con);

			AvaloniaXamlLoader.Load(this);
		}

		//	public override void OnFrameworkInitializationCompleted()
		//	{
		//		if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
		//			desktop.MainWindow = new JanelaPrincipal();
		//		base.OnFrameworkInitializationCompleted();
		//	}

		public static void MostarCliente(Window w)
		{
			var janelaCliente = new JanelaCliente {DAOCliente = _daoCliente};
			janelaCliente.ShowDialog(w);
		}

		public static void MostarProduto(Window w)
		{
			var janelaProduto = new JanelaProduto {DAOProduto = _daoProduto};
			janelaProduto.ShowDialog(w);
		}

		public static void MostarNotaFiscal(Window w)
		{
			var empresa = new Empresa
			{
				Nome     = "Valve",
				Rua      = "Rua Goiás, 92",
				UF       = "PR",
				Bairro   = "Centro",
				CEP      = "85660-000",
				Cidade   = "Dois Vizinhos",
				CNPJ     = "12345678910",
				Telefone = "+1 (49) 0000-9999"
			};

			var nota = _daoNota.Buscar(100);
			nota.Empresa = empresa;

			var janelaImprimir = new JanelaImprimir();
			janelaImprimir.SetNota(nota);
			janelaImprimir.ShowDialog(w);
		}

		public static void NovaNotaFiscal(Window w)
		{
			var empresa = new Empresa
			{
				Nome     = "Valve",
				Rua      = "Rua Goiás, 92",
				UF       = "PR",
				Bairro   = "Centro",
				CEP      = "85660-000",
				Cidade   = "Dois Vizinhos",
				CNPJ     = "12345678910",
				Telefone = "+1 (49) 0000-9999"
			};

			var janelaNovaNota = new JanelaNovaNota();
			janelaNovaNota.SetEmpresa(empresa);
			janelaNovaNota.ShowDialog(w);
		}
	}
}
