using System;

using Npgsql;

namespace Projeto3.DAO
{
    public class Conexao
    {
        private readonly NpgsqlConnection _con;

        public Conexao()
        {
            var host = "localhost";
            var user = "postgres";
            var pass = "aluno";
            var db = "projeto3";
            var uri = String.Format("Host={0};Username={1};Password={2};Database={3}", host, user, pass, db);

            _con = new NpgsqlConnection(uri);
            _con.Open();
        }

        public NpgsqlCommand CriarComando(String sql)
        {
            var cmd = new NpgsqlCommand(sql, _con);
            return cmd;
        }
    }
}
