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
    public partial class Pedido_Add_Cliente : Form
    {
        public Pedido_Add_Cliente()
        {
            InitializeComponent();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Pedido_Add_Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btConfirmar_Click(sender, e);
            }
            if(e.KeyCode == Keys.Escape)
            {
                btCancelar_Click(sender, e);
            }
        }
    }
}
