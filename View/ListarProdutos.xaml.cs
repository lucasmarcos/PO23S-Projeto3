using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;

namespace Projeto3.View
{
	public class ListarProdutos : Window
	{
		public ListarProdutos()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void SetDAO(DAOProduto dao)
		{
			DataContext = dao.ListarProdutos();
		}
	}
}
