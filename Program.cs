using System;
using System.Windows.Forms;

using Projeto3.DAO;
using Projeto3.View;

namespace Projeto3
{
	class Program
	{
		[STAThread]
		static void Main()
		{
			var con = new Conexao();
			var daoProduto = new DAOProduto(con);
			var daoCliente = new DAOCliente(con);
			var daoNota = new DAONota(con);

			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ProdutoView(daoProduto));
		}
	}
}
