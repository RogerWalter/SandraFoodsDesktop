namespace SistemaClientes
{
    partial class Configuracoes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracoes));
            this.labelCliente = new System.Windows.Forms.Label();
            this.toolTipPar1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cbMot = new System.Windows.Forms.CheckBox();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbRetirada = new System.Windows.Forms.TextBox();
            this.tbEntrega = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDom = new System.Windows.Forms.CheckBox();
            this.cbSex = new System.Windows.Forms.CheckBox();
            this.cbSab = new System.Windows.Forms.CheckBox();
            this.cbQua = new System.Windows.Forms.CheckBox();
            this.cbQui = new System.Windows.Forms.CheckBox();
            this.cbTer = new System.Windows.Forms.CheckBox();
            this.cbSeg = new System.Windows.Forms.CheckBox();
            this.tbInicio = new System.Windows.Forms.MaskedTextBox();
            this.tbFim = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSincronizar = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbManutencao = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCliente
            // 
            this.labelCliente.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.labelCliente.ForeColor = System.Drawing.Color.Orange;
            this.labelCliente.Location = new System.Drawing.Point(12, 9);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(149, 30);
            this.labelCliente.TabIndex = 6;
            this.labelCliente.Text = "Motoboy Único:";
            this.labelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTipPar1.SetToolTip(this.labelCliente, resources.GetString("labelCliente.ToolTip"));
            // 
            // toolTipPar1
            // 
            this.toolTipPar1.AutoPopDelay = 10000;
            this.toolTipPar1.ForeColor = System.Drawing.Color.Orange;
            this.toolTipPar1.InitialDelay = 500;
            this.toolTipPar1.ReshowDelay = 100;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(12, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(314, 30);
            this.label5.TabIndex = 29;
            this.label5.Text = "Sincronizar com o Aplicativo:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTipPar1.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // cbMot
            // 
            this.cbMot.AutoSize = true;
            this.cbMot.Location = new System.Drawing.Point(470, 20);
            this.cbMot.Name = "cbMot";
            this.cbMot.Size = new System.Drawing.Size(15, 14);
            this.cbMot.TabIndex = 7;
            this.cbMot.UseVisualStyleBackColor = true;
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(435, 410);
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
            this.btConfirmar.Location = new System.Drawing.Point(12, 410);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 25;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRetirada);
            this.groupBox1.Controls.Add(this.tbEntrega);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Orange;
            this.groupBox1.Location = new System.Drawing.Point(7, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 105);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prazo de Entrega/Retirada";
            // 
            // tbRetirada
            // 
            this.tbRetirada.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbRetirada.Location = new System.Drawing.Point(424, 65);
            this.tbRetirada.MaxLength = 4;
            this.tbRetirada.Name = "tbRetirada";
            this.tbRetirada.Size = new System.Drawing.Size(54, 30);
            this.tbRetirada.TabIndex = 19;
            this.tbRetirada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEntrega_KeyPress);
            // 
            // tbEntrega
            // 
            this.tbEntrega.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbEntrega.Location = new System.Drawing.Point(424, 29);
            this.tbEntrega.MaxLength = 4;
            this.tbEntrega.Name = "tbEntrega";
            this.tbEntrega.Size = new System.Drawing.Size(54, 30);
            this.tbEntrega.TabIndex = 19;
            this.tbEntrega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEntrega_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tempo em minutos para Retirada:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tempo em minutos para Entrega:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbDom);
            this.groupBox2.Controls.Add(this.cbSex);
            this.groupBox2.Controls.Add(this.cbSab);
            this.groupBox2.Controls.Add(this.cbQua);
            this.groupBox2.Controls.Add(this.cbQui);
            this.groupBox2.Controls.Add(this.cbTer);
            this.groupBox2.Controls.Add(this.cbSeg);
            this.groupBox2.Controls.Add(this.tbInicio);
            this.groupBox2.Controls.Add(this.tbFim);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.Orange;
            this.groupBox2.Location = new System.Drawing.Point(7, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 150);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Horário de Atendimento";
            // 
            // cbDom
            // 
            this.cbDom.AutoSize = true;
            this.cbDom.Location = new System.Drawing.Point(415, 115);
            this.cbDom.Name = "cbDom";
            this.cbDom.Size = new System.Drawing.Size(68, 27);
            this.cbDom.TabIndex = 36;
            this.cbDom.Text = "Dom";
            this.cbDom.UseVisualStyleBackColor = true;
            // 
            // cbSex
            // 
            this.cbSex.AutoSize = true;
            this.cbSex.Location = new System.Drawing.Point(277, 115);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(63, 27);
            this.cbSex.TabIndex = 35;
            this.cbSex.Text = "Sex";
            this.cbSex.UseVisualStyleBackColor = true;
            // 
            // cbSab
            // 
            this.cbSab.AutoSize = true;
            this.cbSab.Location = new System.Drawing.Point(346, 115);
            this.cbSab.Name = "cbSab";
            this.cbSab.Size = new System.Drawing.Size(63, 27);
            this.cbSab.TabIndex = 34;
            this.cbSab.Text = "Sáb";
            this.cbSab.UseVisualStyleBackColor = true;
            // 
            // cbQua
            // 
            this.cbQua.AutoSize = true;
            this.cbQua.Location = new System.Drawing.Point(143, 115);
            this.cbQua.Name = "cbQua";
            this.cbQua.Size = new System.Drawing.Size(64, 27);
            this.cbQua.TabIndex = 33;
            this.cbQua.Text = "Qua";
            this.cbQua.UseVisualStyleBackColor = true;
            // 
            // cbQui
            // 
            this.cbQui.AutoSize = true;
            this.cbQui.Location = new System.Drawing.Point(213, 115);
            this.cbQui.Name = "cbQui";
            this.cbQui.Size = new System.Drawing.Size(58, 27);
            this.cbQui.TabIndex = 32;
            this.cbQui.Text = "Qui";
            this.cbQui.UseVisualStyleBackColor = true;
            // 
            // cbTer
            // 
            this.cbTer.AutoSize = true;
            this.cbTer.Location = new System.Drawing.Point(79, 115);
            this.cbTer.Name = "cbTer";
            this.cbTer.Size = new System.Drawing.Size(58, 27);
            this.cbTer.TabIndex = 31;
            this.cbTer.Text = "Ter";
            this.cbTer.UseVisualStyleBackColor = true;
            // 
            // cbSeg
            // 
            this.cbSeg.AutoSize = true;
            this.cbSeg.Location = new System.Drawing.Point(10, 115);
            this.cbSeg.Name = "cbSeg";
            this.cbSeg.Size = new System.Drawing.Size(63, 27);
            this.cbSeg.TabIndex = 30;
            this.cbSeg.Text = "Seg";
            this.cbSeg.UseVisualStyleBackColor = true;
            // 
            // tbInicio
            // 
            this.tbInicio.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbInicio.Location = new System.Drawing.Point(424, 29);
            this.tbInicio.Mask = "00:00";
            this.tbInicio.Name = "tbInicio";
            this.tbInicio.Size = new System.Drawing.Size(54, 30);
            this.tbInicio.TabIndex = 29;
            this.tbInicio.ValidatingType = typeof(System.DateTime);
            this.tbInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInicio_KeyPress);
            // 
            // tbFim
            // 
            this.tbFim.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbFim.Location = new System.Drawing.Point(424, 65);
            this.tbFim.Mask = "00:00";
            this.tbFim.Name = "tbFim";
            this.tbFim.Size = new System.Drawing.Size(54, 30);
            this.tbFim.TabIndex = 29;
            this.tbFim.ValidatingType = typeof(System.DateTime);
            this.tbFim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInicio_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(5, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fim do Atendimento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(391, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Início do Atendimento:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbSincronizar
            // 
            this.cbSincronizar.AutoSize = true;
            this.cbSincronizar.Location = new System.Drawing.Point(470, 50);
            this.cbSincronizar.Name = "cbSincronizar";
            this.cbSincronizar.Size = new System.Drawing.Size(15, 14);
            this.cbSincronizar.TabIndex = 30;
            this.cbSincronizar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(12, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(314, 30);
            this.label6.TabIndex = 29;
            this.label6.Text = "App em manutenção:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbManutencao
            // 
            this.cbManutencao.AutoSize = true;
            this.cbManutencao.Location = new System.Drawing.Point(470, 80);
            this.cbManutencao.Name = "cbManutencao";
            this.cbManutencao.Size = new System.Drawing.Size(15, 14);
            this.cbManutencao.TabIndex = 30;
            this.cbManutencao.UseVisualStyleBackColor = true;
            this.cbManutencao.CheckedChanged += new System.EventHandler(this.cbManutencao_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Configuracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 474);
            this.Controls.Add(this.cbManutencao);
            this.Controls.Add(this.cbSincronizar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btConfirmar);
            this.Controls.Add(this.cbMot);
            this.Controls.Add(this.labelCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Configuracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.Configuracoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ToolTip toolTipPar1;
        private System.Windows.Forms.CheckBox cbMot;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEntrega;
        private System.Windows.Forms.TextBox tbRetirada;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox tbInicio;
        private System.Windows.Forms.MaskedTextBox tbFim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbDom;
        private System.Windows.Forms.CheckBox cbSex;
        private System.Windows.Forms.CheckBox cbSab;
        private System.Windows.Forms.CheckBox cbQua;
        private System.Windows.Forms.CheckBox cbQui;
        private System.Windows.Forms.CheckBox cbTer;
        private System.Windows.Forms.CheckBox cbSeg;
        private System.Windows.Forms.CheckBox cbSincronizar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbManutencao;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}