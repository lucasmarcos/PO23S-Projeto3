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

		private void BotaoCliente(object s, object e)
		{
			Projeto3.MostarCliente();
		}

		private void BotaoProduto(object s, object e)
		{
			Projeto3.MostarProduto();
		}

		private void BotaoNotas(object s, object e)
		{
			Projeto3.MostarNotaFiscal();
		}

		private void BotaoEmitir(object s, object e)
		{
			Projeto3.MostarNotaFiscal();
		}
	}
}
