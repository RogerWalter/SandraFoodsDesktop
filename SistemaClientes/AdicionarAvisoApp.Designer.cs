namespace SistemaClientes
{
    partial class AdicionarAvisoApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarAvisoApp));
            this.btAdd = new System.Windows.Forms.PictureBox();
            this.btExcluir = new System.Windows.Forms.PictureBox();
            this.imagemSelecionada = new System.Windows.Forms.PictureBox();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.tbValidade = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbProgressoDesc = new System.Windows.Forms.Label();
            this.labelPorcentagem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemSelecionada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.Image = global::SistemaClientes.Properties.Resources.Adicionar;
            this.btAdd.Location = new System.Drawing.Point(12, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(61, 61);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btAdd.TabIndex = 26;
            this.btAdd.TabStop = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Image = global::SistemaClientes.Properties.Resources.Remover;
            this.btExcluir.Location = new System.Drawing.Point(446, 12);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(62, 61);
            this.btExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btExcluir.TabIndex = 27;
            this.btExcluir.TabStop = false;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // imagemSelecionada
            // 
            this.imagemSelecionada.Location = new System.Drawing.Point(12, 79);
            this.imagemSelecionada.Name = "imagemSelecionada";
            this.imagemSelecionada.Size = new System.Drawing.Size(496, 301);
            this.imagemSelecionada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagemSelecionada.TabIndex = 28;
            this.imagemSelecionada.TabStop = false;
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(452, 386);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 30;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(12, 386);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 29;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // tbValidade
            // 
            this.tbValidade.Enabled = false;
            this.tbValidade.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbValidade.Location = new System.Drawing.Point(306, 398);
            this.tbValidade.Mask = "00/00/0000";
            this.tbValidade.Name = "tbValidade";
            this.tbValidade.Size = new System.Drawing.Size(78, 30);
            this.tbValidade.TabIndex = 31;
            this.tbValidade.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(126, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 30);
            this.label4.TabIndex = 32;
            this.label4.Text = "Validade do Aviso:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbProgressoDesc
            // 
            this.lbProgressoDesc.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.lbProgressoDesc.ForeColor = System.Drawing.Color.Orange;
            this.lbProgressoDesc.Location = new System.Drawing.Point(126, 46);
            this.lbProgressoDesc.Name = "lbProgressoDesc";
            this.lbProgressoDesc.Size = new System.Drawing.Size(124, 30);
            this.lbProgressoDesc.TabIndex = 33;
            this.lbProgressoDesc.Text = "Carregando: ";
            this.lbProgressoDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbProgressoDesc.Visible = false;
            // 
            // labelPorcentagem
            // 
            this.labelPorcentagem.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.labelPorcentagem.ForeColor = System.Drawing.Color.Orange;
            this.labelPorcentagem.Location = new System.Drawing.Point(286, 46);
            this.labelPorcentagem.Name = "labelPorcentagem";
            this.labelPorcentagem.Size = new System.Drawing.Size(98, 30);
            this.labelPorcentagem.TabIndex = 34;
            this.labelPorcentagem.Text = "0%";
            this.labelPorcentagem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPorcentagem.Visible = false;
            // 
            // AdicionarAvisoApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 450);
            this.Controls.Add(this.labelPorcentagem);
            this.Controls.Add(this.lbProgressoDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbValidade);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btConfirmar);
            this.Controls.Add(this.imagemSelecionada);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdicionarAvisoApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avisos do App";
            this.Load += new System.EventHandler(this.AdicionarAvisoApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemSelecionada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.PictureBox btExcluir;
        private System.Windows.Forms.PictureBox imagemSelecionada;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.MaskedTextBox tbValidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbProgressoDesc;
        private System.Windows.Forms.Label labelPorcentagem;
    }
}