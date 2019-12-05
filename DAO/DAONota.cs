using System;
using System.Collections.Generic;

using Npgsql;

using Projeto3.Model;

namespace Projeto3.DAO
{
	public class DAONota
	{
		private NpgsqlCommand comandoCadastrarNota;
		private NpgsqlCommand resgatarCodigo;
		private NpgsqlCommand comandoCadastrarProduto;

		private NpgsqlCommand comandoBuscar;
		private NpgsqlCommand comandoListar;
		private NpgsqlCommand comandoAtualizar;
		private NpgsqlCommand comandoRemover;

		public DAONota(Conexao con)
		{
			preparaCadastrar(con);

			comandoBuscar = con.criarComando("");
			comandoBuscar.Prepare();

			comandoListar = con.criarComando("");
			comandoListar.Prepare();

			comandoAtualizar = con.criarComando("");
			comandoAtualizar.Prepare();

			comandoRemover = con.criarComando("");
			comandoRemover.Prepare();
		}

		private void preparaCadastrar(Conexao con)
		{
			comandoCadastrarNota = con.criarComando("INSERT INTO nota (cliente, data) VALUES (@cliente, @data);");
			comandoCadastrarNota.Parameters.Add("@cliente", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoCadastrarNota.Parameters.Add("@data",    NpgsqlTypes.NpgsqlDbType.Timestamp);
			comandoCadastrarNota.Prepare();

			resgatarCodigo = con.criarComando("SELECT codigo FROM nota ORDER BY codigo DESC LIMIT 1;");
			resgatarCodigo.Prepare();

			comandoCadastrarProduto = con.criarComando("INSERT INTO produto_comprado (nota, produto, quantidade) VALUES (@nota, @produto, @quantidade);");
			comandoCadastrarProduto.Parameters.Add("@nota",       NpgsqlTypes.NpgsqlDbType.Integer);
			comandoCadastrarProduto.Parameters.Add("@produto",    NpgsqlTypes.NpgsqlDbType.Integer);
			comandoCadastrarProduto.Parameters.Add("@quantidade", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoCadastrarProduto.Prepare();
		}

		public List<Nota> listarNotas()
		{
			var lista = new List<Nota>();
			return lista;
		}

		public void cadastrar(Nota nota)
		{
			defineParametrosNota(comandoCadastrarNota.Parameters, nota);
			comandoCadastrarNota.ExecuteNonQuery();

			nota.Codigo = (Int32) resgatarCodigo.ExecuteScalar();

			foreach(var p in nota.Produtos)
			{
				defineParametrosProduto(comandoCadastrarProduto.Parameters, nota.Codigo, p.Item1.Codigo, p.Item2);
				comandoCadastrarProduto.ExecuteNonQuery();
			}
		}

		public void remover(Nota nota)
		{

		}

		public void buscar(Int32 codigo)
		{

		}

		public void atualizar(Int32 codigo)
		{

		}

		private void defineParametrosNota(NpgsqlParameterCollection parametros, Nota nota)
		{
			parametros["@cliente"].NpgsqlValue = nota.Cliente.Codigo;
			parametros["@data"].NpgsqlValue = nota.Data;
		}
		
		private void defineParametrosProduto(NpgsqlParameterCollection parametros, Int32 nota, Int32 produto, Int32 quantidade)
		{
			parametros["@nota"].NpgsqlValue       = nota;
			parametros["@produto"].NpgsqlValue    = produto;
			parametros["@quantidade"].NpgsqlValue = quantidade;
		}
	}
}
