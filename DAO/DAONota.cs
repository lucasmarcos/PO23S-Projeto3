using System;
using System.Collections.Generic;

using Npgsql;

using Projeto3.Model;

namespace Projeto3.DAO
{
    public class DAONota
    {
        private NpgsqlCommand _comandoCadastrarNota;
        private NpgsqlCommand _resgatarCodigo;
        private NpgsqlCommand _comandoCadastrarProduto;

        private NpgsqlCommand _comandoBuscarNota;
        private NpgsqlCommand _comandoBuscarProdutos;
        private NpgsqlCommand _comandoListarNotas;

        private NpgsqlCommand _comandoRemoverNota;

        public DAONota(Conexao con)
        {
            PreparaCadastrar(con);
            PreparaBuscar(con);
            PreparaRemover(con);
        }

        private void PreparaCadastrar(Conexao con)
        {
            _comandoCadastrarNota = con.CriarComando("INSERT INTO nota (cliente, data) VALUES (@cliente, @data);");
            _comandoCadastrarNota.Parameters.Add("@cliente", NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoCadastrarNota.Parameters.Add("@data",    NpgsqlTypes.NpgsqlDbType.Timestamp);
            _comandoCadastrarNota.Prepare();

            _resgatarCodigo = con.CriarComando("SELECT codigo FROM nota ORDER BY codigo DESC LIMIT 1;");
            _resgatarCodigo.Prepare();

            _comandoCadastrarProduto = con.CriarComando("INSERT INTO produto_comprado (nota, produto, quantidade) VALUES (@nota, @produto, @quantidade);");
            _comandoCadastrarProduto.Parameters.Add("@nota",       NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoCadastrarProduto.Parameters.Add("@produto",    NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoCadastrarProduto.Parameters.Add("@quantidade", NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoCadastrarProduto.Prepare();
        }

        private void PreparaBuscar(Conexao con)
        {
            _comandoBuscarNota = con.CriarComando("SELECT nota.codigo, nota.data, nota.cliente, cliente.nome, cliente.cpf, cliente.endereco, cliente.bairro, cliente.cep, cliente.cidade, cliente.telefone, cliente.uf FROM nota, cliente WHERE nota.cliente = cliente.codigo AND nota.codigo = @codigo;");
            _comandoBuscarNota.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoBuscarNota.Prepare();

            _comandoBuscarProdutos = con.CriarComando("SELECT produto_comprado.produto, produto.nome, produto.valor, produto.unidade, produto_comprado.quantidade FROM produto_comprado, produto WHERE produto_comprado.produto = produto.codigo AND produto_comprado.nota = @nota;");
            _comandoBuscarProdutos.Parameters.Add("@nota", NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoBuscarProdutos.Prepare();

            _comandoListarNotas = con.CriarComando("SELECT nota.codigo, nota.data, nota.cliente, cliente.nome, cliente.cpf, cliente.endereco, cliente.bairro, cliente.cep, cliente.cidade, cliente.telefone, cliente.uf FROM nota, cliente WHERE nota.cliente = cliente.codigo;");
            _comandoListarNotas.Prepare();
        }

        private void PreparaRemover(Conexao con)
        {
            _comandoRemoverNota = con.CriarComando("DELETE FROM nota WHERE codigo = @codigo;");
            _comandoRemoverNota.Parameters.Add("@nota", NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoRemoverNota.Prepare();
        }

        public List<Nota> ListarNotas()
        {
            var notas = new List<Nota>();

            var reader = _comandoListarNotas.ExecuteReader();
            while (reader.Read())
            {
                var nota = new Nota();
                LerLinhaNota(reader, nota);
                notas.Add(nota);
            }
            reader.Close();

            foreach (var n in notas)
            {
                _comandoBuscarProdutos.Parameters["@nota"].NpgsqlValue = n.Codigo;
                reader = _comandoBuscarProdutos.ExecuteReader();
                while (reader.Read())
                {
                    LerLinhaProduto(reader, n);
                }
                reader.Close();

                n.CalcularTotal();
            }

            return notas;
        }

        public void Cadastrar(Nota nota)
        {
            DefineParametrosNota(_comandoCadastrarNota.Parameters, nota);
            _comandoCadastrarNota.ExecuteNonQuery();

            nota.Codigo = (Int32)_resgatarCodigo.ExecuteScalar();

            foreach (var p in nota.Produtos)
            {
                DefineParametrosProduto(_comandoCadastrarProduto.Parameters, nota.Codigo, p.Produto.Codigo, p.Quantidade);
                _comandoCadastrarProduto.ExecuteNonQuery();
            }
        }

        public void Remover(Nota nota)
        {
            _comandoRemoverNota.Parameters["@nota"].NpgsqlValue = nota.Codigo;
            _comandoRemoverNota.ExecuteNonQuery();
        }

        public Nota Buscar(Int32 codigo)
        {
            var nota = new Nota();

            _comandoBuscarNota.Parameters["@codigo"].NpgsqlValue = codigo;
            var reader = _comandoBuscarNota.ExecuteReader();
            reader.Read();
            LerLinhaNota(reader, nota);
            reader.Close();

            _comandoBuscarProdutos.Parameters["@nota"].NpgsqlValue = nota.Codigo;
            reader = _comandoBuscarProdutos.ExecuteReader();
            while (reader.Read())
            {
                LerLinhaProduto(reader, nota);
            }
            reader.Close();

            nota.CalcularTotal();
            return nota;
        }

        private static void LerLinhaProduto(NpgsqlDataReader reader, Nota nota)
        {
            var quantidade = (Int32) reader["quantidade"];

            var produto = new Produto();
            produto.Codigo =  (Int32)  reader["produto"];
            produto.Nome =    (String) reader["nome"];
            produto.Valor =   (Int32)  reader["valor"];
            produto.Unidade = (String) reader["unidade"];

            nota.Produtos.Add(new ProdutoComprado(produto, quantidade));
        }

        private static void LerLinhaNota(NpgsqlDataReader reader, Nota nota)
        {
            nota.Codigo = (Int32)    reader["codigo"];
            nota.Data =   (DateTime) reader["data"];

            var cliente = new Cliente();
            cliente.Codigo =   (Int32)  reader["cliente"];
            cliente.Nome =     (String) reader["nome"];
            cliente.Endereco = (String) reader["endereco"];
            cliente.Bairro =   (String) reader["bairro"];
            cliente.Cidade =   (String) reader["cidade"];
            cliente.CEP =      (String) reader["cep"];
            cliente.Telefone = (String) reader["telefone"];
            cliente.CPF =      (String) reader["cpf"];
            cliente.UF =       (String) reader["uf"];

            nota.Cliente = cliente;
        }

        private static void DefineParametrosNota(NpgsqlParameterCollection parametros, Nota nota)
        {
            parametros["@cliente"].NpgsqlValue = nota.Cliente.Codigo;
            parametros["@data"].NpgsqlValue    = nota.Data;
        }

        private static void DefineParametrosProduto(NpgsqlParameterCollection parametros, Int32 nota, Int32 produto, Int32 quantidade)
        {
            parametros["@nota"].NpgsqlValue       = nota;
            parametros["@produto"].NpgsqlValue    = produto;
            parametros["@quantidade"].NpgsqlValue = quantidade;
        }
    }
}
