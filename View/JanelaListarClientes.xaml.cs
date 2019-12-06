using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3.View
{
	public class JanelaListarClientes : Window
	{
		public JanelaListarClientes()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
