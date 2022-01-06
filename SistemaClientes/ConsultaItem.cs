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
    public partial class ConsultaItem : Form
    {
        int idSelecionado = 0;
        int idProvisorio = 0;
        public ConsultaItem()
        {
            InitializeComponent();
        }

        public int enviaCodProd()
        {
            return idSelecionado; ;
        }
        /*
        public static int retornaId()
        {
           //return idSelecionado;
        }*/


        private void ConsultaItem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable produtos = new DataTable("Produtos");
            DataSet dsFinal = new DataSet();
            produtos = AcessoFB.fb_buscaItensConsulta();
            dsFinal.Tables.Add(produtos);
            bindingSource1.DataSource = produtos;
            dataGridView1.DataSource = bindingSource1;

        }
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count - 1)
                {
                    idProvisorio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                }
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

        private void ConsultaItem_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            idSelecionado = 0;
            this.Close();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void tbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void ConsultaItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void tbPesquisa_TextChanged(object sender, EventArgs e)
        {
            var bd = (BindingSource)dataGridView1.DataSource;
            var dt = (DataTable)bd.DataSource;
            dt.DefaultView.RowFilter = string.Format("DESCRICAO like '%{0}%'", tbPesquisa.Text.Trim().Replace("'", "''"));
            dataGridView1.Refresh();
        }
    }
}
