using FireSharp.Config;
using FireSharp.Interfaces;
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
    public partial class CupomDeDesconto : Form
    {
        int ultBotPress = 0;
        int parametroUnico = 0;

        Parametros parametrosSistema = new Parametros();
        public CupomDeDesconto()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "tJVQSamSvHRtZguzUcn0h3YfPGFoEjl37nI2uNDD",
            BasePath = "https://sandra-foods-34d79-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void CupomDeDesconto_Load(object sender, EventArgs e)
        {
            parametrosSistema = AcessoFB.fb_recuperaParametrosSistema();

            if (parametrosSistema.sincronizar == 0)
            {
                MessageBox.Show("A sincronização com o aplicativo está desabilitada.\nNão é possível gerenciar os cupons de desconto.\nVerifique os parâmetros do sistema e tente novamente.", "Aplicativo desabilitado");
                this.Close();
            }
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar ao Firebase.\nVerifique sua conexão com a internet e tente acessar esta tela novamente.", "Erro");
                this.Close();
            }
            cbTipo.Items.Add("PORCENTAGEM");
            cbTipo.Items.Add("VALOR EM R$");
            groupBox1.Enabled = false;
            habilitaBotoesPrincipais();
            carregaDataGridView();
        }
        public void habilitaBotoesPrincipais()
        {
            btAdd.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btSincronizar.Enabled = true;
        }

        public void desabilitaBotoesPrincipais()
        {
            btAdd.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btSincronizar.Enabled = false;
        }

        public void carregaDataGridView()
        {
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable cupons = new DataTable("Cupons");
            DataSet dsFinal = new DataSet();
            cupons = AcessoFB.fb_buscaCuponsConsulta();
            dsFinal.Tables.Add(cupons);
            bindingSource1.DataSource = cupons;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        public void desabilitaGroupBox()
        {
            groupBox1.Enabled = false;
            //groupBox2.Enabled = false;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int pesquisar;
            try
            {
                desabilitaGroupBox();
                habilitaBotoesPrincipais();
                if (dataGridView1.CurrentRow != null)
                {
                    pesquisar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    Cupom buscado = AcessoFB.fb_pesquisaCupomPorId(pesquisar);
                    tbCodigo.Text = buscado.Id.ToString();
                    idAlteracao = buscado.Id;
                    tbDescricao.Text = buscado.Descricao;
                    tbValidade.Text = buscado.Validade;
                    tbMinimo.Text = buscado.Minimo.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$;

                    String tipoStr = "";
                    if (buscado.Tipo == 1)
                        tipoStr = "PORCENTAGEM";
                    else
                        tipoStr = "VALOR EM R$";

                    cbTipo.SelectedItem = tipoStr;

                    String valorStr = "";
                    valorStr = buscado.Valor.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                    if (buscado.Tipo == 1)
                        valorStr = valorStr.Replace("R$", "") + "%";
                    tbValor.Text = valorStr;

                    if(buscado.cupomUnico == 1)
                    {
                        cbUnico.Checked = true;
                    }
                    else
                    {
                        cbUnico.Checked = false;
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

        private void btAdd_Click(object sender, EventArgs e)
        {
            ultBotPress = 1;
            groupBox1.Enabled = true;
            limpaCampos();
            habilitaBotoes();
            desabilitaBotoesPrincipais();
            tbDescricao.Select();
            tbDescricao.Focus();
        }

        public void limpaCampos()
        {
            tbCodigo.Text = "";
            tbDescricao.Text = "";
            tbValidade.Text = "";
            tbMinimo.Text = "";
            cbTipo.SelectedItem = null;
            tbValor.Text = "";
        }
        public void habilitaBotoes()
        {
            btCancelar.Enabled = true;
            btConfirmar.Enabled = true;
        }

        public void desabilitaBotoes()
        {
            btCancelar.Enabled = false;
            btConfirmar.Enabled = false;
        }

        public int entradaValor = 0;
        public int idAlteracao = 0;
        private void btEditar_Click(object sender, EventArgs e)
        {
            ultBotPress = 2;
            entradaValor = 2;
            groupBox1.Enabled = true;
            habilitaBotoes();
            desabilitaBotoesPrincipais();
            tbDescricao.Select();
            tbDescricao.Focus();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este cupom?", "Exclusão de Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AcessoFB.fb_excluirCupom(idAlteracao);
                excluirCupomNoFirebase(idAlteracao);
                limpaCampos();
                desabilitaGroupBox();
                mostraTelaConfirmacao();
                habilitaBotoesPrincipais();
                carregaDataGridView();
            }
            else
            {
                return;
            }
        }
        public void excluirCupomNoFirebase(int idExcluir)
        {
            try
            {
                String chaveOndeDeletar = idExcluir.ToString().PadLeft(5, '0');
                var delete = client.Delete(@"cupom/" + chaveOndeDeletar);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao excluir este item do Aplicativo.\nSincronize os dados novamente para que tudo seja ajustado.", "Erro");
            }
        }

        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
        }

        private void btSincronizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta ação recarregará todos os dados de cupons para o aplicativo.\nO ideal é que este procedimento seja executado somente quando o estabelecimento estiver fechado.\nDeseja executá-lo agora?", "Sincronizar Cupons", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("Deseja realmente continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        carregando.Show();
                        carregando.BringToFront();
                        if (backgroundWorker1.IsBusy != true)
                        {
                            backgroundWorker1.RunWorkerAsync();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ocorreu um erro ao concluir esta ação.\nVerifique sua conexão com a internet e tente novamente.", "Erro na Operação");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        TelaCarregamento carregando = new TelaCarregamento();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AcessoFB.sincronizaCuponsFirebirdComFirebase(config, client);
            fechaCarregamento();
            mostraTelaConfirmacao();
        }

        public void fechaCarregamento()
        {
            if (carregando.InvokeRequired)
            {
                carregando.Invoke(new Action(() => carregando.Close()));
            }
            else
            {
                carregando.Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            desabilitaGroupBox();
            btAdd.Enabled = true;
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if (ultBotPress == 1)
            {
                confirmaCupom();
            }
            if (ultBotPress == 2)
            {
                confirmaUpdate();
            }
        }

        public void confirmaCupom()
        {
            if (validaCampos() == 1)
            {
                return;
            }
            if (validaCampos() == 2)
            {
                adicionaCupom();
            }
        }

        public void confirmaUpdate()
        {
            if (validaCampos() == 1)
            {
                return;
            }
            if (validaCampos() == 2)
            {
                atualizarCupom();
            }
        }

        public Decimal valorAdd = 0;
        public void adicionaCupom()
        {
            Cupom novo = new Cupom();
            novo.Id = AcessoFB.fb_verificaUltIdCupom() + 1;
            novo.Descricao = tbDescricao.Text.Trim().Replace("'","");
            novo.Validade = tbValidade.Text.Trim();
            novo.Minimo = Convert.ToDecimal(tbMinimo.Text.Replace("R$", ""));
            if (cbTipo.Text == "PORCENTAGEM")
                novo.Tipo = 1;
            if (cbTipo.Text == "VALOR EM R$")
                novo.Tipo = 2;
            novo.Valor = Convert.ToDecimal(tbValor.Text.Replace("R$", "").Replace("%", ""));
            novo.cupomUnico = parametroUnico;
            AcessoFB.fb_adicionarCupom(novo);
            adicionarCupomNoFirebase(novo);
            limpaCampos();
            desabilitaGroupBox();
            mostraTelaConfirmacao();
            habilitaBotoesPrincipais();
            carregaDataGridView();
        }
        public void atualizarCupom()
        {
            Cupom novo = new Cupom();
            novo.Descricao = tbDescricao.Text.Trim().Replace("'", "");
            novo.Validade = tbValidade.Text.Trim();
            novo.Minimo = Convert.ToDecimal(tbMinimo.Text.Replace("R$", ""));
            if (cbTipo.Text == "PORCENTAGEM")
                novo.Tipo = 1;
            if (cbTipo.Text == "VALOR EM R$")
                novo.Tipo = 2;
            novo.Valor = Convert.ToDecimal(tbValor.Text.Replace("R$", "").Replace("%", ""));
            novo.Id = idAlteracao;
            novo.cupomUnico = parametroUnico;
            AcessoFB.fb_atualizaCupom(novo);
            atualizarCupomNoFirebase(novo);
            limpaCampos();
            desabilitaGroupBox();
            mostraTelaConfirmacao();
            habilitaBotoesPrincipais();
            carregaDataGridView();
        }
        public void adicionarCupomNoFirebase(Cupom novo)
        {
            try
            {
                CupomFirebase inserir = new CupomFirebase();
                inserir.id = novo.Id;
                inserir.descricao = novo.Descricao;
                inserir.validade = novo.Validade;
                inserir.tipo = novo.Tipo;
                inserir.minimo = novo.Minimo;
                inserir.valor = novo.Valor;
                inserir.cupomUnico = novo.cupomUnico;
                String chaveOndeAdicionar = novo.Id.ToString().PadLeft(5, '0');
                var set = client.Set(@"cupom/" + chaveOndeAdicionar, inserir);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao inserir este item no Aplicativo.\nSincronize os dados para que tudo seja ajustado", "Erro");
            }
        }
        public void atualizarCupomNoFirebase(Cupom novo)
        {
            try
            {
                CupomFirebase inserir = new CupomFirebase();
                inserir.id = novo.Id;
                inserir.descricao = novo.Descricao;
                inserir.validade = novo.Validade;
                inserir.tipo = novo.Tipo;
                inserir.minimo = novo.Minimo;
                inserir.valor = novo.Valor;
                inserir.cupomUnico = novo.cupomUnico;
                String chaveOndeAtualziar = novo.Id.ToString().PadLeft(5, '0');
                var set = client.Set(@"cupom/" + chaveOndeAtualziar, inserir);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao atualizar este item no Aplicativo.\nTente atualizar o item novamente.", "Erro");
            }
        }

        public int validaCampos()
        {
            DateTime time;
            if (DateTime.TryParse(tbValidade.Text, out time))
            {
                try
                {
                    String valor = tbMinimo.Text.Replace("R$", "");
                    Decimal vlorMinimo = Convert.ToDecimal(valor);
                }
                catch
                {
                    MessageBox.Show("O Valor Mínimo para este cupom é inválido.", "Erro");
                    tbMinimo.Select();
                    tbMinimo.Focus();
                    return 1;
                }
                try
                {
                    String valor = tbValor.Text.Replace("R$", "").Replace("%", "");
                    Decimal vlorMinimo = Convert.ToDecimal(valor);
                }
                catch
                {
                    MessageBox.Show("O Valor de Desconto para este cupom é inválido.", "Erro");
                    tbMinimo.Select();
                    tbMinimo.Focus();
                    return 1;
                }
                if (tbDescricao.Text.ToString() == "" ||
                tbMinimo.Text.ToString() == "" ||
                tbValidade.Text.ToString() == "" ||
                tbValidade.Text.ToString() == "  /  /    " ||
                cbTipo.Text.ToString() == "" ||
                cbTipo.SelectedItem == null ||
                tbValor.Text.ToString() == "")
                {
                    MessageBox.Show("Todos os campos devem ser preenchidos", "Erro");
                    return 1;
                }
                else
                {
                    if(Convert.ToDecimal(tbMinimo.Text.Replace("R$","").Replace("%", "")) <= 0)
                    {
                        if (MessageBox.Show("O valor mínimo deste Cupom é R$0,00.\nCom isso, qualquer valor de pedido poderá aplicar este cupom.\nDeseja realmente continuar?", "Mínimo do Cupom", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if ((Convert.ToDecimal(tbValor.Text.Replace("R$", "").Replace("%", "")) == 100 && cbTipo.SelectedItem.ToString() == "PORCENTAGEM") ||
                                (Convert.ToDecimal(tbValor.Text.Replace("R$", "").Replace("%", "")) >= 20 && cbTipo.SelectedItem.ToString() == "VALOR EM R$"))
                            {
                                if (MessageBox.Show("O valor de desconto deste cupom é maior do que o recomendável.\nCom isso, o desconto pode ser muito alto, o que pode gerar custos indesejados.\nDeseja realmente continuar?", "Desconto do Cupom", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    return 2;
                                }
                                else
                                {
                                    return 1;
                                }
                            }
                            else
                            {
                                return 2;
                            }
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        if ((Convert.ToDecimal(tbValor.Text.Replace("R$", "").Replace("%", "")) == 100 && cbTipo.SelectedItem.ToString() == "PORCENTAGEM") ||
                                (Convert.ToDecimal(tbValor.Text.Replace("R$", "").Replace("%", "")) >= 20 && cbTipo.SelectedItem.ToString() == "VALOR EM R$"))
                        {
                            if (MessageBox.Show("O valor de desconto deste cupom é maior do que o recomendável.\nCom isso, o desconto pode ser muito alto, o que pode gerar custos indesejados.\nDeseja realmente continuar?", "Desconto do Cupom", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                return 2;
                            }
                            else
                            {
                                return 1;
                            }
                        }
                        else
                        {
                            return 2;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Data de validade inválida.\nVerifique e tente novamente.", "Erro");
                tbValidade.Select();
                tbValidade.Focus();
                return 1;
            }
        }

        private void tbMinimo_Enter(object sender, EventArgs e)
        {
            if (tbMinimo.Text == "")
            {
                return;
            }
            else
            {
                tbMinimo.Text = tbMinimo.Text.Replace("R$", "");
            }
        }

        private void tbMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (tbMinimo.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void tbMinimo_Leave(object sender, EventArgs e)
        {
            if (tbMinimo.Text.Contains("R$"))
            {
                return;
            }
            else
            {
                try
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbMinimo.Text);
                    Decimal valorAcrescimo = ajuste;
                    tbMinimo.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                }
                catch
                {
                    
                }
            }
        }

        private void tbValor_Enter(object sender, EventArgs e)
        {
            if (tbValor.Text == "")
            {
                return;
            }
            else
            {
                tbValor.Text = tbValor.Text.Replace("R$", "").Replace("%", "");
            }
        }

        private void tbValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (tbValor.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void tbValor_Leave(object sender, EventArgs e)
        {
            if(cbTipo.Text == "PORCENTAGEM")
            {
                if (tbMinimo.Text.Contains("%"))
                {
                    return;
                }
                else
                {
                    tbValor.Text = tbValor.Text + "%";
                }
            }
            if(cbTipo.Text == "VALOR EM R$")
            {
                if (tbMinimo.Text.Contains("R$"))
                {
                    return;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbValor.Text);
                    Decimal valorAcrescimo = ajuste;
                    tbValor.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                }
            }
        }

        private void cbTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            if(tbValor.Text != "" && cbTipo.SelectedItem != null && cbTipo.SelectedItem.ToString() != "")
            {
                if(cbTipo.SelectedItem.ToString() == "PORCENTAGEM")
                {
                    String valorCampo = tbValor.Text.Replace("%", "").Replace("R$", "");
                    tbValor.Text = valorCampo + "%";
                }
                if(cbTipo.SelectedItem.ToString() == "VALOR EM R$")
                {
                    String valorCampo = tbValor.Text.Replace("%", "").Replace("R$", "");
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(valorCampo);
                    Decimal valorAcrescimo = ajuste;
                    tbValor.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                }
            }
        }

        private void cbUnico_CheckedChanged(object sender, EventArgs e)
        {
            if(cbUnico.Checked == true)
            {
                parametroUnico = 1;
            }
            else
            {
                parametroUnico = 0;
            }
        }
    }
}
