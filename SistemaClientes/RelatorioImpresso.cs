using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewLabelPrinter;

namespace SistemaClientes
{
    public partial class RelatorioImpresso : Form
    {
        public RelatorioImpresso()
        {
            InitializeComponent();
        }
        private void AutoPrint()
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
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

        private void RelatorioImpresso_Load(object sender, EventArgs e)
        {
            String dataMostrar = "";
            List<Lancamentos> listaLancamentos = new List<Lancamentos>();
            List<Comanda> listaComanda = new List<Comanda>();
            List<ItemComanda> listaItemComanda = new List<ItemComanda>();
            List<Itens_Pedido_Relatorio> listaItemPedido = new List<Itens_Pedido_Relatorio>();
            List<int> listaIdPedidos = new List<int>();
            if (parametro == 1)
            {
                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10);
                dataMostrar = data;
                //INFORMAÇÕES LANÇAMENTOS               
                listaLancamentos = AcessoFB.fb_recuperaListaLancamentos(data);
                listaComanda = AcessoFB.fb_recuperaListaComandas(data.Replace("/", "-"));
                listaIdPedidos = AcessoFB.fb_recuperaListaPedidos(data);
                if(listaIdPedidos.Count > 0)
                    listaItemPedido = AcessoFB.fb_recuperaListaItemPedido(listaIdPedidos);
                listaItemComanda = AcessoFB.fb_recuperaListaItemComandas(data.Replace("/", "-"));
            }
            if (parametro == 2)
            {
                String mes = DateTime.Now.ToString();
                mes = mes.Substring(3, 7);
                dataMostrar = mes;
                //INFORMAÇÕES LANÇAMENTOS               
                listaLancamentos = AcessoFB.fb_recuperaListaLancamentosMes(mes);
                listaComanda = AcessoFB.fb_recuperaListaComandasMes(mes.Replace("/", "-"));
                listaIdPedidos = AcessoFB.fb_recuperaListaPedidosMes(mes);
                if (listaIdPedidos.Count > 0)
                    listaItemPedido = AcessoFB.fb_recuperaListaItemPedido(listaIdPedidos);
                listaItemComanda = AcessoFB.fb_recuperaListaItemComandasMes(mes.Replace("/", "-"));
            }
            if (parametro == 3)
            {
                String iniDia = DataInicial.Substring(0, 2);
                String iniMes = DataInicial.Substring(3, 2);
                String iniAno = DataInicial.Substring(6, 4);
                String fimDia = DataInicial.Substring(0, 2);
                String fimMes = DataInicial.Substring(3, 2);
                String fimAno = DataInicial.Substring(6, 4);
                String inicio = iniMes + "/" + iniDia + "/" + iniAno;
                String final = fimMes + "/" + fimDia + "/" + fimAno; ;
                String periodo = DataInicial + " até " + DataFinal;
                dataMostrar = periodo;
                //INFORMAÇÕES LANÇAMENTOS               
                listaLancamentos = AcessoFB.fb_recuperaListaLancamentosPeriodo(inicio, final);
                listaComanda = AcessoFB.fb_recuperaListaComandasPeriodo(inicio.Replace("-", "/"), final.Replace("-", "/"));
                listaIdPedidos = AcessoFB.fb_recuperaListaPedidosPeriodo(inicio, final);
                if (listaIdPedidos.Count > 0)
                    listaItemPedido = AcessoFB.fb_recuperaListaItemPedido(listaIdPedidos);
                listaItemComanda = AcessoFB.fb_recuperaListaItemComandasPeriodo(inicio.Replace("-", "/"), final.Replace("-", "/"));
            }

            if(listaLancamentos.Count <= 0)
            {
                MessageBox.Show("Não existem registros para o período informado.", "Erro");
                return;
            }

