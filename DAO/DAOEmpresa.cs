using System;
using System.Collections.Generic;

using Npgsql;

using Projeto3.Model;

namespace Projeto3.DAO
{
    public class DAOEmpresa
    {
        private NpgsqlCommand _comandoBuscar;
        private NpgsqlCommand _comandoConfiguar;

        public DAOEmpresa(Conexao con)
        {
            PreparaComandos(con);
        }

        private void PreparaComandos(Conexao con)
        {
            _comandoBuscar = con.CriarComando("SELECT valor FROM configuracao WHERE chave = @chave;");
            _comandoBuscar.Parameters.Add("@chave", NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoBuscar.Prepare();

            _comandoConfiguar = con.CriarComando("INSERT INTO configuracao (chave,valor) VALUES (@chave, @valor) ON CONFLICT (chave) DO UPDATE SET (chave, valor) = (EXCLUDED.chave, EXCLUDED.valor);");
            _comandoConfiguar.Parameters.Add("@chave", NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoConfiguar.Parameters.Add("@valor", NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoConfiguar.Prepare();
        }

        public Empresa Buscar()
        {
    		var empresa = new Empresa();

            _comandoBuscar.Parameters["@chave"].NpgsqlValue = "empresa.nome";
            empresa.Nome = (String) _comandoBuscar.ExecuteScalar();

            _comandoBuscar.Parameters["@chave"].NpgsqlValue = "empresa.cnpj";
            empresa.CNPJ = (String) _comandoBuscar.ExecuteScalar();

            _comandoBuscar.Parameters["@chave"].NpgsqlValue = "empresa.uf";
            empresa.UF = (String) _comandoBuscar.ExecuteScalar();

            _comandoBuscar.Parameters["@chave"].NpgsqlValue = "empresa.telefone";
            empresa.Telefone = (String) _comandoBuscar.ExecuteScalar();

            _comandoBuscar.Parameters["@chave"].NpgsqlValue = "empresa.cidade";
            empresa.Cidade = (String) _comandoBuscar.ExecuteScalar();

            _comandoBuscar.Parameters["@chave"].NpgsqlValue = "empresa.bairro";
            empresa.Bairro = (String) _comandoBuscar.ExecuteScalar();

            _comandoBuscar.Parameters["@chave"].NpgsqlValue = "empresa.cep";
            empresa.CEP = (String) _comandoBuscar.ExecuteScalar();

            _comandoBuscar.Parameters["@chave"].NpgsqlValue = "empresa.rua";
            empresa.Rua = (String) _comandoBuscar.ExecuteScalar();


/*
			var empresa = new Empresa
			{
				Nome     = "Valve",
				Rua      = "Rua Goiás, 92",
				UF       = "PR",
				Bairro   = "Centro",
				CEP      = "85660-000",
				Cidade   = "Dois Vizinhos",
				CNPJ     = "12345678910",
				Telefone = "+1 (49) 0000-9999"
			};
*/

            return empresa;
        }

        private static void DefineParamentros(NpgsqlParameterCollection paramentros, String chave, String valor)
        {
            paramentros["@chave"].NpgsqlValue = chave;
            paramentros["@valor"].NpgsqlValue = valor;
        }
    }
}
