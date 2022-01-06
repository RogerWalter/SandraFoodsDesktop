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
    public partial class Impressora : Form
    {
        public Impressora()
        {
            InitializeComponent();
        }

        private void Impressora_Load(object sender, EventArgs e)
        {
            tbTitulo.Focus();
            tbTitulo.Select();
        }

        private void tbTitulo_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void tbMensagem_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tbTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Impressora_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void tbTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbRodape_KeyUp(object sender, KeyEventArgs e)
        {
            String titulo = tbTitulo.Text;
            String mensagem = tbMensagem.Text;
            String rodape = tbRodape.Text;

            if (e.KeyCode == Keys.Enter)
            {
                //imprime
                rodape = tbRodape.Text;

                if (titulo.Trim() == "" && mensagem.Trim() == "" && rodape.Trim() == "")
                {
                    this.Close();
                }
                else
                {
                    ImpressoraImprimir nova = new ImpressoraImprimir();
                    nova.recebeTextos(titulo, mensagem, rodape);
                    nova.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
