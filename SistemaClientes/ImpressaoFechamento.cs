using NewLabelPrinter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class ImpressaoFechamento : Form
    {
        public ImpressaoFechamento()
        {
            InitializeComponent();
        }
        private void AutoPrint()
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
        }

        int motoboy = 0;
        public void recebeMotoboy(int cod)
        {
            motoboy = cod;
        }

        private void ImpressaoFechamento_Load(object sender, EventArgs e)
        {
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);

            // TODO: esta linha de código carrega dados na tabela 'FECHAMENTO_IMPRESSAO.IMPRESSAO_FECHAMENTO'. Você pode movê-la ou removê-la conforme necessário.
            this.IMPRESSAO_FECHAMENTOTableAdapter.Fill(this.FECHAMENTO_IMPRESSAO.IMPRESSAO_FECHAMENTO);

            Motoboys buscado = AcessoFB.fb_pesquisaMotoboyPorCodigo(motoboy);

            Fechamento imprimir = new Fechamento();
            imprimir = AcessoFB.fb_buscaDadosImpressaoFechamento(motoboy, data);

            Decimal totalMotoboy = imprimir.Total + imprimir.Troco;
            
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ENTREGADOR", buscado.Nome.Replace(" ", "")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("QTDENT", imprimir.Entrega.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOTAL", imprimir.Total.ToString("C", CultureInfo.CurrentCulture)));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TAXA", imprimir.Taxa.ToString("C", CultureInfo.CurrentCulture)));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", data));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TROCO", imprimir.Troco.ToString("C", CultureInfo.CurrentCulture)));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOTALMOT", totalMotoboy.ToString("C", CultureInfo.CurrentCulture)));
            this.reportViewer1.RefreshReport();

            AutoPrint();

            DialogResult = DialogResult.OK;
        }
    }
}
