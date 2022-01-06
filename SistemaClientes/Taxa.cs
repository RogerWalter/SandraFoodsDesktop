using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using FireSharp.Interfaces;
using FireSharp.Config;
using System.Media;

namespace SistemaClientes
{
    public partial class Taxa : Form
    {
        public Taxa()
        {
            InitializeComponent();
        }
        public int ultBotPress = 0;
        public int entradaValor = 0;
        public int idAlteracao = 0;
        Parametros parametrosSistema = new Parametros();

        public void recebeValorConsulta(int taxaSel)
        {
            ultBotPress = 2;
            if(taxaSel == 0)
            {
                limpaCampos();
            }
            else
            {
                Taxas buscado = new Taxas();
                buscado = AcessoFB.fb_pesquisaTaxaPorId(taxaSel);
                if (buscado.Local == "VAZIO")
                {
                    MessageBox.Show("Não foi possível localizar a taxa \nVerifique se informou o bairro corretamente.", "Não encontrado");
                    return;
                }
                else
                {
                    preencheTB(buscado);
                }
            }
            desabilitaTB();
            habilitaBotoes();


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

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "tJVQSamSvHRtZguzUcn0h3YfPGFoEjl37nI2uNDD",
            BasePath = "https://sandra-foods-34d79-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public void carregaDataGridView()
        {
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable taxas = new DataTable("Taxas");
            DataSet dsFinal = new DataSet();
            taxas = AcessoFB.fb_buscaTaxasConsulta();
            dsFinal.Tables.Add(taxas);
            bindingSource1.DataSource = taxas;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public void limpaCampos()
        {
            tbCodigo.Text = "";
            tbBairro.Text = "";
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
        private void btAdd_Click(object sender, EventArgs e)
        {
            ultBotPress = 1;
            groupBox1.Enabled = true;
            limpaCampos();
            habilitaBotoes();
            desabilitaBotoesPrincipais();
            habilitaTB();
            tbBairro.Select();
            tbBairro.Focus();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            ConsultarTaxa nova = new ConsultarTaxa();
            nova.ShowDialog();
            recebeValorConsulta(nova.enviaCodTaxa());
            //groupBox2.Enabled = true;
            //tbPesquisa.Enabled = true;
            //tbPesquisa.Select();
            //tbPesquisa.Focus();
        }

        private void tbBairro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbValor.Select();
                tbValor.Focus();
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

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        public int validaCampos()
        {
            if (tbBairro.Text.ToString() == "" || tbValor.Text.ToString() == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Erro");
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public void confirmaTaxa()
        {
            if (validaCampos() == 1)
            {
                return;
            }
            if (validaCampos() == 2)
            {
                adicionarTaxa();
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
                atualizarTaxa();
            }
        }

        public void desabilitaGroupBox()
        {
            groupBox1.Enabled = false;
            //groupBox2.Enabled = false;
        }

        public Decimal valorAdd = 0;
        public void adicionarTaxa()
        {
            Taxas novo = new Taxas();
            novo.Local = tbBairro.Text.ToString();
            //novo.Local = RemoverAcentos(novo.Local);
            novo.Local.Replace("'", " ");

            valorAdd = Convert.ToDecimal(tbValor.Text);
            if (valorAdd < 0)
            {
                MessageBox.Show("Não é possível inserir valores negativos", "Erro");
                tbValor.Text = "";
                tbValor.Select();
                tbValor.Focus();
                return;
            }
            else
            {
                novo.Valor = valorAdd;
                novo.Id = AcessoFB.fb_verificaUltIdTaxa() + 1;
                AcessoFB.fb_adicionarTaxa(novo);
                if (parametrosSistema.sincronizar == 1)
                    adicionarTaxaNoFirebase(novo);
                limpaCampos();
                desabilitaGroupBox();
                mostraTelaConfirmacao();
                habilitaBotoesPrincipais();
                carregaDataGridView();
            }
        }

        public void atualizarTaxa()
        {
            Taxas novo = new Taxas();
            novo.Local = tbBairro.Text.ToString();
            //novo.Local = RemoverAcentos(novo.Local);
            novo.Local.Replace("'", " ");

            String testar = tbValor.Text.ToString();

            if (tbValor.Text.Length > 3)
            {
                if (testar.Substring(0, 2) == "R$")
                {
                    String resto;
                    int tamanho = 0;
                    tamanho = tbValor.Text.Length;
                    resto = tbValor.Text.Substring(2, tamanho - 2);
                    valorAdd = Convert.ToDecimal(resto);
                }
                else
                {
                    valorAdd = Convert.ToDecimal(tbValor.Text);
                }
            }
            else
            {
                valorAdd = Convert.ToDecimal(tbValor.Text);
            }


            novo.Valor = valorAdd;
            if (valorAdd < 0)
            {
                MessageBox.Show("Não é possível inserir valores negativos", "Erro");
                tbValor.Text = "";
                tbValor.Select();
                tbValor.Focus();
                return;
            }
            else
            {
                novo.Id = idAlteracao;
                AcessoFB.fb_atualizaTaxa(novo);
                if (parametrosSistema.sincronizar == 1)
                    atualizarTaxaNoFirebase(novo);
                limpaCampos();
                desabilitaGroupBox();
                mostraTelaConfirmacao();
                habilitaBotoesPrincipais();
                carregaDataGridView();
            }
        }


        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
        }

        private void tbValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btConfirmar.Select();
                btConfirmar.Focus();

                if (ultBotPress == 1)
                {
                    confirmaTaxa();
                    btAdd.Enabled = true;
                }
                if (ultBotPress == 2)
                {
                    confirmaUpdate();
                    btAdd.Enabled = true;
                }
                btAdd.Enabled = true;

            }
        }

        private void tbValor_Enter(object sender, EventArgs e)
        {
            if (entradaValor == 1)
            {
                return;
            }
            if (entradaValor == 2)
            {
                tbValor.Text = "";
            }
        }

        private void tbValor_Leave(object sender, EventArgs e)
        {

        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if (ultBotPress == 1)
            {
                confirmaTaxa();
            }
            if (ultBotPress == 2)
            {
                confirmaUpdate();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            desabilitaGroupBox();
            btAdd.Enabled = true;
        }

        public void habilitaTB()
        {
            tbBairro.Enabled = true;
            tbValor.Enabled = true;
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            ultBotPress = 2;
            entradaValor = 2;
            groupBox1.Enabled = true;
            habilitaBotoes();
            desabilitaBotoesPrincipais();
            tbBairro.Select();
            tbBairro.Focus();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este item?", "Exclusão de Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AcessoFB.fb_excluirTaxa(idAlteracao);
                if (parametrosSistema.sincronizar == 1)
                    excluirTaxaNoFirebase(idAlteracao);
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


        public void preencheTB(Taxas buscado)
        {
            entradaValor = 1;
            habilitaBotoes();
            groupBox1.Enabled = true;
            //tbPesquisa.Text = "";
            //tbPesquisa.Enabled = false;
            idAlteracao = buscado.Id;
            tbBairro.Text = buscado.Local.Trim();

            tbValor.Text = buscado.Valor.ToString("C", CultureInfo.CurrentCulture);
        }

        public void desabilitaTB()
        {
            tbBairro.Enabled = false;
            tbValor.Enabled = false;
        }

        private void tbPesquisa_KeyUp(object sender, KeyEventArgs e)
        {

           
        }

        private void Taxa_Load(object sender, EventArgs e)
        {
            parametrosSistema = AcessoFB.fb_recuperaParametrosSistema();

            if (parametrosSistema.sincronizar == 1)
            {
                try
                {
                    client = new FireSharp.FirebaseClient(config);
                }
                catch
                {
                    MessageBox.Show("Não foi possível conectar ao Servidor.\nVerifique sua conexão com a internet e tente acessar esta tela novamente.", "Erro");
                    this.Close();
                }
            }

            groupBox1.Enabled = false;
            desabilitaBotoes();
            habilitaBotoesPrincipais();
            carregaDataGridView();
        }

        private void Taxa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private SoundPlayer soundPlayer;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (soundPlayer == null)
            {
                soundPlayer = new SoundPlayer(@"C:\Program Files (x86)\SSoft\Sandra Foods\moto.wav");
            }
            soundPlayer.Play();
            MessageBox.Show("Brum brum", "Bê ré bé bé");
        }

        TelaCarregamento carregando = new TelaCarregamento();

        private void btSincronizar_Click(object sender, EventArgs e)
        {
            if (parametrosSistema.sincronizar == 0)
            {
                MessageBox.Show("A sincronização com o aplicativo está desabilitada.\nNão é possível realizar esta operação.", "Erro na Operação");
                return;
            }
            if (MessageBox.Show("Esta ação recarregará todos os dados de taxas para o aplicativo.\nO ideal é que este procedimento seja executado somente quando o estabelecimento estiver fechado.\nDeseja executá-lo agora?", "Sincronizar Taxas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AcessoFB.sincronizaTaxasFirebirdComFirebase(config, client);
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
                    Taxas buscado = AcessoFB.fb_pesquisaTaxaPorId(pesquisar);
                    tbCodigo.Text = buscado.Id.ToString();
                    idAlteracao = buscado.Id;
                    tbBairro.Text = buscado.Local.ToString().Trim();
                    buscado.Valor.ToString("C", CultureInfo.CurrentCulture);
                    tbValor.Text = buscado.Valor.ToString("C", CultureInfo.CurrentCulture);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void excluirTaxaNoFirebase(int idExcluir)
        {
            try
            {
                String chaveOndeDeletar = idExcluir.ToString().PadLeft(5, '0');
                var delete = client.Delete(@"taxa/" + chaveOndeDeletar);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao excluir este item no Aplicativo.\nSincronize os dados novamente para que tudo seja ajustado.", "Erro");
            }
        }
        public void adicionarTaxaNoFirebase(Taxas novo)
        {
            try
            {
                TaxasFirebase inserir = new TaxasFirebase();
                inserir.id = novo.Id;
                inserir.bairro = novo.Local;
                inserir.valor = novo.Valor;
                String chaveOndeAdicionar = novo.Id.ToString().PadLeft(5, '0');
                var set = client.Set(@"taxa/" + chaveOndeAdicionar, inserir);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao inserir este item no Aplicativo.\nSincronize os dados para que tudo seja ajustado", "Erro");
            }
        }
        public void atualizarTaxaNoFirebase(Taxas novo)
        {
            try
            {
                TaxasFirebase inserir = new TaxasFirebase();
                inserir.id = novo.Id;
                inserir.bairro = novo.Local;
                inserir.valor = novo.Valor;
                String chaveOndeAtualziar = novo.Id.ToString().PadLeft(5, '0');
                var set = client.Set(@"taxa/" + chaveOndeAtualziar, inserir);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao atualizar este item no Aplicativo.\nTente atualizar o item novamente.", "Erro");
            }
        }

        private void tbPesquisa_TextChanged(object sender, EventArgs e)
        {
            var bd = (BindingSource)dataGridView1.DataSource;
            var dt = (DataTable)bd.DataSource;
            dt.DefaultView.RowFilter = string.Format("LOCAL like '%{0}%'", tbPesquisa.Text.Trim().Replace("'", "''"));
            dataGridView1.Refresh();
        }
    }
}


