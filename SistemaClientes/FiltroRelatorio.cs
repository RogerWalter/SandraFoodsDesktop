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
    public partial class FiltroRelatorio : Form
    {
        public FiltroRelatorio()
        {
            InitializeComponent();
        }

        String dtIni = "";
        String dtFin = "";
        int parametro = 0;
        int parametroImpressao = 1;
        public String retornaDataIni()
        {
            return dtIni;
        }

        public String retornaDataFin()
        {
            return dtFin;
        }

        public int retornaParametro()
        {
            return parametro;
        }

        public int retornaParametroImpressao()
        {
            return parametroImpressao;
        }

        private void tbInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                
            }
        }

        private void tbInicio_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void FiltroRelatorio_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(maskedTextBox1.Text.ToString().Length == 10)
            {
                maskedTextBox2.Focus();
                maskedTextBox2.Select();
            }
        }

        public void preencheRelatorio()
        {
            dtIni = maskedTextBox1.Text.ToString();
            dtFin = maskedTextBox2.Text.ToString();

            parametro = 3;
            this.Close();
        }

        private void maskedTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (maskedTextBox1.MaskCompleted == false || maskedTextBox2.MaskCompleted == false)
                {
                    MessageBox.Show("Não foi informado um intervalo de datas válido!", "Erro");
                    return;
                }
                else
                {
                    int par = 0;
                    DateTime resultado = DateTime.MinValue;
                    DateTime resultado1 = DateTime.MinValue;
                    if (DateTime.TryParse(this.maskedTextBox1.Text.Trim(), out resultado) && DateTime.TryParse(this.maskedTextBox2.Text.Trim(), out resultado1))
                    {
                        par = 1;
                    }
                    else
                    {
                        par = 2;
                    }

                    if (par == 2)
                    {
                        MessageBox.Show("Não foi informado um intervalo de datas válido!", "Erro");
                        return;
                    }
                    else
                    {
                        preencheRelatorio();
                    }
                }
            }
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskCompleted == false || maskedTextBox2.MaskCompleted == false)
            {
                MessageBox.Show("Não foi informado um intervalo de datas válido!", "Erro");
                return;
            }
            else
            {
                int par = 0;
                DateTime resultado = DateTime.MinValue;
                DateTime resultado1 = DateTime.MinValue;
                if (DateTime.TryParse(this.maskedTextBox1.Text.Trim(), out resultado) && DateTime.TryParse(this.maskedTextBox2.Text.Trim(), out resultado1))
                {
                    par = 1;
                }
                else
                {
                    par = 2;
                }

                if(par == 2)
                {
                    MessageBox.Show("Não foi informado um intervalo de datas válido!", "Erro");
                    return;
                }
                else
                {
                    preencheRelatorio();
                }    
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parametro = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parametro = 2;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            maskedTextBox1.Select();
            maskedTextBox1.Focus();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            parametro = 0;
            this.Close();
        }

        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {

        }

        private void maskedTextBox2_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {

        }

        private void FiltroRelatorio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cbImprimeOuNao_CheckedChanged(object sender, EventArgs e)
        {
            if(cbImprimeOuNao.Checked == true)
            {
                parametroImpressao = 1;
            }
            else
            {
                parametroImpressao = 0;
            }
        }
    }
}
