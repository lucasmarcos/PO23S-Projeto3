using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3.View
{
	public class NovoCliente : Window
	{
		public DAOCliente DAOCliente { get; set; }

		public NovoCliente()
		{
			DataContext = new Cliente();
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void BotaoCadastrar(object s, RoutedEventArgs e)
		{
			var cliente = ((Cliente) DataContext);
			if (cliente.Validar())
			{
				DAOCliente.Cadastrar(cliente);
				this.Close();
			}
		}
	}
}
