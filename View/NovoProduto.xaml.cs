using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3.View
{
	public class NovoProduto : Window
	{
		public DAOProduto DAOProduto { get; set; }

		public NovoProduto()
		{
			DataContext = new Produto();
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void BotaoCadastrar(object s, RoutedEventArgs e)
		{
			var produto = ((Produto) DataContext);
			if (produto.Validar())
			{
				DAOProduto.Cadastrar(produto);
				this.Close();
			}
		}
	}
}
