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
    public partial class SenhasPainel : Form
    {
        public SenhasPainel()
        {
            InitializeComponent();
        }

        public void alteraLabel(String senha, String nome)
        {
            labelSenha.Text = senha;
            labelCliente.Text = nome;
        }
        public void limpaPainel()
        {
            labelSenha.Text = "--";
            labelCliente.Text = "--";
        }
        private void SenhasPainel_Load(object sender, EventArgs e)
        {

        }

        FormWindowState LastWindowState = FormWindowState.Minimized;
        private void Form1_Resize(object sender, EventArgs e)
        {

            // When window state changes
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;


                if (WindowState == FormWindowState.Maximized)
                {
                    labelSenha.Font = new Font("Arial Black", 200, FontStyle.Bold);
                    //Arial Black; 100pt; style=Bold - SENHA
                    label1.Font = new Font("Arial Black", 40, FontStyle.Bold);
                    //Arial Black; 40pt; style=Bold - DESC-SENHA
                    label2.Font = new Font("Arial Black", 40, FontStyle.Bold);
                    //Arial Black; 100pt; style=Bold
                    labelCliente.Font = new Font("Arial Black", 60, FontStyle.Bold);
                }
                if (WindowState == FormWindowState.Normal)
                {
                    labelSenha.Font = new Font("Arial Black", 100, FontStyle.Bold);
                    label1.Font = new Font("Arial Black", 40, FontStyle.Bold);
                    label2.Font = new Font("Arial Black", 40, FontStyle.Bold);
                    labelCliente.Font = new Font("Arial Black", 40, FontStyle.Bold);
                }
            }

        }
    }
}
