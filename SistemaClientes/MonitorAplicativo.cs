using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using LiteDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SistemaClientes
{
    public partial class MonitorAplicativo : Form
    {
        List<Taxas> listaTaxas = new List<Taxas>();
        List<PedidoFirebase> listaPedidos = new List<PedidoFirebase>();
        List<AndamentoFirebase> listaAndamentos = new List<AndamentoFirebase>();
        Parametros parametrosSistema = new Parametros();
        public MonitorAplicativo()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "tJVQSamSvHRtZguzUcn0h3YfPGFoEjl37nI2uNDD",
            BasePath = "https://sandra-foods-34d79-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
        private void MonitorAplicativo_Load(object sender, EventArgs e)
        {
            parametrosSistema = AcessoFB.fb_recuperaParametrosSistema();

            if (parametrosSistema.sincronizar == 0)
            {
                MessageBox.Show("A sincronização com o aplicativo está desabilitada.\nNão é possível gerenciar pedidos vindos do aplicativo.\nVerifique os parâmetros do sistema e tente novamente.", "Aplicativo desabilitado");
                this.Close();
            }

            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar ao Firebase", "Erro");
                this.Close();
            }
            criaListeneAndamentosApp();
            carregaDataGridView();
        }

        async void criaListeneAndamentosApp()
        {
            EventStreamResponse response = await client.OnAsync(@"andamento",
                    added: (s, args, context) =>
                    {

                    },
                    changed: (s, args, context) =>
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() => carregaDataGridView()));
                        }
                        else
                        {
                            carregaDataGridView();
                        }
                    },
                    removed: (s, args, context) =>
                    {

                    });
        }
        public void carregaDataGridView()
        {
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable pedidos = new DataTable("Pedidos");
            DataSet dsFinal = new DataSet();
            pedidos = AcessoFB.fb_buscaPedidosMonitor();
            dsFinal.Tables.Add(pedidos);
            bindingSource1.DataSource = pedidos;
            dataGridView1.DataSource = bindingSource1;
            if(dataGridView1.Rows.Count > 0)
            {
                if(dataGridView1.Columns.Count <= 0)
                {
                    carregaDataGridView();
                    return;
                }
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].DefaultCellStyle.ForeColor = Color.Gold;
                dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.DarkBlue;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name.Equals("TIPO"))
            {
                if (e.Value != null && e.Value.ToString().Trim() == "ENTREGA")
                {
                    dgv.Rows[e.RowIndex].Cells["TIPO"].Style.ForeColor = Color.Goldenrod;
                }
                if (e.Value != null && (e.Value.ToString().Trim() == "RETIRADA" || e.Value.ToString().Trim() == "CONSUMO NO LOCAL"))
                {
                    dgv.Rows[e.RowIndex].Cells["TIPO"].Style.ForeColor = Color.OliveDrab;
                }
            }
            if (dgv.Columns[e.ColumnIndex].Name.Equals("STATUS"))
            {
                if (e.Value != null && e.Value.ToString().Trim() == "EM PREPARACAO")
                {
                    dgv.Rows[e.RowIndex].Cells["STATUS"].Style.ForeColor = Color.OrangeRed;
                }
                if (e.Value != null && e.Value.ToString().Trim() == "SAIU PARA ENTREGA")
                {
                    dgv.Rows[e.RowIndex].Cells["STATUS"].Style.ForeColor = Color.Chocolate;
                }
                if (e.Value != null && e.Value.ToString().Trim() == "PRONTO")
                {
                    dgv.Rows[e.RowIndex].Cells["STATUS"].Style.ForeColor = Color.SeaGreen;
                }
                if (e.Value != null && e.Value.ToString().Trim() == "FINALIZADO")
                {
                    dgv.Rows[e.RowIndex].Cells["STATUS"].Style.ForeColor = Color.Black;
                }
            }
        }

        int pesquisar = 0;
        PedidoMonitor itemSelecionado = new PedidoMonitor();
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    pesquisar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    PedidoMonitor buscado = AcessoFB.fb_pesquisPedidoMonitorPorId(pesquisar);
                    if(!String.IsNullOrEmpty(buscado.Nome))
                    {
                        tbSenha.Text = buscado.Senha.ToString();
                        itemSelecionado = buscado;
                        tbCliente.Text = buscado.Nome.ToString().Trim();

                        String valorStr = buscado.Valor.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        tbValor.Text = valorStr.Trim();

                        if (buscado.Tipo == 1)
                            tbTipo.Text = "ENTREGA";
                        if (buscado.Tipo == 2)
                            tbTipo.Text = "RETIRADA";
                        if (buscado.Tipo == 3)
                            tbTipo.Text = "CONSUMO NO LOCAL";

                        if (buscado.Status == 0)
                            tbStatus.Text = "EM PREPARAÇÃO";
                        if (buscado.Status == 1)
                            tbStatus.Text = "SAIU PARA ENTREGA";
                        if (buscado.Status == 2)
                            tbStatus.Text = "PRONTO";
                        if (buscado.Status == 3)
                            tbStatus.Text = "FINALIZADO";
                    }
                }
                else
                {
                    return;
                }
            }
            catch
            {

            }
        }

        String mensagemStatus0para1 = "O status deste item será alterado.\n\nStatus atual: EM PREPARACAO\n\nNovo Status: SAIU PARA ENTREGA\n\nDeseja confirmar a alteração?";
        String mensagemStatus0para2 = "O status deste item será alterado.\n\nStatus atual: EM PREPARACAO\n\nNovo Status: PRONTO\n\nDeseja confirmar a alteração?";
        String mensagemStatus1para3 = "O status deste item será alterado.\n\nStatus atual: SAIU PARA ENTREGA\n\nNovo Status: FINALIZADO\n\nDeseja confirmar a alteração?";
        String mensagemStatus2para3 = "O status deste item será alterado.\n\nStatus atual: PRONTO\n\nNovo Status: FINALIZADO\n\nDeseja confirmar a alteração?";

        private void btEditar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count <= 0)
            {
                return;
            }
            //EM PREPARACAO
            if(itemSelecionado.Status == 0)
            {
                //TIPO ENTREGA
                if(itemSelecionado.Tipo == 1)
                {
                    if (MessageBox.Show(mensagemStatus0para1, "Alteração de Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //ALTERA-SE O STATUS PARA 1
                        AcessoFB.fb_atualizaStatusPedido(itemSelecionado.Id, 1);
                        String statusFirebase= "SAIU";
                        atualizaStatusFirebase(itemSelecionado, statusFirebase);
                        carregaDataGridView();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                //TIPO RETIRADA/CONSUMO
                else
                {
                    if (MessageBox.Show(mensagemStatus0para2, "Alteração de Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //ALTERA-SE O STATUS PARA 2
                        AcessoFB.fb_atualizaStatusPedido(itemSelecionado.Id, 2);
                        String statusFirebase = "PRONTO";
                        atualizaStatusFirebase(itemSelecionado, statusFirebase);
                        carregaDataGridView();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            //SAIU PARA ENTREGA
            if (itemSelecionado.Status == 1)
            {
                if (MessageBox.Show(mensagemStatus1para3, "Alteração de Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //PEDIDO É FINALIZADO
                    AcessoFB.fb_excluirPedidoMonitor(itemSelecionado);
                    excluirPedidoFirebase(itemSelecionado);
                    carregaDataGridView();
                    return;
                }
                else
                {
                    return;
                }
            }
            //PRONTO
            if (itemSelecionado.Status == 2)
            {
                if (MessageBox.Show(mensagemStatus2para3, "Alteração de Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //PEDIDO É FINALIZADO
                    AcessoFB.fb_excluirPedidoMonitor(itemSelecionado);
                    excluirPedidoFirebase(itemSelecionado);
                    carregaDataGridView();
                    return;
                }
                else
                {
                    return;
                }
            }
        }

        public void atualizaStatusFirebase(PedidoMonitor item, String novoStatus)
        {
            try
            {
                String chaveAlterarAndamento = item.Identificador.Trim();
                var set = client.Set(@"andamento/" + chaveAlterarAndamento + "/status", novoStatus);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao atualizar este pedido no Aplicativo.\nTente atualizar o item novamente.", "Erro");
            }
        }

        public void excluirPedidoFirebase(PedidoMonitor item)
        {
            try
            {
                String chaveOndeDeletar = item.Identificador.Trim();
                //ALTERAMOS PARA QUE O APP EXCLUA AS TABELAS INTERNAS
                var set = client.Set(@"andamento/" + chaveOndeDeletar + "/status", "FINALIZADO");
                //EXCLUIR TUDO
                var delete1 = client.Delete(@"pedido/" + chaveOndeDeletar);
                var delete2 = client.Delete(@"andamento/" + chaveOndeDeletar);
                var delete3 = client.Delete(@"pedido-itens/" + chaveOndeDeletar);
                var delete4 = client.Delete(@"notificacao/" + chaveOndeDeletar);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao escluir este pedido no Aplicativo.\nTente atualizar o item novamente.", "Erro");
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar este pedido?", "Exclusão de Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idPedidoGerado = AcessoFB.fb_pesquisaIdPedido(itemSelecionado.Senha, itemSelecionado.Data);
                //APAGAMOS O PEDIDO
                //APAGAR NO BANCO
                AcessoFB.fb_excluirPedido(idPedidoGerado);
                AcessoFB.fb_excluirPedidoMonitor(itemSelecionado);
                //APAGAR NO FIREBASE
                excluirPedidoFirebase(itemSelecionado);

                mostraTelaConfirmacao();
                carregaDataGridView();
            }
            else
            {
                return;
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

        private void btCupom_Click(object sender, EventArgs e)
        {
            CupomDeDesconto nova = new CupomDeDesconto();
            nova.ShowDialog();
        }

        private void btAnuncio_Click(object sender, EventArgs e)
        {
            AdicionarAvisoApp nova = new AdicionarAvisoApp();
            nova.ShowDialog();
        }

        private void btLocalizarMotoboy_Click(object sender, EventArgs e)
        {
            PosicaoMotoboy nova = new PosicaoMotoboy();
            nova.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        /*public void baixarTodoCardapio()
{
listaCardapio.Clear();
FirebaseResponse response = client.Get(@"cardapio");
Dictionary<string, Itens_Firebase> getCardapio = JsonConvert.DeserializeObject<Dictionary<string, Itens_Firebase>>(response.Body.ToString());
foreach (var item in getCardapio)
{
Itens_Firebase inserir = new Itens_Firebase();
inserir.id = item.Value.id;
inserir.nome = item.Value.nome;
inserir.valor = item.Value.valor;
inserir.descricao = item.Value.descricao;
inserir.tipo = item.Value.tipo;
inserir.grupo = item.Value.grupo;
listaCardapio.Add(inserir);
}
AcessoFB.fb_zerarTabelaProduto();
AcessoFB.fb_adicionarProdutoTodosFirebase(listaCardapio);
}
public void baixarTodasTaxa()
{
listaTaxasFirebase.Clear();
FirebaseResponse response = client.Get(@"taxa");
Dictionary<string, TaxasFirebase> getCardapio = JsonConvert.DeserializeObject<Dictionary<string, TaxasFirebase>>(response.Body.ToString());
foreach (var item in getCardapio)
{
TaxasFirebase inserir = new TaxasFirebase();
inserir.id = item.Value.id;
inserir.bairro = item.Value.bairro;
inserir.valor = item.Value.valor;
listaTaxasFirebase.Add(inserir);
}
AcessoFB.fb_zerarTabelaTaxa();
AcessoFB.fb_adicionarTaxasTodasFirebase(listaTaxasFirebase);
}*/
    }
}
