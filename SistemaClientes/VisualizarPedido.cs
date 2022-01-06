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
    public partial class VisualizarPedido : Form
    {
        public VisualizarPedido()
        {
            InitializeComponent();
        }
        int numPed = 0;
        public void recebeNumPedido(int codigo)
        {
            numPed = codigo;
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VisualizarPedido_Load(object sender, EventArgs e)
        {
            int qtdItemPed = AcessoFB.fb_contaItemPedTemp(numPed);
            String[] listar = new String[qtdItemPed];
            listar = AcessoFB.fb_buscaItensPedTempListar(qtdItemPed, numPed);
            
            for(int i = 0; i < qtdItemPed; i++)
            {
                tbLista.Text = tbLista.Text + listar[i] + "\r\n";
            }

            tbLista.SelectionStart = 0;
            tbLista.SelectionLength = tbLista.Text.Length;
            Clipboard.SetText(tbLista.Text.ToString());
        }

        private void VisualizarPedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                tbLista.SelectionStart = 0;
                tbLista.SelectionLength = tbLista.Text.Length;
                Clipboard.SetText(tbLista.Text.ToString());
                this.Close();
            }
        }
    }
}
