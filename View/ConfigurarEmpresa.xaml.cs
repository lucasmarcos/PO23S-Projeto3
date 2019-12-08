using System;

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.Model;

namespace Projeto3.View
{
	public class ConfigurarEmpresa : Window
	{
        public void SetEmpresa(Empresa empresa)
        {
            DataContext = empresa;
        }

		public ConfigurarEmpresa()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
