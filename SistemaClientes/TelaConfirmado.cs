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
    public partial class TelaConfirmado : Form
    {
        public TelaConfirmado()
        {
            InitializeComponent();
        }

        private void TelaConfirmado_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1200;
            timer1.Tick += new EventHandler(timer1_Tick_1);
            timer1.Start();

            var form = new TelaConfirmado();
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

        private void TelaConfirmado_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
