using System;
using System.Collections.Generic;

namespace Projeto3.Model
{
	public class Nota
	{
		public Int32 Codigo { get; set; }
		public Cliente Cliente { get; set; }
		public List<ProdutoComprado> Produtos { get; set; }
		public Int32 Total { get; set; }
		public DateTime Data { get; set; }
		public Empresa Empresa { get; set; }

		public Nota()
		{
			Produtos = new List<ProdutoComprado>();
		}

		public void CalcularTotal()
		{
			Total = 0;
			foreach (var p in Produtos)
			{
				Total += p.Total;
			}
		}

		public void Debug()
		{
			Console.WriteLine($"nota:{Codigo}|{Data}|{Total}");
			Cliente.Debug();
			foreach (var p in Produtos)
			{
				Console.Write($"{p.Total}|{p.Quantidade}x|");
				p.Produto.Debug();
			}
		}
	}
}
