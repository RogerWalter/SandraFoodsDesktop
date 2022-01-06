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
    public partial class Lancamento : Form
    {
        public Lancamento()
        {
            InitializeComponent();
        }

        int enterJaFoiPress = 0;
        private void Lancamento_Load(object sender, EventArgs e)
        {
            tbValor.Select();
            tbValor.Focus();
            rbDin.Checked = true;
            metPag = 1;
        }

        public void adicionaNovoLancamento()
        {
            if (tbValor.Text == "")
            {
                MessageBox.Show("Não foi informado nenhum valor \nVerifique e tente novamente.", "Erro");

                return;
            }
            else
            {
                Decimal totalSalvar = 0;
                if (tbValor.Text.Contains("R$"))
                {
                    Decimal total;
                    String resto;
                    int tamanho = 0;
                    tamanho = tbValor.Text.Length;
                    resto = tbValor.Text.Substring(2, tamanho - 2);
                    total = Convert.ToDecimal(resto);
                    totalSalvar = total;
                    tbValor.Text = total.ToString();
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbValor.Text);
                    totalSalvar = ajuste;
                    tbValor.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                }
                /*Decimal total;
                String resto;
                int tamanho = 0;
                tamanho = tbValor.Text.Length;
                resto = tbValor.Text.Substring(2, tamanho - 2);
                total = Convert.ToDecimal(resto);
                */
                String atual = DateTime.Now.ToString();
                String data = atual.Substring(0, 10);
                
                int pagamento = metPag;

                Lancamentos novoLanc = new Lancamentos();
                novoLanc.Id = AcessoFB.fb_verificaUltIdLanc() + 1;
                novoLanc.Data = data;
                novoLanc.Valor = totalSalvar;
                novoLanc.Pagamento = metPag;
                novoLanc.Tipo = 3; // local
                novoLanc.Pedido = 0; //OUTROS

                AcessoFB.fb_adicionarLanc(novoLanc);

                mostraTelaConfirmacao();
                this.Close();
            }
        }

        private void tbValor_Enter(object sender, EventArgs e)
        {
            enterJaFoiPress = 0;
            if (tbValor.Text == "")
            {
                return;
            }
            else
            {
                Decimal total;
                String resto;
                int tamanho = 0;
                tamanho = tbValor.Text.Length;
                resto = tbValor.Text.Substring(2, tamanho - 2);
                total = Convert.ToDecimal(resto);
                tbValor.Text = total.ToString();
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

        private void tbValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                if(jaApertouEnter == 1)
                {
                    return;
                }
                else
                {
                    if (metPag == 0)
                    {
                        MessageBox.Show("Não foi informado um método de pagamento.", "Erro");
                        return;
                    }
                    else
                    {
                        enterJaFoiPress = 1;
                        if (tbValor.Text == "")
                        {
                            return;
                        }
                        else
                        {
                            Decimal ajuste = 0;
                            ajuste = Convert.ToDecimal(tbValor.Text);
                            tbValor.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);

                            adicionaNovoLancamento();
                        }
                    }
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

        private void tbValor_Leave(object sender, EventArgs e)
        {
            if (enterJaFoiPress == 1)
            {
                return;
            }
            else
            {
                if (tbValor.Text == "")
                {
                    return;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbValor.Text);
                    tbValor.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                }
            }
        }
        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if(metPag == 0)
            {
                MessageBox.Show("Não foi informado um método de pagamento.", "Erro");
                return;
            }
            else
            {
                if (enterJaFoiPress == 1)
                {
                    return;
                }
                else
                {
                    if (tbValor.Text == "")
                    {
                        return;
                    }
                    else
                    {
                        adicionaNovoLancamento();
                    }
                }
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
        int jaApertouEnter = 0;
        private void Lancamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                jaApertouEnter = 1;
                btConfirmar_Click(sender, e);
                
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
