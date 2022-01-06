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
    public partial class Motoboy : Form
    {
        public Motoboy()
        {
            InitializeComponent();
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

        public void verificaFechamento()
        {
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);

            int qtdentregadores = AcessoFB.fb_contaQtdEntregadores();
            String[] listar = new String[qtdentregadores];
            listar = AcessoFB.fb_buscaNomesEntregadoresListar(qtdentregadores);
       
            for (int i = 0; i < qtdentregadores; i++)
            {
                int id = AcessoFB.fb_pesquisaIdMotoboyPorNome(listar[i]);
                int resultado = AcessoFB.fb_verficaFechamento(id, data);
                if(resultado == -1)
                {
                    Fechamento novo = new Fechamento();
                    novo.Id = AcessoFB.fb_verificaUltIdFechamento() + 1;
                    novo.Motoboy = id;
                    novo.Troco = 0;
                    novo.Taxa = 0;
                    novo.Total = 0;
                    novo.Entrega = 0;
                    novo.Data = data;
                    AcessoFB.fb_adicionaNovoFechamento(novo);
                }
            }

        }

        private void btEntrega_Click(object sender, EventArgs e)
        {
            this.tabEntregas.SelectedTab = tabEntrega;
        }

        private void btInfMotoboy_Click(object sender, EventArgs e)
        {
            this.tabEntregas.SelectedTab = tabEntregador;
        }

        private void btFechamento_Click(object sender, EventArgs e)
        {
            this.tabEntregas.SelectedTab = tabFechamento;
        }

        private void btOutroApp_Click(object sender, EventArgs e)
        {
            this.tabEntregas.SelectedTab = tabOutrosApps;
        }

        private void btMotoboy_Click(object sender, EventArgs e)
        {
            this.tabEntregas.SelectedTab = tabMotoboy;
        }

        private void btTroco_Click(object sender, EventArgs e)
        {
            this.tabEntregas.SelectedTab = tabTroco;
        }

        private void tabMotoboy_Click(object sender, EventArgs e)
        {

        }

        int ultBotPressEntregador = 0;

//#####################################ABA-MOTOBOY#########################################
        private void tabEntregas_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabMotoboy)
            {
                gbNovoMotoboy.Enabled = false;
                btAddMotoboy.Enabled = true;
                btPesquisarMotoboy.Enabled = true;
                tbCodigo.Text = "";
                tbDesc.Text = "";
            }
            if (e.TabPage == tabEntrega)
            {
                dataGridView2.DataSource = null;
                CarregaGridEntregas();
                CarregaComboBoxEntregas();
            }
            if (e.TabPage == tabTroco)
            {
                ultBotPressTroco = 0;
                verificaFechamento();
                CarregaComboBoxTroco();
                tbDesconto.Enabled = false;
                tbDesconto.Text = "";
                labelTroco.Text = "R$0,00";
                comboBoxTroco.SelectedItem = null;
            }
            if (e.TabPage == tabEntregador)
            {
                ultBotPressEntregador = 0;
                dataGridView1.DataSource = null;
                CarregaGridSemEntregador();
                CarregaComboBoxEntregador();
                comboBoxTroco.SelectedItem = null;
            }

            if (e.TabPage == tabOutrosApps)
            {
                tbTotalOutApp.Text = "";
                tbTaxaOutApp.Text = "";
                tbNumPedOutApp.Text = "";
                tbTotalOutApp.Enabled = false;
                tbTaxaOutApp.Enabled = false;
                tbNumPedOutApp.Enabled = false;
                rbDin.Checked = false;
                rbCart.Checked = false;
                rbDin.Enabled = false;
                rbCart.Enabled = false;
                CarregaGridOutrosApps();
            }

        }

        private void btAddMotoboy_Click(object sender, EventArgs e)
        {
            ultBotPress = 1;
            gbNovoMotoboy.Enabled = true;
            tbCodigo.Text = (AcessoFB.fb_verificaUltIdMotoboy() + 1).ToString();
            tbDesc.Select();
            tbDesc.Focus();
        }
        int ultBotPress = 0;

        public int validaCampos()
        {
            if (tbDesc.Text.ToString() == "")
            {
                MessageBox.Show("Nome não informado!", "Erro");
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
        }
        public void adicionarMotoboy()
        {
            Motoboys novo = new Motoboys();
            novo.Nome = tbDesc.Text.ToString();
            novo.Nome = RemoverAcentos(novo.Nome);
            novo.Nome.Replace("'", " ").Trim();
            novo.Id = AcessoFB.fb_verificaUltIdMotoboy() + 1;
            AcessoFB.fb_adicionarMotoboy(novo);
            mostraTelaConfirmacao();
            gbNovoMotoboy.Enabled = false;
            btAddMotoboy.Enabled = true;
            btPesquisarMotoboy.Enabled = true;
            tbCodigo.Text = "";
            tbDesc.Text = "";
        }

        public void confirmaMotoboy()
        {
            if (validaCampos() == 1)
            {
                return;
            }
            if (validaCampos() == 2)
            {
                adicionarMotoboy();
            }
        }


        public void atualizarMotoboy()
        {
            Motoboys novo = new Motoboys();
            novo.Nome = tbDesc.Text.ToString();
            novo.Nome = RemoverAcentos(novo.Nome);
            novo.Nome.Replace("'", " ").Trim();
            novo.Id = Convert.ToInt32(tbCodigo.Text);
            AcessoFB.fb_atualizaMotoboy(novo);
            mostraTelaConfirmacao();
            gbNovoMotoboy.Enabled = false;
            btAddMotoboy.Enabled = true;
            btPesquisarMotoboy.Enabled = true;
            tbCodigo.Text = "";
            tbDesc.Text = "";
        }

        public void confirmaUpdateMotoboy()
        {
            if (validaCampos() == 1)
            {
                return;
            }
            if (validaCampos() == 2)
            {
                atualizarMotoboy();
            }
        }

        private void btConfirmarMotoboy_Click(object sender, EventArgs e)
        {
            if (ultBotPress == 1)
            {
                confirmaMotoboy();
                btAddMotoboy.Enabled = true;
                btPesquisarMotoboy.Enabled = true;
            }
            if (ultBotPress == 2)
            {
                confirmaUpdateMotoboy();
                btAddMotoboy.Enabled = true;
                btPesquisarMotoboy.Enabled = true;
            }
            //Ajusta parametro caso exista mais de 1 motoboy cadastrado
            int qtdMotAtual = AcessoFB.fb_contaQtdEntregadores();
            if(qtdMotAtual != 1)
            {
                Parametros parametros = AcessoFB.fb_recuperaParametrosSistema();
                parametros.motoboy = 0;
                AcessoFB.fb_atualizarParametrosSistema(parametros);
            }
            
            btAddMotoboy.Enabled = true;
            btPesquisarMotoboy.Enabled = true;
        }

        public void recebeValorConsulta(int codMotoboy)
        {
            if (codMotoboy == 0)
            {
                tbCodigo.Text = "";
                tbDesc.Text = "";
            }
            else
            {
                tbCodigo.Text = codMotoboy.ToString();
                Motoboys buscado = AcessoFB.fb_pesquisaMotoboyPorCodigo(codMotoboy);
                tbDesc.Text = buscado.Nome.Trim();
            }
        }
        public void desabilitaTBNovoMotoboy()
        {
            tbCodigo.Enabled = false;
            tbDesc.Enabled = false;;
        }

        public void habilitaBotoesNovoMotoboy()
        {
            btCancelarMotoboy.Enabled = true;
            btEditarMotoboy.Enabled = true;
            btExcluirMotoboy.Enabled = true;
            btConfirmarMotoboy.Enabled = true;
        }
        private void btPesquisarMotoboy_Click(object sender, EventArgs e)
        {
            ultBotPress = 2;
            ConsultaMotoboy nova = new ConsultaMotoboy();
            nova.ShowDialog();
            recebeValorConsulta(nova.retornaValor());
            gbNovoMotoboy.Enabled = true;
            desabilitaTBNovoMotoboy();
            habilitaBotoesNovoMotoboy();
        }

        private void btCancelarMotoboy_Click(object sender, EventArgs e)
        {
            btAddMotoboy.Enabled = true;
            btPesquisarMotoboy.Enabled = true;
            tbCodigo.Text = "";
            tbDesc.Text = "";
            gbNovoMotoboy.Enabled = false;
        }

        private void btExcluirMotoboy_Click(object sender, EventArgs e)
        {
            AcessoFB.fb_excluirMotoboy(Convert.ToInt32(tbCodigo.Text));
            tbCodigo.Text = "";
            tbDesc.Text = "";
            gbNovoMotoboy.Enabled = false;
            mostraTelaConfirmacao();
            btAddMotoboy.Enabled = true;
            btPesquisarMotoboy.Enabled = true;
        }

        private void btEditarMotoboy_Click(object sender, EventArgs e)
        {
            if(tbCodigo.Text == "")
            {
                MessageBox.Show("Não há motoboy para editar!", "Alerta");
                return;
            }
            else
            {
                ultBotPress = 2;
                tbDesc.Enabled = true;
                tbDesc.Select();
                tbDesc.Focus();
            }          
        }

        private void tbDesc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btConfirmarMotoboy_Click(sender,e);
            }
        }
