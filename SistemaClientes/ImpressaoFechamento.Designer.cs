namespace SistemaClientes
{
    partial class ImpressaoFechamento
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpressaoFechamento));
            this.IMPRESSAO_FECHAMENTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FECHAMENTO_IMPRESSAO = new SistemaClientes.FECHAMENTO_IMPRESSAO();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.IMPRESSAO_FECHAMENTOTableAdapter = new SistemaClientes.FECHAMENTO_IMPRESSAOTableAdapters.IMPRESSAO_FECHAMENTOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.IMPRESSAO_FECHAMENTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FECHAMENTO_IMPRESSAO)).BeginInit();
            this.SuspendLayout();
            // 
            // IMPRESSAO_FECHAMENTOBindingSource
            // 
            this.IMPRESSAO_FECHAMENTOBindingSource.DataMember = "IMPRESSAO_FECHAMENTO";
            this.IMPRESSAO_FECHAMENTOBindingSource.DataSource = this.FECHAMENTO_IMPRESSAO;
            // 
            // FECHAMENTO_IMPRESSAO
            // 
            this.FECHAMENTO_IMPRESSAO.DataSetName = "FECHAMENTO_IMPRESSAO";
            this.FECHAMENTO_IMPRESSAO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.IMPRESSAO_FECHAMENTOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaClientes.ImpressaoFechamento.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(291, 363);
            this.reportViewer1.TabIndex = 0;
            // 
            // IMPRESSAO_FECHAMENTOTableAdapter
            // 
            this.IMPRESSAO_FECHAMENTOTableAdapter.ClearBeforeFill = true;
            // 
            // ImpressaoFechamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(291, 363);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImpressaoFechamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impressão de Fechamento";
            this.Load += new System.EventHandler(this.ImpressaoFechamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IMPRESSAO_FECHAMENTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FECHAMENTO_IMPRESSAO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource IMPRESSAO_FECHAMENTOBindingSource;
        private FECHAMENTO_IMPRESSAO FECHAMENTO_IMPRESSAO;
        private FECHAMENTO_IMPRESSAOTableAdapters.IMPRESSAO_FECHAMENTOTableAdapter IMPRESSAO_FECHAMENTOTableAdapter;
    }
}