            //TOTLANC
            Decimal totalLancamentos = 0;
            totalLancamentos = listaLancamentos.Where(item => item.Tipo == 3).Sum(x => Convert.ToDecimal(x.Valor));
            String totalLancamentosMostrar = totalLancamentos.ToString("C", CultureInfo.CurrentCulture);
            //TOUTAPPV
            Decimal totalLancamentosOutApps = 0;
            totalLancamentosOutApps = listaLancamentos.Where(item => item.Tipo == 0).Sum(x => Convert.ToDecimal(x.Valor));
            String totalLancamentosOutAppsMostrar = totalLancamentosOutApps.ToString("C", CultureInfo.CurrentCulture);
            //QTDLANC
            int qtdLancamentos = 0;
            qtdLancamentos = listaLancamentos.Count(item => item.Tipo == 3);
            String qtdLancamentosMostrar = qtdLancamentos.ToString();
            //QTDOUTAPP    
            int qtdOutrosApps = 0;
            qtdOutrosApps = listaLancamentos.Count(item => item.Tipo == 0);
            String qtdOutrosAppsMostrar = qtdOutrosApps.ToString();
            //TPAGAMENTO
            int qtdPagamentos = 0;
            qtdPagamentos = listaLancamentos.Count;
            String qtdPagamentosMostrar = qtdPagamentos.ToString();
            //TPEDIDO
            int qtdPedidos = 0;
            qtdPedidos = listaLancamentos.Count(item => item.Pedido != 0);
            String qtdPedMostrar = qtdPedidos.ToString();
            //TVALORPEDIDO
            Decimal valorTotalPedidos = 0;
            valorTotalPedidos = listaLancamentos.Where(item => item.Tipo != 9).Sum(x => Convert.ToDecimal(x.Valor));
            String valorTotalPedidosMostrar = valorTotalPedidos.ToString("C", CultureInfo.CurrentCulture);
            //TVALOR
            Decimal total = 0;
            total = listaLancamentos.Sum(x => Convert.ToDecimal(x.Valor));
            String totalMostrar = total.ToString("C", CultureInfo.CurrentCulture);
            //TVALORD
            Decimal totalDin = 0;
            totalDin = listaLancamentos.Where(item => item.Pagamento == 0).Sum(x => Convert.ToDecimal(x.Valor));
            String totalDMostrar = totalDin.ToString("C", CultureInfo.CurrentCulture);
            //TVALORC
            Decimal totalCart = 0;
            totalCart = listaLancamentos.Where(item => item.Pagamento == 1).Sum(x => Convert.ToDecimal(x.Valor));
            String totalCMostrar = totalCart.ToString("C", CultureInfo.CurrentCulture);
            //TVALORPIX
            Decimal totalPix = 0;
            totalPix = listaLancamentos.Where(item => item.Pagamento == 2).Sum(x => Convert.ToDecimal(x.Valor));
            String totalPMostrar = totalPix.ToString("C", CultureInfo.CurrentCulture);
            //TDIN
            int qtdPagamentoD = 0;
            qtdPagamentoD = listaLancamentos.Count(item => item.Pagamento == 0);
            String qtdPagDM = qtdPagamentoD.ToString();
            //TPIX
            int qtdPagamentoP = 0;
            qtdPagamentoP = listaLancamentos.Count(item => item.Pagamento == 2);
            String qtdPagPM = qtdPagamentoP.ToString();
            //TCART
            int qtdPagamentoC = 0;
            qtdPagamentoC = listaLancamentos.Count(item => item.Pagamento == 1);
            String qtdPagCM = qtdPagamentoC.ToString();
            //TENT
            int qtdTipoE = 0;
            qtdTipoE = listaLancamentos.Count(item => item.Tipo == 1);
            String qtdTipoEM = qtdTipoE.ToString();
            //TBAL
            int qtdTipoB = 0;
            qtdTipoB = listaLancamentos.Count(item => item.Tipo == 2);
            String qtdTipoBM = qtdTipoB.ToString();
            //TENTV
            Decimal totalEntrega = 0;
            totalEntrega = listaLancamentos.Where(item => item.Tipo == 1).Sum(x => Convert.ToDecimal(x.Valor)); ;
            String totalEntregaMostrar = totalEntrega.ToString("C", CultureInfo.CurrentCulture);
            //TBALV
            Decimal totalBalcao = 0;
            totalBalcao = listaLancamentos.Where(item => item.Tipo == 2).Sum(x => Convert.ToDecimal(x.Valor));
            String totalBalcaoMostrar = totalBalcao.ToString("C", CultureInfo.CurrentCulture);
            //TVALORENTBAL
            Decimal totalEntregaBalcao = 0;
            totalEntregaBalcao = totalEntrega + totalBalcao + totalLancamentos + totalLancamentosOutApps;
            String totalEntregaBalcaoMostrar = totalEntregaBalcao.ToString("C", CultureInfo.CurrentCulture);
            //GARCOM_TOTAL_ATEND
            int totalAtendimentos = 0;
            totalAtendimentos = listaComanda.Count(x => x.fechamento == 1);
            //GARCOM_TOTAL_RECEB
            Decimal totalRecebido = 0;
            totalRecebido = listaLancamentos.Where(item => item.Tipo == 9).Sum(x => Convert.ToDecimal(x.Valor));
            String totalRecebidoMostrar = totalRecebido.ToString("C", CultureInfo.CurrentCulture);
            //GARCOM_TOTAL_DIN
            Decimal totalDinRecebido = 0;
            totalDinRecebido = listaLancamentos.Where(item => item.Tipo == 9 && item.Pagamento == 0).Sum(x => Convert.ToDecimal(x.Valor));
            String totalDinRecebidoMostrar = totalDinRecebido.ToString("C", CultureInfo.CurrentCulture);
            //GARCOM_TOTAL_CART
            Decimal totalCarRecebido = 0;
            totalCarRecebido = listaLancamentos.Where(item => item.Tipo == 9 && item.Pagamento == 1).Sum(x => Convert.ToDecimal(x.Valor));
            String totalCarRecebidoMostrar = totalCarRecebido.ToString("C", CultureInfo.CurrentCulture);
            //GARCOM_TOTAL_PIX
            Decimal totalPixRecebido = 0;
            totalPixRecebido = listaLancamentos.Where(item => item.Tipo == 9 && item.Pagamento == 2).Sum(x => Convert.ToDecimal(x.Valor));
            String totalPixRecebidoMostrar = totalPixRecebido.ToString("C", CultureInfo.CurrentCulture);
            //GARCOM_QTD_PAGAMENTO
            Decimal totalPagamentosRecebido = 0;
            totalPagamentosRecebido = listaComanda.Count();
            String totalPagamentosRecebidoMostrar = totalPagamentosRecebido.ToString();
            //GARCOM_MESA_MAIS
            int ultima_mesa = 0;
            ultima_mesa = listaComanda.Max(t => t.mesa);
            int mesa_mais = 0;
            int maior_contagem = 0;
            for (int i = 1; i <= ultima_mesa; i++)
            {
                int soma_uso_mesa = 0;
                soma_uso_mesa = listaComanda.Where(t => t.fechamento == 1).Count(x => x.mesa == i);
                if (soma_uso_mesa > maior_contagem)
                {
                    maior_contagem = soma_uso_mesa;
                    mesa_mais = i;
                }
            }
            //TATENDIMENTO
            int total_lancamentos_registrados = 0;
            total_lancamentos_registrados = listaLancamentos.Count;
            int total_comanda_parcial = 0;
            total_comanda_parcial = listaComanda.Where(item => item.fechamento == 0).Count();
            int total_atendimentos = 0;
            total_atendimentos = total_lancamentos_registrados - total_comanda_parcial;
            String totalAtendimentosMostrar = total_atendimentos.ToString();
            //MAIORAPPWHATS
            Decimal maior_app_whats = 0;
            try
            {
                maior_app_whats = listaLancamentos.Where(item => item.Tipo != 9).Max(t => t.Valor);
            }
            catch(Exception)
            {
                maior_app_whats = 0;
            }
            String maior_app_whatsMostrar = maior_app_whats.ToString("C", CultureInfo.CurrentCulture);
            //MAIORMESA
            Decimal maior_mesa = 0;
            maior_mesa = listaComanda.Where(item => item.fechamento == 1).Max(t => t.total);
            String maior_mesaMostrar = maior_mesa.ToString("C", CultureInfo.CurrentCulture);
            //CUR_TOTAL_LANC
            int total_pedidos_lanches = 0;
            total_pedidos_lanches = listaItemPedido.Where(item => item.Grupo == 1).Sum(x => Convert.ToInt32(x.Quantidade));
            int total_comandas_lanches = 0;
            total_comandas_lanches = listaItemComanda.Where(item => item.grupo == 1).Sum(x => Convert.ToInt32(x.qtd));
            int total_lanches = 0;
            total_lanches = total_pedidos_lanches + total_comandas_lanches;
            String total_lanchesMostrar = total_lanches.ToString();
            //CUR_TOTAL_CREP
            int total_pedidos_crepes = 0;
            total_pedidos_crepes = listaItemPedido.Where(item => item.Grupo == 2).Sum(x => Convert.ToInt32(x.Quantidade));
            int total_comandas_crepes = 0;
            total_comandas_crepes = listaItemComanda.Where(item => item.grupo == 2).Sum(x => Convert.ToInt32(x.qtd));
            int total_crepes = 0;
            total_crepes = total_pedidos_crepes + total_comandas_crepes;
            String total_crepesMostrar = total_crepes.ToString();
            //CUR_TOTAL_TAPI
            int total_pedidos_tapiocas = 0;
            total_pedidos_tapiocas = listaItemPedido.Where(item => item.Grupo == 3).Sum(x => Convert.ToInt32(x.Quantidade));
            int total_comandas_tapiocas = 0;
            total_comandas_tapiocas = listaItemComanda.Where(item => item.grupo == 3).Sum(x => Convert.ToInt32(x.qtd));
            int total_tapiocas = 0;
            total_tapiocas = total_pedidos_tapiocas + total_comandas_tapiocas;
            String total_tapiocasMostrar = total_tapiocas.ToString();
            //CUR_TOTAL_PAST
            int total_pedidos_pasteis = 0;
            total_pedidos_pasteis = listaItemPedido.Where(item => item.Grupo == 4).Sum(x => Convert.ToInt32(x.Quantidade));
            int total_comandas_pasteis = 0;
            total_comandas_pasteis = listaItemComanda.Where(item => item.grupo == 4).Sum(x => Convert.ToInt32(x.qtd));
            int total_pasteis = 0;
            total_pasteis = total_pedidos_pasteis + total_comandas_pasteis;
            String total_pasteisMostrar = total_pasteis.ToString();
            //CUR_TOTAL_PORC
            int total_pedidos_porcoes = 0;
            total_pedidos_porcoes = listaItemPedido.Where(item => item.Grupo == 5).Sum(x => Convert.ToInt32(x.Quantidade));
            int total_comandas_porcoes = 0;
            total_comandas_porcoes = listaItemComanda.Where(item => item.grupo == 5).Sum(x => Convert.ToInt32(x.qtd));
            int total_porcoes = 0;
            total_porcoes = total_pedidos_porcoes + total_comandas_porcoes;
            String total_porcoesMostrar = total_porcoes.ToString();
            //CUR_TOTAL_PROD
            int total_producao = 0;
            total_producao = total_lanches + total_crepes + total_tapiocas + total_pasteis + total_porcoes;
            String total_producaoMostrar = total_producao.ToString();

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DATA", dataMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TATENDIMENTO", totalAtendimentosMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TPEDIDO", qtdPedMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TPAGAMENTO", qtdPagamentosMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALOR", totalMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORD", totalDMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORC", totalCMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TVALORPEDIDO", valorTotalPedidosMostrar));
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
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("GARCOM_TOTAL_ATEND", totalAtendimentos.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("GARCOM_TOTAL_RECEB", totalRecebidoMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("GARCOM_TOTAL_DIN", totalDinRecebidoMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("GARCOM_TOTAL_CART", totalCarRecebidoMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("GARCOM_TOTAL_PIX", totalPixRecebidoMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("GARCOM_QTD_PAGAMENTO", totalPagamentosRecebidoMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("GARCOM_MESA_MAIS", mesa_mais.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("MAIORAPPWHATS", maior_app_whatsMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("MAIORMESA", maior_mesaMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CUR_TOTAL_PROD", total_producaoMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CUR_TOTAL_LANC", total_lanchesMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CUR_TOTAL_CREP", total_crepesMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CUR_TOTAL_TAPI", total_tapiocasMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CUR_TOTAL_PAST", total_pasteisMostrar));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CUR_TOTAL_PORC", total_porcoesMostrar));
            this.reportViewer1.RefreshReport();

            AutoPrint();

            DialogResult = DialogResult.OK;

        }
    }
}
