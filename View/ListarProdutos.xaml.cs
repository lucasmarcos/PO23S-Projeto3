using System;

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3.View
{
	public class ListarProdutos : Window
	{
		public DAOProduto DAOProduto { get; set; }
		public NovaNota CallBack { get; set; }

		public ListarProdutos()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void Selecionar(object s, RoutedEventArgs e)
		{
			var dg = this.FindControl<DataGrid>("DataGridProdutos");
			var p = (Produto) dg.SelectedItem;

			var nud = this.FindControl<NumericUpDown>("Quantidade");
			var q = (Int32) nud.Value;

			CallBack.AdicionarProduto(p, q);
			Close();
		}

		public void Atualizar()
		{
			DataContext = DAOProduto.ListarProdutos();
		}
	}
}
