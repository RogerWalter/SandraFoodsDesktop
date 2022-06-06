using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class PedidosNaNuvem : Form
    {
        List<PedidoNuvem> listaPedidos = new List<PedidoNuvem>();

        public PedidosNaNuvem()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "tJVQSamSvHRtZguzUcn0h3YfPGFoEjl37nI2uNDD",
            BasePath = "https://sandra-foods-34d79-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void PedidosNaNuvem_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar ao Servidor.\nVerifique sua conexão com a internet e tente acessar o sistema novamente.", "Erro");
                this.Close();
            }

            listaPedidos.Clear();
            FirebaseResponse response = client.Get(@"pedido");
            if(response.Body.ToString() == "null")
            {
                label6.Visible = true;
                dataGridView1.Visible = false;
                return;
            }
            Dictionary<string, PedidoFirebase> getPedido = JsonConvert.DeserializeObject<Dictionary<string, PedidoFirebase>>(response.Body.ToString());
            foreach (var item in getPedido)
            {
                PedidoNuvem novo = new PedidoNuvem();
                novo.Cliente = RemoverAcentos(item.Value.clt_nome).Trim().ToUpper();
                novo.Data = RemoverAcentos(item.Value.data).Trim().ToUpper();
                novo.Valor = item.Value.valor.ToString("C", CultureInfo.CurrentCulture);
               
                listaPedidos.Add(novo);
            }
            if (listaPedidos.Count == 0)
            {
                label6.Visible = true;
                dataGridView1.Visible = false;
                return;
            }
            var bindingList = new BindingList<PedidoNuvem>(listaPedidos);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        public static string RemoverAcentos(string valor)
        {
            valor = Regex.Replace(valor, "[ÁÀÂÃ]", "A");
            valor = Regex.Replace(valor, "[ÉÈÊ]", "E");
            valor = Regex.Replace(valor, "[Í]", "I");
            valor = Regex.Replace(valor, "[ÓÒÔÕ]", "O");
            valor = Regex.Replace(valor, "[ÚÙÛÜ]", "U");
            valor = Regex.Replace(valor, "[Ç]", "C");
            valor = Regex.Replace(valor, "[áàâã]", "a");
            valor = Regex.Replace(valor, "[éèê]", "e");
            valor = Regex.Replace(valor, "[í]", "i");
            valor = Regex.Replace(valor, "[óòôõ]", "o");
            valor = Regex.Replace(valor, "[úùûü]", "u");
            valor = Regex.Replace(valor, "[ç]", "c");
            return valor;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
