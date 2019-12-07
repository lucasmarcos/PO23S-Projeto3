using Avalonia.Interactivity;
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

		public void SelecionarCliente(object s, RoutedEventArgs e)
		{
			var janelaListarClientes = new JanelaListarClientes();
			janelaListarClientes.ShowDialog(this);
		}

		public void AdicionarProduto(object s, RoutedEventArgs e)
		{
			var janelaListarProdutos = new JanelaListarProdutos();
			janelaListarProdutos.ShowDialog(this);
		}
	}
}
