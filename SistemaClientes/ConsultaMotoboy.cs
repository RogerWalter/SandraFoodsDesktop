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
    public partial class ConsultaMotoboy : Form
    {
        public ConsultaMotoboy()
        {
            InitializeComponent();
        }
        int idSelecionado = 0;
        int idProvisorio = 0;

        public int retornaValor()
        {
            return idSelecionado;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idProvisorio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int linha = Convert.ToInt32(dataGridView1.CurrentRow.Index);
                    idSelecionado = Convert.ToInt32(dataGridView1.Rows[linha - 1].Cells[0].Value);
                }
                catch
                {
                    //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
                }
                this.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idSelecionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
            }
            this.Close();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            idSelecionado = idProvisorio;
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaMotoboy_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable motoboys = new DataTable("Motoboys");
            DataSet dsFinal = new DataSet();
            motoboys = AcessoFB.fb_buscaMotoboysConsulta();
            dsFinal.Tables.Add(motoboys);
            bindingSource1.DataSource = motoboys;
            dataGridView1.DataSource = bindingSource1;
        }

        private void ConsultaMotoboy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
