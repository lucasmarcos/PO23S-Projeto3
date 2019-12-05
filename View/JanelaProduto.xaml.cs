using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3
{
	public class JanelaProduto : Window
	{
		public JanelaProduto()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
