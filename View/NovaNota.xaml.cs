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

		private ObservableCollection<Tuple<Produto, Int32, Int32>> _produtos;

		public NovaNota()
		{
			InitializeComponent();
			_produtos = new ObservableCollection<Tuple<Produto, Int32, Int32>>();
			DataContext = new Nota {Produtos = _produtos};
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
		}

		public void AdicionarProduto(object s, RoutedEventArgs e)
		{
			App.ListarProdutos(this);
		}

		public void AdicionarProduto(Produto p)
		{
			_produtos.Add(Tuple.Create(p, 1, p.Valor));
		}

		public void Emitir(object s, RoutedEventArgs e)
		{
			((Nota) DataContext).Debug();
		}
	}
}
