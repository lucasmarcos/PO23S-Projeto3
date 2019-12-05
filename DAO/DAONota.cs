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
		
		private NpgsqlCommand comandoRemoverNota;

		public DAONota(Conexao con)
		{
			preparaCadastrar(con);
			preparaBuscar(con);
			preparaAtualizar(con);
			preparaRemover(con);
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
			comandoBuscarNota = con.criarComando("SELECT nota.codigo, nota.data, nota.cliente, cliente.nome, cliente.cpf, cliente.endereco, cliente.bairro, cliente.cep, cliente.cidade, cliente.telefone, cliente.uf FROM nota, cliente WHERE nota.cliente = cliente.codigo AND nota.codigo = @codigo;");
			comandoBuscarNota.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoBuscarNota.Prepare();

			comandoBuscarProdutos = con.criarComando("SELECT produto_comprado.produto, produto.nome, produto.valor, produto.unidade, produto_comprado.quantidade FROM produto_comprado, produto WHERE produto_comprado.produto = produto.codigo AND produto_comprado.nota = @nota;");
			comandoBuscarProdutos.Parameters.Add("@nota", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoBuscarProdutos.Prepare();

			comandoListarNotas = con.criarComando("SELECT nota.codigo, nota.data, nota.cliente, cliente.nome, cliente.cpf, cliente.endereco, cliente.bairro, cliente.cep, cliente.cidade, cliente.telefone, cliente.uf FROM nota, cliente WHERE nota.cliente = cliente.codigo;");
			comandoListarNotas.Prepare();
		}

		private void preparaAtualizar(Conexao con)
		{
			comandoAtualizar = con.criarComando("");
			comandoAtualizar.Prepare();
		}

		private void preparaRemover(Conexao con)
		{
			comandoRemoverNota = con.criarComando("DELETE FROM nota WHERE codigo = @codigo;");
			comandoRemoverNota.Parameters.Add("@nota", NpgsqlTypes.NpgsqlDbType.Integer);
			comandoRemoverNota.Prepare();
		}

		public List<Nota> listarNotas()
		{
			var notas = new List<Nota>();

			var reader = comandoListarNotas.ExecuteReader();
			while(reader.Read())
			{
				var nota = new Nota();
				lerLinhaNota(reader, nota);
				notas.Add(nota);
			}
			reader.Close();

			foreach (var n in notas)
			{
				comandoBuscarProdutos.Parameters["@nota"].NpgsqlValue = n.Codigo;
				reader = comandoBuscarProdutos.ExecuteReader();
				while(reader.Read())
				{
					lerLinhaProduto(reader, n);
				}
				reader.Close();
			}

			return notas;
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
			comandoRemoverNota.Parameters["@nota"].NpgsqlValue = nota.Codigo;
			comandoRemoverNota.ExecuteNonQuery();
		}

		public Nota buscar(Int32 codigo)
		{
			var nota = new Nota();

			comandoBuscarNota.Parameters["@codigo"].NpgsqlValue = codigo;
			comandoBuscarProdutos.Parameters["@nota"].NpgsqlValue = nota.Codigo;

			var reader = comandoBuscarNota.ExecuteReader();
			reader.Read();
			lerLinhaNota(reader, nota);
			reader.Close();

			reader = comandoBuscarProdutos.ExecuteReader();
			while(reader.Read())
			{
				lerLinhaProduto(reader, nota);
			}
			reader.Close();

			return nota;
		}

		public void atualizar(Int32 codigo)
		{

		}

		private void lerLinhaProduto(NpgsqlDataReader reader, Nota nota)
		{
			var quantidade = (Int32) reader["quantidade"];

			var produto = new Produto();
			produto.Codigo  = (Int32) reader["produto"];
			produto.Nome    = (String) reader["nome"];
			produto.Valor   = (Int32) reader["valor"];
			produto.Unidade = (String) reader["unidade"];
				
			nota.Produtos.Add(Tuple.Create(produto, quantidade));
		}

		private void lerLinhaNota(NpgsqlDataReader reader, Nota nota)
		{
			nota.Codigo  = (Int32) reader["codigo"];
			nota.Data    = (DateTime) reader["data"];

			var cliente = new Cliente();
			cliente.Codigo   = (Int32) reader["cliente"];
			cliente.Nome     = (String) reader["nome"];
			cliente.Endereco = (String) reader["endereco"];
			cliente.Bairro   = (String) reader["bairro"];
			cliente.Cidade   = (String) reader["cidade"];
			cliente.CEP      = (String) reader["cep"];
			cliente.Telefone = (String) reader["telefone"];
			cliente.CPF      = (String) reader["cpf"];
			cliente.UF       = (String) reader["uf"];

			nota.Cliente = cliente;
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
