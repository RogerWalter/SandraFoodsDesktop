namespace SistemaClientes
{
    partial class Impressora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Impressora));
            this.tbMensagem = new System.Windows.Forms.TextBox();
            this.tbRodape = new System.Windows.Forms.TextBox();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMensagem
            // 
            this.tbMensagem.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.tbMensagem.Location = new System.Drawing.Point(9, 183);
            this.tbMensagem.Margin = new System.Windows.Forms.Padding(0);
            this.tbMensagem.Multiline = true;
            this.tbMensagem.Name = "tbMensagem";
            this.tbMensagem.Size = new System.Drawing.Size(397, 323);
            this.tbMensagem.TabIndex = 0;
            this.tbMensagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMensagem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbMensagem_KeyUp);
            // 
            // tbRodape
            // 
            this.tbRodape.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.tbRodape.Location = new System.Drawing.Point(9, 515);
            this.tbRodape.Margin = new System.Windows.Forms.Padding(0);
            this.tbRodape.Multiline = true;
            this.tbRodape.Name = "tbRodape";
            this.tbRodape.Size = new System.Drawing.Size(397, 102);
            this.tbRodape.TabIndex = 1;
            this.tbRodape.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbRodape.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbRodape_KeyUp);
            // 
            // tbTitulo
            // 
            this.tbTitulo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.tbTitulo.Location = new System.Drawing.Point(9, 136);
            this.tbTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.tbTitulo.Multiline = true;
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(397, 41);
            this.tbTitulo.TabIndex = 2;
            this.tbTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTitulo.TextChanged += new System.EventHandler(this.tbTitulo_TextChanged);
            this.tbTitulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTitulo_KeyPress);
            this.tbTitulo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTitulo_KeyUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::SistemaClientes.Properties.Resources.logo_sandra_foods;
            this.pictureBox2.Location = new System.Drawing.Point(146, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 121);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 55;
            this.pictureBox2.TabStop = false;
            // 
            // Impressora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::SistemaClientes.Properties.Resources.Impressao_Cor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(418, 625);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tbTitulo);
            this.Controls.Add(this.tbRodape);
            this.Controls.Add(this.tbMensagem);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(434, 664);
            this.MinimumSize = new System.Drawing.Size(434, 664);
            this.Name = "Impressora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir";
            this.Load += new System.EventHandler(this.Impressora_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Impressora_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMensagem;
        private System.Windows.Forms.TextBox tbRodape;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}