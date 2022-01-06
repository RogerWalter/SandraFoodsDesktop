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
    public partial class ImpressaoEntrega : Form
    {
        public ImpressaoEntrega()
        {
            InitializeComponent();
        }
        
        private void AutoPrint()
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
        }

        

        private void ImpressaoEntrega_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'IMPRESSAO.IMPRESSAO_ITENS'. Você pode movê-la ou removê-la conforme necessário.
            this.IMPRESSAO_ITENSTableAdapter.Fill(this.IMPRESSAO.IMPRESSAO_ITENS);


            DadosImpressao imprimir = new DadosImpressao();
            imprimir = AcessoFB.fb_buscaDadosImpressa();
            if(imprimir.obs == "                                                                                                    ")
            {
                imprimir.obs = " ";
            }
            if (imprimir.obs.Trim() == "-")
            {
                imprimir.obs = "";
            }
            if (imprimir.desc.Trim() != "R$0,00" && imprimir.desc.Trim() != "R$ 0,00" && imprimir.desc.Trim() != "-")
            {
                imprimir.obs = "DESCONTO: " + imprimir.desc.Trim() + "\n" + imprimir.obs.Trim();
            }
            if (imprimir.obs.Length <= 0)
                imprimir.obs = " ";
            /*if(imprimir.rua.Trim().ToUpper().Substring(0,3) != "RUA")
            {
                imprimir.rua = "RUA " + imprimir.rua;
            }*/
            Parametros parametros = AcessoFB.fb_recuperaParametrosSistema();
            DateTime prazoDateTime = DateTime.ParseExact(imprimir.hora.Trim(), "HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime prazoFinalDateTime = prazoDateTime.AddMinutes(parametros.entrega);
            String prazoFinal = prazoFinalDateTime.ToString("HH:mm:ss", CultureInfo.CurrentCulture);


            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("SENHA", imprimir.senha));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", imprimir.hora));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("HORA", imprimir.data));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CLIENTE", imprimir.cliente));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CELULAR", imprimir.celular));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("RUA", imprimir.rua));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("NUMERO", imprimir.numero));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("BAIRRO", imprimir.bairro));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("REFERENCIA", imprimir.referencia));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TAXA", imprimir.taxa));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOTAL", imprimir.total));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("OBS", imprimir.obs));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("PAGAMENTO", imprimir.pagamento));
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
            p.Start();
            //LEMBRANDO QUE PARA COMPUTADORES MAIS NOVOS, É POSSIVEL USAR SIMPLESMENTE AS LINHAS ABAIXO, SEM A NECESSIDADE DE GERAR O PDF
            */

            AutoPrint();
            
            AutoPrint();

            DialogResult = DialogResult.OK;
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
