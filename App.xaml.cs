using System;
using System.IO;
using System.Windows;
using System.Windows.Xps.Packaging;
using System.Windows.Documents;

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
            eu.Bairro = "Centro";
            eu.CEP = "85660-000";
            eu.Cidade = "Tulsa";
            eu.CPF = "12345678910";
            eu.Endereco = "Relógio";
            eu.UF = "OK";
            eu.Telefone = "9999-0000";
            daoCliente.cadastrar(eu);

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
            nota.Produtos.Add(Tuple.Create(prod1, 3));
            nota.Produtos.Add(Tuple.Create(prod2, 2));
            nota.Produtos.Add(Tuple.Create(prod3, 1));
            nota.calcularTotal();

            nota.debug();
            
            var documento = new FixedDocument();
            var conteudo = new PageContent();
            var pagina = new FixedPage();

            conteudo.Child = pagina;
            documento.Pages.Add(conteudo);

            var xps = new XpsDocument("tmp.xps", FileAccess.ReadWrite);
            var escritor = XpsDocument.CreateXpsDocumentWriter(xps);
            escritor.Write(documento);

            xps.Close();
        }
    }
}
