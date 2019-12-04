using System;
using System.Collections.Generic;

namespace Projeto3.Model {
	public class Nota {
		public UInt64 Codigo { get; set; }
		public Cliente Cliente { get; set; }
		public List<Produto> Produtos { get; set; }
		public UInt64 Total { get; set; }
	}
}
