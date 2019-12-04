using System;

using Npgsql;

namespace Projeto3.DAO {
	public class Conexao {
		private NpgsqlConnection con;

		public Conexao() {
			var host = "localhost";
			var user = "postgres";
			var pass = "aluno";
			var db = "Projeto3";

			var uri = String.Format(
					"Host={0};Username={1};Password={2};Database={3}",
					host, user, pass, db);

			con = new NpgsqlConnection(uri);
		}

		public void Executa(String sql) {
		}

		public void Busca(String sql) {
		}
	}
}
