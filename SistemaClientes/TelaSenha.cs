using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class TelaSenha : Form
    {
        public TelaSenha()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if(tbCodigo.Text == "belinha1234")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("A senha informada está incorreta!", "Erro");
                tbCodigo.Text = "";
                tbCodigo.Select();
                tbCodigo.Focus();
                return;
            }
        }

        private void tbCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbCodigo.Text == "belinha1234")
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("A senha informada está incorreta!", "Erro");
                    tbCodigo.Text = "";
                    tbCodigo.Select();
                    tbCodigo.Focus();
                    return;
                }
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void TelaSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void TelaSenha_Load(object sender, EventArgs e)
        {

        }
    }
}
