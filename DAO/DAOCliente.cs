using System;
using System.Collections.Generic;

using Projeto3.Model;

namespace Projeto3.DAO {
	public class DAOCliente {
		private Conexao con;

		public DAOCliente(Conexao con) {
			this.con = con;
		}

		public List<Cliente> listarClientes() {
			var lista = new List<Cliente>();

			return lista;
		}
	}
}
