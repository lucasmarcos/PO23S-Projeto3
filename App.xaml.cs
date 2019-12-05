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
            empresa.Rua = "Rua Goiás, 92";
            empresa.UF = "PR";
            empresa.Bairro = "Centro";
            empresa.CEP = "85660-000";
            empresa.Cidade = "Dois Vizinhos";
            empresa.CNPJ = "12345678910";
            empresa.Telefone = "+1 (49) 0000-9999";
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
            prod1.Unidade = "l";
            daoProduto.cadastrar(prod1);

            var prod2 = new Produto();
            prod2.Nome = "AirPods Pro";
            prod2.Valor = 200;
            prod2.Unidade = "kg";
            daoProduto.cadastrar(prod2);

            var prod3 = new Produto();
            prod3.Nome = "Valve Index";
            prod3.Valor = 300;
            prod3.Unidade = "cx.";
            daoProduto.cadastrar(prod3);

            var nota = new Nota();
            nota.Cliente = eu;
            nota.Data = DateTime.Now;
            nota.Produtos.Add(Tuple.Create(prod1, 3));
            nota.Produtos.Add(Tuple.Create(prod2, 2));
            nota.Produtos.Add(Tuple.Create(prod3, 1));
            nota.calcularTotal();
            daoNota.cadastrar(nota);

            nota.debug();
            
            var documento = new FixedDocument();
            var conteudo = new PageContent();
            var pagina = new FixedPage();

            conteudo.Child = pagina;
            documento.Pages.Add(conteudo);

            var xps = new XpsDocument("tmp.xps", FileAccess.ReadWrite);
            var escritor = XpsDocument.CreateXpsDocumentWriter(xps);
            xps.Close();
        }
    }
}
