using System;

namespace Projeto3.Model {
	public class ProdutoComprado
	{
		public Produto Produto;
		public Int32   Quantidade;
		public Int32   Total;
		
		public ProdutoComprado(Produto p, Int32 q)
		{
			Produto = p;
			Quantidade = q;
			Total = (p.Valor * q);
		}
	}
}