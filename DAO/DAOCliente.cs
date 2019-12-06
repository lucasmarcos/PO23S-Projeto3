using System;
using System.Collections.Generic;

using Npgsql;

using Projeto3.Model;

namespace Projeto3.DAO
{
    public class DAOCliente
    {
        private NpgsqlCommand _comandoCadastrar;
        private NpgsqlCommand _comandoBuscar;
        private NpgsqlCommand _comandoListar;
        private NpgsqlCommand _comandoAtualizar;
        private NpgsqlCommand _comandoRemover;

        private NpgsqlCommand _resgatarCodigo;

        public DAOCliente(Conexao con)
        {
            PreparaCadastrar(con);
            PreparaBuscar(con);
            PreparaListar(con);
            PreparaAtualizar(con);
            PreparaRemover(con);
        }

        private void PreparaCadastrar(Conexao con)
        {
            _comandoCadastrar = con.CriarComando("INSERT INTO cliente (nome, cpf, endereco, bairro, cep, cidade, telefone, uf) VALUES (@nome, @cpf, @endereco, @bairro, @cep, @cidade, @telefone, @uf);");
            _comandoCadastrar.Parameters.Add("@nome",     NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Parameters.Add("@cpf",      NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Parameters.Add("@endereco", NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Parameters.Add("@bairro",   NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Parameters.Add("@cep",      NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Parameters.Add("@cidade",   NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Parameters.Add("@telefone", NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Parameters.Add("@uf",       NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoCadastrar.Prepare();

            _resgatarCodigo = con.CriarComando("SELECT codigo FROM cliente ORDER BY codigo DESC LIMIT 1;");
            _resgatarCodigo.Prepare();
        }

        private void PreparaBuscar(Conexao con)
        {
            _comandoBuscar = con.CriarComando("SELECT codigo, nome, cpf, endereco, bairro, cep, cidade, telefone, uf FROM cliente WHERE codigo = @codigo;");
            _comandoBuscar.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoBuscar.Prepare();
        }

        private void PreparaListar(Conexao con)
        {
            _comandoListar = con.CriarComando("SELECT codigo, nome, cpf, endereco, bairro, cep, cidade, telefone, uf FROM cliente");
            _comandoListar.Prepare();
        }

        private void PreparaAtualizar(Conexao con)
        {
            _comandoAtualizar = con.CriarComando("UPDATE cliente SET nome = @nome, cpf = @cpf, endereco = @endereco, bairro = @bairro, cep = @cep, cidade = @cidade, telefone = @telefone, uf = @uf WHERE codigo = @codigo");
            _comandoAtualizar.Parameters.Add("@nome",     NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@cpf",      NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@endereco", NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@bairro",   NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@cep",      NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@cidade",   NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@telefone", NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@uf",       NpgsqlTypes.NpgsqlDbType.Varchar);
            _comandoAtualizar.Parameters.Add("@codigo",   NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoAtualizar.Prepare();
        }

        private void PreparaRemover(Conexao con)
        {
            _comandoRemover = con.CriarComando("DELETE FROM cliente WHERE codigo = @codigo;");
            _comandoRemover.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
            _comandoRemover.Prepare();
        }

        public List<Cliente> ListarClientes()
        {
            var lista = new List<Cliente>();

            var reader = _comandoListar.ExecuteReader();
            while (reader.Read())
            {
                var cliente = new Cliente();
                LerLinha(reader, cliente);
                lista.Add(cliente);
            }
            reader.Close();

            return lista;
        }

        public void Cadastrar(Cliente cliente)
        {
            DefineParametros(_comandoCadastrar.Parameters, cliente);
            _comandoCadastrar.ExecuteNonQuery();

            cliente.Codigo = (Int32)_resgatarCodigo.ExecuteScalar();
        }

        public void Remover(Cliente cliente)
        {
            _comandoRemover.Parameters["@codigo"].NpgsqlValue = cliente.Codigo;
            _comandoRemover.ExecuteNonQuery();
        }

        public Cliente Buscar(Int32 codigo)
        {
            _comandoBuscar.Parameters["@codigo"].NpgsqlValue = codigo;
            var reader = _comandoBuscar.ExecuteReader();
            reader.Read();

            var cliente = new Cliente();
            LerLinha(reader, cliente);
            reader.Close();

            return cliente;
        }

        public void Atualizar(Cliente cliente)
        {
            _comandoAtualizar.Parameters["@codigo"].NpgsqlValue = cliente.Codigo;
            DefineParametros(_comandoAtualizar.Parameters, cliente);
            _comandoAtualizar.ExecuteNonQuery();
        }

        private static void LerLinha(NpgsqlDataReader reader, Cliente cliente)
        {
            cliente.Codigo   = (Int32)  reader["codigo"];
            cliente.Nome     = (String) reader["nome"];
            cliente.CPF      = (String) reader["cpf"];
            cliente.Endereco = (String) reader["endereco"];
            cliente.Bairro   = (String) reader["bairro"];
            cliente.CEP      = (String) reader["cep"];
            cliente.Cidade   = (String) reader["cidade"];
            cliente.Telefone = (String) reader["telefone"];
            cliente.UF       = (String) reader["uf"];
        }

        private static void DefineParametros(NpgsqlParameterCollection paramentros, Cliente cliente)
        {
            paramentros["@nome"].NpgsqlValue     = cliente.Nome;
            paramentros["@cpf"].NpgsqlValue      = cliente.CPF;
            paramentros["@endereco"].NpgsqlValue = cliente.Endereco;
            paramentros["@bairro"].NpgsqlValue   = cliente.Bairro;
            paramentros["@cep"].NpgsqlValue      = cliente.CEP;
            paramentros["@cidade"].NpgsqlValue   = cliente.Cidade;
            paramentros["@telefone"].NpgsqlValue = cliente.Telefone;
            paramentros["@uf"].NpgsqlValue       = cliente.UF;
        }
    }
}
