namespace SistemaClientes
{
    partial class MonitorAplicativo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorAplicativo));
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.tbCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.tbTipo = new System.Windows.Forms.TextBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btAnuncio = new System.Windows.Forms.PictureBox();
            this.btCupom = new System.Windows.Forms.PictureBox();
            this.btExcluir = new System.Windows.Forms.PictureBox();
            this.btEditar = new System.Windows.Forms.PictureBox();
            this.btLocalizarMotoboy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btAnuncio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCupom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btLocalizarMotoboy)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(7, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(252, 28);
            this.label6.TabIndex = 47;
            this.label6.Text = "Pedidos do Aplicativo:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(748, 391);
            this.dataGridView1.TabIndex = 48;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(12, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 28);
            this.label2.TabIndex = 50;
            this.label2.Text = "Senha:";
            // 
            // tbSenha
            // 
            this.tbSenha.Enabled = false;
            this.tbSenha.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbSenha.Location = new System.Drawing.Point(103, 437);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.Size = new System.Drawing.Size(277, 30);
            this.tbSenha.TabIndex = 51;
            // 
            // tbCliente
            // 
            this.tbCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCliente.Enabled = false;
            this.tbCliente.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbCliente.Location = new System.Drawing.Point(103, 473);
            this.tbCliente.MaxLength = 30;
            this.tbCliente.Name = "tbCliente";
            this.tbCliente.Size = new System.Drawing.Size(277, 30);
            this.tbCliente.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(12, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 28);
            this.label1.TabIndex = 50;
            this.label1.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(12, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 28);
            this.label3.TabIndex = 50;
            this.label3.Text = "Valor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(12, 544);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 28);
            this.label4.TabIndex = 50;
            this.label4.Text = "Tipo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(12, 580);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 28);
            this.label5.TabIndex = 50;
            this.label5.Text = "Status:";
            // 
            // tbValor
            // 
            this.tbValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbValor.Enabled = false;
            this.tbValor.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbValor.Location = new System.Drawing.Point(103, 509);
            this.tbValor.MaxLength = 30;
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(277, 30);
            this.tbValor.TabIndex = 58;
            // 
            // tbTipo
            // 
            this.tbTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTipo.Enabled = false;
            this.tbTipo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbTipo.Location = new System.Drawing.Point(103, 545);
            this.tbTipo.MaxLength = 30;
            this.tbTipo.Name = "tbTipo";
            this.tbTipo.Size = new System.Drawing.Size(277, 30);
            this.tbTipo.TabIndex = 58;
            // 
            // tbStatus
            // 
            this.tbStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbStatus.Enabled = false;
            this.tbStatus.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbStatus.Location = new System.Drawing.Point(103, 581);
            this.tbStatus.MaxLength = 30;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(277, 30);
            this.tbStatus.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(139, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 23);
            this.label7.TabIndex = 50;
            this.label7.Text = "Informações";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(386, 434);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 249);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(7, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 19);
            this.label12.TabIndex = 50;
            this.label12.Text = "Finalizado:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.SeaGreen;
            this.label10.Location = new System.Drawing.Point(7, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 19);
            this.label10.TabIndex = 50;
            this.label10.Text = "Pronto:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Orange;
            this.label15.Location = new System.Drawing.Point(7, 202);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(258, 19);
            this.label15.TabIndex = 50;
            this.label15.Text = "O pedido foi retirado ou entregue";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Orange;
            this.label14.Location = new System.Drawing.Point(7, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(330, 19);
            this.label14.TabIndex = 50;
            this.label14.Text = "Pedido pronto para ser retirado/consumido";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Orange;
            this.label13.Location = new System.Drawing.Point(6, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(340, 19);
            this.label13.TabIndex = 50;
            this.label13.Text = "O motoboy saiu com o pedido para entregar";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Orange;
            this.label11.Location = new System.Drawing.Point(7, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(359, 19);
            this.label11.TabIndex = 50;
            this.label11.Text = "O pedido está sendo preparado no restaurante";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Chocolate;
            this.label9.Location = new System.Drawing.Point(7, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 19);
            this.label9.TabIndex = 50;
            this.label9.Text = "Saiu para entrega:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(6, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 19);
            this.label8.TabIndex = 50;
            this.label8.Text = "Em preparação:";
            // 
            // btAnuncio
            // 
            this.btAnuncio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnuncio.Image = global::SistemaClientes.Properties.Resources.BotaoAnuncio;
            this.btAnuncio.Location = new System.Drawing.Point(250, 624);
            this.btAnuncio.Name = "btAnuncio";
            this.btAnuncio.Size = new System.Drawing.Size(62, 61);
            this.btAnuncio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btAnuncio.TabIndex = 54;
            this.btAnuncio.TabStop = false;
            this.btAnuncio.Click += new System.EventHandler(this.btAnuncio_Click);
            // 
            // btCupom
            // 
            this.btCupom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCupom.Image = global::SistemaClientes.Properties.Resources.CumpoDeDesconto;
            this.btCupom.Location = new System.Drawing.Point(318, 624);
            this.btCupom.Name = "btCupom";
            this.btCupom.Size = new System.Drawing.Size(62, 61);
            this.btCupom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCupom.TabIndex = 54;
            this.btCupom.TabStop = false;
            this.btCupom.Click += new System.EventHandler(this.btCupom_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Image = global::SistemaClientes.Properties.Resources.Remover;
            this.btExcluir.Location = new System.Drawing.Point(80, 624);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(62, 61);
            this.btExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btExcluir.TabIndex = 54;
            this.btExcluir.TabStop = false;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btEditar
            // 
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.Image = global::SistemaClientes.Properties.Resources.Editar;
            this.btEditar.Location = new System.Drawing.Point(12, 624);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(62, 61);
            this.btEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btEditar.TabIndex = 49;
            this.btEditar.TabStop = false;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btLocalizarMotoboy
            // 
            this.btLocalizarMotoboy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLocalizarMotoboy.Image = global::SistemaClientes.Properties.Resources.btMotoboyMapa;
            this.btLocalizarMotoboy.Location = new System.Drawing.Point(168, 624);
            this.btLocalizarMotoboy.Name = "btLocalizarMotoboy";
            this.btLocalizarMotoboy.Size = new System.Drawing.Size(62, 61);
            this.btLocalizarMotoboy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btLocalizarMotoboy.TabIndex = 54;
            this.btLocalizarMotoboy.TabStop = false;
            this.btLocalizarMotoboy.Click += new System.EventHandler(this.btLocalizarMotoboy_Click);
            // 
            // MonitorAplicativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(773, 704);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.tbTipo);
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.tbCliente);
            this.Controls.Add(this.btLocalizarMotoboy);
            this.Controls.Add(this.btAnuncio);
            this.Controls.Add(this.btCupom);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MonitorAplicativo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor do Aplicativo";
            this.Load += new System.EventHandler(this.MonitorAplicativo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btAnuncio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCupom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btLocalizarMotoboy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox btEditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.PictureBox btExcluir;
        private System.Windows.Forms.TextBox tbCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.TextBox tbTipo;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox btCupom;
        private System.Windows.Forms.PictureBox btAnuncio;
        private System.Windows.Forms.PictureBox btLocalizarMotoboy;
    }
}