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

		public void BotaoCliente()
		{
			App.MostarCliente();
		}

		public void BotaoProduto()
		{
			App.MostarProduto();
		}

		public void BotaoNotas()
		{
			App.MostarNotaFiscal();
		}

		public void BotaoEmitir()
		{
			App.MostarNotaFiscal();
		}
	}
}
