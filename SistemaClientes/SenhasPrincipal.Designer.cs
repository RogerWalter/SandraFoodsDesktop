namespace SistemaClientes
{
    partial class SenhasPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SenhasPrincipal));
            this.label2 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.btAbrirPainel = new System.Windows.Forms.Button();
            this.btLimpaPainel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(88, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 28);
            this.label2.TabIndex = 37;
            this.label2.Text = "Inserir senha no painel:";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            this.tbCodigo.Location = new System.Drawing.Point(168, 40);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(102, 64);
            this.tbCodigo.TabIndex = 38;
            this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
            this.tbCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyUp);
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(364, 179);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 36;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(12, 179);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 35;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // btAbrirPainel
            // 
            this.btAbrirPainel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAbrirPainel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAbrirPainel.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.btAbrirPainel.ForeColor = System.Drawing.Color.Orange;
            this.btAbrirPainel.Location = new System.Drawing.Point(103, 179);
            this.btAbrirPainel.Name = "btAbrirPainel";
            this.btAbrirPainel.Size = new System.Drawing.Size(228, 52);
            this.btAbrirPainel.TabIndex = 40;
            this.btAbrirPainel.Text = "Abrir Painel";
            this.btAbrirPainel.UseVisualStyleBackColor = true;
            this.btAbrirPainel.Click += new System.EventHandler(this.btAbrirPainel_Click);
            // 
            // btLimpaPainel
            // 
            this.btLimpaPainel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLimpaPainel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpaPainel.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.btLimpaPainel.ForeColor = System.Drawing.Color.Orange;
            this.btLimpaPainel.Location = new System.Drawing.Point(103, 121);
            this.btLimpaPainel.Name = "btLimpaPainel";
            this.btLimpaPainel.Size = new System.Drawing.Size(228, 52);
            this.btLimpaPainel.TabIndex = 41;
            this.btLimpaPainel.Text = "Limpar Painel";
            this.btLimpaPainel.UseVisualStyleBackColor = true;
            this.btLimpaPainel.Click += new System.EventHandler(this.btLimpaPainel_Click);
            // 
            // SenhasPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(437, 243);
            this.Controls.Add(this.btLimpaPainel);
            this.Controls.Add(this.btAbrirPainel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCodigo);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SenhasPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Senhas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SenhasPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.SenhasPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.Button btAbrirPainel;
        private System.Windows.Forms.Button btLimpaPainel;
    }
}