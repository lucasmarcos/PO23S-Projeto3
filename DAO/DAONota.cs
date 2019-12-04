using System;
using System.Collections.Generic;

using Projeto3.Model;

namespace Projeto3.DAO {
	public class DAONota {
		private Conexao con;

		public DAONota(Conexao con) {
			this.con = con;
		}

		public List<Nota> listarNotas() {
			var lista = new List<Nota>();

			return lista;
		}
	}
}
