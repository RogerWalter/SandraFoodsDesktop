namespace SistemaClientes
{
    partial class Relatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relatorio));
            this.RELATORIOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RELATORIO_DIARIO = new SistemaClientes.RELATORIO_DIARIO();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RELATORIOTableAdapter = new SistemaClientes.RELATORIO_DIARIOTableAdapters.RELATORIOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.RELATORIOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RELATORIO_DIARIO)).BeginInit();
            this.SuspendLayout();
            // 
            // RELATORIOBindingSource
            // 
            this.RELATORIOBindingSource.DataMember = "RELATORIO";
            this.RELATORIOBindingSource.DataSource = this.RELATORIO_DIARIO;
            // 
            // RELATORIO_DIARIO
            // 
            this.RELATORIO_DIARIO.DataSetName = "RELATORIO_DIARIO";
            this.RELATORIO_DIARIO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.RELATORIOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaClientes.RelatorioDiario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(830, 385);
            this.reportViewer1.TabIndex = 0;
            // 
            // RELATORIOTableAdapter
            // 
            this.RELATORIOTableAdapter.ClearBeforeFill = true;
            // 
            // Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(830, 385);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Relatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorio";
            this.Load += new System.EventHandler(this.Relatorio_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Relatorio_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.RELATORIOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RELATORIO_DIARIO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RELATORIOBindingSource;
        private RELATORIO_DIARIO RELATORIO_DIARIO;
        private RELATORIO_DIARIOTableAdapters.RELATORIOTableAdapter RELATORIOTableAdapter;
    }
}