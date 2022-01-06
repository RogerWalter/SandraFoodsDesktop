using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class ConsultarPedido : Form
    {
        public ConsultarPedido()
        {
            InitializeComponent();
        }

        public int enviaCodPed()
        {
            return idSelecionado;
        }

        private void ConsultarPedido_Load(object sender, EventArgs e)
        {
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);

            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable pedidos = new DataTable("Pedidos");
            DataSet dsFinal = new DataSet();
            pedidos = AcessoFB.fb_buscaPedidosConsulta(data);
            dsFinal.Tables.Add(pedidos);
            bindingSource1.DataSource = pedidos;
            dataGridView1.DataSource = bindingSource1;
        }

        private void tbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
        }

        int idSelecionado = 0;
        int idProvisorio = 0;

        private void tbPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.Enter)
            {


                String procurar = tbPesquisa.Text.ToString();
                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[2].Value.ToString().Contains(procurar) || row.Cells[2].Value.ToString().Equals(procurar))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                if (rowIndex == -1)
                {
                    MessageBox.Show("Não foram encontrados resultados para o termo pesquisado", "Erro", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    dataGridView1.Rows[rowIndex].Selected = true;
                    idSelecionado = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
                    return;
                }   
            }*/
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idProvisorio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int linha = Convert.ToInt32(dataGridView1.CurrentRow.Index);
                    idSelecionado = Convert.ToInt32(dataGridView1.Rows[linha - 1].Cells[0].Value);
                }
                catch
                {
                    //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
                }
                this.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idSelecionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
            }
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            idSelecionado = 0;
            this.Close();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            idSelecionado = idProvisorio;
            this.Close();
        }

        private void ConsultarPedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            idSelecionado = idProvisorio;
            var result = MessageBox.Show(this, "Deseja realmente excluir o pedido atual?", "Confirmação", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            else
            {

                Pedidos busca = new Pedidos();
                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10);
                busca = AcessoFB.fb_pesquisaPedido(idSelecionado, data);

                int idExcluir = Convert.ToInt32(busca.Id);
                AcessoFB.fb_excluirPedido(idExcluir);
                mostraTelaConfirmacao();

                AcessoFB.fb_limparItemPedidoTemp(busca.Id);

                dataGridView1.DataSource = null;
                BindingSource bindingSource1 = new BindingSource();
                DataTable pedidos = new DataTable("Pedidos");
                DataSet dsFinal = new DataSet();
                pedidos = AcessoFB.fb_buscaPedidosConsulta(data);
                dsFinal.Tables.Add(pedidos);
                bindingSource1.DataSource = pedidos;
                dataGridView1.DataSource = bindingSource1;
                idSelecionado = 0;
            }

        }
        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
            nova.WindowState = FormWindowState.Normal;
            nova.BringToFront();
            nova.TopMost = true;
            nova.Focus();
        }

        private void btImpressora_Click(object sender, EventArgs e)
        {
            idSelecionado = idProvisorio;
            Pedidos busca = new Pedidos();
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            busca = AcessoFB.fb_pesquisaPedido(idSelecionado, data);
            Pedidos recuperado = AcessoFB.fb_pesquisaPedidoPorId(busca.Id);
            insereDadosImpressao(recuperado.Senha, busca.Id);
            AcessoFB.fb_limpaTabelasImpressao();
            AcessoFB.fb_limparItemPedidoTemp(busca.Id);
            idSelecionado = 0;
        }

        public void insereDadosImpressao(int senha, int idParaImpressao)
        {
            var result = MessageBox.Show(this, "Deseja reimprimir este pedido?", "Confirmação", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            else
            {
                Pedidos recuperado = AcessoFB.fb_pesquisaPedidoPorId(idParaImpressao);
                Clientes clientePedido = AcessoFB.fb_pesquisaClientePorId(recuperado.Id_Cliente);
                Taxas taxaRecuperada = AcessoFB.fb_pesquisaTaxa(clientePedido.Bairro);
                int id_pedido = Convert.ToInt32(recuperado.Id);
                String atual = DateTime.Now.ToString();
                String data = atual.Substring(0, 10);
                String hora = atual.Substring(11, 8);
                String cliente = RemoverAcentos(recuperado.Nome_Cliente).Trim();
                cliente.Replace("'", " ");
                String celular, rua, numero, bairro, referencia, taxa;
                if (recuperado.Tipo == 1)
                {
                    celular = clientePedido.Celular.ToString().Trim();
                    rua = clientePedido.Rua.ToString().Trim();
                    numero = clientePedido.Numero.ToString().Trim();
                    bairro = clientePedido.Bairro.ToString().Trim();
                    referencia = clientePedido.Referencia.ToString().Trim();
                    Decimal valorTaxa = taxaRecuperada.Valor;
                    taxa = valorTaxa.ToString("C", CultureInfo.CurrentCulture);
                }
                else
                {
                    celular = "-";
                    rua = "-";
                    numero = "-";
                    bairro = "-";
                    referencia = "-";
                    taxa = "-";
                }
                Decimal valorTotal = recuperado.Valor;
                String total = valorTotal.ToString("C", CultureInfo.CurrentCulture);
                String obs = recuperado.Observacao.ToString().Trim();
                String pagamento = "";
                if (recuperado.Pagamento == 0)
                {
                    pagamento = "DINHEIRO";
                }
                if (recuperado.Pagamento == 1)
                {
                    pagamento = "CARTAO";
                }
                if(recuperado.Pagamento == 3)
                {
                    pagamento = "PIX";
                }
                obs.Replace("'", " ");
                String desc;
                if (recuperado.Desconto == 0)
                {
                    desc = "R$0,00";
                }
                else
                {
                    Decimal desconto = recuperado.Desconto;
                    desc = desconto.ToString("C", CultureInfo.CurrentCulture);
                }

                AcessoFB.insereDadosImpressao(senha, data, hora, cliente, celular, rua, numero, bairro, referencia, taxa, total, obs, desc, pagamento);
                AcessoFB.insereItensImpressao(idParaImpressao);

                if (recuperado.Tipo == 1)
                {
                    imprimirPedidoEntrega();
                }
                if (recuperado.Tipo == 2 || recuperado.Tipo == 3)
                {
                    imprimirPedidoBalcao();
                }
            }
        }
        public void imprimirPedidoBalcao()
        {
            ImpressaoBalcao nova = new ImpressaoBalcao();
            nova.ShowDialog();
        }
        public void imprimirPedidoEntrega()
        {
            ImpressaoEntrega nova = new ImpressaoEntrega();
            nova.ShowDialog();

            AcessoFB.fb_limpaTabelasImpressao();
        }
        public static string RemoverAcentos(string valor)
        {
            valor = Regex.Replace(valor, "[ÁÀÂÃ]", "A");
            valor = Regex.Replace(valor, "[ÉÈÊ]", "E");
            valor = Regex.Replace(valor, "[Í]", "I");
            valor = Regex.Replace(valor, "[ÓÒÔÕ]", "O");
            valor = Regex.Replace(valor, "[ÚÙÛÜ]", "U");
            valor = Regex.Replace(valor, "[Ç]", "C");
            valor = Regex.Replace(valor, "[áàâã]", "a");
            valor = Regex.Replace(valor, "[éèê]", "e");
            valor = Regex.Replace(valor, "[í]", "i");
            valor = Regex.Replace(valor, "[óòôõ]", "o");
            valor = Regex.Replace(valor, "[úùûü]", "u");
            valor = Regex.Replace(valor, "[ç]", "c");
            return valor;
        }

        private void converter_Click(object sender, EventArgs e)
        {
            idSelecionado = idProvisorio;
            Pedidos busca = new Pedidos();
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            //RECUPERAMOS OS DADOS DO PEDIDO
            busca = AcessoFB.fb_pesquisaPedido(idSelecionado, data);
            //SE ENTREGA, CONVERTEMOS PARA BALCAO. SE BALCAO, CONVERTEMOS PARA ENTREGA
            ConverterPedido nova = new ConverterPedido();
            nova.recebeValorIdPedido(busca.Id);
            nova.ShowDialog();
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable pedidos = new DataTable("Pedidos");
            DataSet dsFinal = new DataSet();
            pedidos = AcessoFB.fb_buscaPedidosConsulta(data);
            dsFinal.Tables.Add(pedidos);
            bindingSource1.DataSource = pedidos;
            dataGridView1.DataSource = bindingSource1;
            idSelecionado = 0;
        }
    }
}
