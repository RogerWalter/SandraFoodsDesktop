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
    public partial class ConsultarTaxa : Form
    {
        public ConsultarTaxa()
        {
            InitializeComponent();
        }

        public int enviaCodTaxa()
        {
            return idSelec;
        }



        String taxaSelec = "";

        private void ConsultarTaxa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable taxas = new DataTable("Taxas");
            DataSet dsFinal = new DataSet();
            taxas = AcessoFB.fb_buscaTaxasConsulta();
            dsFinal.Tables.Add(taxas);
            bindingSource1.DataSource = taxas;
            dataGridView1.DataSource = bindingSource1;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idProv = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
            }
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            idSelec = idProv;
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            taxaSelec = "";
            this.Close();
        }

        int idSelec = 0;
        int idProv = 0;
        private void tbPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                String procurar = tbPesquisa.Text.ToString();
                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains(procurar) || row.Cells[1].Value.ToString().Equals(procurar))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                if (rowIndex == -1)
                {
                    MessageBox.Show("Não foram encontrados resultados para o termo pesquisado", "Erro", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    dataGridView1.Rows[rowIndex].Selected = true;
                    idProv = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
                    tbPesquisa.Text = "";
                    tbPesquisa.Enabled = true;
                    dataGridView1.Select();
                    dataGridView1.Focus();
                    return;
                }

            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int linha = Convert.ToInt32(dataGridView1.CurrentRow.Index);
                    idSelec = Convert.ToInt32(dataGridView1.Rows[linha - 1].Cells[0].Value);
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
                idSelec = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
            }
            this.Close();
        }

        private void ConsultarTaxa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
