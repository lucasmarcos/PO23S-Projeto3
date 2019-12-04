using System;

namespace Projeto3.Model
{
	public class Produto
	{
		public Int32 Codigo { get; set; }
		public String Nome { get; set; }
		public Int32 Valor { get; set; }

		public void debug()
		{
			Console.WriteLine($"produto:{Codigo}|{Nome}|{Valor}");
		}
	}
}
