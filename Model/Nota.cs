using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Projeto3.Model
{
	public class Nota
	{
		public int Codigo { get; set; }
		public int Total { get; set; }
		public DateTime Data { get; set; }

		public ObservableCollection<Tuple<Produto, int, int>> Produtos;
		public Empresa Empresa;
		public Cliente Cliente;

		public Nota()
		{
			Produtos = new ObservableCollection<Tuple<Produto, int, int>>();
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
			var map = new Dictionary<int, int>();
			var prods = new Dictionary<int, Produto>();

			foreach (var p in Produtos)
			{
				map[p.Item1.Codigo] = 0;
				prods[p.Item1.Codigo] = p.Item1;
			}

			foreach (var p in Produtos)
			{
				map[p.Item1.Codigo] += p.Item2;
			}

			Produtos = new ObservableCollection<Tuple<Produto, int, int>>();
			foreach (KeyValuePair<Int32, Int32> p in map)
			{
				var produto = prods[p.Key];
				Produtos.Add(Tuple.Create(produto, p.Value, (produto.Valor * p.Value)));
			}
		}

		public void Debug()
		{
			Empresa.Debug();
			Console.WriteLine("nota:{Codigo}|{Data}|{Total}");
			Cliente.Debug();
			foreach (var p in Produtos)
			{
				Console.Write("{p.Item2}, {p.Item3}");
				p.Item1.Debug();
			}
		}
	}
}
