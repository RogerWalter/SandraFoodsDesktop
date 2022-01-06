namespace SistemaClientes
{
    partial class ConverterPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConverterPedido));
            this.labelCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labPara = new System.Windows.Forms.Label();
            this.labDe = new System.Windows.Forms.Label();
            this.labSenha = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.tbCelular = new System.Windows.Forms.TextBox();
            this.tbRua = new System.Windows.Forms.TextBox();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.tbBairro = new System.Windows.Forms.TextBox();
            this.tbReferencia = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Arial Black", 15F);
            this.labelCliente.ForeColor = System.Drawing.Color.Orange;
            this.labelCliente.Location = new System.Drawing.Point(12, 9);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(216, 28);
            this.labelCliente.TabIndex = 6;
            this.labelCliente.Text = "Número do Pedido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Para:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "De:";
            // 
            // labPara
            // 
            this.labPara.AutoSize = true;
            this.labPara.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.labPara.ForeColor = System.Drawing.Color.Black;
            this.labPara.Location = new System.Drawing.Point(86, 94);
            this.labPara.Name = "labPara";
            this.labPara.Size = new System.Drawing.Size(106, 28);
            this.labPara.TabIndex = 6;
            this.labPara.Text = "BALCÃO";
            // 
            // labDe
            // 
            this.labDe.AutoSize = true;
            this.labDe.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.labDe.ForeColor = System.Drawing.Color.Black;
            this.labDe.Location = new System.Drawing.Point(66, 50);
            this.labDe.Name = "labDe";
            this.labDe.Size = new System.Drawing.Size(120, 28);
            this.labDe.TabIndex = 6;
            this.labDe.Text = "ENTREGA";
            // 
            // labSenha
            // 
            this.labSenha.AutoSize = true;
            this.labSenha.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.labSenha.ForeColor = System.Drawing.Color.Black;
            this.labSenha.Location = new System.Drawing.Point(234, 9);
            this.labSenha.Name = "labSenha";
            this.labSenha.Size = new System.Drawing.Size(38, 28);
            this.labSenha.TabIndex = 6;
            this.labSenha.Text = "15";
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(216, 376);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 26;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(17, 376);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 25;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 28);
            this.label3.TabIndex = 27;
            this.label3.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 28);
            this.label4.TabIndex = 28;
            this.label4.Text = "Celular:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(6, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 28);
            this.label5.TabIndex = 29;
            this.label5.Text = "Rua:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(24, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 28);
            this.label6.TabIndex = 30;
            this.label6.Text = "Código ou Celular:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(6, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 28);
            this.label7.TabIndex = 31;
            this.label7.Text = "Número da Casa:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(6, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 28);
            this.label8.TabIndex = 32;
            this.label8.Text = "Bairro:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(6, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 28);
            this.label9.TabIndex = 33;
            this.label9.Text = "Complemento:";
            // 
            // tbNome
            // 
            this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNome.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbNome.Location = new System.Drawing.Point(11, 47);
            this.tbNome.MaxLength = 40;
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(404, 30);
            this.tbNome.TabIndex = 34;
            // 
            // tbCelular
            // 
            this.tbCelular.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbCelular.Location = new System.Drawing.Point(11, 111);
            this.tbCelular.MaxLength = 15;
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(186, 30);
            this.tbCelular.TabIndex = 35;
            // 
            // tbRua
            // 
            this.tbRua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRua.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbRua.Location = new System.Drawing.Point(11, 175);
            this.tbRua.MaxLength = 50;
            this.tbRua.Name = "tbRua";
            this.tbRua.Size = new System.Drawing.Size(404, 30);
            this.tbRua.TabIndex = 36;
            // 
            // tbCodigo
            // 
            this.tbCodigo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbCodigo.Location = new System.Drawing.Point(8, 47);
            this.tbCodigo.MaxLength = 12;
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(241, 30);
            this.tbCodigo.TabIndex = 37;
            this.tbCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyUp);
            // 
            // tbNum
            // 
            this.tbNum.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbNum.Location = new System.Drawing.Point(11, 239);
            this.tbNum.MaxLength = 10;
            this.tbNum.Name = "tbNum";
            this.tbNum.Size = new System.Drawing.Size(81, 30);
            this.tbNum.TabIndex = 38;
            // 
            // tbBairro
            // 
            this.tbBairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbBairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBairro.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbBairro.Location = new System.Drawing.Point(11, 303);
            this.tbBairro.MaxLength = 30;
            this.tbBairro.Name = "tbBairro";
            this.tbBairro.Size = new System.Drawing.Size(404, 30);
            this.tbBairro.TabIndex = 39;
            // 
            // tbReferencia
            // 
            this.tbReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbReferencia.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbReferencia.Location = new System.Drawing.Point(11, 367);
            this.tbReferencia.MaxLength = 100;
            this.tbReferencia.Name = "tbReferencia";
            this.tbReferencia.Size = new System.Drawing.Size(404, 30);
            this.tbReferencia.TabIndex = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbReferencia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbBairro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbNum);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbRua);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbCelular);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbNome);
            this.groupBox1.Location = new System.Drawing.Point(278, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 419);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 10F);
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.MaximumSize = new System.Drawing.Size(240, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(227, 96);
            this.label10.TabIndex = 42;
            this.label10.Text = "Esta tela irá converter o pedido da senha acima para seu correspondente. Se for u" +
    "m pedido de BALCÃO para ENTREGA, deve ser selecionado um cliente através de seu " +
    "código ou cadastrá-lo.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(17, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 125);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbCodigo);
            this.groupBox3.Location = new System.Drawing.Point(17, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 100);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            // 
            // ConverterPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(719, 435);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btConfirmar);
            this.Controls.Add(this.labSenha);
            this.Controls.Add(this.labDe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labPara);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConverterPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Converter Pedido:";
            this.Load += new System.EventHandler(this.ConverterPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labPara;
        private System.Windows.Forms.Label labDe;
        private System.Windows.Forms.Label labSenha;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNome;
        public System.Windows.Forms.TextBox tbCelular;
        private System.Windows.Forms.TextBox tbRua;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.TextBox tbBairro;
        private System.Windows.Forms.TextBox tbReferencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}