//###############################################ABA-ENTREGAS###################################
        
        public void ContaEntregasMostradas()
        {
            this.labelEntregasQTD.Text = this.dataGridView1.Rows.Count.ToString();
        }
        
        public void CarregaGridEntregas()
        {
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable entregas = new DataTable("Entregas");
            DataSet dsFinal = new DataSet();
            entregas = AcessoFB.fb_buscaEntregasPainel(data);
            dsFinal.Tables.Add(entregas);
            bindingSource1.DataSource = entregas;
            dataGridView1.DataSource = bindingSource1;
            ContaEntregasMostradas();
        }

        public void CarregaGridEntregasPorNome(String nome)
        {
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            int cod = -1;
            if (nome == "-SEM-MOTOBOY-")
            {
                cod = 0;
            }
            else
            {
                String buscar = comboBox1.SelectedItem.ToString();
                cod= AcessoFB.fb_pesquisaIdMotoboyPorNome(buscar);
            }

            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable entregas = new DataTable("Entregas");
            DataSet dsFinal = new DataSet();
            entregas = AcessoFB.fb_buscaEntregasPainelPorNome(data, cod);
            dsFinal.Tables.Add(entregas);
            bindingSource1.DataSource = entregas;
            dataGridView1.DataSource = bindingSource1;
            ContaEntregasMostradas();
        }




        public void CarregaComboBoxEntregas()
        {
            comboBox1.Items.Clear();

            int qtdentregadores = AcessoFB.fb_contaQtdEntregadores();
            String[] listar = new String[qtdentregadores];
            listar = AcessoFB.fb_buscaNomesEntregadoresListar(qtdentregadores);

            for (int i = 0; i < qtdentregadores; i++)
            {
                comboBox1.Items.Add(listar[i].ToString());
            }
            comboBox1.Items.Add("-SEM-MOTOBOY-");
            comboBox1.Items.Add("-TODAS-");
        }

        private void Motoboy_Load(object sender, EventArgs e)
        {
            verificaFechamento();
            CarregaGridEntregas();
            CarregaComboBoxEntregas();
            CarregaGridSemEntregador();
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "-TODAS-")
            {
                CarregaGridEntregas();
                comboBox1.SelectedItem = null;
            }
            else
            {
                CarregaGridEntregasPorNome(comboBox1.SelectedItem.ToString());
            }
            
        }
        //#####################################ABA-TROCO###################################
        int enterJaFoiPress = 0;
        int ultBotPressTroco = 0;

        private void tbDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (tbDesconto.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }
            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void tbDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enterJaFoiPress = 1;
                if (tbDesconto.Text == "")
                {
                    return;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbDesconto.Text);
                    tbDesconto.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);

                    btAdicionarTroco_Click(sender, e);
                }
            }
        }

        private void tbDesconto_Enter(object sender, EventArgs e)
        {
            enterJaFoiPress = 0;
            if (tbDesconto.Text == "")
            {
                return;
            }
            else
            {
                Decimal total;
                String resto;
                int tamanho = 0;
                tamanho = tbDesconto.Text.Length;
                resto = tbDesconto.Text.Substring(2, tamanho - 2);
                total = Convert.ToDecimal(resto);
                tbDesconto.Text = total.ToString();  
            }
        }

        private void tbDesconto_Leave(object sender, EventArgs e)
        {
            if (enterJaFoiPress == 1)
            {
                return;
            }
            else
            {
                if (tbDesconto.Text == "")
                {
                    return;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbDesconto.Text);
                    tbDesconto.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                }
            }
        }
        public void CarregaComboBoxTroco()
        {
            comboBoxTroco.Items.Clear();

            int qtdentregadores = AcessoFB.fb_contaQtdEntregadores();
            String[] listar = new String[qtdentregadores];
            listar = AcessoFB.fb_buscaNomesEntregadoresListar(qtdentregadores);

            for (int i = 0; i < qtdentregadores; i++)
            {
                comboBoxTroco.Items.Add(listar[i].ToString());
            }
        }


        public void BuscaTroco(String nome)
        {
            int id_motoboy = AcessoFB.fb_pesquisaIdMotoboyPorNome(nome);
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            Decimal valor = AcessoFB.fb_buscaTrocoMotoboy(id_motoboy, data);
            String mostrar = valor.ToString("C", CultureInfo.CurrentCulture);
            labelTroco.Text = mostrar;
            tbDesconto.Text = mostrar;
        }
            

        private void comboBoxTroco_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BuscaTroco(comboBoxTroco.SelectedItem.ToString());
        }

        private void btEditarTroco_Click(object sender, EventArgs e)
        {
            if(comboBoxTroco.SelectedItem == null)
            {
                return;
            }
            else
            {
                ultBotPressTroco = 1;
                tbDesconto.Enabled = true;
                tbDesconto.Select();
                tbDesconto.Focus();
            }
            
        }

        private void btAdicionarTroco_Click(object sender, EventArgs e)
        {
            if (ultBotPressTroco == 0)
            {
                return;
            }
            else
            {
                if (enterJaFoiPress == 1)
                {
                    //return;
                }
                else
                {
                    if (tbDesconto.Text == "")
                    {
                        return;
                    }
                    else
                    {
                        Decimal ajuste = 0;
                        ajuste = Convert.ToDecimal(tbDesconto.Text);
                        tbDesconto.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                    }
                }

                Decimal total;
                String resto;
                int tamanho = 0;
                tamanho = tbDesconto.Text.Length;
                resto = tbDesconto.Text.Substring(2, tamanho - 2);
                total = Convert.ToDecimal(resto);
                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10);
                int id_motoboy = AcessoFB.fb_pesquisaIdMotoboyPorNome(comboBoxTroco.SelectedItem.ToString());
                AcessoFB.fb_atualizaTrocoMotoboy(id_motoboy, data, total);
                mostraTelaConfirmacao();
                tbDesconto.Text = "";
                labelTroco.Text = "R$0,00";
                comboBoxTroco.SelectedItem = null;
                tbDesconto.Enabled = false;
            }
                
        }

        private void btCancelarTroco_Click(object sender, EventArgs e)
        {
            tbDesconto.Text = "";
            labelTroco.Text = "R$0,00";
            comboBoxTroco.SelectedItem = null;
            tbDesconto.Enabled = false;
        }
        //####################################ABA-ENTREGADOR####################################
        
        int idSelEntregador = 0;

        private void pictureBox2_Click_1(object sender, EventArgs e) //btEditarEntregador
        {
            ultBotPressEntregador = 1;
            CarregaGridEntregadorEditar();
        }
        public void CarregaComboBoxEntregador()
        {
            comboBoxEntregador.Items.Clear();

            int qtdentregadores = AcessoFB.fb_contaQtdEntregadores();
            String[] listar = new String[qtdentregadores];
            listar = AcessoFB.fb_buscaNomesEntregadoresListar(qtdentregadores);

            for (int i = 0; i < qtdentregadores; i++)
            {
                comboBoxEntregador.Items.Add(listar[i].ToString());
            }
        }
        public void CarregaGridSemEntregador()
        {
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            int cod = 0;
            dataGridView2.DataSource = null;
            BindingSource bindingSource2 = new BindingSource();
            DataTable entregas1 = new DataTable("Entregas");
            DataSet dsFinal1 = new DataSet();
            entregas1 = AcessoFB.fb_buscaEntregasSemMotoboy(data, cod);
            dsFinal1.Tables.Add(entregas1);
            dataGridView2.DataSource = entregas1;
            int linhas = Convert.ToInt32(this.dataGridView2.Rows.Count);
            if(linhas == 0)
            {
                labelPedido.Text = "--";
            }
        }

        public void CarregaGridEntregadorEditar()
        {
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            dataGridView2.DataSource = null;
            BindingSource bindingSource2 = new BindingSource();
            DataTable entregas1 = new DataTable("Entregas");
            DataSet dsFinal1 = new DataSet();
            entregas1 = AcessoFB.fb_buscaEntregasEditarMotoboy(data);
            dsFinal1.Tables.Add(entregas1);
            dataGridView2.DataSource = entregas1;
        }

        String nomeClienteAtualizaMotoboy = "";
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idSelEntregador = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                nomeClienteAtualizaMotoboy = Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value).Replace("  ","");
                labelPedido.Text = idSelEntregador.ToString();
            }
            catch
            {
                //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
            }
        }

        private void btConfirmarEntregador_Click(object sender, EventArgs e)
        {
            if (comboBoxEntregador.SelectedItem is null)
            {
                MessageBox.Show("Não foi selecionado um motoboy!","Alerta");
                return;
            }
            else
            {
                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10); 
                int id_motoboy = AcessoFB.fb_pesquisaIdMotoboyPorNome(comboBoxEntregador.SelectedItem.ToString());             
                Decimal valor = AcessoFB.fb_buscaTrocoMotoboy(id_motoboy, data);
                if(valor == 0)
                {
                    MessageBox.Show("O motoboy não possui troco! \nÉ necessário informar troco antes de liberar a entrega.", "Alerta");
                    this.tabEntregas.SelectedTab = tabTroco;
                    comboBoxTroco.SelectedItem = comboBoxEntregador.SelectedItem;
                    tbDesconto.Enabled = true;
                    ultBotPressTroco = 1;
                    tbDesconto.Select();
                    tbDesconto.Focus();
                    return;
                }
                else
                { 
                    if(ultBotPressEntregador == 0)
                    {
                        int senha = Convert.ToInt32(labelPedido.Text);
                        int id_pedido = AcessoFB.fb_pesquisaIdPedido(senha, data);

                        if (nomeClienteAtualizaMotoboy.Contains("PEDIDOS 10"))
                        {
                            AcessoFB.fb_atualizaEntregaMotoboyOutrosApps(senha, id_motoboy, data);
                        }
                        else
                        {
                            AcessoFB.fb_atualizaEntregaMotoboy(senha, id_motoboy, data, nomeClienteAtualizaMotoboy);
                        }
                        mostraTelaConfirmacao();
                        CarregaGridSemEntregador();
                        CarregaComboBoxEntregador();
                        comboBoxEntregador.SelectedItem = null;
                    }
                    else
                    {
                        int senha = Convert.ToInt32(labelPedido.Text);
                        int id_pedido = AcessoFB.fb_pesquisaIdPedido(senha, data);

                        if (nomeClienteAtualizaMotoboy.Contains("PEDIDOS 10"))
                        {
                            AcessoFB.fb_atualizaEntregaMotoboyOutrosApps(senha, id_motoboy, data);
                        }
                        else
                        {
                            AcessoFB.fb_atualizaEntregaMotoboy(senha, id_motoboy, data, nomeClienteAtualizaMotoboy);
                        }
                        mostraTelaConfirmacao();
                        CarregaGridSemEntregador();
                        CarregaComboBoxEntregador();
                        comboBoxEntregador.SelectedItem = null;
                    }
                }              
            }
        }

        private void tabEntregador_Click(object sender, EventArgs e)
        {

        }
        private void btCancelarEntregador_Click(object sender, EventArgs e)
        {
            comboBoxEntregador.SelectedItem = null;
            CarregaGridSemEntregador();
        }
        //###################################ABA-OUTROS-APPS###########################
        int ultBotPressOutApp = 0;

        public void CarregaGridOutrosApps()
        {
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            dataGridView3.DataSource = null;
            BindingSource bindingSource2 = new BindingSource();
            DataTable entregas1 = new DataTable("Entregas");
            DataSet dsFinal1 = new DataSet();
            entregas1 = AcessoFB.fb_buscaEntregasOutrosApps(data);
            dsFinal1.Tables.Add(entregas1);
            dataGridView3.DataSource = entregas1;

        }
        private void tbTotalOutApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (tbTotalOutApp.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }
            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        int enterJaFoiPressOA = 0;
        private void tbTotalOutApp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enterJaFoiPressOA = 1;
                if (tbTotalOutApp.Text == "")
                {
                    return;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbTotalOutApp.Text);
                    tbTotalOutApp.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);

                    tbTaxaOutApp.Select();
                    tbTaxaOutApp.Focus();
                }
            }
        }

        private void tbTotalOutApp_Enter(object sender, EventArgs e)
        {
            enterJaFoiPressOA = 0;
            if (tbTotalOutApp.Text == "")
            {
                return;
            }
            else
            {
                Decimal total;
                String resto;
                int tamanho = 0;
                tamanho = tbTotalOutApp.Text.Length;
                resto = tbTotalOutApp.Text.Substring(2, tamanho - 2);
                total = Convert.ToDecimal(resto);
                tbTotalOutApp.Text = total.ToString();
            }
        }

        private void tbTotalOutApp_Leave(object sender, EventArgs e)
        {
            if (enterJaFoiPressOA == 1)
            {
                return;
            }
            else
            {
                if (tbTotalOutApp.Text == "")
                {
                    return;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbTotalOutApp.Text);
                    tbTotalOutApp.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                }
            }
        }

        private void tbTaxaOutApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (tbTaxaOutApp.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }
            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        int enterJaFoiPressOA1 = 0;
        private void tbTaxaOutApp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enterJaFoiPressOA1 = 1;
                if (tbTaxaOutApp.Text == "")
                {
                    return;
                }
                else
                {
                    if(tbTaxaOutApp.Text.Contains("R$"))
                    {
                        Decimal total;
                        String resto;
                        int tamanho = 0;
                        tamanho = tbTaxaOutApp.Text.Length;
                        resto = tbTaxaOutApp.Text.Substring(2, tamanho - 2);
                        total = Convert.ToDecimal(resto);
                        tbTaxaOutApp.Text = total.ToString();
                    }
                    else
                    {
                        Decimal ajuste = 0;
                        ajuste = Convert.ToDecimal(tbTaxaOutApp.Text);
                        tbTaxaOutApp.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                    }
                    btConfirmarOutApp_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.D)
            {
                rbDin.Checked = true;
            }
            if (e.KeyCode == Keys.C)
            {
                rbCart.Checked = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTotalOutApp.Select();
                tbTotalOutApp.Focus();
            }
        }

        private void btAddOutApp_Click(object sender, EventArgs e)
        {
            ultBotPressOutApp = 1;
            tbTotalOutApp.Text = "";
            tbTaxaOutApp.Text = "";
            tbNumPedOutApp.Text = "";
            tbTotalOutApp.Enabled = true;
            tbTaxaOutApp.Enabled = true;
            tbNumPedOutApp.Enabled = true;
            rbCart.Checked = false;
            rbDin.Checked = true;
            rbCart.Enabled = true;
            rbDin.Enabled = true;
            metPag = 1;
            tbNumPedOutApp.Select();
            tbNumPedOutApp.Focus();
        }

        private void btCancelarOutApp_Click(object sender, EventArgs e)
        {
            tbTotalOutApp.Text = "";
            tbTaxaOutApp.Text = "";
            tbNumPedOutApp.Text = "";
            tbTotalOutApp.Enabled = false;
            tbTaxaOutApp.Enabled = false;
            tbNumPedOutApp.Enabled = false;
            rbCart.Checked = false;
            rbDin.Checked = false;
            rbCart.Enabled = false;
            rbDin.Enabled = false;
        }
        private void btExcluirOutrosApps_Click(object sender, EventArgs e)
        {
            if (this.dataGridView3.Rows.Count <= 0)
            {
                MessageBox.Show("Não existem pedidos de outros apps cadastrados!\nNão é possível excluir.", "Alerta");
                return;
            }
            else
            {
                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10);

                int senha = Convert.ToInt32(tbNumPedOutApp.Text);

                if (tbNumPedOutApp.Text == "" || tbNumPedOutApp.Enabled == true)
                {
                    return;
                }
                else
                {
                    int idEntrega = AcessoFB.fb_buscaIdEntregaExclusaoOutrosApps(senha, data);
                    int idLancamento = AcessoFB.fb_buscaIdEntregaLancamento(senha, data);
                    AcessoFB.fb_excluirPedidoOutrosApps(idEntrega, idLancamento);
                    mostraTelaConfirmacao();
                    tbTotalOutApp.Text = "";
                    tbTaxaOutApp.Text = "";
                    tbNumPedOutApp.Text = "";
                    tbTotalOutApp.Enabled = false;
                    tbTaxaOutApp.Enabled = false;
                    tbNumPedOutApp.Enabled = false;
                    rbDin.Checked = false;
                    rbCart.Checked = false;
                    rbDin.Enabled = false;
                    rbCart.Enabled = false;
                    CarregaGridOutrosApps();
                }
            }
        }

        private void tbTaxaOutApp_Enter(object sender, EventArgs e)
        {
            enterJaFoiPressOA1 = 0;
            if (tbTaxaOutApp.Text == "")
            {
                return;
            }
            else
            {
                Decimal total;
                String resto;
                int tamanho = 0;
                tamanho = tbTaxaOutApp.Text.Length;
                resto = tbTaxaOutApp.Text.Substring(2, tamanho - 2);
                total = Convert.ToDecimal(resto);
                tbTaxaOutApp.Text = total.ToString();
            }
        }

        private void tbTaxaOutApp_Leave(object sender, EventArgs e)
        {
            if (enterJaFoiPressOA1 == 1)
            {
                return;
            }
            else
            {
                if (tbTaxaOutApp.Text == "")
                {
                    return;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbTaxaOutApp.Text);
                    tbTaxaOutApp.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                }
            }
        }
        public void adicionaNovoLancamento()
        {
            if (tbTotalOutApp.Text == "")
            {
                MessageBox.Show("Não foi informado valor para a inserção do lançamento.", "Alerta");

                return;
            }
            else
            {
                Decimal total;
                String resto;
                int tamanho = 0;
                tamanho = tbTotalOutApp.Text.Length;
                resto = tbTotalOutApp.Text.Substring(2, tamanho - 2);
                total = Convert.ToDecimal(resto);

                String atual = DateTime.Now.ToString();
                String data = atual.Substring(0, 10);

                int pagamento = metPag;

                Lancamentos novoLanc = new Lancamentos();
                novoLanc.Id = AcessoFB.fb_verificaUltIdLanc() + 1;
                novoLanc.Data = data;
                novoLanc.Valor = total;
                novoLanc.Pagamento = pagamento;
                novoLanc.Tipo = 1;
                novoLanc.Pedido = 0; //É PEDIDO DE UM APP EXTERNO, COMO PEDIDOS 10 OU DELIVERY MUCH
                AcessoFB.fb_adicionarLanc(novoLanc);
            }
        }

        private void btConfirmarOutApp_Click(object sender, EventArgs e)
        {
            if(tbNumPedOutApp.Text == "")
            { 
                MessageBox.Show("Não informado numero do pedido!", "Alerta");
                return;
            }
            if (metPag == 0)
            {
                MessageBox.Show("Não foi informado um método de pagamento.", "Erro");
                return;
            }

            if (ultBotPressOutApp == 0)
            {
                return;
            }

            else
            {
                if (enterJaFoiPressOA == 1)
                {
                    //return;
                }
                else
                {
                    if (tbTotalOutApp.Text == "")
                    {
                        return;
                    }
                }

                if (enterJaFoiPressOA1 == 1)
                {
                    //return;
                }
                else
                {
                    if (tbTaxaOutApp.Text == "")
                    {
                        return;
                    }
                }

                if (ultBotPressOutApp == 1) //bt adicionar
                {
                    Decimal total;
                    String resto;
                    int tamanho = 0;


                    if (tbTotalOutApp.Text.Contains("R$"))
                    {
                        tamanho = tbTotalOutApp.Text.Length;
                        resto = tbTotalOutApp.Text.Substring(2, tamanho - 2);
                        total = Convert.ToDecimal(resto);
                    }
                    else
                    {
                        total = total = Convert.ToDecimal(tbTotalOutApp.Text);
                    }

                    Decimal total1;
                    String resto1;
                    int tamanho1 = 0;

                    if (tbTaxaOutApp.Text.Contains("R$"))
                    {
                        tamanho1 = tbTaxaOutApp.Text.Length;
                        resto1 = tbTaxaOutApp.Text.Substring(2, tamanho1 - 2);
                        total1 = Convert.ToDecimal(resto1);
                    }
                    else
                    {
                        total1 = Convert.ToDecimal(tbTaxaOutApp.Text);
                    }

                    String data = DateTime.Now.ToString();
                    data = data.Substring(0, 10);

                    Entregas nova = new Entregas();
                    nova.Id = AcessoFB.fb_verificaUltIdEntrega() + 1;
                    nova.Pedido = 0;
                    nova.Senha = Convert.ToInt32(tbNumPedOutApp.Text);
                    nova.Cliente = "PEDIDOS 10";
                    nova.Total = total;
                    nova.Taxa = total1;
                    nova.Entregador = 0;
                    //Verifica se o parametro para unico motoboy está ativo
                    Parametros parametros = AcessoFB.fb_recuperaParametrosSistema();
                    int parametroUnicoMotoboy = parametros.motoboy;
                    if (parametroUnicoMotoboy == 1)
                    {
                        int entregador = AcessoFB.fb_buscaIdUnicoMotoboy();
                        nova.Entregador = entregador;
                    }
                    else
                    {
                        nova.Entregador = 0;
                    }
                    nova.Data = data;
                    nova.Pagamento = metPag;
                    int id = AcessoFB.fb_verificaUltIdLanc() + 1;
                    nova.Lancamento = id;
                    AcessoFB.fb_adicionaNovaEntrega(nova);
                    adicionaNovoLancamento();

                    mostraTelaConfirmacao();
                    tbTotalOutApp.Text = "";
                    tbTaxaOutApp.Text = "";
                    tbNumPedOutApp.Text = "";
                    tbTotalOutApp.Enabled = false;
                    tbTaxaOutApp.Enabled = false;
                    tbNumPedOutApp.Enabled = false;
                    rbDin.Checked = false;
                    rbCart.Checked = false;
                    rbDin.Enabled = false;
                    rbCart.Enabled = false;
                    CarregaGridOutrosApps();
                }

                else //bt editar
                {
                    Decimal total;
                    String resto;
                    int tamanho = 0;
                    

                    if (tbTotalOutApp.Text.Contains("R$"))
                    {
                        tamanho = tbTotalOutApp.Text.Length;
                        resto = tbTotalOutApp.Text.Substring(2, tamanho - 2);
                        total = Convert.ToDecimal(resto);
                    }
                    else
                    {
                        total = total = Convert.ToDecimal(tbTotalOutApp.Text);
                    }

                    Decimal total1;
                    String resto1;
                    int tamanho1 = 0;

                    if(tbTaxaOutApp.Text.Contains("R$"))
                    {
                        tamanho1 = tbTaxaOutApp.Text.Length;
                        resto1 = tbTaxaOutApp.Text.Substring(2, tamanho1 - 2);
                        total1 = Convert.ToDecimal(resto1);
                    }
                    else
                    {
                        total1 = Convert.ToDecimal(tbTaxaOutApp.Text);
                    }

                    String data = DateTime.Now.ToString();
                    data = data.Substring(0, 10);

                    Entregas atualiza = new Entregas();
                    atualiza.Senha = Convert.ToInt32(tbNumPedOutApp.Text);
                    atualiza.Total = total;
                    atualiza.Taxa = total1;
                    atualiza.Data = data;
                    atualiza.Pagamento = metPag;
                    atualiza.Lancamento = AcessoFB.fb_buscaIdEntregaLancamento(atualiza.Senha, atualiza.Data);
                    
                    AcessoFB.fb_atualizaEntregaOutrosApps(atualiza);
                    AcessoFB.fb_atualizaLancamento(atualiza);

                    mostraTelaConfirmacao();
                    tbTotalOutApp.Text = "";
                    tbTaxaOutApp.Text = "";
                    tbNumPedOutApp.Text = "";
                    tbTotalOutApp.Enabled = false;
                    tbTaxaOutApp.Enabled = false;
                    tbNumPedOutApp.Enabled = false;
                    rbDin.Checked = false;
                    rbCart.Checked = false;
                    rbDin.Enabled = false;
                    rbCart.Enabled = false;
                    CarregaGridOutrosApps();
                }
            }
        }

        private void btEditarOutApp_Click(object sender, EventArgs e)
        {
            if(this.dataGridView3.Rows.Count <= 0)
            {
                MessageBox.Show("Não existem pedidos de outros apps cadastrados!\nNão é possível editar.", "Alerta");
                return;
            }
            else
            {
                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10);

                int senha = Convert.ToInt32(tbNumPedOutApp.Text);

                if (tbNumPedOutApp.Text == "" || tbNumPedOutApp.Enabled == true)
                {
                    return;
                }
                else
                {
                    /*if(AcessoFB.fb_verificaSeEntregaTemMotoboy(senha, data) == 0)
                    {
                        MessageBox.Show("Não é possivel alterar uma entrega que já possui entregador ", "Alerta");
                        return;
                    }*/
                    ultBotPressOutApp = 2;
                    tbTaxaOutApp.Enabled = true;
                    tbTotalOutApp.Enabled = true;
                    rbCart.Enabled = true;
                    rbDin.Enabled = true;
                    tbTotalOutApp.Select();
                    tbTotalOutApp.Focus();
                }
            }
        }
        
        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            try
            {
                tbNumPedOutApp.Text = Convert.ToString(dataGridView3.CurrentRow.Cells[0].Value);
                tbTotalOutApp.Text = Convert.ToString(dataGridView3.CurrentRow.Cells[1].Value);
                tbTaxaOutApp.Text = Convert.ToString(dataGridView3.CurrentRow.Cells[2].Value);
                metPag = AcessoFB.fb_buscaMetodoPagOutrosApps(Convert.ToInt32(tbNumPedOutApp.Text), data);
                if(metPag == 1)
                {
                    rbDin.Checked = true;
                }
                if(metPag == 2)
                {
                    rbCart.Checked = true;
                }
            }
            catch
            {
                
            }
        }

        int metPag = 0;

        private void rbDin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDin.Checked == true)
            {
                metPag = 1;
            }
            if (rbDin.Checked == false)
            {
                metPag = 2;
            }
        }

        private void rbCart_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCart.Checked == true)
            {
                metPag = 2;
            }
            if (rbCart.Checked == false)
            {
                metPag = 1;
            }
        }
        //#####################################ABA-FECHAMENTO#############################################
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //verifica os trocos
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);

            
            int qtdentregadores = AcessoFB.fb_contaQtdEntregadores();
            String[] listar = new String[qtdentregadores];
            listar = AcessoFB.fb_buscaNomesEntregadoresListar(qtdentregadores);
            /*
            for (int i = 0; i < qtdentregadores; i++)
            {
                int id = AcessoFB.fb_pesquisaIdMotoboyPorNome(listar[i]);
                Decimal valor = AcessoFB.fb_buscaTrocoMotoboy(id, data);
                if (valor == 0)
                {
                    MessageBox.Show("Não há troco informado para o entregador " + listar[i], "Erro");
                    return;
                }
                
            }*/
            //Verifica se existe alguma entrega feita por algum motoboy hj
            int contaTotalEntregas = 0;
            for (int i = 0; i < qtdentregadores; i++)
            {
                int id = AcessoFB.fb_pesquisaIdMotoboyPorNome(listar[i]);
                int existeEntrega = AcessoFB.fb_contaEntregasMotoboy(id, data);
                contaTotalEntregas = contaTotalEntregas + existeEntrega;
            }
            if(contaTotalEntregas == 0)
            {
                MessageBox.Show("Nenhum entregador efetuou entregas hoje \nNão é possível emitir o fechamento", "Erro");
                return;
            }

            

            for (int i = 0; i < qtdentregadores; i++)
            {
                AcessoFB.fb_limpaImpFechamento();

                //Preenche tabela impressão entregas
                int id = AcessoFB.fb_pesquisaIdMotoboyPorNome(listar[i]);
                AcessoFB.insereFechamentoImpressaoEntregas(id, data);

                //Totaliza dados do fechamento
                //Entregas
                int totalEntregas = AcessoFB.fb_contaEntregasMotoboy(id, data);
                AcessoFB.fb_atualizaQtdEntregaFechamento(totalEntregas, id, data);
                //Taxas
                Decimal totalTaxas = AcessoFB.fb_somaTotalTaxaFechamento(id, data);
                AcessoFB.fb_atualizaTotalTaxaFechamento(totalTaxas, id, data);
                //Total
                Decimal totalTotal = AcessoFB.fb_somaTotalTotalFechamento(id, data);
                AcessoFB.fb_atualizaTotalTotalFechamento(totalTotal, id, data);

                //GeraImpressao
                ImpressaoFechamento nova = new ImpressaoFechamento();
                nova.recebeMotoboy(id);
                nova.ShowDialog();

                AcessoFB.fb_limpaImpFechamento();
            }


        }

        private void Motoboy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        
    }
}
