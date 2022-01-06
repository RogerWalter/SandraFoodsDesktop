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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class Produtos : Form
    {
        public Produtos()
        {
            InitializeComponent();
        }

        public int ultBotPress = 0; // 1 - ADD || 2 - EDIT
        int idAlteracao = 0; //id para ver qual vamos atualizar no banco
        int tipoPesquisa = 0; // 1 - CODIGO || 2 - DESCRICAO
        int entradaValor = 0; //pra nao deixar tb em branco depois da pesquisa
        Parametros parametrosSistema = new Parametros();

        public List<Grupo_Produto> listaGrupos = new List<Grupo_Produto>();
        public List<Tipo_Produto> listaTipos = new List<Tipo_Produto>();

        /// <summary>
        /// Função para remover acentos da string
        /// </summary>
        /// <param name="valor">String para receber tratamento</param>
        /// <returns>String tratada</returns>
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

        public void recebeValorConsulta(int nProd)
        {
            if (nProd == 0)
            {
                tbCodigo.Text = "";
                tbDesc.Text = "";
                tbValor.Text = "";
            }
            else
            {
                tbCodigo.Text = nProd.ToString();

                Itens buscado = new Itens();
                buscado = AcessoFB.fb_pesquisaProdutoPorCodigo(Convert.ToInt32(tbCodigo.Text));
                if (buscado.Nome == "VAZIO")
                {
                    MessageBox.Show("Não foi possível localizar o produto \nVerifique se informou o código corretamente.", "Não encontrado");
                    return;
                }
                else
                {
                    preencheTB(buscado);
                }
            }


        }
        int parametro = 0;
        public void deOndeVem(int par)
        {
            parametro = par;
        }

        public int retornaCodigoProduto()
        {
            return codProdutoAdicionado;
        }

        public void CarregaComboBoxGrupo()
        {
            comboBoxGrupo.Items.Clear();

            listaGrupos = AcessoFB.fb_recuperaGruposProduto();
            for (int i = 0; i < listaGrupos.Count; i++)
            {
                comboBoxGrupo.Items.Add(listaGrupos[i].Grupo.ToString());
            }
        }

        public void CarregaComboBoxTipo(int grupoSelecionado)
        {
            comboBoxTipo.Items.Clear();

            listaTipos = AcessoFB.fb_recuperaTiposProduto();
            if(grupoSelecionado == 0)
            {
                comboBoxTipo.SelectedItem = null;
                comboBoxTipo.Enabled = true;
                for (int i = 0; i < listaTipos.Count; i++)
                {
                    if (listaTipos[i].Id != 1 && listaTipos[i].Id != 2)
                        comboBoxTipo.Items.Add(listaTipos[i].Tipo.ToString());
                }
            }
            else
            {
                if(grupoSelecionado == 6 || grupoSelecionado == 1 || grupoSelecionado == 5)
                {
                    comboBoxTipo.SelectedItem = null;
                    comboBoxTipo.Enabled = false;
                }
                else
                {
                    comboBoxTipo.SelectedItem = null;
                    comboBoxTipo.Enabled = true;
                    for (int i = 0; i < listaTipos.Count; i++)
                    {
                        if (listaTipos[i].Id == 1 || listaTipos[i].Id == 2)
                            comboBoxTipo.Items.Add(listaTipos[i].Tipo.ToString());
                    }
                }
            }
        }
        private void comboBoxGrupo_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBoxGrupo.SelectedItem != null)
            {
                int codigo = AcessoFB.fb_recuperaIdGruposProduto(comboBoxGrupo.SelectedItem.ToString());
                if (codigo == -1)
                {
                    MessageBox.Show("Houve um erro ao definir o Grupo", "Erro");
                    return;
                }
                else
                {
                    CarregaComboBoxTipo(codigo);
                }
            }
        }


        private void Produtos_Load(object sender, EventArgs e)
        {
            parametrosSistema = AcessoFB.fb_recuperaParametrosSistema();

            if(parametrosSistema.sincronizar == 1)
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
            CarregaComboBoxGrupo();
            carregaDataGridView();
            if (parametro == 0) //vem do menu principal
            {
                groupBox1.Enabled = false;
                desabilitaBotoes();
            }
            if(parametro == 1) // vem da tela 'Adicionar' do pedido
            {
                ultBotPress = 1;
                limpaCampos();
                groupBox1.Enabled = true;
                habilitaBotoes();
                desabilitaBotoesPrincipais();
                tbDesc.Select();
                tbDesc.Focus();
            }
        }

        public void carregaDataGridView()
        {
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable produtos = new DataTable("Produtos");
            DataSet dsFinal = new DataSet();
            produtos = AcessoFB.fb_buscaItensConsulta();
            dsFinal.Tables.Add(produtos);
            bindingSource1.DataSource = produtos;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public void habilitaBotoes()
        {
            btCancelar.Enabled = true;
            btConfirmar.Enabled = true;
            comboBoxGrupo.Enabled = true;
            comboBoxTipo.Enabled = true;
        }

        public void desabilitaBotoes()
        {
            btCancelar.Enabled = false;
            btConfirmar.Enabled = false;
            comboBoxGrupo.Enabled = false;
            comboBoxTipo.Enabled = false;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            ultBotPress = 1;
            limpaCampos();
            groupBox1.Enabled = true;
            habilitaBotoes();
            desabilitaBotoesPrincipais();
            tbDesc.Select();
            tbDesc.Focus();
        }

        public void desabilitaBotoesPrincipais()
        {
            btAdd.Enabled = false;
            btSincronizar.Enabled = true;
            btExcluir.Enabled = false;
            btEditar.Enabled = false;
        }
        public void habilitaBotoesPrincipais()
        {
            btAdd.Enabled = true;
            btSincronizar.Enabled = true;
            btExcluir.Enabled = true;
            btEditar.Enabled = true;
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

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if (ultBotPress == 1)
            {
                confirmaProduto();
            }
            if (ultBotPress == 2)
            {              
                confirmaUpdate();
            }
        }
        public void limpaCampos()
        {
            tbDesc.Text = "";
            tbCodigo.Text = "";
            tbValor.Text = "";
            comboBoxGrupo.SelectedItem = null;
            comboBoxTipo.SelectedItem = null;
            tbInformacoes.Text = "";
        }


        public void desabilitaGroupBox()
        {
            groupBox1.Enabled = false;
            
        }

        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
        }

        public Decimal valorAdd = 0;
        int codProdutoAdicionado = 0;
        public void adicionarProduto()
        {
            Itens novo = new Itens();
            novo.Nome = tbDesc.Text.ToString();         
            //novo.Nome = RemoverAcentos(novo.Nome);
            novo.Nome.Replace("'", " ").Trim();

            String grupoSelecionado = comboBoxGrupo.SelectedItem.ToString().Trim();
            Grupo_Produto buscaNaLista = listaGrupos.Find(item => item.Grupo.Trim() == grupoSelecionado.Trim());
            novo.Grupo = buscaNaLista.Id;

            if(comboBoxTipo.SelectedItem == null)
            {
                novo.Tipo = 0;
            }
            else
            {
                String tipoSelecionado = comboBoxTipo.SelectedItem.ToString().Trim();
                Tipo_Produto buscaNaLista1 = listaTipos.Find(item1 => item1.Tipo.Trim() == tipoSelecionado.Trim());
                novo.Tipo = buscaNaLista1.Id;
            }

            novo.Descricao = tbInformacoes.Text.Trim();
            novo.Descricao.Replace("'", " ").Trim();

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
                novo.App = parametroApp;
                novo.Id = AcessoFB.fb_verificaUltIdProduto() + 1;
                AcessoFB.fb_adicionarProduto(novo);
                if(parametrosSistema.sincronizar == 1 && novo.App == 1)
                    adicionarProdutoNoFirebase(novo);
                limpaCampos();
                desabilitaGroupBox();
                mostraTelaConfirmacao();
                if(parametro == 1)
                {
                    codProdutoAdicionado = novo.Id;
                }
                habilitaBotoesPrincipais();
                carregaDataGridView();
            }
            if (parametro == 1)
            {
                this.Close();
            }
        }

        public void atualizarProduto()
        {
            Itens novo = new Itens();
            novo.Nome = tbDesc.Text.ToString();
            novo.Nome = novo.Nome.Replace("'", " ").Trim();

            String grupoSelecionado = comboBoxGrupo.SelectedItem.ToString().Trim();
            Grupo_Produto buscaNaLista = listaGrupos.Find(item => item.Grupo.Trim() == grupoSelecionado.Trim());
            novo.Grupo = buscaNaLista.Id;

            if (comboBoxTipo.SelectedItem == null)
            {
                novo.Tipo = 0;
            }
            else
            {
                String tipoSelecionado = comboBoxTipo.SelectedItem.ToString().Trim();
                Tipo_Produto buscaNaLista1 = listaTipos.Find(item1 => item1.Tipo.Trim() == tipoSelecionado.Trim());
                novo.Tipo = buscaNaLista1.Id;
            }

            novo.Descricao = tbInformacoes.Text.Trim();
            novo.Descricao.Replace("'", " ").Trim();

            String testar = tbValor.Text.ToString();
            
            if(tbValor.Text.Length > 3)
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
                novo.App = parametroApp;
                AcessoFB.fb_atualizaProduto(novo);

                if(parametrosSistema.sincronizar == 1 && parametroAppAntigo == 1 && parametroApp == 0) //está sendo retirado do app
                {
                    //Removemos do app
                    excluirProdutoNoFirebase(novo.Id);
                }
                if(parametrosSistema.sincronizar == 1 && parametroAppAntigo == 0 && parametroApp == 1) //está sendo inserido no app
                {
                    //Adicionamos ao app
                    adicionarProdutoNoFirebase(novo);
                }
                if (parametrosSistema.sincronizar == 1 && parametroAppAntigo == 1 && parametroApp == 1) //atualizamos o item que já estava no firebase
                {
                    //Atualizamos no app
                    atualizarProdutoNoFirebase(novo);
                }  
                limpaCampos();
                desabilitaGroupBox();
                mostraTelaConfirmacao();
                habilitaBotoesPrincipais();
                carregaDataGridView();
            }
            
        }

        public int validaCampos()
        {
            if (String.IsNullOrEmpty(tbDesc.Text.ToString()) || tbDesc.Text.ToString() == "" || tbValor.Text.ToString() == "" || comboBoxGrupo.SelectedItem == null || tbInformacoes.Text.ToString() == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Erro");
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public void confirmaProduto()
        {
            if (validaCampos() == 1)
            {
                return;
            }
            if (validaCampos() == 2)
            {
                adicionarProduto();
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
                atualizarProduto();
            }
        }

        private void tbValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btConfirmar.Select();
                btConfirmar.Focus();

                if (ultBotPress == 1)
                {
                    confirmaProduto();
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

        private void tbValor_Leave(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            desabilitaGroupBox();
            habilitaBotoesPrincipais();
        }

        public void preencheTB(Itens buscado)
        {
            entradaValor = 1;
            habilitaBotoes();
            groupBox1.Enabled = true;
            idAlteracao = buscado.Id;
            tbCodigo.Text = buscado.Id.ToString();
            tbDesc.Text = buscado.Nome.Trim();

            buscado.Valor.ToString("C", CultureInfo.CurrentCulture);

            tbValor.Text = buscado.Valor.ToString("C", CultureInfo.CurrentCulture);
        }

        public void desabilitaTB()
        {
            tbCodigo.Enabled = false;
            tbDesc.Enabled = false;
            tbValor.Enabled = false;
        }

        private void tbValor_Enter(object sender, EventArgs e)
        {
            if(entradaValor == 1)
            {
                return;
            }
            if(entradaValor == 2)
            {
                tbValor.Text = "";
            }
        }

        public void habilitaTB()
        {
            tbDesc.Enabled = true;
            tbValor.Enabled = true;
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            ultBotPress = 2;
            entradaValor = 2;
            groupBox1.Enabled = true;
            habilitaBotoes();
            desabilitaBotoesPrincipais();
            tbDesc.Select();
            tbDesc.Focus();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este item?", "Exclusão de Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AcessoFB.fb_excluirProduto(idAlteracao);
                if (parametrosSistema.sincronizar == 1 && cbApp.Checked == true)
                    excluirProdutoNoFirebase(idAlteracao);
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

        private void tbDesc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbValor.Select();
                tbValor.Focus();
            }
        }

        private void Produtos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public int pesquisar = 0;
        public int parametroAppAntigo = 0;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            try
            {
                desabilitaGroupBox();
                habilitaBotoesPrincipais();
                if (dataGridView1.CurrentRow != null)
                {
                    pesquisar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    Itens buscado = AcessoFB.fb_pesquisaProdutoPorCodigo(pesquisar);
                    tbCodigo.Text = buscado.Id.ToString();
                    idAlteracao = buscado.Id;
                    tbDesc.Text = buscado.Nome.ToString().Trim();

                    buscado.Valor.ToString("C", CultureInfo.CurrentCulture);
                    tbValor.Text = buscado.Valor.ToString("C", CultureInfo.CurrentCulture);

                    Grupo_Produto buscaNaLista = listaGrupos.Find(item => item.Id == buscado.Grupo);
                    comboBoxGrupo.Text = buscaNaLista.Grupo;

                    Tipo_Produto buscaNaLista1 = listaTipos.Find(item1 => item1.Id == buscado.Tipo);
                    comboBoxTipo.Text = buscaNaLista1.Tipo;

                    tbInformacoes.Text = buscado.Descricao.ToString().Trim();

                    parametroAppAntigo = buscado.App;
                    if(buscado.App == 1)
                    {
                        cbApp.Checked = true;
                    }
                    else
                    {
                        cbApp.Checked = false;
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

        public void atualizarProdutoNoFirebase(Itens novo)
        {
            try
            {
                Itens_Firebase inserir = new Itens_Firebase();
                inserir.id = novo.Id;
                inserir.nome = novo.Nome;
                inserir.valor = novo.Valor;
                inserir.descricao = novo.Descricao;
                inserir.tipo = novo.Tipo;
                inserir.grupo = novo.Grupo;
                String chaveOndeAtualziar = novo.Id.ToString().PadLeft(5, '0');
                var set = client.Set(@"cardapio/" + chaveOndeAtualziar, inserir);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao atualizar este item no Aplicativo.\nTente atualizar o item novamente.", "Erro");
            }
        }

        public void adicionarProdutoNoFirebase(Itens novo)
        {
            try
            {
                Itens_Firebase inserir = new Itens_Firebase();
                inserir.id = novo.Id;
                inserir.nome = novo.Nome;
                inserir.valor = novo.Valor;
                inserir.descricao = novo.Descricao;
                inserir.tipo = novo.Tipo;
                inserir.grupo = novo.Grupo;
                String chaveOndeAdicionar = novo.Id.ToString().PadLeft(5, '0');
                var set = client.Set(@"cardapio/" + chaveOndeAdicionar, inserir);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao inserir este item no Aplicativo.\nSincronize os dados para que tudo seja ajustado", "Erro");
            }
        }

        public void excluirProdutoNoFirebase(int idExcluir)
        {
            try
            {
                String chaveOndeDeletar = idExcluir.ToString().PadLeft(5, '0');
                var delete = client.Delete(@"cardapio/" + chaveOndeDeletar);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao excluir este item no Aplicativo.\nSincronize os dados novamente para que tudo seja ajustado.", "Erro");
            }
        }

        TelaCarregamento carregando = new TelaCarregamento();

        private void btSincronizar_Click(object sender, EventArgs e)
        {
            if (parametrosSistema.sincronizar == 0)
            {
                MessageBox.Show("A sincronização com o aplicativo está desabilitada.\nNão é possível realizar esta operação.", "Erro na Operação");
                return;
            }

            if (MessageBox.Show("Esta ação recarregará todos os dados do cardápio para o aplicativo.\nO ideal é que este procedimento seja executado somente quando o estabelecimento estiver fechado.\nDeseja executá-lo agora?", "Sincronizar Cardápio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            AcessoFB.sincronizaCardapioFirebirdComFirebase(config, client);
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

        private void tbPesquisa_TextChanged(object sender, EventArgs e)
        {
            var bd = (BindingSource)dataGridView1.DataSource;
            var dt = (DataTable)bd.DataSource;
            dt.DefaultView.RowFilter = string.Format("DESCRICAO like '%{0}%'", tbPesquisa.Text.Trim().Replace("'", "''"));
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {

            }
        }

        int parametroApp = 0;
        private void cbApp_CheckedChanged(object sender, EventArgs e)
        {
            if(cbApp.Checked == true)
            {
                parametroApp = 1;
            }
            else
            {
                parametroApp = 0;
            }
        }
    }
}
