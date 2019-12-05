using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3
{
	public class JanelaCliente : Window
	{
		public JanelaCliente()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
