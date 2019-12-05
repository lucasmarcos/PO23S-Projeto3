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

		private NpgsqlCommand comandoBuscarNota;
		private NpgsqlCommand comandoBuscarProdutos;
		private NpgsqlCommand comandoListarNotas;

		private NpgsqlCommand comandoAtualizar;
		private NpgsqlCommand comandoRemover;

		private DAOCliente daoCliente;
		private DAOProduto daoProduto;

		public DAONota(Conexao con, DAOCliente daoCliente, DAOProduto daoProduto)
		{
			this.daoCliente = daoCliente;
			this.daoProduto = daoProduto;

			preparaCadastrar(con);
			preparaBuscar(con);

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

		private void preparaBuscar(Conexao con)
		{
			comandoBuscarNota = con.criarComando("SELECT codigo, cliente, data FROM nota WHERE codigo = @codigo;");
			comandoBuscarNota.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoBuscarNota.Prepare();

			comandoBuscarProdutos = con.criarComando("SELECT produto, quantidade FROM produto_comprado WHERE nota = @nota;");
			comandoBuscarProdutos.Parameters.Add("@nota", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoBuscarProdutos.Prepare();

			comandoListarNotas = con.criarComando("SELECT codigo, cliente, data FROM nota;");
			comandoListarNotas.Prepare();
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

		public Nota buscar(Int32 codigo)
		{
			comandoBuscarNota.Parameters["@codigo"].NpgsqlValue = codigo;
			var reader = comandoBuscarNota.ExecuteReader();
			reader.Read();

			var nota = new Nota();
			lerLinhaNota(reader, nota);
			reader.Close();

			nota.Cliente = daoCliente.buscar(nota.Cliente.Codigo);

			comandoBuscarProdutos.Parameters["@nota"].NpgsqlValue = nota.Codigo;
			reader = comandoBuscarProdutos.ExecuteReader();

			while(reader.Read())
			{
				
			}
			
			
			return nota;
		}

		public void atualizar(Int32 codigo)
		{

		}
		
		private void lerLinhaNota(NpgsqlDataReader reader, Nota nota)
		{
			nota.Codigo  = (Int32) reader["codigo"];
			nota.Data    = (DateTime) reader["data"];

			nota.Cliente = new Cliente();
			nota.Cliente.Codigo = (Int32) reader["cliente"];
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
