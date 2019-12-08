using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3.View
{
	public class JanelaPrincipal : Window
	{
		public JanelaPrincipal()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void BotaoCliente(object s, RoutedEventArgs e)
		{
			App.MostarCliente(this);
		}

		public void BotaoProduto(object s, RoutedEventArgs e)
		{
			App.MostarProduto(this);
		}

		public void BotaoNotas(object s, RoutedEventArgs e)
		{
		}

		public void BotaoEmitir(object s, RoutedEventArgs e)
		{
			App.NovaNotaFiscal(this);
		}

		public void BotaoEmpresa(object s, RoutedEventArgs e)
		{
			App.ConfigurarEmpresa(this);
		}
	}
}
