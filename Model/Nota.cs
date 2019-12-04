using System;
using System.Collections.Generic;

namespace Projeto3.Model {
	public class Nota {
		public Int32 Codigo { get; set; }
		public Cliente Cliente { get; set; }
		public List<Produto> Produtos { get; set; }
		public Int32 Total { get; set; }
	}
}
