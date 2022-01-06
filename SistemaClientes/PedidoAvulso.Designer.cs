namespace SistemaClientes
{
    partial class PedidoAvulso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidoAvulso));
            this.label1 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.btConfirmar = new System.Windows.Forms.PictureBox();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btRemItem = new System.Windows.Forms.PictureBox();
            this.btAddItem = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTotal = new System.Windows.Forms.Label();
            this.cbImprimeOuNao = new System.Windows.Forms.CheckBox();
            this.btPesquisar = new System.Windows.Forms.PictureBox();
            this.btReimprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRemItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAddItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btPesquisar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(12, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 43;
            this.label1.Text = "Total dos itens:";
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(433, 427);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 48;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConfirmar.Image = global::SistemaClientes.Properties.Resources.Confirmar;
            this.btConfirmar.Location = new System.Drawing.Point(16, 427);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(56, 52);
            this.btConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btConfirmar.TabIndex = 47;
            this.btConfirmar.TabStop = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // tbSenha
            // 
            this.tbSenha.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.tbSenha.Location = new System.Drawing.Point(215, 10);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.Size = new System.Drawing.Size(111, 45);
            this.tbSenha.TabIndex = 57;
            this.tbSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSenha_KeyPress);
            this.tbSenha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSenha_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(12, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 28);
            this.label6.TabIndex = 58;
            this.label6.Text = "Senha do Pedido:";
            // 
            // btRemItem
            // 
            this.btRemItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRemItem.Image = global::SistemaClientes.Properties.Resources.RemoverItem;
            this.btRemItem.Location = new System.Drawing.Point(12, 164);
            this.btRemItem.Name = "btRemItem";
            this.btRemItem.Size = new System.Drawing.Size(56, 52);
            this.btRemItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btRemItem.TabIndex = 61;
            this.btRemItem.TabStop = false;
            this.btRemItem.Click += new System.EventHandler(this.btRemItem_Click);
            // 
            // btAddItem
            // 
            this.btAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddItem.Image = global::SistemaClientes.Properties.Resources.AdicionarItem;
            this.btAddItem.Location = new System.Drawing.Point(12, 106);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(56, 52);
            this.btAddItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btAddItem.TabIndex = 60;
            this.btAddItem.TabStop = false;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.dataGridView1.Location = new System.Drawing.Point(69, 106);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(420, 259);
            this.dataGridView1.TabIndex = 59;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // labelTotal
            // 
            this.labelTotal.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            this.labelTotal.ForeColor = System.Drawing.Color.Black;
            this.labelTotal.Location = new System.Drawing.Point(198, 368);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(291, 56);
            this.labelTotal.TabIndex = 62;
            this.labelTotal.Text = "-";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbImprimeOuNao
            // 
            this.cbImprimeOuNao.AutoSize = true;
            this.cbImprimeOuNao.BackColor = System.Drawing.Color.Transparent;
            this.cbImprimeOuNao.BackgroundImage = global::SistemaClientes.Properties.Resources.N_Imprimir;
            this.cbImprimeOuNao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbImprimeOuNao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbImprimeOuNao.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.cbImprimeOuNao.Location = new System.Drawing.Point(78, 432);
            this.cbImprimeOuNao.Name = "cbImprimeOuNao";
            this.cbImprimeOuNao.Size = new System.Drawing.Size(81, 42);
            this.cbImprimeOuNao.TabIndex = 63;
            this.cbImprimeOuNao.Text = "     ";
            this.cbImprimeOuNao.UseVisualStyleBackColor = false;
            this.cbImprimeOuNao.CheckedChanged += new System.EventHandler(this.cbImprimeOuNao_CheckedChanged);
            // 
            // btPesquisar
            // 
            this.btPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPesquisar.Image = global::SistemaClientes.Properties.Resources.Procurar;
            this.btPesquisar.Location = new System.Drawing.Point(332, 10);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(48, 45);
            this.btPesquisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btPesquisar.TabIndex = 64;
            this.btPesquisar.TabStop = false;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // btReimprimir
            // 
            this.btReimprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReimprimir.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.btReimprimir.ForeColor = System.Drawing.Color.Orange;
            this.btReimprimir.Location = new System.Drawing.Point(383, 10);
            this.btReimprimir.Margin = new System.Windows.Forms.Padding(0);
            this.btReimprimir.Name = "btReimprimir";
            this.btReimprimir.Size = new System.Drawing.Size(106, 45);
            this.btReimprimir.TabIndex = 65;
            this.btReimprimir.Text = "Reimprimir Senha";
            this.btReimprimir.UseVisualStyleBackColor = true;
            this.btReimprimir.Click += new System.EventHandler(this.btReimprimir_Click);
            // 
            // PedidoAvulso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(501, 490);
            this.Controls.Add(this.btReimprimir);
            this.Controls.Add(this.btPesquisar);
            this.Controls.Add(this.cbImprimeOuNao);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.btRemItem);
            this.Controls.Add(this.btAddItem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(517, 529);
            this.MinimumSize = new System.Drawing.Size(517, 529);
            this.Name = "PedidoAvulso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar item à comanda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PedidoAvulso_FormClosing);
            this.Load += new System.EventHandler(this.PedidoAvulso_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PedidoAvulso_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btConfirmar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRemItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAddItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btPesquisar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btCancelar;
        private System.Windows.Forms.PictureBox btConfirmar;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox btRemItem;
        private System.Windows.Forms.PictureBox btAddItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.CheckBox cbImprimeOuNao;
        private System.Windows.Forms.PictureBox btPesquisar;
        private System.Windows.Forms.Button btReimprimir;
    }
}