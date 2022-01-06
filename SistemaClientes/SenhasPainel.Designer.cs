namespace SistemaClientes
{
    partial class SenhasPainel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SenhasPainel));
            this.labelSenha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSenha
            // 
            this.labelSenha.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSenha.Font = new System.Drawing.Font("Arial Black", 100F, System.Drawing.FontStyle.Bold);
            this.labelSenha.ForeColor = System.Drawing.Color.Orange;
            this.labelSenha.Location = new System.Drawing.Point(0, 72);
            this.labelSenha.Margin = new System.Windows.Forms.Padding(0);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(800, 290);
            this.labelSenha.TabIndex = 34;
            this.labelSenha.Text = "--";
            this.labelSenha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Black", 40F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 72);
            this.label1.TabIndex = 35;
            this.label1.Text = "Senha:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCliente
            // 
            this.labelCliente.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCliente.Font = new System.Drawing.Font("Arial Black", 60F, System.Drawing.FontStyle.Bold);
            this.labelCliente.ForeColor = System.Drawing.Color.Orange;
            this.labelCliente.Location = new System.Drawing.Point(0, 362);
            this.labelCliente.Margin = new System.Windows.Forms.Padding(0);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(800, 153);
            this.labelCliente.TabIndex = 36;
            this.labelCliente.Text = "--";
            this.labelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Arial Black", 40F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 76);
            this.label2.TabIndex = 37;
            this.label2.Text = "Cliente:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SenhasPainel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SenhasPainel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sandra Foods";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SenhasPainel_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label labelSenha;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelCliente;
        public System.Windows.Forms.Label label2;
    }
}