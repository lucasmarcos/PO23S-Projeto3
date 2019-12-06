using System;
using System.Collections.Generic;

using Npgsql;

using Projeto3.Model;

namespace Projeto3.DAO
{
    public class DAOProduto
    {
        private NpgsqlCommand _comandoCadastrar;
        private NpgsqlCommand _comandoBuscar;
        private NpgsqlCommand _comandoListar;
        private NpgsqlCommand _comandoAtualizar;
        private NpgsqlCommand _comandoRemover;
        private NpgsqlCommand _resgatarCodigo;

        public DAOProduto(Conexao con)
        {
            PreparaCadastrar(con);
            PreparaBuscar(con);
            PreparaListar(con);
            PreparaAtualizar(con);
            PreparaRemover(con);
        }

        private void PreparaCadastrar(Conexao con)
        {
            _comandoCadastrar = con.CriarComando("INSERT INTO produto (nome, valor, unidade) VALUES (@nome, @valor, @unidade);");
            _comandoCadastrar.Parameters.Add("@nome",    NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Parameters.Add("@valor",   NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoCadastrar.Parameters.Add("@unidade", NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Prepare();

            _resgatarCodigo = con.CriarComando("SELECT codigo FROM produto ORDER BY codigo DESC LIMIT 1;");
            _resgatarCodigo.Prepare();
        }

        private void PreparaBuscar(Conexao con)
        {
            _comandoBuscar = con.CriarComando("SELECT codigo, nome, valor, unidade FROM produto WHERE codigo = @codigo;");
            _comandoBuscar.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoBuscar.Prepare();
        }

        private void PreparaListar(Conexao con)
        {
            _comandoListar = con.CriarComando("SELECT codigo, nome, valor, unidade FROM produto;");
            _comandoListar.Prepare();
        }

        private void PreparaAtualizar(Conexao con)
        {
            _comandoAtualizar = con.CriarComando("UPDATE produto SET nome = @nome, valor = @valor, unidade = @unidade WHERE codigo = @codigo;");
            _comandoAtualizar.Parameters.Add("@nome",    NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@valor",   NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoAtualizar.Parameters.Add("@unidade", NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@codigo",  NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoAtualizar.Prepare();
        }

        private void PreparaRemover(Conexao con)
        {
            _comandoRemover = con.CriarComando("DELETE FROM produto WHERE codigo = @codigo;");
            _comandoRemover.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoRemover.Prepare();
        }

        public List<Produto> ListarProdutos()
        {
            var lista = new List<Produto>();

            var reader = _comandoListar.ExecuteReader();
            while (reader.Read())
            {
                var produto = new Produto();
                LerLinha(reader, produto);
                lista.Add(produto);
            }

            reader.Close();

            return lista;
        }

        public void Cadastrar(Produto produto)
        {
            DefineParamentros(_comandoCadastrar.Parameters, produto);
            _comandoCadastrar.ExecuteNonQuery();

            produto.Codigo = (Int32)_resgatarCodigo.ExecuteScalar();
        }

        public void Remover(Produto produto)
        {
            _comandoRemover.Parameters["@codigo"].NpgsqlValue = produto.Codigo;
            _comandoRemover.ExecuteNonQuery();
        }

        public void Atualizar(Produto produto)
        {
            _comandoAtualizar.Parameters["@codigo"].NpgsqlValue = produto.Codigo;
            DefineParamentros(_comandoAtualizar.Parameters, produto);
            _comandoAtualizar.ExecuteNonQuery();
        }

        public Produto Buscar(Int32 codigo)
        {
            _comandoBuscar.Parameters["@codigo"].NpgsqlValue = codigo;
            var reader = _comandoBuscar.ExecuteReader();
            reader.Read();

            var produto = new Produto();
            LerLinha(reader, produto);
            reader.Close();

            return produto;
        }

        private static void LerLinha(NpgsqlDataReader reader, Produto produto)
        {
            produto.Codigo  = (Int32)  reader["codigo"];
            produto.Nome    = (String) reader["nome"];
            produto.Valor   = (Int32)  reader["valor"];
            produto.Unidade = (String) reader["unidade"];
        }

        private static void DefineParamentros(NpgsqlParameterCollection paramentros, Produto produto)
        {
            paramentros["@nome"].NpgsqlValue    = produto.Nome;
            paramentros["@valor"].NpgsqlValue   = produto.Valor;
            paramentros["@unidade"].NpgsqlValue = produto.Unidade;
        }
    }
}
