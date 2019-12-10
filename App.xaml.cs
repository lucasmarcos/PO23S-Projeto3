using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;

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
		private static DAOEmpresa _daoEmpresa;

		public override void Initialize()
		{
			_con = new Conexao();
			_daoCliente = new DAOCliente(_con);
			_daoProduto = new DAOProduto(_con);
			_daoNota    = new DAONota(_con);
			_daoEmpresa = new DAOEmpresa(_con);

			AvaloniaXamlLoader.Load(this);
		}

		public override void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
				desktop.MainWindow = new JanelaPrincipal();

			base.OnFrameworkInitializationCompleted();
		}

		public static void MostarCliente(Window w)
		{
			var janelaCliente = new NovoCliente {DAOCliente = _daoCliente};
			janelaCliente.ShowDialog(w);
		}

		public static void MostarProduto(Window w)
		{
			var janelaProduto = new NovoProduto {DAOProduto = _daoProduto};
			janelaProduto.ShowDialog(w);
		}

		public static void Imprimir(Nota n)
		{
			n.Unificar();

			var janelaImprimir = new ImprimirNota();
			var compNota = janelaImprimir.FindControl<StackPanel>("Nota");

			janelaImprimir.SetNota(n);
			janelaImprimir.Show();

			var pixelSize = new PixelSize(794, 1123);
			var dpi = new Vector(96, 96);

			var vezes = 0;
			janelaImprimir.LayoutUpdated += (object s, EventArgs e) =>
			{
				if(vezes < 1)
				{
					vezes++;
				}
				if(vezes == 1)
				{
					var bitmap = new RenderTargetBitmap(pixelSize, dpi);
					bitmap.Render(compNota);
					bitmap.Save("nota.bmp");
					vezes++;
				}
			};
		}

		public static void NovaNotaFiscal(Window w)
		{
			var janelaNovaNota = new NovaNota {DAONota = _daoNota, Empresa = _daoEmpresa.Buscar()};
			janelaNovaNota.Atualizar();
			janelaNovaNota.ShowDialog(w);
		}

		public static void MostrarNotas(Window w)
		{
			var listarNotas = new ListarNotas {DAONota = _daoNota, Empresa = _daoEmpresa.Buscar()};
			listarNotas.Atualizar();
			listarNotas.ShowDialog(w);
		}

		public static void ConfigurarEmpresa(Window w)
		{
			var configurarEmpresa = new ConfigurarEmpresa {DAOEmpresa = _daoEmpresa};
			configurarEmpresa.Atualizar();
			configurarEmpresa.ShowDialog(w);
		}

		public static void ListarClientes(NovaNota w)
		{
			var listarClientes = new ListarClientes {DAOCliente = _daoCliente, CallBack = w};
			listarClientes.Atualizar();
			listarClientes.ShowDialog(w);
		}

		public static void ListarProdutos(NovaNota w)
		{
			var listarProdutos = new ListarProdutos {DAOProduto = _daoProduto, CallBack = w};
			listarProdutos.Atualizar();
			listarProdutos.ShowDialog(w);
		}
	}
}
