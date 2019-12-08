using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.Model;
using Projeto3.DAO;

namespace Projeto3.View
{
	public class NovaNota : Window
	{
		public DAONota DAONota { get; set; }
		public Empresa Empresa { get; set; }
		private Button BotaoSelecionar;

		public NovaNota()
		{
			InitializeComponent();
			BotaoSelecionar = this.FindControl<Button>("BotaoSelecionar");

			DataContext = new Nota();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void Atualizar()
		{
			((Nota) DataContext).Empresa = Empresa;
		}

		public void SelecionarCliente(object s, RoutedEventArgs e)
		{
			App.ListarClientes(this);
		}

		public void SelecionarCliente(Cliente c)
		{
			((Nota) DataContext).Cliente = c;
			BotaoSelecionar.IsVisible = false;
		}

		public void RemoverCliente(object s, RoutedEventArgs e)
		{
			((Nota) DataContext).Cliente = null;
			BotaoSelecionar.IsVisible = true;
		}

		public void AdicionarProduto(object s, RoutedEventArgs e)
		{
			App.ListarProdutos(this);
		}

		public void AdicionarProduto(Produto p, Int32 q)
		{
			((Nota) DataContext).Produtos.Add(Tuple.Create(p, q, p.Valor * q));
		}

		public void Emitir(object s, RoutedEventArgs e)
		{
			var nota = (Nota) DataContext;
			nota.CalcularTotal();
			DAONota.Cadastrar(nota);
			App.MostarNotaFiscal(nota);
			Close();
		}
	}
}
