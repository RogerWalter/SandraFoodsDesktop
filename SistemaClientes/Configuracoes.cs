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
    public partial class Configuracoes : Form
    {
        public Parametros parametrosRecuperados = new Parametros();
        //usamos este objeto para verificar se houve alteração nos
        //parametros antes de salvar no banco e no firebase

        public Configuracoes()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "tJVQSamSvHRtZguzUcn0h3YfPGFoEjl37nI2uNDD",
            BasePath = "https://sandra-foods-34d79-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
            nova.WindowState = FormWindowState.Normal;
            nova.BringToFront();
            nova.TopMost = true;
            nova.Focus();
        }

        public int parametroLoad = 0;
        public int parametroSincronizacaoAntigo = 0;
        private void Configuracoes_Load(object sender, EventArgs e)
        {
            parametroLoad = 1;
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar ao Firebase.\nVerifique sua conexão com a internet e tente acessar esta tela novamente.", "Erro");
                this.Close();
            }

            Parametros parametros = AcessoFB.fb_recuperaParametrosSistema();
            parametrosRecuperados = parametros;
            parametroSincronizacaoAntigo = parametros.sincronizar;
            if(parametros.motoboy == 1)
            {
                cbMot.Checked = true;
            }
            else
            {
                cbMot.Checked = false;
            }
            if (parametros.sincronizar == 1)
            {
                cbSincronizar.Checked = true;
            }
            else
            {
                cbSincronizar.Checked = false;
            }
            if (parametros.manutencao == 1)
            {
                cbManutencao.Checked = true;
            }
            else
            {
                cbManutencao.Checked = false;
            }
            tbEntrega.Text = parametros.entrega.ToString().Trim();
            tbRetirada.Text = parametros.retirada.ToString().Trim();
            tbInicio.Text = parametros.inicio.ToString().Trim();
            tbFim.Text = parametros.fim.ToString().Trim();
            if (parametros.seg == 1)
            {
                cbSeg.Checked = true;
            }
            else
            {
                cbSeg.Checked = false;
            }
            if (parametros.ter == 1)
            {
                cbTer.Checked = true;
            }
            else
            {
                cbTer.Checked = false;
            }
            if (parametros.qua == 1)
            {
                cbQua.Checked = true;
            }
            else
            {
                cbQua.Checked = false;
            }
            if (parametros.qui == 1)
            {
                cbQui.Checked = true;
            }
            else
            {
                cbQui.Checked = false;
            }
            if (parametros.sex == 1)
            {
                cbSex.Checked = true;
            }
            else
            {
                cbSex.Checked = false;
            }
            if (parametros.sab == 1)
            {
                cbSab.Checked = true;
            }
            else
            {
                cbSab.Checked = false;
            }
            if (parametros.dom == 1)
            {
                cbDom.Checked = true;
            }
            else
            {
                cbDom.Checked = false;
            }
            parametroLoad = 0;
        }
        TelaCarregamento carregando = new TelaCarregamento();
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Parametros parametrosParaBackGroundWorker = new Parametros();
        public int parametroSincronizarNovo = 0;
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            //verifica quantos motoboys existem cadastrados
            int qtdMotoboy = AcessoFB.fb_contaQtdEntregadores();
            if (qtdMotoboy != 1)
            {
                MessageBox.Show("Existe mais de 1 motoboy cadastrado. \nNão é possível ativar o parâmetro 'Motoboy único'.", "Erro");
                return;
            }

            if (tbEntrega.Text.ToString() == "" || tbRetirada.Text.ToString() == "" || 
                tbInicio.Text.ToString() == "  :  " || tbFim.Text.ToString() == "  :  " ||
                tbInicio.Text.ToString() == "" || tbFim.Text.ToString() == "")
            {
                MessageBox.Show("Existem campos obrigatórios que não foram preenchidos.\nVerifique e tente novamente.", "Aviso");
                return;
            }

            String horaAbrir = tbInicio.Text.ToString();
            String horaFechar = tbFim.Text.ToString();
            TimeSpan horaAbrirTempo, horaFecharTempo;
            if (!TimeSpan.TryParse(horaAbrir, out horaAbrirTempo))
            {
                MessageBox.Show("Hora de Início do expediente é inválida.\nVerifique e tente novamente.", "Aviso");
                tbInicio.Focus();
                tbInicio.Select();
                return;
            }
            if (!TimeSpan.TryParse(horaFechar, out horaFecharTempo))
            {
                MessageBox.Show("Hora de Final do expediente é inválida.\nVerifique e tente novamente.", "Aviso");
                tbFim.Focus();
                tbFim.Select();
                return;
            }

            int minutosEnt = Convert.ToInt32(tbEntrega.Text);
            int minutosRet = Convert.ToInt32(tbRetirada.Text);
            if(minutosEnt < 0 || minutosRet < 0)
            {
                MessageBox.Show("Tempo de Entrega ou Retirada é inválido.\nVerifique e tente novamente.", "Aviso");;
                return;
            }
            //RECUPERA PARAMETROS
            Parametros parametrosInformados = new Parametros();
            //UNICO MOTOBOY
            if (cbMot.Checked == true)
                parametrosInformados.motoboy = 1;
            else
                parametrosInformados.motoboy = 0;
            //SINCRONIZAR COM O APLICATIVO
            if (cbSincronizar.Checked == true)
                parametrosInformados.sincronizar = 1;
            else
                parametrosInformados.sincronizar = 0;
            parametroSincronizarNovo = parametrosInformados.sincronizar;
            //APP EM MANUTENCAO
            if (cbManutencao.Checked == true)
                parametrosInformados.manutencao = 1;
            else
                parametrosInformados.manutencao = 0;
            //PRAZOS
            parametrosInformados.entrega = minutosEnt;
            parametrosInformados.retirada = minutosRet;
            //ABRE E FECHA
            parametrosInformados.inicio = horaAbrir;
            parametrosInformados.fim = horaFechar;
            //SEGUNDA
            if (cbSeg.Checked == true)
                parametrosInformados.seg = 1;
            else
                parametrosInformados.seg = 0;
            //TERÇA
            if (cbTer.Checked == true)
                parametrosInformados.ter = 1;
            else
                parametrosInformados.ter = 0;
            //QUARTA
            if (cbQua.Checked == true)
                parametrosInformados.qua = 1;
            else
                parametrosInformados.qua = 0;
            //QUINTA
            if (cbQui.Checked == true)
                parametrosInformados.qui = 1;
            else
                parametrosInformados.qui = 0;
            //SEXTA
            if (cbSex.Checked == true)
                parametrosInformados.sex = 1;
            else
                parametrosInformados.sex = 0;
            //SABADO
            if (cbSab.Checked == true)
                parametrosInformados.sab = 1;
            else
                parametrosInformados.sab = 0;
            //DOMINGO
            if (cbDom.Checked == true)
                parametrosInformados.dom = 1;
            else
                parametrosInformados.dom = 0;

            int parametroRespostaUsuario = 0;
            if(parametrosInformados.seg == 0 && parametrosInformados.ter == 0 &&
                parametrosInformados.qua == 0 && parametrosInformados.qui == 0 &&
                parametrosInformados.sex == 0 && parametrosInformados.sab == 0 &&
                parametrosInformados.dom == 0)
            {
                if (MessageBox.Show("Esta configuração fará com que o estabelecimento encontre-se fechado todos os dias.\nIsto significa que os clientes não conseguirão fazer pedidos em momento algum.\n\nDeseja realmente continuar com esta configuração?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    parametroRespostaUsuario = 1;
                }
                else
                {
                    parametroRespostaUsuario = 0;
                }
            }

            if(parametroRespostaUsuario == 1)
            {
                return;
            }
            if(parametrosRecuperados.motoboy == parametrosInformados.motoboy &&
                parametrosRecuperados.sincronizar == parametrosInformados.sincronizar &&
                parametrosRecuperados.manutencao == parametrosInformados.manutencao &&
                parametrosRecuperados.retirada == parametrosInformados.retirada &&
                parametrosRecuperados.entrega == parametrosInformados.entrega &&
                parametrosRecuperados.inicio == parametrosInformados.inicio &&
                parametrosRecuperados.fim == parametrosInformados.fim &&
                parametrosRecuperados.seg == parametrosInformados.seg &&
                parametrosRecuperados.ter == parametrosInformados.ter &&
                parametrosRecuperados.qua == parametrosInformados.qua &&
                parametrosRecuperados.qui == parametrosInformados.qui &&
                parametrosRecuperados.sex == parametrosInformados.sex &&
                parametrosRecuperados.sab == parametrosInformados.sab &&
                parametrosRecuperados.dom == parametrosInformados.dom)
            {
                //NADA MUDOU, SIMPLESMENTE FECHAMOS A TELA
                this.Close();
            }
            else
            {
                //HOUVE ALTERAÇÃO - SALVAMOS NO BANCO E NO FIREBASE
                if (parametroSincronizacaoAntigo == 0 && parametrosInformados.sincronizar == 1)//significa é necessário atualizar os itens do firebase (cardapio, cupom e taxa)
                {
                    if (MessageBox.Show("A sincronização com o App foi habilitada.\nIsto atualizará o cardápio, as taxas e os cupons do aplicativo. O sistema também passará a receber pedidos vindos do app.\nIsto poderá levar algum tempo.\nDeseja executar esta operação agora?", "Sincronizar Aplicativo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            parametrosParaBackGroundWorker = parametrosInformados;
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
                        parametrosInformados.sincronizar = 0;
                        try
                        {
                            AcessoFB.fb_atualizarParametrosSistema(parametrosInformados);
                            var set = client.Set(@"parametro/", parametrosInformados);
                            mostraTelaConfirmacao();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ocorreu um problema ao salvar os parâmetros.\nVerifique sua conexão com a internet e tente novamente.", "Erro");
                        }
                    }
                }
                else
                {
                    try
                    {
                        AcessoFB.fb_atualizarParametrosSistema(parametrosInformados);
                        var set = client.Set(@"parametro/", parametrosInformados);
                        mostraTelaConfirmacao();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ocorreu um problema ao salvar os parâmetros.\nVerifique sua conexão com a internet e tente novamente.", "Erro");
                    }
                }
            }
        }

        private void tbEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void tbInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void cbManutencao_CheckedChanged(object sender, EventArgs e)
        {
            if (parametroLoad == 1)
                return;
            if(cbManutencao.Checked==true)
            {
                if (MessageBox.Show("Esta configuração fará com que o aplicativo seja desabilitado.\nIsto significa que os clientes não conseguirão fazer pedidos em momento algum.\n\nDeseja realmente continuar com esta configuração?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cbManutencao.Checked = true;
                }
                else
                {
                    cbManutencao.Checked = false;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AcessoFB.sincronizaCardapioFirebirdComFirebase(config, client);
            AcessoFB.sincronizaTaxasFirebirdComFirebase(config, client);
            AcessoFB.sincronizaCuponsFirebirdComFirebase(config, client);
            AcessoFB.fb_atualizarParametrosSistema(parametrosParaBackGroundWorker);
            var set = client.Set(@"parametro/", parametrosParaBackGroundWorker);
            fechaCarregamento(); 
            mostraTelaConfirmacao();
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.Close()));
            }
            else
            {
                this.Close();
            }
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
    }
}
