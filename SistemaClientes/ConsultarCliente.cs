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
    public partial class ConsultarCliente : Form
    {
        public ConsultarCliente()
        {
            InitializeComponent();
        }
        int tipoPesquisa = 1;

        public int enviaCodCli()
        {
            return idSelecionado; 
        }

        public void limpaCampos()
        {
            tbPesquisa.Text = "";
        }

        private void rbNome_CheckedChanged(object sender, EventArgs e)
        {
            limpaCampos();
            if (rbCodigo.Checked == true) // pesquisa por nome habilitada
            {
                tbPesquisa.Enabled = true;
                tipoPesquisa = 1;
                tbPesquisa.Select();
                tbPesquisa.Focus();
            }
            if (rbCodigo.Checked == false) //pesquisa por celular
            {
                tipoPesquisa = 2;
            }
        }

        private void rbCelular_CheckedChanged(object sender, EventArgs e)
        {
            limpaCampos();
            if (rbCelular.Checked == true) // pesquisa por celular habilitada
            {
                tbPesquisa.Enabled = true;
                tipoPesquisa = 2;
                tbPesquisa.Select();
                tbPesquisa.Focus();

            }
            if (rbCelular.Checked == false) //pesquisa por nome 
            {
                tipoPesquisa = 1;
            }
        }

        private void ConsultarCliente_Load(object sender, EventArgs e)
        {
            rbCelular.Checked = false;
            rbCodigo.Checked = false;
            rbCodigo.Enabled = true;
            rbCelular.Enabled = true;
            tbPesquisa.Text = "";
            tbPesquisa.Enabled = true;


            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable clientes = new DataTable("Clientes");
            DataSet dsFinal = new DataSet();
            clientes = AcessoFB.fb_buscaClientesConsulta();
            dsFinal.Tables.Add(clientes);
            bindingSource1.DataSource = clientes;
            dataGridView1.DataSource = bindingSource1;
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void tbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            
 
        }

        private void tbPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Enter)
            {
                

                if (tipoPesquisa == 1)
                {
                    String procurar = tbPesquisa.Text.ToString();
                    int rowIndex = -1;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(procurar))
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
                        idProvisorio = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
                        dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
                        dataGridView1.Select();
                        dataGridView1.Focus();
                        return;
                    }
                    
                }

                if(tipoPesquisa == 2)
                {
                    String procurar = tbPesquisa.Text.ToString();
                    int rowIndex = -1;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[2].Value.ToString().Contains(procurar) || row.Cells[2].Value.ToString().Equals(procurar))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }
                    if (rowIndex == -1)
                    {
                        MessageBox.Show("Não foram encontrados resultados para o termo pesquisado", "Pesquisa!", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        dataGridView1.Rows[rowIndex].Selected = true;
                        idProvisorio = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
                        dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
                        return;
                    }
                    
                }
                rbCelular.Checked = false;
                rbCodigo.Checked = false;
                rbCodigo.Enabled = true;
                rbCelular.Enabled = true;
                tbPesquisa.Text = "";
                tbPesquisa.Enabled = true;
            }*/
        }
        int idSelecionado = 0;
        int idProvisorio = 0;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idProvisorio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
            }
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            idSelecionado = idProvisorio;
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            idSelecionado = 0;
            this.Close();
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

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void ConsultarCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void tbPesquisa_TextChanged(object sender, EventArgs e)
        {
            if(tipoPesquisa == 1)
            {
                var bd = (BindingSource)dataGridView1.DataSource;
                var dt = (DataTable)bd.DataSource;
                dt.DefaultView.RowFilter = string.Format("NOME like '%{0}%'", tbPesquisa.Text.Trim().Replace("'", "''"));
                dataGridView1.Refresh();
            }
            if (tipoPesquisa == 2)
            {
                var bd = (BindingSource)dataGridView1.DataSource;
                var dt = (DataTable)bd.DataSource;
                dt.DefaultView.RowFilter = string.Format("CELULAR like '%{0}%'", tbPesquisa.Text.Trim().Replace("'", "''"));
                dataGridView1.Refresh();
            }
        }
    }
}
