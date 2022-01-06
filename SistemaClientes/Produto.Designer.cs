namespace SistemaClientes
{
    partial class Produtos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produtos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.comboBoxGrupo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInformacoes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btAdd = new System.Windows.Forms.PictureBox();
            this.btEditar = new System.Windows.Forms.PictureBox();
            this.btSincronizar = new System.Windows.Forms.PictureBox();
            this.btExcluir = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPesquisa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbApp = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSincronizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbApp);
            this.groupBox1.Controls.Add(this.comboBoxTipo);
            this.groupBox1.Controls.Add(this.comboBoxGrupo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbInformacoes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCodigo);
            this.groupBox1.Controls.Add(this.labelCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btCancelar);
            this.groupBox1.Controls.Add(this.tbDesc);
            this.groupBox1.Controls.Add(this.tbValor);
            this.groupBox1.Controls.Add(this.btConfirmar);
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 438);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.BackColor = System.Drawing.Color.White;
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.comboBoxTipo.ForeColor = System.Drawing.Color.Orange;
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(138, 183);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(277, 31);
            this.comboBoxTipo.TabIndex = 61;
            // 
            // comboBoxGrupo
            // 
            this.comboBoxGrupo.BackColor = System.Drawing.Color.White;
            this.comboBoxGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.comboBoxGrupo.ForeColor = System.Drawing.Color.Orange;
            this.comboBoxGrupo.FormattingEnabled = true;
            this.comboBoxGrupo.Location = new System.Drawing.Point(138, 145);
            this.comboBoxGrupo.Name = "comboBoxGrupo";
            this.comboBoxGrupo.Size = new System.Drawing.Size(277, 31);
            this.comboBoxGrupo.TabIndex = 60;
            this.comboBoxGrupo.SelectedValueChanged += new System.EventHandler(this.comboBoxGrupo_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(63, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 28);
            this.label5.TabIndex = 29;
            this.label5.Text = "Tipo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(44, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 28);
            this.label4.TabIndex = 29;
            this.label4.Text = "Grupo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(1, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 28);
            this.label3.TabIndex = 27;
            this.label3.Text = "Informações:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbInformacoes
            // 
            this.tbInformacoes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbInformacoes.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbInformacoes.Location = new System.Drawing.Point(6, 290);
            this.tbInformacoes.MaxLength = 300;
            this.tbInformacoes.Multiline = true;
            this.tbInformacoes.Name = "tbInformacoes";
            this.tbInformacoes.Size = new System.Drawing.Size(409, 84);
            this.tbInformacoes.TabIndex = 28;
            this.tbInformacoes.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(35, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 28);
            this.label2.TabIndex = 25;
            this.label2.Text = "Código:";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Enabled = false;
            this.tbCodigo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbCodigo.Location = new System.Drawing.Point(138, 35);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(277, 30);
            this.tbCodigo.TabIndex = 26;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.labelCliente.ForeColor = System.Drawing.Color.Orange;
            this.labelCliente.Location = new System.Drawing.Point(1, 70);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(128, 28);
            this.labelCliente.TabIndex = 5;
            this.labelCliente.Text = "Descrição:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(52, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Valor:";
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(359, 380);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 24;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // tbDesc
            // 
            this.tbDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDesc.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbDesc.Location = new System.Drawing.Point(138, 71);
            this.tbDesc.MaxLength = 30;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(277, 30);
            this.tbDesc.TabIndex = 11;
            this.tbDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbDesc_KeyUp);
            // 
            // tbValor
            // 
            this.tbValor.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbValor.Location = new System.Drawing.Point(138, 107);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(135, 30);
            this.tbValor.TabIndex = 18;
            this.tbValor.Enter += new System.EventHandler(this.tbValor_Enter);
            this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
            this.tbValor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyUp);
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(6, 380);
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
            this.dataGridView1.Location = new System.Drawing.Point(439, 48);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(634, 469);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // btAdd
            // 
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.Image = global::SistemaClientes.Properties.Resources.Adicionar;
            this.btAdd.Location = new System.Drawing.Point(236, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(61, 61);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btAdd.TabIndex = 25;
            this.btAdd.TabStop = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEditar
            // 
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.Image = global::SistemaClientes.Properties.Resources.Editar;
            this.btEditar.Location = new System.Drawing.Point(371, 12);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(62, 61);
            this.btEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btEditar.TabIndex = 23;
            this.btEditar.TabStop = false;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btSincronizar
            // 
            this.btSincronizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSincronizar.Image = global::SistemaClientes.Properties.Resources.Atualizar;
            this.btSincronizar.Location = new System.Drawing.Point(12, 12);
            this.btSincronizar.Name = "btSincronizar";
            this.btSincronizar.Size = new System.Drawing.Size(62, 61);
            this.btSincronizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btSincronizar.TabIndex = 23;
            this.btSincronizar.TabStop = false;
            this.btSincronizar.Click += new System.EventHandler(this.btSincronizar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Image = global::SistemaClientes.Properties.Resources.Remover;
            this.btExcluir.Location = new System.Drawing.Point(303, 12);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(62, 61);
            this.btExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btExcluir.TabIndex = 23;
            this.btExcluir.TabStop = false;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(457, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(288, 28);
            this.label6.TabIndex = 46;
            this.label6.Text = "Pesquisar item por nome:";
            // 
            // tbPesquisa
            // 
            this.tbPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPesquisa.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbPesquisa.Location = new System.Drawing.Point(751, 12);
            this.tbPesquisa.Name = "tbPesquisa";
            this.tbPesquisa.Size = new System.Drawing.Size(322, 30);
            this.tbPesquisa.TabIndex = 45;
            this.tbPesquisa.TextChanged += new System.EventHandler(this.tbPesquisa_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(1, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 28);
            this.label7.TabIndex = 29;
            this.label7.Text = "Aplicativo:";
            // 
            // cbApp
            // 
            this.cbApp.AutoSize = true;
            this.cbApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApp.Location = new System.Drawing.Point(138, 229);
            this.cbApp.Name = "cbApp";
            this.cbApp.Size = new System.Drawing.Size(15, 14);
            this.cbApp.TabIndex = 62;
            this.cbApp.UseVisualStyleBackColor = true;
            this.cbApp.CheckedChanged += new System.EventHandler(this.cbApp_CheckedChanged);
            // 
            // Produtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1085, 529);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPesquisa);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btSincronizar);
            this.Controls.Add(this.btExcluir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Produtos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos";
            this.Load += new System.EventHandler(this.Produtos_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Produtos_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSincronizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.PictureBox btEditar;
        private System.Windows.Forms.PictureBox btExcluir;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbInformacoes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.ComboBox comboBoxGrupo;
        private System.Windows.Forms.PictureBox btSincronizar;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPesquisa;
        private System.Windows.Forms.CheckBox cbApp;
        private System.Windows.Forms.Label label7;
    }
}