using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3.View
{
	public class JanelaImprimir : Window
	{
		public JanelaImprimir()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
