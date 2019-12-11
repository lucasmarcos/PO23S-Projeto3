/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 12/11/2019
 * Time: 2:15 AM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PO23S_Projeto3.View
{
	partial class CadastrarProduto
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button1;

		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// tableLayoutPanel1
			//
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel1.TabIndex = 0;
			//
			// label1
			//
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(8, 8);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			//
			// label2
			//
			this.label2.Location = new System.Drawing.Point(3, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "label2";
			//
			// label3
			//
			this.label3.Location = new System.Drawing.Point(3, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "label3";
			//
			// textBox1
			//
			this.textBox1.Location = new System.Drawing.Point(103, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(94, 20);
			this.textBox1.TabIndex = 3;
			//
			// textBox2
			//
			this.textBox2.Location = new System.Drawing.Point(103, 36);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(94, 20);
			this.textBox2.TabIndex = 4;
			//
			// textBox3
			//
			this.textBox3.Location = new System.Drawing.Point(103, 69);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(94, 20);
			this.textBox3.TabIndex = 5;
			//
			// button1
			//
			this.button1.Location = new System.Drawing.Point(70, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Cadastrar";
			this.button1.UseVisualStyleBackColor = true;
			//
			// CadastrarProduto
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "CadastrarProduto";
			this.Text = "Novo Produto";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
