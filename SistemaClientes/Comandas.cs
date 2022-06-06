using FireSharp.Config;
using FireSharp.Interfaces;
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
    public partial class Comandas : Form
    {
        public Comandas()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "yKdYGvHvhJgzoHzo8vVDhy6dN5scylE77DqpUgxh",
            BasePath = "https://comandas-5e2ea-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        TelaCarregamento carregando = new TelaCarregamento();

        private void atualizarCardapioGarcom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta ação recarregará todos os dados de cardápio para o aplicativo do Garçom.\nO ideal é que este procedimento seja executado somente quando o estabelecimento estiver fechado.\nDeseja executá-lo agora?", "Sincronizar Cardápio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("Deseja realmente continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        carregando.Show();
                        carregando.BringToFront();
                        if (backgroundWorker1.IsBusy != true)
                        {
                            backgroundWorker1.RunWorkerAsync();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ocorreu um erro ao concluir esta ação.\nVerifique sua conexão com a internet e tente novamente.", "Erro na Operação");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void atualizarTaxasGarcom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta ação recarregará todos os dados de taxas para o aplicativo do Garçom.\nO ideal é que este procedimento seja executado somente quando o estabelecimento estiver fechado.\nDeseja executá-lo agora?", "Sincronizar Cardápio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("Deseja realmente continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        carregando.Show();
                        carregando.BringToFront();
                        if (backgroundWorker2.IsBusy != true)
                        {
                            backgroundWorker2.RunWorkerAsync();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ocorreu um erro ao concluir esta ação.\nVerifique sua conexão com a internet e tente novamente.", "Erro na Operação");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AcessoFB.sincronizaCardapioFirebirdComGarcom(config, client);
            fechaCarregamento();
            mostraTelaConfirmacao();
        }

        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
            if (nova.InvokeRequired)
            {
                nova.Invoke(new Action(() => nova.Close()));
            }
            else
            {
                nova.Close();
            }
            this.Close();
        }

        public void fechaCarregamento()
        {
            if (carregando.InvokeRequired)
            {
                carregando.Invoke(new Action(() => carregando.Close()));
            }
            else
            {
                carregando.Close();
            }
        }

        private void Comandas_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar ao Servidor.\nVerifique sua conexão com a internet e tente acessar esta tela novamente.", "Erro");
                this.Close();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            AcessoFB.sincronizaTaxasFirebirdComFirebase(config, client);
            fechaCarregamento();
            mostraTelaConfirmacao();
        }
    }
}
