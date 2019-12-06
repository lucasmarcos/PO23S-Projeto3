using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3.View
{
	public class JanelaCliente : Window
	{
		public DAOCliente DAOCliente { get; set; }

		public JanelaCliente()
		{
			DataContext = new Cliente();
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		private void BotaoCadastrar()
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
