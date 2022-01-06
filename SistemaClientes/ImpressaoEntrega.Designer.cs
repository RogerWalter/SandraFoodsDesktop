namespace SistemaClientes
{
    partial class ImpressaoEntrega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpressaoEntrega));
            this.IMPRESSAO_ITENSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IMPRESSAO = new SistemaClientes.ImpressaoBalcaoObsCustom();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.IMPRESSAO_ITENSTableAdapter = new SistemaClientes.ImpressaoBalcaoObsCustomTableAdapters.IMPRESSAO_ITENSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.IMPRESSAO_ITENSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMPRESSAO)).BeginInit();
            this.SuspendLayout();
            // 
            // IMPRESSAO_ITENSBindingSource
            // 
            this.IMPRESSAO_ITENSBindingSource.DataMember = "IMPRESSAO_ITENS";
            this.IMPRESSAO_ITENSBindingSource.DataSource = this.IMPRESSAO;
            // 
            // IMPRESSAO
            // 
            this.IMPRESSAO.DataSetName = "IMPRESSAO";
            this.IMPRESSAO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.IMPRESSAO_ITENSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaClientes.PedidoEntregaFinal.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(309, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // IMPRESSAO_ITENSTableAdapter
            // 
            this.IMPRESSAO_ITENSTableAdapter.ClearBeforeFill = true;
            // 
            // ImpressaoEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(309, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImpressaoEntrega";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedido";
            this.Load += new System.EventHandler(this.ImpressaoEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IMPRESSAO_ITENSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMPRESSAO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource IMPRESSAO_ITENSBindingSource;
        private ImpressaoBalcaoObsCustom IMPRESSAO;
        private ImpressaoBalcaoObsCustomTableAdapters.IMPRESSAO_ITENSTableAdapter IMPRESSAO_ITENSTableAdapter;
    }
}