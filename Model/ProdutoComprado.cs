using System;

namespace Projeto3.Model {
	public class ProdutoComprado
	{
		public readonly Produto Produto;
		public readonly Int32   Quantidade;
		public readonly Int32   Total;
		
		public ProdutoComprado(Produto p, Int32 q)
		{
			Produto = p;
			Quantidade = q;
			Total = (p.Valor * q);
		}
	}
}