using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class SenhasPrincipal : Form
    {
        public SenhasPrincipal()
        {
            InitializeComponent();
        }

        int painelAberto = 0;

        private SoundPlayer soundPlayer;
        public SenhasPainel form = new SenhasPainel();

        private void btAbrirPainel_Click(object sender, EventArgs e)
        {
            if(painelAberto == 1)
            {
                MessageBox.Show("O painel de senhas já está aberto!", "Alerta");
                return;
            }
            else
            {
                var formsAbertos = Application.OpenForms;
                foreach (var frm in formsAbertos)
                {
                    form = new SenhasPainel();
                    if (Application.OpenForms[form.Name] == null)
                    {
                        form.Show();
                        painelAberto = 1;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("O painel de senhas já está aberto!", "Alerta");
                        return;
                    }
                }
            }   
        }
        int parametroSom = 0;
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            var formsAbertos = Application.OpenForms;
            foreach (var frm in formsAbertos)
            {
                //form = new SenhasPainel();
                if (Application.OpenForms[form.Name] == null)
                {
                    MessageBox.Show("O painel de senhas está fechado!\nAntes de informar uma senha, o painel deve ser aberto e ajustado a segunda tela.", "Alerta");
                    return;
                }
                else
                {
                    if (tbCodigo.Text == "")
                    {
                        MessageBox.Show("Não foi informada uma senha", "Alerta");
                        return;
                    }
                    else
                    {   
                        int senha = Convert.ToInt32(tbCodigo.Text);
                        String data = DateTime.Now.ToString();
                        data = data.Substring(0, 10);
                        int verificaPedido = AcessoFB.fb_buscaPedidoUsandoSenhaData(senha, data);
                        if (verificaPedido == 0)
                        {
                            MessageBox.Show("A senha informada não existe no sistema!", "Alerta");
                            tbCodigo.Focus();
                            tbCodigo.Select();
                            return;
                        }
                        else
                        {
                            int tipoPedido = AcessoFB.fb_buscaTipoPedidoUsandoSenhaData(senha, data);
                            if (tipoPedido == 1)
                            {
                                MessageBox.Show("A senha informada refere-se a uma entrega!\nNesta tela, só é permitido inserir senhas do tipo de pedido Balcão.\nVerifique a senha e tente novamente.", "Alerta");
                                tbCodigo.Focus();
                                tbCodigo.Select();
                                return;
                            }
                            else
                            {
                                String nomeCliente = AcessoFB.fb_pesquisaNomeClienteDoPedido(verificaPedido).Trim();
                                String senhaMostrar = tbCodigo.Text;
                                form.alteraLabel(senhaMostrar, nomeCliente);
                                if (soundPlayer == null)
                                {
                                    soundPlayer = new SoundPlayer(@"C:\Program Files (x86)\SSoft\Sandra Foods\som.wav");
                                }
                                
                                soundPlayer.Play();
                                parametroSom = 1;
                                tbCodigo.Text = "";
                                return;
                            }
                        }
                    }
                }
            }            
        }

        private void tbCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btConfirmar_Click(sender, e);
        }

        private void SenhasPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SenhasPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(this, "Você tem certeza que deseja sair?\nAo sair, o painel de senhas será fechado.", "Confirmação", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    //soundPlayer.Stop();
                    if(painelAberto == 0)
                    {
                        return;
                    }
                    else
                    {
                        Application.OpenForms["SenhasPainel"].Close();
                    }
                    
                }
            }
        }

        private void btLimpaPainel_Click(object sender, EventArgs e)
        {
            if (painelAberto == 0)
            {
                MessageBox.Show("O painel de senhas está fechado!\nAntes de limpá-lo, o painel deve ser aberto e ajustado a segunda tela.", "Alerta");
                return;
            }
            else
            {
                form.limpaPainel();
                soundPlayer.Stop();
            }     
        }

        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
