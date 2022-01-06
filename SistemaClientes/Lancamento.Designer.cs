namespace SistemaClientes
{
    partial class Lancamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lancamento));
            this.labelCliente = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rbCart = new System.Windows.Forms.RadioButton();
            this.rbDin = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.labelCliente.ForeColor = System.Drawing.Color.Orange;
            this.labelCliente.Location = new System.Drawing.Point(12, 9);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(77, 28);
            this.labelCliente.TabIndex = 25;
            this.labelCliente.Text = "Valor:";
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(319, 110);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 29;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // tbValor
            // 
            this.tbValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbValor.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbValor.Location = new System.Drawing.Point(95, 7);
            this.tbValor.MaxLength = 40;
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(280, 30);
            this.tbValor.TabIndex = 26;
            this.tbValor.Enter += new System.EventHandler(this.tbValor_Enter);
            this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
            this.tbValor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyUp);
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(17, 110);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 28;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(12, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 28);
            this.label10.TabIndex = 52;
            this.label10.Text = "Pagamento:";
            // 
            // rbCart
            // 
            this.rbCart.AutoSize = true;
            this.rbCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbCart.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.rbCart.ForeColor = System.Drawing.Color.Orange;
            this.rbCart.Location = new System.Drawing.Point(285, 59);
            this.rbCart.Name = "rbCart";
            this.rbCart.Size = new System.Drawing.Size(104, 32);
            this.rbCart.TabIndex = 51;
            this.rbCart.TabStop = true;
            this.rbCart.Text = "Cartão";
            this.rbCart.UseVisualStyleBackColor = true;
            this.rbCart.CheckedChanged += new System.EventHandler(this.rbCart_CheckedChanged);
            // 
            // rbDin
            // 
            this.rbDin.AutoSize = true;
            this.rbDin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDin.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.rbDin.ForeColor = System.Drawing.Color.Orange;
            this.rbDin.Location = new System.Drawing.Point(158, 59);
            this.rbDin.Name = "rbDin";
            this.rbDin.Size = new System.Drawing.Size(121, 32);
            this.rbDin.TabIndex = 50;
            this.rbDin.TabStop = true;
            this.rbDin.Text = "Dinheiro";
            this.rbDin.UseVisualStyleBackColor = true;
            this.rbDin.CheckedChanged += new System.EventHandler(this.rbDin_CheckedChanged);
            // 
            // Lancamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 174);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rbCart);
            this.Controls.Add(this.rbDin);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.btConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Lancamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento Manual";
            this.Load += new System.EventHandler(this.Lancamento_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Lancamento_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbCart;
        private System.Windows.Forms.RadioButton rbDin;
    }
}