using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3.View
{
	public class ListarClientes : Window
	{
		public DAOCliente DAOCliente { get; set; }
		public NovaNota CallBack { get; set; }

		public ListarClientes()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void Selecionar(object s, RoutedEventArgs e)
		{
			var dg = this.FindControl<DataGrid>("DataGridClientes");
			var c = (Cliente) dg.SelectedItem;
			CallBack.SelecionarCliente(c);
			Close();
		}

		public void Atualizar()
		{
			DataContext = DAOCliente.ListarClientes();
		}
	}
}
