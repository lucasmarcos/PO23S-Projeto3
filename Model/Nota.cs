using System;
using System.Collections.Generic;

namespace Projeto3.Model {
	public class Nota {
		public UInt64 codigo { get; set; }
        public Cliente cliente { get; set; }
        public List<Produto> produtos { get; set; }
        public UInt64 total { get; set; }
    }
}