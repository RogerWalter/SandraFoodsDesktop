namespace SistemaClientes
{
    partial class Taxa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Taxa));
            this.labelCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBairro = new System.Windows.Forms.TextBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPesquisa = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btSincronizar = new System.Windows.Forms.PictureBox();
            this.btEditar = new System.Windows.Forms.PictureBox();
            this.btExcluir = new System.Windows.Forms.PictureBox();
            this.btAdd = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSincronizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.labelCliente.ForeColor = System.Drawing.Color.Orange;
            this.labelCliente.Location = new System.Drawing.Point(41, 51);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(87, 28);
            this.labelCliente.TabIndex = 5;
            this.labelCliente.Text = "Bairro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(41, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Valor:";
            // 
            // tbBairro
            // 
            this.tbBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBairro.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbBairro.Location = new System.Drawing.Point(139, 52);
            this.tbBairro.MaxLength = 30;
            this.tbBairro.Name = "tbBairro";
            this.tbBairro.Size = new System.Drawing.Size(267, 30);
            this.tbBairro.TabIndex = 11;
            this.tbBairro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBairro_KeyUp);
            // 
            // tbValor
            // 
            this.tbValor.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbValor.Location = new System.Drawing.Point(139, 88);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(135, 30);
            this.tbValor.TabIndex = 18;
            this.tbValor.Enter += new System.EventHandler(this.tbValor_Enter);
            this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
            this.tbValor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyUp);
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCodigo);
            this.groupBox1.Controls.Add(this.labelCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btCancelar);
            this.groupBox1.Controls.Add(this.tbBairro);
            this.groupBox1.Controls.Add(this.tbValor);
            this.groupBox1.Controls.Add(this.btConfirmar);
            this.groupBox1.Location = new System.Drawing.Point(11, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 206);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(34, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 28);
            this.label2.TabIndex = 25;
            this.label2.Text = "Código:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbCodigo
            // 
            this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCodigo.Enabled = false;
            this.tbCodigo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbCodigo.Location = new System.Drawing.Point(139, 16);
            this.tbCodigo.MaxLength = 30;
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(135, 30);
            this.tbCodigo.TabIndex = 26;
            this.tbCodigo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(351, 148);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 24;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(11, 148);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 23;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
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
            this.dataGridView1.Location = new System.Drawing.Point(438, 79);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(399, 463);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(433, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(293, 28);
            this.label6.TabIndex = 49;
            this.label6.Text = "Pesquisar taxa por bairro:";
            // 
            // tbPesquisa
            // 
            this.tbPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPesquisa.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbPesquisa.Location = new System.Drawing.Point(438, 43);
            this.tbPesquisa.Name = "tbPesquisa";
            this.tbPesquisa.Size = new System.Drawing.Size(399, 30);
            this.tbPesquisa.TabIndex = 48;
            this.tbPesquisa.TextChanged += new System.EventHandler(this.tbPesquisa_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaClientes.Properties.Resources.AdornoTaxas;
            this.pictureBox1.Location = new System.Drawing.Point(94, 317);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 225);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btSincronizar
            // 
            this.btSincronizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSincronizar.Image = global::SistemaClientes.Properties.Resources.Atualizar;
            this.btSincronizar.Location = new System.Drawing.Point(11, 12);
            this.btSincronizar.Name = "btSincronizar";
            this.btSincronizar.Size = new System.Drawing.Size(65, 65);
            this.btSincronizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btSincronizar.TabIndex = 50;
            this.btSincronizar.TabStop = false;
            this.btSincronizar.Click += new System.EventHandler(this.btSincronizar_Click);
            // 
            // btEditar
            // 
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.Image = global::SistemaClientes.Properties.Resources.Editar;
            this.btEditar.Location = new System.Drawing.Point(367, 12);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(65, 65);
            this.btEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btEditar.TabIndex = 23;
            this.btEditar.TabStop = false;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Image = global::SistemaClientes.Properties.Resources.Remover;
            this.btExcluir.Location = new System.Drawing.Point(296, 12);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(65, 65);
            this.btExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btExcluir.TabIndex = 23;
            this.btExcluir.TabStop = false;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAdd
            // 
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.Image = global::SistemaClientes.Properties.Resources.Adicionar;
            this.btAdd.Location = new System.Drawing.Point(225, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(65, 65);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btAdd.TabIndex = 33;
            this.btAdd.TabStop = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Taxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btSincronizar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPesquisa);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Taxa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taxas";
            this.Load += new System.EventHandler(this.Taxa_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Taxa_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSincronizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.PictureBox btEditar;
        private System.Windows.Forms.PictureBox btExcluir;
        private System.Windows.Forms.TextBox tbBairro;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPesquisa;
        private System.Windows.Forms.PictureBox btSincronizar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}