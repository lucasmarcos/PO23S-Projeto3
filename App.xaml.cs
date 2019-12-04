using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3
{
    public partial class App : Application
    {
        public App()
        {
            var con = new Conexao();
            var daoCliente = new DAOCliente(con);
            var daoProduto = new DAOProduto(con);
            var daoNota = new DAONota(con);

            var empresa = new Empresa();
            empresa.Nome = "Valve";
            empresa.debug();

            var eu = new Cliente();
            eu.Nome = "Angela Abar";

            var prod1 = new Produto();
            prod1.Nome = "DualShock 4";
            prod1.Valor = 100;

            var prod2 = new Produto();
            prod2.Nome = "AirPods Pro";
            prod2.Valor = 200;

            var prod3 = new Produto();
            prod3.Nome = "Valve Index";
            prod3.Valor = 300;

            var nota = new Nota();
            nota.Cliente = eu;
            nota.Produtos = new List<Tuple<Produto, Int32>>();
            nota.Produtos.Add(Tuple.Create(prod1, 3));
            nota.Produtos.Add(Tuple.Create(prod2, 2));
            nota.Produtos.Add(Tuple.Create(prod3, 1));
            nota.calcularTotal();

            nota.debug();

            var impressora = new PrintDialog();
        }
    }
}
