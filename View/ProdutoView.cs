using System;
using System.Windows.Forms;

using Projeto3.DAO;

namespace Projeto3.View
{
	public partial class ProdutoView : Form
	{
		private DAOProduto daoProduto;

		public ProdutoView(DAOProduto dao)
		{
			this.daoProduto = dao;
			InitializeComponent();
		}
	}
}
