using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3.View
{
	public class ConfigurarEmpresa : Window
	{
		public DAOEmpresa DAOEmpresa { get; set; }

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

		public void Salvar(object s, RoutedEventArgs e)
		{
			DAOEmpresa.Salvar((Empresa) DataContext);
			Close();
		}
	}
}
