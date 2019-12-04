using System;
using System.Collections.Generic;

using Projeto3.Model;

namespace Projeto3.DAO {
	public class DAOProduto {
		private Conexao con;

		public DAOProduto(Conexao con) {
			this.con = con;
		}

		public List<Produto> listarProdutos() {
			var lista = new List<Produto>();

			return lista;
		}
	}
}
