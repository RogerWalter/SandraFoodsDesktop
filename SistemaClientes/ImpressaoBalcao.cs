using NewLabelPrinter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class ImpressaoBalcao : Form
    {
        public ImpressaoBalcao()
        {
            InitializeComponent();
        }
        

        private void AutoPrint()
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
        }

        private void ImpressaoBalcao_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'IMPRESSAO.IMPRESSAO_ITENS'. Você pode movê-la ou removê-la conforme necessário.
            this.IMPRESSAO_ITENSTableAdapter.Fill(this.IMPRESSAO.IMPRESSAO_ITENS);

            DadosImpressao imprimir = new DadosImpressao();
            imprimir = AcessoFB.fb_buscaDadosImpressa();

            if (imprimir.obs == "                                                                                                    ")
            {
                imprimir.obs = " ";
            }

            if(imprimir.obs.Trim() == "-")
            {
                imprimir.obs = "-";
            }

            if (imprimir.desc.Trim() != "R$0,00" && imprimir.desc.Trim() != "R$ 0,00" && imprimir.desc.Trim() != "-")
            {
                imprimir.obs = "DESCONTO: " + imprimir.desc.Trim() + "\n" + imprimir.obs.Trim();
            }

            if (imprimir.obs.Length <= 0)
                imprimir.obs = " ";

            Parametros parametros = AcessoFB.fb_recuperaParametrosSistema();
            DateTime prazoDateTime = DateTime.ParseExact(imprimir.hora.Trim(), "HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime prazoFinalDateTime = prazoDateTime.AddMinutes(parametros.retirada);
            String prazoFinal = prazoFinalDateTime.ToString("HH:mm:ss", CultureInfo.CurrentCulture);

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("SENHA", imprimir.senha));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", imprimir.hora));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("HORA", imprimir.data));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CLIENTE", imprimir.cliente));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOTAL", imprimir.total));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("OBS", imprimir.obs));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("PRAZO", prazoFinal));
            this.reportViewer1.RefreshReport();
            /*
            //CODIGO USADO PARA GERAR O PDF, IMPRIMIR E EXCLUIR, PARA QUE NÃO EXISTAM FALHAS QUANTO AO LAYOUT DO PEDIDO
            byte[] byteViewerPDF = reportViewer1.LocalReport.Render("PDF");

            ExportarRelatorio("PDF", @"C:\Program Files (x86)\StizSoftware\Crepe_da_Sandra\Pedido.pdf");

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = @"C:\Program Files (x86)\StizSoftware\Crepe_da_Sandra\Pedido.pdf"
            };
            p.Start();
            //LEMBRANDO QUE PARA COMPUTADORES MAIS NOVOS, É POSSIVEL USAR SIMPLESMENTE AS LINHAS ABAIXO, SEM A NECESSIDADE DE GERAR O PDF
            */

            AutoPrint();

            DialogResult = DialogResult.OK;
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void IMPRESSAO_ITENSBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        /*
private void ExportarRelatorio(string formato, string nomeArquivo)
{
   byte[] byteViewerPDF = reportViewer1.LocalReport.Render("PDF");
   System.IO.File.WriteAllBytes(nomeArquivo, byteViewerPDF);
}
public void deletaPdf()
{
   if (System.IO.File.Exists(@"C:\Program Files (x86)\StizSoftware\Crepe_da_Sandra\Pedido.pdf"))
   {
       // Use a try block to catch IOExceptions, to
       // handle the case of the file already being
       // opened by another process.
       try
       {
           System.IO.File.Delete(@"C:\Program Files (x86)\StizSoftware\Crepe_da_Sandra\Pedido.pdf");
       }
       catch (System.IO.IOException f)
       {
           MessageBox.Show(f.Message, "Erro");
           return;
       }
   }
}*/
    }
}
