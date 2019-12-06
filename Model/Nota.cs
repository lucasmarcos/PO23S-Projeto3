using System;
using System.Collections.Generic;

namespace Projeto3.Model
{
	public class Nota
	{
		public Int32 Codigo { get; set; }
		public Cliente Cliente { get; set; }
		public List<Tuple<Produto, Int32>> Produtos { get; set; }
		public Int32 Total { get; set; }
		public DateTime Data { get; set; }

		public Nota()
		{
			Produtos = new List<Tuple<Produto, int>>();
		}

		public void CalcularTotal()
		{
			Total = 0;
			foreach (var p in Produtos)
			{
				Total += p.Item1.Valor * p.Item2;
			}
		}

		public void Debug()
		{
			Console.WriteLine($"nota:{Codigo}|{Data}|{Total}");
			Cliente.Debug();
			foreach (var p in Produtos)
			{
				Console.Write($"{p.Item2}x ");
				p.Item1.Debug();
			}
		}
	}
}
