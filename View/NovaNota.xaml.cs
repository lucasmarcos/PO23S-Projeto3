using System;

using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.Model;
using Projeto3.DAO;

namespace Projeto3.View
{
	public class NovaNota : Window
	{
		private DAONota    _daoNota;

		public void SetEmpresa(Empresa empresa)
		{
			DataContext = new Nota();
			((Nota) DataContext).Empresa = empresa;
		}

		public void SetDAONota(DAONota dao)
		{
			_daoNota = dao;
		}

		public NovaNota()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void ConfigurarEmpresa(object s, RoutedEventArgs e)
		{
			App.ConfigurarEmpresa(this);
		}

		public void SelecionarCliente(object s, RoutedEventArgs e)
		{
			App.ListarClientes(this);
		}

		public void AdicionarProduto(object s, RoutedEventArgs e)
		{
			App.ListarProdutos(this);
		}
	}
}
