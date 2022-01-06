namespace SistemaClientes
{
    partial class CupomDeDesconto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CupomDeDesconto));
            this.btSincronizar = new System.Windows.Forms.PictureBox();
            this.btEditar = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btExcluir = new System.Windows.Forms.PictureBox();
            this.btAdd = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbValidade = new System.Windows.Forms.MaskedTextBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMinimo = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUnico = new System.Windows.Forms.CheckBox();
            this.toolTipUnico = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btSincronizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            this.SuspendLayout();
            // 
            // btSincronizar
            // 
            this.btSincronizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSincronizar.Image = global::SistemaClientes.Properties.Resources.Atualizar;
            this.btSincronizar.Location = new System.Drawing.Point(12, 12);
            this.btSincronizar.Name = "btSincronizar";
            this.btSincronizar.Size = new System.Drawing.Size(65, 65);
            this.btSincronizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btSincronizar.TabIndex = 58;
            this.btSincronizar.TabStop = false;
            this.btSincronizar.Click += new System.EventHandler(this.btSincronizar_Click);
            // 
            // btEditar
            // 
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.Image = global::SistemaClientes.Properties.Resources.Editar;
            this.btEditar.Location = new System.Drawing.Point(368, 12);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(65, 65);
            this.btEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btEditar.TabIndex = 51;
            this.btEditar.TabStop = false;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(462, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(399, 463);
            this.dataGridView1.TabIndex = 55;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btExcluir
            // 
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Image = global::SistemaClientes.Properties.Resources.Remover;
            this.btExcluir.Location = new System.Drawing.Point(297, 12);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(65, 65);
            this.btExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btExcluir.TabIndex = 52;
            this.btExcluir.TabStop = false;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAdd
            // 
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.Image = global::SistemaClientes.Properties.Resources.Adicionar;
            this.btAdd.Location = new System.Drawing.Point(226, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(65, 65);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btAdd.TabIndex = 53;
            this.btAdd.TabStop = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUnico);
            this.groupBox1.Controls.Add(this.tbValidade);
            this.groupBox1.Controls.Add(this.cbTipo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCodigo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelCliente);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbMinimo);
            this.groupBox1.Controls.Add(this.btCancelar);
            this.groupBox1.Controls.Add(this.tbDescricao);
            this.groupBox1.Controls.Add(this.tbValor);
            this.groupBox1.Controls.Add(this.btConfirmar);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 392);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // tbValidade
            // 
            this.tbValidade.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbValidade.Location = new System.Drawing.Point(140, 89);
            this.tbValidade.Mask = "00/00/0000";
            this.tbValidade.Name = "tbValidade";
            this.tbValidade.Size = new System.Drawing.Size(267, 30);
            this.tbValidade.TabIndex = 30;
            this.tbValidade.ValidatingType = typeof(System.DateTime);
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(140, 161);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(267, 31);
            this.cbTipo.TabIndex = 27;
            this.cbTipo.SelectedValueChanged += new System.EventHandler(this.cbTipo_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(40, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 28);
            this.label2.TabIndex = 25;
            this.label2.Text = "Código:";
            // 
            // tbCodigo
            // 
            this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCodigo.Enabled = false;
            this.tbCodigo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbCodigo.Location = new System.Drawing.Point(140, 17);
            this.tbCodigo.MaxLength = 30;
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(135, 30);
            this.tbCodigo.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(68, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 28);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tipo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(36, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "Minimo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(21, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Validade:";
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.labelCliente.ForeColor = System.Drawing.Color.Orange;
            this.labelCliente.Location = new System.Drawing.Point(6, 52);
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
            this.label1.Location = new System.Drawing.Point(57, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Valor:";
            // 
            // tbMinimo
            // 
            this.tbMinimo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbMinimo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbMinimo.Location = new System.Drawing.Point(140, 125);
            this.tbMinimo.MaxLength = 30;
            this.tbMinimo.Name = "tbMinimo";
            this.tbMinimo.Size = new System.Drawing.Size(135, 30);
            this.tbMinimo.TabIndex = 11;
            this.tbMinimo.Enter += new System.EventHandler(this.tbMinimo_Enter);
            this.tbMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMinimo_KeyPress);
            this.tbMinimo.Leave += new System.EventHandler(this.tbMinimo_Leave);
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(382, 334);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 24;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // tbDescricao
            // 
            this.tbDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDescricao.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbDescricao.Location = new System.Drawing.Point(140, 53);
            this.tbDescricao.MaxLength = 30;
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(267, 30);
            this.tbDescricao.TabIndex = 11;
            // 
            // tbValor
            // 
            this.tbValor.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.tbValor.Location = new System.Drawing.Point(140, 197);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(135, 30);
            this.tbValor.TabIndex = 18;
            this.tbValor.Enter += new System.EventHandler(this.tbValor_Enter);
            this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
            this.tbValor.Leave += new System.EventHandler(this.tbValor_Leave);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(6, 334);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 23;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(57, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 28);
            this.label6.TabIndex = 6;
            this.label6.Text = "Único:";
            this.toolTipUnico.SetToolTip(this.label6, "Ao marcar a caixa ao lado, fará com que este cupom possa ser usado uma única vez " +
        "por cada cliente.");
            // 
            // cbUnico
            // 
            this.cbUnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbUnico.Location = new System.Drawing.Point(140, 233);
            this.cbUnico.Name = "cbUnico";
            this.cbUnico.Size = new System.Drawing.Size(31, 28);
            this.cbUnico.TabIndex = 31;
            this.cbUnico.UseVisualStyleBackColor = true;
            this.cbUnico.CheckedChanged += new System.EventHandler(this.cbUnico_CheckedChanged);
            // 
            // toolTipUnico
            // 
            this.toolTipUnico.ToolTipTitle = "Parâmetro Cupom Único";
            // 
            // CupomDeDesconto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(873, 490);
            this.Controls.Add(this.btSincronizar);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CupomDeDesconto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cupons de Desconto";
            this.Load += new System.EventHandler(this.CupomDeDesconto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btSincronizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btSincronizar;
        private System.Windows.Forms.PictureBox btEditar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox btExcluir;
        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.TextBox tbDescricao;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMinimo;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MaskedTextBox tbValidade;
        private System.Windows.Forms.CheckBox cbUnico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTipUnico;
    }
}