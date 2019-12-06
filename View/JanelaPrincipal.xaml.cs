using System.Windows.Input;
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

		public void BotaoCliente(object s, object e)
		{
			App.MostarCliente();
		}

		public void BotaoProduto(object s, object e)
		{
			App.MostarProduto();
		}

		public void BotaoNotas(object s, object e)
		{
			App.MostarNotaFiscal();
		}

		public void BotaoEmitir(object s, object e)
		{
			App.NovaNotaFiscal();
		}
	}
}
