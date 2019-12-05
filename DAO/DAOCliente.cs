using System;
using System.Collections.Generic;

using Npgsql;

using Projeto3.Model;

namespace Projeto3.DAO
{
    public class DAOCliente
    {
        private NpgsqlCommand comandoCadastrar;
        private NpgsqlCommand comandoBuscar;
        private NpgsqlCommand comandoListar;
        private NpgsqlCommand comandoAtualizar;
        private NpgsqlCommand comandoRemover;

        private NpgsqlCommand resgatarCodigo;

        public DAOCliente(Conexao con)
        {
            preparaCadastrar(con);
            preparaBuscar(con);
            preparaListar(con);
            preparaAtualizar(con);
            preparaRemover(con);
        }

        private void preparaCadastrar(Conexao con)
        {
            comandoCadastrar = con.criarComando("INSERT INTO cliente (nome, cpf, endereco, bairro, cep, cidade, telefone, uf) VALUES (@nome, @cpf, @endereco, @bairro, @cep, @cidade, @telefone, @uf);");
            comandoCadastrar.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoCadastrar.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoCadastrar.Parameters.Add("@endereco", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoCadastrar.Parameters.Add("@bairro", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoCadastrar.Parameters.Add("@cep", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoCadastrar.Parameters.Add("@cidade", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoCadastrar.Parameters.Add("@telefone", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoCadastrar.Parameters.Add("@uf", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoCadastrar.Prepare();

            resgatarCodigo = con.criarComando("SELECT codigo FROM cliente ORDER BY codigo DESC LIMIT 1;");
            resgatarCodigo.Prepare();
        }

        private void preparaBuscar(Conexao con)
        {
            comandoBuscar = con.criarComando("SELECT codigo, nome, cpf, endereco, bairro, cep, cidade, telefone, uf FROM cliente WHERE codigo = @codigo;");
            comandoBuscar.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
            comandoBuscar.Prepare();
        }

        private void preparaListar(Conexao con)
        {
            comandoListar = con.criarComando("SELECT codigo, nome, cpf, endereco, bairro, cep, cidade, telefone, uf FROM cliente");
            comandoListar.Prepare();
        }

        private void preparaAtualizar(Conexao con)
        {
            comandoAtualizar = con.criarComando("UPDATE cliente SET nome = @nome, cpf = @cpf, endereco = @endereco, bairro = @bairro, cep = @cep, cidade = @cidade, telefone = @telefone, uf = @uf WHERE codigo = @codigo");
            comandoAtualizar.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoAtualizar.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoAtualizar.Parameters.Add("@endereco", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoAtualizar.Parameters.Add("@bairro", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoAtualizar.Parameters.Add("@cep", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoAtualizar.Parameters.Add("@cidade", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoAtualizar.Parameters.Add("@telefone", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoAtualizar.Parameters.Add("@uf", NpgsqlTypes.NpgsqlDbType.Varchar);
            comandoAtualizar.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
            comandoAtualizar.Prepare();
        }

        private void preparaRemover(Conexao con)
        {
            comandoRemover = con.criarComando("DELETE FROM cliente WHERE codigo = @codigo;");
            comandoRemover.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer);
            comandoRemover.Prepare();
        }

        public List<Cliente> listarClientes()
        {
            var lista = new List<Cliente>();

            var reader = comandoListar.ExecuteReader();
            while (reader.Read())
            {
                var cliente = new Cliente();
                lerLinha(reader, cliente);
                lista.Add(cliente);
            }
            reader.Close();

            return lista;
        }

        public void cadastrar(Cliente cliente)
        {
            defineParametros(comandoCadastrar.Parameters, cliente);
            comandoCadastrar.ExecuteNonQuery();

            cliente.Codigo = (Int32)resgatarCodigo.ExecuteScalar();
        }

        public void remover(Cliente cliente)
        {
            comandoRemover.Parameters["@codigo"].NpgsqlValue = cliente.Codigo;
            comandoRemover.ExecuteNonQuery();
        }

        public Cliente buscar(Int32 codigo)
        {
            comandoBuscar.Parameters["@codigo"].NpgsqlValue = codigo;
            var reader = comandoBuscar.ExecuteReader();
            reader.Read();

            var cliente = new Cliente();
            lerLinha(reader, cliente);
            reader.Close();

            return cliente;
        }

        public void atualizar(Cliente cliente)
        {
            comandoAtualizar.Parameters["@codigo"].NpgsqlValue = cliente.Codigo;
            defineParametros(comandoAtualizar.Parameters, cliente);
            comandoAtualizar.ExecuteNonQuery();
        }

        private void lerLinha(NpgsqlDataReader reader, Cliente cliente)
        {
            cliente.Codigo = (Int32)reader["codigo"];
            cliente.Nome = (String)reader["nome"];
            cliente.CPF = (String)reader["cpf"];
            cliente.Endereco = (String)reader["endereco"];
            cliente.Bairro = (String)reader["bairro"];
            cliente.CEP = (String)reader["cep"];
            cliente.Cidade = (String)reader["cidade"];
            cliente.Telefone = (String)reader["telefone"];
            cliente.UF = (String)reader["uf"];
        }

        private void defineParametros(NpgsqlParameterCollection paramentros, Cliente cliente)
        {
            paramentros["@nome"].NpgsqlValue = cliente.Nome;
            paramentros["@cpf"].NpgsqlValue = cliente.CPF;
            paramentros["@endereco"].NpgsqlValue = cliente.Endereco;
            paramentros["@bairro"].NpgsqlValue = cliente.Bairro;
            paramentros["@cep"].NpgsqlValue = cliente.CEP;
            paramentros["@cidade"].NpgsqlValue = cliente.Cidade;
            paramentros["@telefone"].NpgsqlValue = cliente.Telefone;
            paramentros["@uf"].NpgsqlValue = cliente.UF;
        }
    }
}
