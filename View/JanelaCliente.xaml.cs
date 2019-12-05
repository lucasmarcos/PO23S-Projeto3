using System;

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3
{
	public class JanelaCliente : Window
	{
		private DAOCliente daoCliente;

		public JanelaCliente(DAOCliente d)
		{
			daoCliente = d;
			DataContext = new Cliente();
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		private void botaoCadastrar(object s, object e)
		{
			var cliente = ((Cliente) DataContext);
			daoCliente.cadastrar(cliente);
			this.Close();
		}
	}
}
