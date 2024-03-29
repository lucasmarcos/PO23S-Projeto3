using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using ReactiveUI;

namespace Projeto3.Model
{
	public class Nota : ReactiveObject
	{
		public Int32 Codigo { get; set; }
		public Int32 Total { get; set; }
		public DateTime Data { get; set; }

		private ObservableCollection<Tuple<Produto, Int32, Int32>> _produtos;
		public ObservableCollection<Tuple<Produto, Int32, Int32>> Produtos
		{ 
			get => _produtos;
			set => this.RaiseAndSetIfChanged(ref _produtos, value);
		}

		private Empresa _empresa;
		public Empresa Empresa
		{
			get => _empresa;
			set => this.RaiseAndSetIfChanged(ref _empresa, value);
		}

		private Cliente _cliente;
		public Cliente Cliente
		{
			get => _cliente;
			set => this.RaiseAndSetIfChanged(ref _cliente, value);
		}

		public Nota()
		{
			Produtos = new ObservableCollection<Tuple<Produto, Int32, Int32>>();
		}

		public void CalcularTotal()
		{
			Total = 0;
			foreach (var p in Produtos)
			{
				Total += p.Item3;
			}
		}

		public void Unificar()
		{
			var map = new Dictionary<Int32, Int32>();
			var prods = new Dictionary<Int32, Produto>();

			foreach (var p in Produtos)
			{
				map[p.Item1.Codigo] = 0;
				prods[p.Item1.Codigo] = p.Item1;
			}

			foreach (var p in Produtos)
			{
				map[p.Item1.Codigo] += p.Item2;
			}

			Produtos = new ObservableCollection<Tuple<Produto, Int32, Int32>>();
			foreach (KeyValuePair<Int32, Int32> p in map)
			{
				var produto = prods[p.Key];
				Produtos.Add(Tuple.Create(produto, p.Value, (produto.Valor * p.Value)));
			}
		}

		public void Debug()
		{
			_empresa.Debug();
			Console.WriteLine($"nota:{Codigo}|{Data}|{Total}");
			_cliente.Debug();
			foreach (var p in Produtos)
			{
				Console.Write($"{p.Item2}, {p.Item3}");
				p.Item1.Debug();
			}
		}
	}
}
