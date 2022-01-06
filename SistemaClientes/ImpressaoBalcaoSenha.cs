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
    public partial class ImpressaoBalcaoSenha : Form
    {
        public ImpressaoBalcaoSenha()
        {
            InitializeComponent();
        }

        int senha = 0;
        String data = "";
        public void recebeDados(int sen, String dat)
        {
            senha = sen;
            data = dat;
        }
        private void AutoPrint()
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
        }

        private void ImpressaoBalcaoSenha_Load(object sender, EventArgs e)
        {
            String atual = DateTime.Now.ToString();
            String dataAtual = atual.Substring(0, 10);
            String horaAtual = atual.Substring(11, 8);

            int idPedido = AcessoFB.fb_buscaPedidoUsandoSenhaData(senha, data);
            Pedidos busca = AcessoFB.fb_pesquisaPedidoPorIdSenhas(idPedido);

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("SENHA", busca.Senha.ToString().Trim()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", dataAtual.Trim()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("HORA", horaAtual.Trim()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CLIENTE", busca.Nome_Cliente.Trim()));
            this.reportViewer1.RefreshReport();

            AutoPrint();

            DialogResult = DialogResult.OK;
        }
    }
}
