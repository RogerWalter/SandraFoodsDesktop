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
    public partial class Relatorio : Form
    {
        public Relatorio()
        {
            InitializeComponent();
        }

        int parametro = -1;

        public void recebeParametro(int par)
        {
            parametro = par;
        }

        String DataInicial = "";
        String DataFinal = "";

        public void recebeDatas(String dtIni, String dtFin)
        {
            DataInicial = dtIni;
            DataFinal = dtFin;
        }
        

        private void Relatorio_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'RELATORIO_DIARIO.RELATORIO'. Você pode movê-la ou removê-la conforme necessário.
            this.RELATORIOTableAdapter.Fill(this.RELATORIO_DIARIO.RELATORIO);



            if(parametro == 1)
            {
                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10);
                //fb_somaTotalLancamentosDiaOutrosApps
                
                Decimal totalLancamentos = 0; // total de valores arrecadados
                totalLancamentos = AcessoFB.fb_somaTotalLancamentosDia(data);
                String totalLancamentosMostrar = totalLancamentos.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalLancamentosOutApps = 0; // total de valores arrecadados
                totalLancamentosOutApps = AcessoFB.fb_somaTotalLancamentosDiaOutrosApps(data);
                String totalLancamentosOutAppsMostrar = totalLancamentosOutApps.ToString("C", CultureInfo.CurrentCulture);

                int qtdLancamentos = 0; // qtd lancamentos do local no dia  
                qtdLancamentos = AcessoFB.fb_contaLancamentosLocal(data);
                String qtdLancamentosMostrar = qtdLancamentos.ToString();

                int qtdOutrosApps = 0; // qtd de pedidos do dia   
                qtdOutrosApps = AcessoFB.fb_contaLancamentosOutrosApps(data);
                String qtdOutrosAppsMostrar = qtdOutrosApps.ToString();

                int qtdPedidos = 0; // qtd de pedidos do dia   
                qtdPedidos = AcessoFB.fb_contaLancamentos(data);
                String qtdPedMostrar = qtdPedidos.ToString();

                Decimal total = 0; // total de valores arrecadados
                total = AcessoFB.fb_somaTotalDia(data);
                String totalMostrar = total.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalDin = 0; // total de valores arrecadados
                totalDin = AcessoFB.fb_somaLancDinheiro(data);
                String totalDMostrar = totalDin.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalCart = 0; // total de valores arrecadados
                totalCart = AcessoFB.fb_somaLancCartao(data);
                String totalCMostrar = totalCart.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalPix = 0; // total de valores arrecadados
                totalPix = AcessoFB.fb_somaLancPix(data);
                String totalPMostrar = totalPix.ToString("C", CultureInfo.CurrentCulture);

                int qtdPagamentoD = 0; // total de vendas no cartão ou no dinheiro
                qtdPagamentoD = AcessoFB.fb_qtdLancamentoDinheiro(data);
                String qtdPagDM = qtdPagamentoD.ToString();

                int qtdPagamentoP = 0; // total de vendas no cartão ou no dinheiro
                qtdPagamentoP = AcessoFB.fb_qtdLancamentoPix(data);
                String qtdPagPM = qtdPagamentoP.ToString();

                int qtdPagamentoC = 0;
                qtdPagamentoC = AcessoFB.fb_qtdLancamentoCartao(data);
                String qtdPagCM = qtdPagamentoC.ToString();

                int qtdTipoE = 0; // total de vendas no balcão e entrega
                qtdTipoE = AcessoFB.fb_qtdEntrega(data);
                String qtdTipoEM = qtdTipoE.ToString();

                int qtdTipoB = 0;
                qtdTipoB = AcessoFB.fb_qtdBalcao(data);
                String qtdTipoBM = qtdTipoB.ToString();

                Decimal totalEntrega = 0; // total de valores arrecadados
                totalEntrega = AcessoFB.fb_somaTotalEntregaDia(data);
                String totalEntregaMostrar = totalEntrega.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalBalcao = 0; // total de valores arrecadados
                totalBalcao = AcessoFB.fb_somaTotalBalcaoDia(data);
                String totalBalcaoMostrar = totalBalcao.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalEntregaBalcao = 0; // total de valores arrecadados
                totalEntregaBalcao = totalEntrega + totalBalcao + totalLancamentos + totalLancamentosOutApps;
                String totalEntregaBalcaoMostrar = totalEntregaBalcao.ToString("C", CultureInfo.CurrentCulture);

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", data));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TPEDIDO", qtdPedMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALOR", totalMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORD", totalDMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORC", totalCMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TDIN", qtdPagDM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TCART", qtdPagCM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TENT", qtdTipoEM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TBAL", qtdTipoBM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TENTV", totalEntregaMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TBALV", totalBalcaoMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORENTBAL", totalEntregaBalcaoMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("QTDLANC", qtdLancamentosMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOTLANC", totalLancamentosMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TPIX", qtdPagPM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORPIX", totalPMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("QTDOUTAPP", qtdOutrosAppsMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOUTAPPV", totalLancamentosOutAppsMostrar));
                this.reportViewer1.RefreshReport();
                
                /*PARÂMETROS
                    TOTAL VALOR CARTÃO (TVALORC)
                    TOTAL VALOR DINHEIRO (TVALORD)
                    TOTAL VALOR PIX (TVALORPIX)
                    TOTAL PAGAMENTO CARTÃO (TCART)
                    TOTAL PAGAMENTO DINHEIRO (TDIN)
                    TOTAL PAGAMENTO PIX (TPIX)
                    TOTAL ENTREGAS (TENT)
                    TOTAL RETIRADA (TBAL)
                    TOTAL LOCAL (QTDLANC)
                    TOTAL OUTROS APPS (QTDOUTAPP)
                    TOTAL ENTREGAS VALOR (TENTV)
                    TOTAL RETIRADA (TBALV)
                    TOTAL LOCAL (TOTLANC)
                    TOTAL OUTROS APPS (TOUTAPPV)
                    TOTAL RECEBIDO (TVALOR)
                    TOTAL PEDIDOS (TPEDIDO)
                    TOTAL VALORES ENTREGA BALCAO (TVALORENTBAL)
                 */


            }

            if (parametro == 2)
            {
                String mes = DateTime.Now.ToString();
                mes = mes.Substring(3, 7);

                Decimal totalLancamentos = 0; // total de valores arrecadados
                totalLancamentos = AcessoFB.fb_somaTotalLancamentosMes(mes);
                String totalLancamentosMostrar = totalLancamentos.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalLancamentosOutApps = 0; // total de valores arrecadados
                totalLancamentosOutApps = AcessoFB.fb_somaTotalLancamentosDiaOutrosAppsMes(mes);
                String totalLancamentosOutAppsMostrar = totalLancamentosOutApps.ToString("C", CultureInfo.CurrentCulture);

                int qtdLancamentos = 0; // qtd lancamentos do local no dia  
                qtdLancamentos = AcessoFB.fb_contaLancamentosLocalMes(mes);
                String qtdLancamentosMostrar = qtdLancamentos.ToString();

                int qtdOutrosApps = 0; // qtd de pedidos do dia   
                qtdOutrosApps = AcessoFB.fb_contaLancamentosOutrosAppsMes(mes);
                String qtdOutrosAppsMostrar = qtdOutrosApps.ToString();

                int qtdPedidos = 0; // qtd de pedidos do dia   
                qtdPedidos = AcessoFB.fb_contaLancamentosMes(mes);
                String qtdPedMostrar = qtdPedidos.ToString();

                Decimal total = 0; // total de valores arrecadados
                total = AcessoFB.fb_somaTotalMes(mes);
                String totalMostrar = total.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalDin = 0; // total de valores arrecadados
                totalDin = AcessoFB.fb_somaTotalDiaDinheiroMes(mes);
                String totalDMostrar = totalDin.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalCart = 0; // total de valores arrecadados
                totalCart = AcessoFB.fb_somaLancCartaoMes(mes);
                String totalCMostrar = totalCart.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalPix = 0; // total de valores arrecadados
                totalPix = AcessoFB.fb_somaLancPixMes(mes);
                String totalPMostrar = totalPix.ToString("C", CultureInfo.CurrentCulture);

                int qtdPagamentoD = 0; // total de vendas no cartão ou no dinheiro
                qtdPagamentoD = AcessoFB.fb_qtdLancamentoDinheiroMes(mes);
                String qtdPagDM = qtdPagamentoD.ToString();

                int qtdPagamentoP = 0; // total de vendas no cartão ou no dinheiro
                qtdPagamentoP = AcessoFB.fb_qtdLancamentoPixMes(mes);
                String qtdPagPM = qtdPagamentoP.ToString();

                int qtdPagamentoC = 0;
                qtdPagamentoC = AcessoFB.fb_qtdLancamentoCartaoMes(mes);
                String qtdPagCM = qtdPagamentoC.ToString();

                int qtdTipoE = 0; // total de vendas no balcão e entrega
                qtdTipoE = AcessoFB.fb_qtdEntregaMes(mes);
                String qtdTipoEM = qtdTipoE.ToString();

                int qtdTipoB = 0;
                qtdTipoB = AcessoFB.fb_qtdBalcaoMes(mes);
                String qtdTipoBM = qtdTipoB.ToString();

                Decimal totalEntrega = 0; // total de valores arrecadados
                totalEntrega = AcessoFB.fb_somaTotalEntregaMes(mes);
                String totalEntregaMostrar = totalEntrega.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalBalcao = 0; // total de valores arrecadados
                totalBalcao = AcessoFB.fb_somaTotalBalcaoMes(mes);
                String totalBalcaoMostrar = totalBalcao.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalEntregaBalcao = 0; // total de valores arrecadados
                totalEntregaBalcao = totalEntrega + totalBalcao + totalLancamentos + totalLancamentosOutApps;
                String totalEntregaBalcaoMostrar = totalEntregaBalcao.ToString("C", CultureInfo.CurrentCulture);

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", mes));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TPEDIDO", qtdPedMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALOR", totalMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORD", totalDMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORC", totalCMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TDIN", qtdPagDM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TCART", qtdPagCM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TENT", qtdTipoEM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TBAL", qtdTipoBM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TENTV", totalEntregaMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TBALV", totalBalcaoMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORENTBAL", totalEntregaBalcaoMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("QTDLANC", qtdLancamentosMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOTLANC", totalLancamentosMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TPIX", qtdPagPM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORPIX", totalPMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("QTDOUTAPP", qtdOutrosAppsMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOUTAPPV", totalLancamentosOutAppsMostrar));
                this.reportViewer1.RefreshReport();
            }

            if (parametro == 3)
            {
                String inicio = DataInicial;
                String final = DataFinal;

                String periodo = DataInicial + " até " + DataFinal;

                Decimal totalLancamentos = 0; // total de valores arrecadados
                totalLancamentos = AcessoFB.fb_somaTotalLancamentosPeriodo(inicio, final);
                String totalLancamentosMostrar = totalLancamentos.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalLancamentosOutApps = 0; // total de valores arrecadados
                totalLancamentosOutApps = AcessoFB.fb_somaTotalLancamentosDiaOutrosAppsPeriodo(inicio, final);
                String totalLancamentosOutAppsMostrar = totalLancamentosOutApps.ToString("C", CultureInfo.CurrentCulture);

                int qtdLancamentos = 0; // qtd de pedidos do dia   
                qtdLancamentos = AcessoFB.fb_contaLancamentosPeriodo(inicio, final);
                String qtdLancamentosMostrar = qtdLancamentos.ToString();

                int qtdOutrosApps = 0; // qtd de pedidos do dia   
                qtdOutrosApps = AcessoFB.fb_contaLancamentosOutrosAppsPeriodo(inicio, final);
                String qtdOutrosAppsMostrar = qtdOutrosApps.ToString();

                int qtdPedidos = 0; // qtd de pedidos do dia   
                qtdPedidos = AcessoFB.fb_contaPedidosPeriodo(inicio, final) + qtdLancamentos;
                String qtdPedMostrar = qtdPedidos.ToString();

                Decimal total = 0; // total de valores arrecadados
                total = AcessoFB.fb_somaTotalPeriodo(inicio, final);
                String totalMostrar = total.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalDin = 0; // total de valores arrecadados
                totalDin = AcessoFB.fb_somaTotalDiaDinheiroPeriodo(inicio, final);
                String totalDMostrar = totalDin.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalCart = 0; // total de valores arrecadados
                totalCart = AcessoFB.fb_somaTotalDiaCartaoPeriodo(inicio, final);
                String totalCMostrar = totalCart.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalPix = 0; // total de valores arrecadados
                totalPix = AcessoFB.fb_somaLancPixPeriodo(inicio, final);
                String totalPMostrar = totalPix.ToString("C", CultureInfo.CurrentCulture);

                int qtdPagamentoD = 0; // total de vendas no cartão ou no dinheiro
                qtdPagamentoD = AcessoFB.fb_qtdDinheiroPeriodo(inicio, final);
                String qtdPagDM = qtdPagamentoD.ToString();

                int qtdPagamentoP = 0; // total de vendas no cartão ou no dinheiro
                qtdPagamentoP = AcessoFB.fb_qtdLancamentoPixPeriodo(inicio, final);
                String qtdPagPM = qtdPagamentoP.ToString();

                int qtdPagamentoC = 0;
                qtdPagamentoC = AcessoFB.fb_qtdCartaoPeriodo(inicio, final) + AcessoFB.fb_qtdLancamentoCartaoPeriodo(inicio, final);
                String qtdPagCM = qtdPagamentoC.ToString();

                int qtdTipoE = 0; // total de vendas no balcão e entrega
                qtdTipoE = AcessoFB.fb_qtdEntregaPeriodo(inicio, final);
                String qtdTipoEM = qtdTipoE.ToString();

                int qtdTipoB = 0;
                qtdTipoB = AcessoFB.fb_qtdBalcaoPeriodo(inicio, final);
                String qtdTipoBM = qtdTipoB.ToString();

                Decimal totalEntrega = 0; // total de valores arrecadados
                totalEntrega = AcessoFB.fb_somaTotalEntregaPeriodo(inicio, final);
                String totalEntregaMostrar = totalEntrega.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalBalcao = 0; // total de valores arrecadados
                totalBalcao = AcessoFB.fb_somaTotalBalcaoPeriodo(inicio, final);
                String totalBalcaoMostrar = totalBalcao.ToString("C", CultureInfo.CurrentCulture);

                Decimal totalEntregaBalcao = 0; // total de valores arrecadados
                totalEntregaBalcao = totalEntrega + totalBalcao + totalLancamentos + totalLancamentosOutApps; ;
                String totalEntregaBalcaoMostrar = totalEntregaBalcao.ToString("C", CultureInfo.CurrentCulture);

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", periodo));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TPEDIDO", qtdPedMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALOR", totalMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORD", totalDMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORC", totalCMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TDIN", qtdPagDM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TCART", qtdPagCM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TENT", qtdTipoEM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TBAL", qtdTipoBM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TENTV", totalEntregaMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TBALV", totalBalcaoMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORENTBAL", totalEntregaBalcaoMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("QTDLANC", qtdLancamentosMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOTLANC", totalLancamentosMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TPIX", qtdPagPM));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORPIX", totalPMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("QTDOUTAPP", qtdOutrosAppsMostrar));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TOUTAPPV", totalLancamentosOutAppsMostrar));
                this.reportViewer1.RefreshReport();
            }

        }

        private void Relatorio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
