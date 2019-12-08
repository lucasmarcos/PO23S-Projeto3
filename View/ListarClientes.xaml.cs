using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;

namespace Projeto3.View
{
	public class ListarClientes : Window
	{
		public ListarClientes()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void SetDAO(DAOCliente dao)
		{
			DataContext = dao.ListarClientes();
		}
	}
}
