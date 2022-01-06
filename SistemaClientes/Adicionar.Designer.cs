namespace SistemaClientes
{
    partial class Adicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adicionar));
            this.label2 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tbQtd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbObs = new System.Windows.Forms.TextBox();
            this.btConsulta = new System.Windows.Forms.PictureBox();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.btAdd = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAcrescimo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbObs2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbObs3 = new System.Windows.Forms.TextBox();
            this.btRemover = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRemover)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 28);
            this.label2.TabIndex = 33;
            this.label2.Text = "Código:";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbCodigo.Location = new System.Drawing.Point(12, 40);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(209, 30);
            this.tbCodigo.TabIndex = 34;
            this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
            this.tbCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyUp);
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.labelCliente.ForeColor = System.Drawing.Color.Orange;
            this.labelCliente.Location = new System.Drawing.Point(7, 73);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(128, 28);
            this.labelCliente.TabIndex = 27;
            this.labelCliente.Text = "Descrição:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(6, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 28;
            this.label1.Text = "Valor:";
            // 
            // tbValor
            // 
            this.tbValor.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbValor.Location = new System.Drawing.Point(11, 424);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(144, 30);
            this.tbValor.TabIndex = 30;
            // 
            // tbDesc
            // 
            this.tbDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDesc.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbDesc.Location = new System.Drawing.Point(11, 104);
            this.tbDesc.MaxLength = 30;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(282, 30);
            this.tbDesc.TabIndex = 29;
            this.tbDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbDesc_KeyUp);
            // 
            // tbQtd
            // 
            this.tbQtd.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbQtd.Location = new System.Drawing.Point(168, 424);
            this.tbQtd.MaxLength = 3;
            this.tbQtd.Name = "tbQtd";
            this.tbQtd.Size = new System.Drawing.Size(123, 30);
            this.tbQtd.TabIndex = 30;
            this.tbQtd.Enter += new System.EventHandler(this.tbQtd_Enter);
            this.tbQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQtd_KeyPress);
            this.tbQtd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbQtd_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(163, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 28);
            this.label3.TabIndex = 28;
            this.label3.Text = "Qtd:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(7, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 28);
            this.label4.TabIndex = 35;
            this.label4.Text = "Observação 1:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbObs
            // 
            this.tbObs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbObs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObs.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbObs.Location = new System.Drawing.Point(11, 168);
            this.tbObs.MaxLength = 33;
            this.tbObs.Name = "tbObs";
            this.tbObs.Size = new System.Drawing.Size(282, 30);
            this.tbObs.TabIndex = 36;
            this.tbObs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbObs_KeyUp);
            // 
            // btConsulta
            // 
            this.btConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConsulta.Image = global::SistemaClientes.Properties.Resources.Procurar;
            this.btConsulta.Location = new System.Drawing.Point(227, 40);
            this.btConsulta.Name = "btConsulta";
            this.btConsulta.Size = new System.Drawing.Size(30, 30);
            this.btConsulta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConsulta.TabIndex = 37;
            this.btConsulta.TabStop = false;
            this.btConsulta.Click += new System.EventHandler(this.btConsulta_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(234, 459);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 32;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(11, 460);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 31;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // btAdd
            // 
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.Image = global::SistemaClientes.Properties.Resources.Adicionar;
            this.btAdd.Location = new System.Drawing.Point(263, 40);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(30, 30);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btAdd.TabIndex = 38;
            this.btAdd.TabStop = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(7, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 28);
            this.label5.TabIndex = 39;
            this.label5.Text = "Acréscimo:";
            // 
            // tbAcrescimo
            // 
            this.tbAcrescimo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbAcrescimo.Location = new System.Drawing.Point(12, 360);
            this.tbAcrescimo.Name = "tbAcrescimo";
            this.tbAcrescimo.Size = new System.Drawing.Size(143, 30);
            this.tbAcrescimo.TabIndex = 40;
            this.tbAcrescimo.Enter += new System.EventHandler(this.tbAcrescimo_Enter);
            this.tbAcrescimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAcrescimo_KeyPress);
            this.tbAcrescimo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbAcrescimo_KeyUp);
            this.tbAcrescimo.Leave += new System.EventHandler(this.tbAcrescimo_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(7, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 28);
            this.label6.TabIndex = 41;
            this.label6.Text = "Observação 2:";
            // 
            // tbObs2
            // 
            this.tbObs2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbObs2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbObs2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObs2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbObs2.Location = new System.Drawing.Point(11, 232);
            this.tbObs2.MaxLength = 33;
            this.tbObs2.Name = "tbObs2";
            this.tbObs2.Size = new System.Drawing.Size(282, 30);
            this.tbObs2.TabIndex = 42;
            this.tbObs2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbObs2_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(6, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 28);
            this.label7.TabIndex = 43;
            this.label7.Text = "Observação 3:";
            // 
            // tbObs3
            // 
            this.tbObs3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbObs3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbObs3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObs3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbObs3.Location = new System.Drawing.Point(10, 296);
            this.tbObs3.MaxLength = 28;
            this.tbObs3.Name = "tbObs3";
            this.tbObs3.Size = new System.Drawing.Size(282, 30);
            this.tbObs3.TabIndex = 44;
            this.tbObs3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbObs3_KeyUp);
            // 
            // btRemover
            // 
            this.btRemover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRemover.Image = global::SistemaClientes.Properties.Resources.Remover;
            this.btRemover.Location = new System.Drawing.Point(130, 460);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(56, 52);
            this.btRemover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btRemover.TabIndex = 45;
            this.btRemover.TabStop = false;
            this.btRemover.Click += new System.EventHandler(this.btRemover_Click);
            // 
            // Adicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(298, 521);
            this.Controls.Add(this.btRemover);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbObs3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbObs2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbAcrescimo);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btConsulta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbObs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCodigo);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbQtd);
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.btConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Adicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo item";
            this.Load += new System.EventHandler(this.Adicionar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Adicionar_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Adicionar_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Adicionar_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.btConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRemover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.TextBox tbQtd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.PictureBox btConsulta;
        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAcrescimo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbObs2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbObs3;
        private System.Windows.Forms.PictureBox btRemover;
    }
}