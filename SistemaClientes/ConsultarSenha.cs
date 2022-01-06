using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class ConsultarSenha : Form
    {
        public ConsultarSenha()
        {
            InitializeComponent();
        }

        int senha = 0;
        String data = "";
        int id_Pedido = 0;
        public void recebeSenha(int sen)
        {
            senha = sen;
        }

        public void RecarregaDados(int id)
        {
            dataGridView1.DataSource = null;

            BindingSource bindingSource1 = new BindingSource();
            DataTable itensPedido = new DataTable("Itens_Pedido");
            DataSet dsFinal = new DataSet();
            itensPedido = AcessoFB.fb_buscaItensPedidoConsultarSenha(id_Pedido);
            dsFinal.Tables.Add(itensPedido);
            bindingSource1.DataSource = itensPedido;
            dataGridView1.DataSource = bindingSource1;

        }
        private void ConsultarSenha_Load(object sender, EventArgs e)
        {
            data = DateTime.Now.ToString();
            data = data.Substring(0, 10);

            Pedidos busca = AcessoFB.fb_pesquisaPedido(senha, data);
            id_Pedido = busca.Id;

            labelSenha.Text = senha.ToString();
            labelNome.Text = busca.Nome_Cliente.Trim();
            labelTotal.Text = busca.Valor.ToString("C", CultureInfo.CurrentCulture);

            RecarregaDados(busca.Id);
            dataGridView1.ClearSelection();
        }


        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultarSenha_KeyUp(object sender, KeyEventArgs e)
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
                dataGridView1.ClearSelection();
        }
    }
}
