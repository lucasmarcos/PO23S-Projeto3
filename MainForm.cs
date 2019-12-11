using System;
using System.Windows.Forms;

using PO23S_Projeto3.View;

namespace PO23S_Projeto3
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		void NovoClienteClick(object sender, EventArgs e)
		{
			var cadastrarCliente = new CadastrarCliente();
			cadastrarCliente.ShowDialog(this);
		}

		void NovoProdutoClick(object sender, EventArgs e)
		{
			var cadastrarProduto = new CadastrarProduto();
			cadastrarProduto.ShowDialog(this);
		}

		void ListarNotasClick(object sender, EventArgs e)
		{
			var listarNotas = new ListarNotas();
			listarNotas.ShowDialog(this);
		}

		void EmitirClick(object sender, EventArgs e)
		{
			var emitir = new Emitir();
			emitir.ShowDialog(this);
		}

		void ConfigurarEmpresaClick(object sender, EventArgs e)
		{
			var configurar = new ConfigurarEmpresa();
			configurar.ShowDialog(this);
		}
	}
}
