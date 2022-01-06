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
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;

namespace SistemaClientes
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        int ultBotPress = 0; // 1 - ADD || 2 - EDIT
        String celularRecebido = "VAZIO";
        int idAlteracao = 0; //variavel usada para aplicar o update no banco

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
        int parametro = 0;
        public void recebeParametro(int par)
        {
            parametro = par;
        }

        public void carregaDataGridView()
        {
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable clientes = new DataTable("Clientes");
            DataSet dsFinal = new DataSet();
            clientes = AcessoFB.fb_buscaClientesConsulta();
            dsFinal.Tables.Add(clientes);
            bindingSource1.DataSource = clientes;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            carregaDataGridView();
            if (parametro == 0)
            {
                groupBox1.Enabled = false;
                desabilitaBotoes();
            }
            else
            {
                btAdd_Click(sender, e);
                tbCelular.Text = celularRecebido;
            }

            //Preenche o autocomplete dos bairros
            List<string> nomes = new List<string>();
            using (FbConnection conn = new FbConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ConnectionString;
                using (FbCommand cmd = new FbCommand())
                {
                    cmd.CommandText = "SELECT LOCAL FROM TAXA";
                    //cmd.Parameters.AddWithValue("@Texto", prefixo);
                    cmd.Connection = conn;
                    conn.Open();
                    using (FbDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            nomes.Add(string.Format("{0}", sdr["LOCAL"]).Trim());
                        }
                    }
                    conn.Close();
                }
            }
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();

            foreach (string name in nomes)
            {
                source.Add(name);
            }

            tbBairro.AutoCompleteCustomSource = source;
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

        public void desabilitaBotoesPrincipais()
        {
            btAdd.Enabled = false;
            btExcluir.Enabled = false;
            btEditar.Enabled = false;
        }
        public void habilitaBotoesPrincipais()
        {
            btAdd.Enabled = true;
            btExcluir.Enabled = true;
            btEditar.Enabled = true;
        }

        public void recebeNovoCel(String numTelefone)
        {
            tbCelular.Text = numTelefone;
            celularRecebido = numTelefone;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            ultBotPress = 1;
            limpaCampos();
            groupBox1.Enabled = true;
            habilitaBotoes();
            desabilitaBotoesPrincipais();
            tbNome.Select();
            tbNome.Focus();
        }

        private void tbNome_Leave(object sender, EventArgs e)
        {
            tbNome.Text.ToUpper();
        }

        private void tbNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbCelular.Select();
                tbCelular.Focus();
            }
        }

        private void tbCelular_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {   
                tbRua.Select();
                tbRua.Focus();
            }
        }

        private void tbCelular_Leave(object sender, EventArgs e)
        {

        }

        private void tbRua_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbNum.Select();
                tbNum.Focus();
            }
            
        }

        private void tbNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbBairro.Select();
                tbBairro.Focus();
            }
            
        }
        private void tbBairro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbReferencia.Select();
                tbReferencia.Focus();
            }
        }

        private void tbReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btConfirmar.Select();
                btConfirmar.Focus();

                btConfirmar_Click(sender, e);
            }
        }

        public void limpaCampos()
        {
            tbNome.Text = "";
            tbCelular.Text = "";
            tbRua.Text = "";
            tbNum.Text = "";
            tbBairro.Text = "";
            tbReferencia.Text = "";
            tbCodigo.Text = "";
        }

        public int validaCampos()
        {
            if (tbNome.Text.ToString() == "" || tbCelular.Text.ToString() == "" || tbRua.Text.ToString() == "" || tbBairro.Text.ToString() == "")
            {
                MessageBox.Show("O nome, celular, rua e bairro devem ser preenchidos.", "Erro");
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public int verificaBairro()
        {
            String buscar;
            buscar = tbBairro.Text;

            Taxas buscado = new Taxas();
            buscado = AcessoFB.fb_pesquisaTaxa(buscar);
            if (buscado.Local == "VAZIO")
            {
                MessageBox.Show("Não foi possível localizar o bairro \nVerifique se informou corretamente.", "Não encontrado");
                return 1;
            }
            else
            {
                Clientes verificar = AcessoFB.fb_pesquisaClientePorCelular(tbCelular.Text.ToString());

                if (verificar.Nome == tbNome.Text && tbCelular.Text == verificar.Celular && ultBotPress == 1)
                {
                    MessageBox.Show("Este cliente já possui cadastro! \nNão é possível inseri-lo novamente\nTente alterar o nome caso esteja adicionando um novo endereço para este cliente.", "Alerta");
                    tbNome.Select();
                    tbNome.Focus();
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        public void desabilitaGroupBox()
        {
            groupBox1.Enabled = false;
            //groupBox2.Enabled = false;
            btAdd.Enabled = true;
        }
        public void adicionarCliente()
        {
            //verifica o telefone pra não inserir duplicado
            Clientes verificar = AcessoFB.fb_pesquisaClientePorCelular(tbCelular.Text.ToString());
            if (verificar.Nome.Trim() == tbNome.Text.Trim() && tbCelular.Text.Trim() == verificar.Celular.Trim() && ultBotPress == 1)
            {
                MessageBox.Show("Este cliente já possui cadastro! \nNão é possível inseri-lo novamente\nTente alterar o nome caso esteja adicionando um novo endereço para este cliente.", "Alerta");
                tbNome.Select();
                tbNome.Focus();
                return;
            }
            else
            {
                Clientes novo = new Clientes();

                novo.Nome = tbNome.Text.ToString();
                novo.Nome.Replace("'", " ").Trim();

                novo.Celular = tbCelular.Text.ToString().Trim();

                novo.Rua = tbRua.Text.ToString();
                novo.Rua.Replace("'", " ").Trim();

                novo.Numero = tbNum.Text.ToString().Trim();

                novo.Bairro = tbBairro.Text.ToString();
                novo.Bairro = RemoverAcentos(novo.Bairro).Trim();

                novo.Referencia = tbReferencia.Text.ToString();
                novo.Referencia.Replace("'", " ").Trim();

                novo.Id = AcessoFB.fb_verificaUltIdCliente() + 1;
                AcessoFB.fb_adicionarCliente(novo);
                limpaCampos();
                desabilitaGroupBox();
                mostraTelaConfirmacao();
                habilitaBotoesPrincipais();
                carregaDataGridView();
            }        
        }

        public void atualizarCliente()
        {
            Clientes novo = new Clientes();
            novo.Nome = tbNome.Text.ToString();
            novo.Nome.Replace("'", " ").Trim();

            novo.Celular = tbCelular.Text.ToString().Trim();

            novo.Rua = tbRua.Text.ToString();
            novo.Rua.Replace("'", " ").Trim();

            novo.Numero = tbNum.Text.ToString();

            novo.Bairro = tbBairro.Text.ToString();
            novo.Bairro = RemoverAcentos(novo.Bairro);
            novo.Bairro.Replace("'", " ").Trim();

            novo.Referencia = tbReferencia.Text.ToString();
            novo.Referencia.Replace("'", " ").Trim();

            novo.Id = idAlteracao;
            AcessoFB.fb_atualizaCliente(novo);
            limpaCampos();
            desabilitaGroupBox();
            mostraTelaConfirmacao();
            habilitaBotoesPrincipais();
            carregaDataGridView();
        }

        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
            nova.Close();
        }

        public int confirmaCliente()
        {
            if (validaCampos() == 1)
            {
                return 1;
            }
            else
            {
                adicionarCliente();
                return 2;
            }
        }
        public int confirmaUpdate()
        {
            if (validaCampos() == 1)
            {
                return 1;
            }
            else 
            {
                atualizarCliente();
                return 2;
            }
        }
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if(verificaBairro() == 1)
            {
                return;
            }
            else
            {
                int testeAdd = 0;
                int testeUpd = 0;
                if (ultBotPress == 1)
                {
                    testeAdd = confirmaCliente();
                }
                if (ultBotPress == 2)
                {
                    testeUpd = confirmaUpdate();
                }
                if(testeAdd == 1 || testeUpd == 2)
                {
                    return;
                }
                else
                {
                    btAdd.Enabled = true;
                }              
            }
            if(parametro == 1)
            {
                this.Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            desabilitaGroupBox();
            habilitaBotoesPrincipais();
        }
        public void preencheTB(Clientes buscado)
        {
            habilitaBotoes();
            groupBox1.Enabled = true;
            //tbPesquisa.Text = "";
            //tbPesquisa.Enabled = false;
            idAlteracao = buscado.Id;
            tbNome.Text = buscado.Nome.Trim();
            tbCelular.Text = buscado.Celular.Trim();
            tbRua.Text = buscado.Rua.Trim();
            tbNum.Text = buscado.Numero;
            tbBairro.Text = buscado.Bairro.Trim();
            tbReferencia.Text = buscado.Referencia.Trim();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            ultBotPress = 2;
            groupBox1.Enabled = true;
            habilitaBotoes();
            desabilitaBotoesPrincipais();
            tbNome.Select();
            tbNome.Focus();
        }

        public void desmarcaRB()
        {
            //rbNome.Checked = false;
            //rbCelular.Checked = false;
        }
        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este item?", "Exclusão de Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AcessoFB.fb_excluirCliente(idAlteracao);
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

        private void tbCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
        }

        private void Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public int pesquisar = 0;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                desabilitaGroupBox();
                habilitaBotoesPrincipais();
                if (dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.Columns.Count <= 0)
                    {
                        carregaDataGridView();
                        return;
                    }
                    pesquisar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    Clientes buscado = AcessoFB.fb_pesquisaClientePorId(pesquisar);
                    tbCodigo.Text = buscado.Id.ToString();
                    idAlteracao = buscado.Id;
                    tbNome.Text = buscado.Nome.ToString().Trim();
                    tbCelular.Text = buscado.Celular.ToString().Trim();
                    tbRua.Text = buscado.Rua.ToString().Trim();
                    tbNum.Text = buscado.Numero.ToString().Trim();
                    tbBairro.Text = buscado.Bairro.ToString().Trim();
                    tbReferencia.Text = buscado.Referencia.ToString().Trim();
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

        private void tbPesquisa_TextChanged(object sender, EventArgs e)
        {
            var bd = (BindingSource)dataGridView1.DataSource;
            var dt = (DataTable)bd.DataSource;
            dt.DefaultView.RowFilter = string.Format("NOME like '%{0}%'", tbPesquisa.Text.Trim().Replace("'", "''"));
            dataGridView1.Refresh();
        }
    }
}
