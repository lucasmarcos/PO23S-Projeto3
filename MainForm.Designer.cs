namespace PO23S_Projeto3
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button novoCliente;
		private System.Windows.Forms.Button novoProduto;
		private System.Windows.Forms.Button listarNotas;
		private System.Windows.Forms.Button emitir;
		private System.Windows.Forms.Button configurarEmpresa;

		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.novoCliente = new System.Windows.Forms.Button();
			this.novoProduto = new System.Windows.Forms.Button();
			this.listarNotas = new System.Windows.Forms.Button();
			this.emitir = new System.Windows.Forms.Button();
			this.configurarEmpresa = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// novoCliente
			//
			this.novoCliente.Location = new System.Drawing.Point(12, 12);
			this.novoCliente.Name = "novoCliente";
			this.novoCliente.Size = new System.Drawing.Size(179, 23);
			this.novoCliente.TabIndex = 0;
			this.novoCliente.Text = "Cadastrar Novo Cliente";
			this.novoCliente.UseVisualStyleBackColor = true;
			this.novoCliente.Click += new System.EventHandler(this.NovoClienteClick);
			//
			// novoProduto
			//
			this.novoProduto.Location = new System.Drawing.Point(12, 41);
			this.novoProduto.Name = "novoProduto";
			this.novoProduto.Size = new System.Drawing.Size(179, 23);
			this.novoProduto.TabIndex = 1;
			this.novoProduto.Text = "Cadastrar Novo Produto";
			this.novoProduto.UseVisualStyleBackColor = true;
			this.novoProduto.Click += new System.EventHandler(this.NovoProdutoClick);
			//
			// listarNotas
			//
			this.listarNotas.Location = new System.Drawing.Point(12, 70);
			this.listarNotas.Name = "listarNotas";
			this.listarNotas.Size = new System.Drawing.Size(179, 23);
			this.listarNotas.TabIndex = 2;
			this.listarNotas.Text = "Re-imprimir Notas Anteriores";
			this.listarNotas.UseVisualStyleBackColor = true;
			this.listarNotas.Click += new System.EventHandler(this.ListarNotasClick);
			//
			// emitir
			//
			this.emitir.Location = new System.Drawing.Point(12, 99);
			this.emitir.Name = "emitir";
			this.emitir.Size = new System.Drawing.Size(179, 23);
			this.emitir.TabIndex = 3;
			this.emitir.Text = "Emitir Nota Fiscal";
			this.emitir.UseVisualStyleBackColor = true;
			this.emitir.Click += new System.EventHandler(this.EmitirClick);
			//
			// configurarEmpresa
			//
			this.configurarEmpresa.Location = new System.Drawing.Point(12, 128);
			this.configurarEmpresa.Name = "configurarEmpresa";
			this.configurarEmpresa.Size = new System.Drawing.Size(179, 23);
			this.configurarEmpresa.TabIndex = 4;
			this.configurarEmpresa.Text = "Configurar Empresa";
			this.configurarEmpresa.UseVisualStyleBackColor = true;
			this.configurarEmpresa.Click += new System.EventHandler(this.ConfigurarEmpresaClick);
			//
			// MainForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(204, 161);
			this.Controls.Add(this.configurarEmpresa);
			this.Controls.Add(this.emitir);
			this.Controls.Add(this.listarNotas);
			this.Controls.Add(this.novoProduto);
			this.Controls.Add(this.novoCliente);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Bem-vindo";
			this.ResumeLayout(false);
		}
	}
}
