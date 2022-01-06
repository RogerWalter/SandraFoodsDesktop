namespace SistemaClientes
{
    partial class Pedido_Add_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pedido_Add_Cliente));
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Orange;
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(341, 62);
            this.label11.TabIndex = 52;
            this.label11.Text = "O cliente com este número de telefone não possui cadastro. ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 59);
            this.label1.TabIndex = 53;
            this.label1.Text = "Gostaria de cadastrá-lo agora?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(297, 205);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 55;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(12, 205);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 54;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // Pedido_Add_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 269);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btConfirmar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pedido_Add_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar cliente";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Pedido_Add_Cliente_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.PictureBox btConfirmar;
    }
}