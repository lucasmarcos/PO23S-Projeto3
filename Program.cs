using System;
using System.Windows.Forms;

using Projeto3.DAO;

namespace Projeto3
{
	class Program
	{
		static void Main()
		{
			var con = new Conexao();
			
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
		}
	}
}