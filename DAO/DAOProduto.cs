using System;
using System.Collections.Generic;

using Npgsql;

using Projeto3.Model;

namespace Projeto3.DAO
{
	public class DAOProduto
	{
		private NpgsqlCommand comandoCadastrar;
		private NpgsqlCommand comandoBuscar;
		private NpgsqlCommand comandoListar;
		private NpgsqlCommand comandoAtualizar;
		private NpgsqlCommand comandoRemover;
		private NpgsqlCommand resgatarCodigo;

		public DAOProduto(Conexao con)
		{
			preparaCadastrar(con);
			preparaBuscar(con);
			preparaListar(con);
			preparaAtualizar(con);
			preparaRemover(con);
		}

		private void preparaCadastrar(Conexao con)
		{
			comandoCadastrar = con.criarComando("INSERT INTO produto (nome, valor) VALUES (@nome, @valor);");
			comandoCadastrar.Parameters.Add("@nome",  NpgsqlTypes.NpgsqlDbType.Varchar);
			comandoCadastrar.Parameters.Add("@valor", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoCadastrar.Prepare();

			resgatarCodigo = con.criarComando("SELECT codigo FROM produto ORDER BY codigo DESC LIMIT 1;");
			resgatarCodigo.Prepare();
		}
		
		private void preparaBuscar(Conexao con)
		{
			comandoBuscar = con.criarComando("SELECT codigo, nome, valor FROM produto WHERE codigo = @codigo;");
			comandoBuscar.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoBuscar.Prepare();
		}

		private void preparaListar(Conexao con)
		{
			comandoListar = con.criarComando("SELECT codigo, nome, valor FROM produto;");
			comandoListar.Prepare();			
		}

		private void preparaAtualizar(Conexao con)
		{
			comandoAtualizar = con.criarComando("UPDATE produto SET nome = @nome, valor = @valor WHERE codigo = @codigo;");
			comandoAtualizar.Parameters.Add("@nome",   NpgsqlTypes.NpgsqlDbType.Varchar);
			comandoAtualizar.Parameters.Add("@valor",  NpgsqlTypes.NpgsqlDbType.Integer);
			comandoAtualizar.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoAtualizar.Prepare();
		}

		private void preparaRemover(Conexao con)
		{
			comandoRemover = con.criarComando("DELETE FROM produto WHERE codigo = @codigo;");
			comandoRemover.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoRemover.Prepare();
		}

		public List<Produto> listarProdutos()
		{
			var lista = new List<Produto>();

			var reader = comandoListar.ExecuteReader();
			while(reader.Read()) {
				var produto = new Produto();
				lerLinha(reader, produto);
				lista.Add(produto);
			}

			reader.Close();

			return lista;
		}

		public void cadastrar(Produto produto)
		{
			defineParamentros(comandoCadastrar.Parameters, produto);
			comandoCadastrar.ExecuteNonQuery();
			
			produto.Codigo = (Int32) resgatarCodigo.ExecuteScalar();
		}

		public void remover(Produto produto)
		{
			comandoRemover.Parameters["@codigo"].NpgsqlValue = produto.Codigo;
			comandoRemover.ExecuteNonQuery();
		}

		public void atualizar(Produto produto)
		{
			comandoAtualizar.Parameters["@codigo"].NpgsqlValue = produto.Codigo;
			defineParamentros(comandoAtualizar.Parameters, produto);
			comandoAtualizar.ExecuteNonQuery();
		}

		public Produto buscar(Int32 codigo)
		{
			comandoBuscar.Parameters["@codigo"].NpgsqlValue = codigo;
			var reader = comandoBuscar.ExecuteReader();
			reader.Read();

			var produto = new Produto();
			lerLinha(reader, produto);
			reader.Close();

			return produto;
		}

		private void lerLinha(NpgsqlDataReader reader, Produto produto)
		{
			produto.Codigo = (Int32)  reader["codigo"];
			produto.Nome   = (String) reader["nome"];
			produto.Valor  = (Int32)  reader["valor"];
		}

		private void defineParamentros(NpgsqlParameterCollection paramentros, Produto produto)
		{
			paramentros["@nome"].NpgsqlValue  = produto.Nome;
			paramentros["@valor"].NpgsqlValue = produto.Valor;
		}
	}
}
