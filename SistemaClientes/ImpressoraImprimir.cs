using NewLabelPrinter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class ImpressoraImprimir : Form
    {
        public ImpressoraImprimir()
        {
            InitializeComponent();
        }

        private void AutoPrint()
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
        }
        String titulo, mensagem, rodape;

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        public void recebeTextos(String tit, String msg, String rod)
        {
            titulo = tit;
            mensagem = msg;
            rodape = rod;
        }

        private void ImpressoraImprimir_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Titulo", titulo));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Mensagem", mensagem));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Rodape", rodape));
            this.reportViewer1.RefreshReport();
           
            AutoPrint();

            DialogResult = DialogResult.OK;
        }
    }
}
