using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class PedidoAvulso : Form
    {
        public PedidoAvulso()
        {
            InitializeComponent();
        }

        public void RecarregaDados(int id)
        {
            dataGridView1.DataSource = null;

            BindingSource bindingSource1 = new BindingSource();
            DataTable itensPedido = new DataTable("Itens_Pedido");
            DataSet dsFinal = new DataSet();
            itensPedido = AcessoFB.fb_buscaItensAvulsos(id);
            dsFinal.Tables.Add(itensPedido);
            bindingSource1.DataSource = itensPedido;
            dataGridView1.DataSource = bindingSource1;

        }
        Decimal totalSalvar = 0;
        public void RecalculaTotal()
        {
            Decimal totalItens = AcessoFB.fb_totalizaItensAvulsos(senha);
            totalSalvar = totalItens;
            labelTotal.Text = totalItens.ToString("C", CultureInfo.CurrentCulture);
        
        }

        Decimal valorTotal = 0;
        String data = "";
        private void PedidoAvulso_Load(object sender, EventArgs e)
        {
            data = DateTime.Now.ToString();
            data = data.Substring(0, 10);

            AcessoFB.fb_atualizaAvulsoEditando(1);
            AcessoFB.fb_limparItemAvulso();

            tbSenha.Select();
            tbSenha.Focus();
        }

        int senha = 0; //é usada a senha no lugar do pedido
        

        private void tbSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void tbSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btAddItem.Select();
                btAddItem.Focus();
            }
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            if(tbSenha.Text == "")
            {
                MessageBox.Show("Senha não informada!", "Alerta");
                tbSenha.Focus();
                tbSenha.Select();
                return;
            }
            else
            {
                senha = Convert.ToInt32(tbSenha.Text);
                int verificaPedido = AcessoFB.fb_buscaPedidoUsandoSenhaData(senha, data);
                if (verificaPedido == 0)
                {
                    MessageBox.Show("A senha informada não existe no sistema!", "Alerta");
                    tbSenha.Focus();
                    tbSenha.Select();
                    return;
                }
                else
                {
                    int tipoPedido = AcessoFB.fb_buscaTipoPedidoUsandoSenhaData(senha, data);
                    if(tipoPedido == 1)
                    {
                        MessageBox.Show("A senha informada refere-se a uma entrega!\nNesta tela, só é permitido inserir pedidos do tipo Balcão.\nVerifique a senha e tente novamente.", "Alerta");
                        tbSenha.Focus();
                        tbSenha.Select();
                        return;
                    }
                    else
                    {
                        senha = Convert.ToInt32(tbSenha.Text);
                        Adicionar nova = new Adicionar();
                        nova.recebeParametro(1);
                        nova.recebeSenha(senha);
                        nova.ShowDialog();
                        RecarregaDados(senha);
                        RecalculaTotal();
                    }     
                }
            }
        }
        int idExcluir = 1;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idExcluir = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
            }
        }

        private void btRemItem_Click(object sender, EventArgs e)
        {
            if (tbSenha.Text == "")
            {
                MessageBox.Show("A senha informada não existe no sistema!", "Alerta");
                tbSenha.Focus();
                tbSenha.Select();
                return;
            }
            else
            {
                if (AcessoFB.fb_verificaUltIdItemAvulso(senha) == 0)
                {
                    MessageBox.Show("Não existem itens lançados para exclusão", "Alerta");
                    return;
                }
                else
                {
                    AcessoFB.fb_excluirItemAvulso(idExcluir);
                    AcessoFB.fb_atualizaIdItemAvulso(senha);
                    RecarregaDados(senha);
                    RecalculaTotal();
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            AcessoFB.fb_limparItemAvulso();
            AcessoFB.fb_atualizaAvulsoEditando(0);
            this.Close();
        }

        private void PedidoAvulso_FormClosing(object sender, FormClosingEventArgs e)
        {
            AcessoFB.fb_atualizaAvulsoEditando(0);
        }

        public int parametroImpressao = 0; //0 - imprime || 1 - não imprime
        private void cbImprimeOuNao_CheckedChanged(object sender, EventArgs e)
        {
            if(cbImprimeOuNao.Checked == true)
            {
                parametroImpressao = 1;
            }
            if(cbImprimeOuNao.Checked == false)
            {
                parametroImpressao = 0;
            }
        }
        int id_do_pedido = 0;
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if(tbSenha.Text == "")
            {
                MessageBox.Show("A senha informada não existe no sistema!", "Alerta");
                tbSenha.Focus();
                tbSenha.Select();
                return;
            }
            else
            {
                if(AcessoFB.fb_verificaUltIdItemAvulso(senha) == 0)
                {
                    MessageBox.Show("Não é possível salvar sem inserir itens", "Alerta");
                    return;
                }
                else
                {
                    //buscar o id do pedido
                    int idPedidoAtualizar = AcessoFB.fb_pesquisaIdPedido(senha, data);
                    id_do_pedido = idPedidoAtualizar;
                    //inserir os itens na tabela ITEM_PEDIDO
                    AcessoFB.fb_adicionaItemAvulsoAoPedido(idPedidoAtualizar);
                    //atualizar o valor do PEDIDO
                    AcessoFB.fb_atualizaValorTotalDoPedido(idPedidoAtualizar, totalSalvar);
                    //imprimir o item inserido
                    if(cbImprimeOuNao.Checked == false)
                    {
                        insereDadosImpressao(senha);
                    }                  
                    //limpar a tabela itens avulsos
                    AcessoFB.fb_limparItemAvulso();
                    //liberar acesso à este form
                    AcessoFB.fb_atualizaAvulsoEditando(0);
                    this.Close();
                }
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

        public void focaForm()
        {
            var form = new Principal();
            if (Application.OpenForms[form.Name] == null)
            {
                form.Show();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
                Application.OpenForms[form.Name].Activate();
            }
        }
        public void insereDadosImpressao(int senha)
        {
            int id_pedido = id_do_pedido;
            String atual = DateTime.Now.ToString();
            String data = atual.Substring(0, 10);
            String hora = atual.Substring(11, 8);

            String nome_cliente = AcessoFB.fb_pesquisaNomeClienteDoPedido(id_pedido);
            String cliente = nome_cliente.Trim();
            cliente.Replace("'", " ");

            String celular = "-";
            String rua = "-";
            String numero = "-";
            String bairro = "-";
            String referencia = "-";
            String taxa = "-";
            String total = totalSalvar.ToString("C", CultureInfo.CurrentCulture);
            String obs = "";
            String desc = "";
            String pagamento = "";

            AcessoFB.insereDadosImpressao(senha, data, hora, cliente, celular, rua, numero, bairro, referencia, taxa, total, obs, desc, pagamento);
            AcessoFB.insereItensImpressaoAvulso(senha);
            
            imprimirPedidoBalcao();

            mostraTelaConfirmacao();
            focaForm();
        }
        public void imprimirPedidoBalcao()
        {
            ImpressaoBalcao nova = new ImpressaoBalcao();
            nova.ShowDialog();
            AcessoFB.fb_limpaTabelasImpressao();
        }

        private void PedidoAvulso_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btAddItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (tbSenha.Text == "")
            {
                MessageBox.Show("Senha não informada!", "Alerta");
                tbSenha.Focus();
                tbSenha.Select();
                return;
            }
            else
            {
                senha = Convert.ToInt32(tbSenha.Text);
                int verificaPedido = AcessoFB.fb_buscaPedidoUsandoSenhaData(senha, data);
                if (verificaPedido == 0)
                {
                    MessageBox.Show("A senha informada não existe no sistema!", "Alerta");
                    tbSenha.Focus();
                    tbSenha.Select();
                    return;
                }
                else
                {
                    ConsultarSenha nova = new ConsultarSenha();
                    nova.recebeSenha(Convert.ToInt32(tbSenha.Text));
                    nova.ShowDialog();
                    tbSenha.Text = "";
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btReimprimir_Click(object sender, EventArgs e)
        {
            if (tbSenha.Text == "")
            {
                MessageBox.Show("Senha não informada!", "Alerta");
                tbSenha.Focus();
                tbSenha.Select();
                return;
            }
            else
            {
                senha = Convert.ToInt32(tbSenha.Text);
                int verificaPedido = AcessoFB.fb_buscaPedidoUsandoSenhaData(senha, data);
                if (verificaPedido == 0)
                {
                    MessageBox.Show("A senha informada não existe no sistema!", "Alerta");
                    tbSenha.Focus();
                    tbSenha.Select();
                    return;
                }
                else
                {
                    ImpressaoBalcaoSenha nova = new ImpressaoBalcaoSenha();
                    nova.recebeDados(senha, data);
                    nova.ShowDialog();
                    mostraTelaConfirmacao();
                    tbSenha.Text = "";
                    var form = new PedidoAvulso();
                    if (Application.OpenForms[form.Name] == null)
                    {
                        form.Show();
                    }
                    else
                    {
                        Application.OpenForms[form.Name].Focus();
                        Application.OpenForms[form.Name].Activate();
                    }
                }
            }
        }
    }
}
