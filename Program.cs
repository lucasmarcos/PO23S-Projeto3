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
			
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProdutoView());
		}
	}
}