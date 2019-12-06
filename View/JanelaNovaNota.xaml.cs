using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.Model;

namespace Projeto3.View
{
	public class JanelaNovaNota : Window
	{
        private Empresa Empresa;

        public void SetEmpresa(Empresa e)
        {
            Empresa = e;
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
