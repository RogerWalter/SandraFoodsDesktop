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
    public partial class SelecionarClienteParaPedido : Form
    {
        public SelecionarClienteParaPedido()
        {
            InitializeComponent();
        }

        int idSelecionado = 0;
        int idProvisorio = 0;
        String numCelular = "";
        public int enviaCodCliente()
        {
            return idSelecionado;
        }

        public void recebeCelularCliente(String celular)
        {
            numCelular = celular;
        }
        private void SelecionarClienteParaPedido_Load(object sender, EventArgs e)
        {
            //CARREGAMOS O GRID
            dataGridView1.DataSource = null;
            BindingSource bindingSource1 = new BindingSource();
            DataTable enderecos = new DataTable("Enderecos");
            DataSet dsFinal = new DataSet();
            enderecos = AcessoFB.fb_buscaEnderecosConsulta(numCelular);
            dsFinal.Tables.Add(enderecos);
            bindingSource1.DataSource = enderecos;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            String mensagemWhats = "Foi encontrado mais de um endereço para este numero de celular.\nEm qual dos endereços abaixo devemos entregar?\n\n";
            int cont = 0;
            for (int i = 0; i < enderecos.Rows.Count; i++)
            {
                cont++;
                Clientes endereco = new Clientes();
                endereco.Rua = enderecos.Rows[i]["RUA"].ToString();
                endereco.Numero = enderecos.Rows[i]["Nº"].ToString();
                endereco.Bairro = enderecos.Rows[i]["BAIRRO"].ToString();

                String enderecoParaMensagem = "";
                enderecoParaMensagem = cont + ": " + endereco.Rua.Trim() + " - Nº " + endereco.Numero.Trim() + " - " + endereco.Bairro.Trim() + "\r\n\r\n";

                mensagemWhats = mensagemWhats + enderecoParaMensagem;
            }
            Clipboard.SetText(mensagemWhats.ToString().Trim());
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            idSelecionado = idProvisorio;
            this.Close();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    idProvisorio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);       
                }
                else
                {
                    return;
                }
            }
            catch
            {

            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            idSelecionado = 0;
            this.Close();
        }
    }
}
