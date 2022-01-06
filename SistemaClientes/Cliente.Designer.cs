namespace SistemaClientes
{
    partial class Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cliente));
            this.labelCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.tbRua = new System.Windows.Forms.TextBox();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.tbBairro = new System.Windows.Forms.TextBox();
            this.tbReferencia = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.tbCelular = new System.Windows.Forms.TextBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.btEditar = new System.Windows.Forms.PictureBox();
            this.btExcluir = new System.Windows.Forms.PictureBox();
            this.btAdd = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPesquisa = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.labelCliente.ForeColor = System.Drawing.Color.Orange;
            this.labelCliente.Location = new System.Drawing.Point(5, 80);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(82, 28);
            this.labelCliente.TabIndex = 5;
            this.labelCliente.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(5, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Celular:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(5, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rua:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(5, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "Número da Casa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(5, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Bairro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(5, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Complemento:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tbNome
            // 
            this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNome.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbNome.Location = new System.Drawing.Point(10, 111);
            this.tbNome.MaxLength = 40;
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(404, 30);
            this.tbNome.TabIndex = 11;
            this.tbNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyUp);
            this.tbNome.Leave += new System.EventHandler(this.tbNome_Leave);
            // 
            // tbRua
            // 
            this.tbRua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRua.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbRua.Location = new System.Drawing.Point(10, 239);
            this.tbRua.MaxLength = 50;
            this.tbRua.Name = "tbRua";
            this.tbRua.Size = new System.Drawing.Size(404, 30);
            this.tbRua.TabIndex = 19;
            this.tbRua.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbRua_KeyUp);
            // 
            // tbNum
            // 
            this.tbNum.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbNum.Location = new System.Drawing.Point(10, 303);
            this.tbNum.MaxLength = 10;
            this.tbNum.Name = "tbNum";
            this.tbNum.Size = new System.Drawing.Size(81, 30);
            this.tbNum.TabIndex = 20;
            this.tbNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNum_KeyPress);
            this.tbNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNum_KeyUp);
            // 
            // tbBairro
            // 
            this.tbBairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbBairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBairro.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbBairro.Location = new System.Drawing.Point(10, 367);
            this.tbBairro.MaxLength = 30;
            this.tbBairro.Name = "tbBairro";
            this.tbBairro.Size = new System.Drawing.Size(404, 30);
            this.tbBairro.TabIndex = 21;
            this.tbBairro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBairro_KeyUp);
            // 
            // tbReferencia
            // 
            this.tbReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbReferencia.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbReferencia.Location = new System.Drawing.Point(10, 431);
            this.tbReferencia.MaxLength = 100;
            this.tbReferencia.Name = "tbReferencia";
            this.tbReferencia.Size = new System.Drawing.Size(404, 30);
            this.tbReferencia.TabIndex = 22;
            this.tbReferencia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbReferencia_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btCancelar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbNome);
            this.groupBox1.Controls.Add(this.tbCelular);
            this.groupBox1.Controls.Add(this.tbRua);
            this.groupBox1.Controls.Add(this.btConfirmar);
            this.groupBox1.Controls.Add(this.tbCodigo);
            this.groupBox1.Controls.Add(this.tbNum);
            this.groupBox1.Controls.Add(this.tbBairro);
            this.groupBox1.Controls.Add(this.tbReferencia);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 535);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 28);
            this.label6.TabIndex = 8;
            this.label6.Text = "Código";
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(358, 467);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 24;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // tbCelular
            // 
            this.tbCelular.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbCelular.Location = new System.Drawing.Point(10, 175);
            this.tbCelular.MaxLength = 15;
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(186, 30);
            this.tbCelular.TabIndex = 18;
            this.tbCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCelular_KeyPress);
            this.tbCelular.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCelular_KeyUp);
            this.tbCelular.Leave += new System.EventHandler(this.tbCelular_Leave);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(10, 467);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 23;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // tbCodigo
            // 
            this.tbCodigo.Enabled = false;
            this.tbCodigo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbCodigo.Location = new System.Drawing.Point(11, 47);
            this.tbCodigo.MaxLength = 10;
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(82, 30);
            this.tbCodigo.TabIndex = 20;
            this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNum_KeyPress);
            this.tbCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNum_KeyUp);
            // 
            // btEditar
            // 
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.Image = global::SistemaClientes.Properties.Resources.Editar;
            this.btEditar.Location = new System.Drawing.Point(373, 14);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(60, 60);
            this.btEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btEditar.TabIndex = 23;
            this.btEditar.TabStop = false;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Image = global::SistemaClientes.Properties.Resources.Remover;
            this.btExcluir.Location = new System.Drawing.Point(197, 12);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(60, 60);
            this.btExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btExcluir.TabIndex = 23;
            this.btExcluir.TabStop = false;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAdd
            // 
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.Image = global::SistemaClientes.Properties.Resources.Adicionar;
            this.btAdd.Location = new System.Drawing.Point(10, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(60, 60);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btAdd.TabIndex = 23;
            this.btAdd.TabStop = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
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
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.Location = new System.Drawing.Point(439, 51);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(513, 562);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(439, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(313, 28);
            this.label7.TabIndex = 48;
            this.label7.Text = "Pesquisar cliente por nome:";
            // 
            // tbPesquisa
            // 
            this.tbPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPesquisa.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbPesquisa.Location = new System.Drawing.Point(753, 15);
            this.tbPesquisa.Name = "tbPesquisa";
            this.tbPesquisa.Size = new System.Drawing.Size(199, 30);
            this.tbPesquisa.TabIndex = 47;
            this.tbPesquisa.TextChanged += new System.EventHandler(this.tbPesquisa_TextChanged);
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(966, 617);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPesquisa);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btEditar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Cliente_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Cliente_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.TextBox tbRua;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.TextBox tbBairro;
        private System.Windows.Forms.TextBox tbReferencia;
        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.PictureBox btEditar;
        private System.Windows.Forms.PictureBox btExcluir;
        private System.Windows.Forms.PictureBox btCancelar;
        public System.Windows.Forms.TextBox tbCelular;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPesquisa;
    }
}