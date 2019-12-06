using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3.View
{
	public class JanelaCliente : Window
	{
		private readonly DAOCliente _daoCliente;

		public JanelaCliente(DAOCliente d)
		{
			_daoCliente = d;
			DataContext = new Cliente();
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		private void BotaoCadastrar(object s, object e)
		{
			var cliente = ((Cliente) DataContext);
			if (cliente.Validar())
			{
				_daoCliente.cadastrar(cliente);
				this.Close();
			}
		}
	}
}
