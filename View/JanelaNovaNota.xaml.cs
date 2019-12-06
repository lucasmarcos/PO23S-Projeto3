using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.Model;

namespace Projeto3.View
{
	public class JanelaNovaNota : Window
	{
        public void SetEmpresa(Empresa e)
        {
			DataContext = e;
        }

		public JanelaNovaNota()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
