using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3.View
{
	public class JanelaListarProdutos : Window
	{
		public JanelaListarProdutos()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
