using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3.View
{
	public class JanelaProduto : Window
	{
		private readonly DAOProduto _daoProduto;

		public JanelaProduto(DAOProduto d)
		{
			_daoProduto = d;
			DataContext = new Produto();
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		private void BotaoCadastrar(object s, object e)
		{
			var produto = ((Produto) DataContext);
			
			if (produto.Validar())
			{
				_daoProduto.Cadastrar(produto);
				this.Close();
			}
		}
	}
}
