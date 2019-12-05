using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3
{
	public class JanelaProduto : Window
	{
		private DAOProduto daoProduto;

		public JanelaProduto(DAOProduto d)
		{
			daoProduto = d;
			DataContext = new Produto();
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		private void botaoCadastrar(object s, object e)
		{
			var produto = ((Produto) DataContext);
			daoProduto.cadastrar(produto);
			this.Close();
		}
	}
}
