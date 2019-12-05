using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3
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

		private void botaoCliente(object s, object e)
		{
			Projeto3.mostarCliente();
		}

		private void botaoProduto(object s, object e)
		{
			Projeto3.mostarNotaFiscal();
		}

		private void botaoNotas(object s, object e)
		{
			Projeto3.mostarNotaFiscal();
		}

		private void botaoEmitir(object s, object e)
		{
			Projeto3.mostarNotaFiscal();
		}
    } 
}
