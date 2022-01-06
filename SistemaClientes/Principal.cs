using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace SistemaClientes
{
    public partial class Principal : Form
    {
        int mov;
        int movX;
        int movY;
        Parametros parametrosSistema = new Parametros();
        List<PedidoFirebase> listaPedidos = new List<PedidoFirebase>();
        List<PedidoMonitor> listaMonitor = new List<PedidoMonitor>();
        List<AndamentoFirebase> listaAndamentos = new List<AndamentoFirebase>();
        List<Itens_Pedido_Firebase> listaItensPedido = new List<Itens_Pedido_Firebase>();
        public Principal()
        {
            InitializeComponent();
            //Database=CASSIO-PC:C:\Program Files (x86)\DBStiz\DBSTIZ.FDB
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "tJVQSamSvHRtZguzUcn0h3YfPGFoEjl37nI2uNDD",
            BasePath = "https://sandra-foods-34d79-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void Principal_Load(object sender, EventArgs e)
        {
            int parametroErroAtual = AcessoFB.fb_recuperaTabelaErro();
            if(parametroErroAtual != 0)
            {
                AcessoFB.fb_atualizaTabelaErro(0);
                AcessoFB.fb_limpaTabelasImpressao();
                AcessoFB.fb_resetItemPedidoTemp();
            }

            parametrosSistema = AcessoFB.fb_recuperaParametrosSistema();

            if(parametrosSistema.sincronizar == 1)
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
                String atual = DateTime.Now.ToString();
                String data = atual.Substring(0, 10);
                AcessoFB.limpaMonitorPedidosApp(data);
                limpaPedidosAntigosApp();
                criaListenerPedidosApp();
                criaListeneAndamentosApp();
            }
        } 
        async void criaListenerPedidosApp()
        {
            //Task.Delay(150000).ContinueWith(t => criaListenerPedidosApp());
            EventStreamResponse response = await client.OnAsync(@"pedido", 
                    added: (s, args, context) =>
                    {
                        inserirNovoPedidoApp();
                    },
                    changed: (s, args, context) =>
                    {
                        inserirNovoPedidoApp();
                    },
                    removed: (s, args, context) =>
                    {
                         
                    });
        }

        async void criaListeneAndamentosApp()
        {
            //Task.Delay(150000).ContinueWith(t => criaListeneAndamentosApp());
            EventStreamResponse response = await client.OnAsync(@"andamento",
                    added: (s, args, context) =>
                    {

                    },
                    changed: (s, args, context) =>
                    {
                        alterarAndamentoPedidoApp();
                    },
                    removed: (s, args, context) =>
                    {

                    });
        }

        public void inserirNovoPedidoApp()
        {
            //RECEBEMOS A LISTA COM TODOS OS PEDIDOS
            listaPedidos.Clear();
            FirebaseResponse response = client.Get(@"pedido");
            Dictionary<string, PedidoFirebase> getPedido = JsonConvert.DeserializeObject<Dictionary<string, PedidoFirebase>>(response.Body.ToString());
            foreach (var item in getPedido)
            {
                PedidoFirebase inserir = new PedidoFirebase();
                inserir.clt_nome = RemoverAcentos(item.Value.clt_nome).Trim().ToUpper();
                inserir.clt_celular = RemoverAcentos(item.Value.clt_celular).Trim().ToUpper();
                inserir.tipo = RemoverAcentos(item.Value.tipo).Trim().ToUpper();
                inserir.valor = item.Value.valor;
                inserir.clt_bairro = RemoverAcentos(item.Value.clt_bairro).Trim().ToUpper();
                inserir.clt_numero = RemoverAcentos(item.Value.clt_numero).Trim().ToUpper();
                inserir.clt_referencia = RemoverAcentos(item.Value.clt_referencia).Trim().ToUpper();
                inserir.clt_rua = RemoverAcentos(item.Value.clt_rua).Trim().ToUpper();
                inserir.data = RemoverAcentos(item.Value.data).Trim().ToUpper();
                inserir.desconto = RemoverAcentos(item.Value.desconto).Trim().ToUpper();
                inserir.id = item.Value.id;
                inserir.observacao = RemoverAcentos(item.Value.observacao).Trim().ToUpper();
                inserir.pagamento = RemoverAcentos(item.Value.pagamento).Trim().ToUpper();
                inserir.troco = RemoverAcentos(item.Value.troco).Trim().ToUpper();

                listaPedidos.Add(inserir);
            }
            if(listaPedidos.Count == 0)
            {
                return;
            }
            //RECUPERAMOS O QUE JÁ FOI INSERIDO
            listaMonitor.Clear();
            listaMonitor = AcessoFB.fb_recuperaListaPedidosMonitor();
            //COMPARAMOS OS PEDIDOS DO FIREBASE COM O QUE JÁ TEMOS INSERIDO
            for(int i = 0; i < listaPedidos.Count(); i++)
            {
                PedidoFirebase pedidoProcurado = listaPedidos[i];
                PedidoMonitor retornoLista = listaMonitor.Find(item => item.Identificador == RemoverAcentos(pedidoProcurado.id));
                if(retornoLista == null)
                {
                    //ESTE PEDIDO NÃO ESTÁ REGISTRADO NO BANCO
                    //RECUPERAMOS OS ITENS DESTE PEDIDO
                    listaItensPedido = recuperaItensPedidoFirebase(config, client, pedidoProcurado.id);
                    //INSERIMOS O PEDIDO NO BANCO
                    inserePedidoNoBanco(pedidoProcurado, listaItensPedido);
                    
                }
                else
                {
                    //ESTE PEDIDO JÁ ESTÁ REGISTRADO NO BANCO
                    //VERIFICAMOS O PRÓXIMO ITEM DA LISTA
                }
            }

        }

        public void alterarAndamentoPedidoApp()
        {
            //RECEBEMOS A LISTA COM TODOS OS ANDAMENTOS
            listaAndamentos.Clear();
            FirebaseResponse response = client.Get(@"andamento");
            Dictionary<string, AndamentoFirebase> getAndamento = JsonConvert.DeserializeObject<Dictionary<string, AndamentoFirebase>>(response.Body.ToString());
            if(response.Body == null || response.Body == "null")
            {
                return;
            }
            foreach (var item in getAndamento)
            {
                AndamentoFirebase inserir = new AndamentoFirebase();
                inserir.id = item.Value.id;
                inserir.cliente = item.Value.cliente;
                inserir.data = item.Value.data;
                inserir.status = item.Value.status;

                listaAndamentos.Add(inserir);
            }
            if (listaAndamentos.Count == 0)
            {
                return;
            }
            //RECUPERAMOS O QUE TEMOS NO BANCO
            listaMonitor.Clear();
            listaMonitor = AcessoFB.fb_recuperaListaPedidosMonitor();
            //COMPARAMOS OS PEDIDOS DO FIREBASE COM O QUE JÁ TEMOS INSERIDO
            for (int i = 0; i < listaAndamentos.Count(); i++)
            {
                AndamentoFirebase andamentoProcurado = listaAndamentos[i];
                PedidoMonitor retornoLista = listaMonitor.Find(item => item.Identificador == RemoverAcentos(andamentoProcurado.id));
                if (retornoLista != null)
                {
                    //LISTA NÃO ESTÁ VAZIA
                    String statusNoBanco = "VAZIO";
                    if (retornoLista.Status == 0)
                        statusNoBanco = "EM PREPARAÇÃO";
                    if (retornoLista.Status == 1)
                        statusNoBanco = "SAIU";
                    if (retornoLista.Status == 2)
                        statusNoBanco = "PRONTO";
                    if (retornoLista.Status == 3)
                        statusNoBanco = "FINALIZADO";
                    if (statusNoBanco == "VAZIO")
                        return;
                    if (andamentoProcurado.status != statusNoBanco)
                    {
                        //STATUS DIFERENTE NO FIREBASE. ATUALIZAMOS O BANCO
                        int novoStatus = 0;
                        if (andamentoProcurado.status == "EM PREPARAÇÃO")
                            novoStatus = 0;
                        if (andamentoProcurado.status == "SAIU")
                            novoStatus = 1;
                        if (andamentoProcurado.status == "PRONTO")
                            novoStatus = 2;
                        if (andamentoProcurado.status == "FINALIZADO")
                            novoStatus = 3;

                        if (novoStatus == 3)
                        {
                            //PEDIDO É FINALIZADO
                            AcessoFB.fb_excluirPedidoMonitor(retornoLista);
                            excluirPedidoFirebase(retornoLista);
                            return;
                        }
                        AcessoFB.fb_atualizaStatusPedido(retornoLista.Id, novoStatus);
                    }

                }
            }

        }
        public void excluirPedidoFirebase(PedidoMonitor item)
        {
            try
            {
                String chaveOndeDeletar = item.Identificador.Trim();
                //ALTERAMOS PARA QUE O APP EXCLUA AS TABELAS INTERNAS
                var set = client.Set(@"andamento/" + chaveOndeDeletar + "/status", "FINALIZADO");
                //EXCLUIR TUDO
                var delete1 = client.Delete(@"pedido/" + chaveOndeDeletar);
                var delete2 = client.Delete(@"andamento/" + chaveOndeDeletar);
                var delete3 = client.Delete(@"pedido-itens/" + chaveOndeDeletar);
                var delete4 = client.Delete(@"notificacao/" + chaveOndeDeletar);
            }
            catch
            {
                MessageBox.Show("Ocorreu um problema ao escluir este pedido no Aplicativo.\nTente atualizar o item novamente.", "Erro");
            }
        }

        public void limpaPedidosAntigosApp()
        {
            //RECEBEMOS A LISTA COM TODOS OS ANDAMENTOS
            listaAndamentos.Clear();
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            FirebaseResponse response = client.Get(@"andamento");
            Dictionary<string, AndamentoFirebase> getAndamento = JsonConvert.DeserializeObject<Dictionary<string, AndamentoFirebase>>(response.Body.ToString());
            if (response.Body == null || response.Body == "null")
            {
                return;
            }
            foreach (var item in getAndamento)
            {
                AndamentoFirebase recuperado = new AndamentoFirebase();
                recuperado.id = item.Value.id;
                recuperado.cliente = item.Value.cliente;
                recuperado.data = item.Value.data;
                recuperado.status = item.Value.status;
                recuperado.data = recuperado.data.Substring(0, 10);
                if(recuperado.data != data)
                {
                    var delete1 = client.Delete(@"pedido/" + recuperado.id);
                    var delete2 = client.Delete(@"andamento/" + recuperado.id);
                    var delete3 = client.Delete(@"pedido-itens/" + recuperado.id);
                    var delete4 = client.Delete(@"notificacao/" + recuperado.id);
                }
            }
        }

        public void focaForm()
        {
            var form = new Principal();
            if (Application.OpenForms[form.Name] == null)
            {
                form.Show();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
                Application.OpenForms[form.Name].Activate();
            }
        }

        private void imagemCliente_Click(object sender, EventArgs e)
        {
            Cliente nova = new Cliente();
            nova.recebeParametro(0);
            nova.Show();
            voltaBtsAoNormal();
        }

        private void imagemProduto_Click(object sender, EventArgs e)
        {
            Produtos nova = new Produtos();
            nova.ShowDialog();
            voltaBtsAoNormal();
        }

        private void imagemTaxa_Click(object sender, EventArgs e)
        {
            Taxa nova = new Taxa();
            nova.ShowDialog();
            voltaBtsAoNormal();
        }

        private void imagemPedido_Click(object sender, EventArgs e)
        {
            Pedido nova = new Pedido();
            nova.Show();
            voltaBtsAoNormal();
        }

        private void btApp_Click(object sender, EventArgs e)
        {
            MonitorAplicativo nova = new MonitorAplicativo();
            nova.Show();
            voltaBtsAoNormal();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TelaSenha novaSenha = new TelaSenha();
            if(novaSenha.ShowDialog() == DialogResult.OK)
            {
                AcessoFB.fb_atualizaPedidoEditando(0);
                FiltroRelatorio novaTela = new FiltroRelatorio();
                novaTela.ShowDialog();

                String dataIni = novaTela.retornaDataIni();
                String dataFin = novaTela.retornaDataFin();

                int parametro = novaTela.retornaParametro();
                int parametroImpressao = novaTela.retornaParametroImpressao();

                if(parametroImpressao == 0)
                {
                    if (parametro == 0)
                    {
                        return;
                    }
                    if (parametro == 1)
                    {
                        int UltSenha = AcessoFB.fb_preencheRelatorioDia();
                        AcessoFB.fb_preencheRelatorioLancamentosDia(UltSenha);
                        Relatorio nova = new Relatorio();
                        nova.recebeParametro(parametro);
                        nova.ShowDialog();
                        AcessoFB.fb_limpaRelatorio();
                    }
                    if (parametro == 2)
                    {
                        int ultSenha = AcessoFB.fb_preencheRelatorioMes();
                        AcessoFB.fb_preencheRelatorioLancamentosMes(ultSenha);
                        Relatorio nova = new Relatorio();
                        nova.recebeParametro(parametro);
                        nova.ShowDialog();
                        AcessoFB.fb_limpaRelatorio();
                    }
                    if (parametro == 3)
                    {
                        int ultSenha = AcessoFB.fb_preencheRelatorioPeriodo(dataIni, dataFin);
                        AcessoFB.fb_preencheRelatorioLancamentosPeriodo(dataIni, dataFin, ultSenha);
                        Relatorio nova = new Relatorio();
                        nova.recebeParametro(parametro);
                        nova.recebeDatas(dataIni, dataFin);
                        nova.ShowDialog();
                        AcessoFB.fb_limpaRelatorio();
                    }   
                }
                else
                {
                    if (parametro == 0)
                    {
                        return;
                    }
                    if (parametro == 1)
                    {
                        int UltSenha = AcessoFB.fb_preencheRelatorioDia();
                        AcessoFB.fb_preencheRelatorioLancamentosDia(UltSenha);
                        RelatorioImpresso nova = new RelatorioImpresso();
                        nova.recebeParametro(parametro);
                        nova.ShowDialog();
                        AcessoFB.fb_limpaRelatorio();
                    }
                    if (parametro == 2)
                    {
                        int ultSenha = AcessoFB.fb_preencheRelatorioMes();
                        AcessoFB.fb_preencheRelatorioLancamentosMes(ultSenha);
                        RelatorioImpresso nova = new RelatorioImpresso();
                        nova.recebeParametro(parametro);
                        nova.ShowDialog();
                        AcessoFB.fb_limpaRelatorio();
                    }
                    if (parametro == 3)
                    {
                        int ultSenha = AcessoFB.fb_preencheRelatorioPeriodo(dataIni, dataFin);
                        AcessoFB.fb_preencheRelatorioLancamentosPeriodo(dataIni, dataFin, ultSenha);
                        RelatorioImpresso nova = new RelatorioImpresso();
                        nova.recebeParametro(parametro);
                        nova.recebeDatas(dataIni, dataFin);
                        nova.ShowDialog();
                        AcessoFB.fb_limpaRelatorio();
                    }
                }
            }
            else
            {
                return;
            }
            voltaBtsAoNormal();
        }

        private void btLancamento_Click(object sender, EventArgs e)
        {
            Lancamento nova = new Lancamento();
            nova.ShowDialog();
            voltaBtsAoNormal();
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Motoboy nova = new Motoboy();
            nova.Show();
            voltaBtsAoNormal();
        }

        private void Principal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                Cliente nova = new Cliente();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.D2)
            {
                Produtos nova = new Produtos();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.D3)
            {
                Taxa nova = new Taxa();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.D4)
            {
                pictureBox1_Click(sender, e);
            }
            if (e.KeyCode == Keys.D5)
            {
                Pedido nova = new Pedido();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.D8)
            {
                pictureBox3_Click(sender, e);
            }
            if (e.KeyCode == Keys.D6)
            {
                Lancamento nova = new Lancamento();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.D7)
            {
                Motoboy nova = new Motoboy();
                nova.Show();
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                Cliente nova = new Cliente();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                Produtos nova = new Produtos();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                Taxa nova = new Taxa();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                pictureBox1_Click(sender, e);
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                Pedido nova = new Pedido();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                pictureBox3_Click(sender, e);
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                Lancamento nova = new Lancamento();
                nova.ShowDialog();
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                Motoboy nova = new Motoboy();
                nova.Show();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            Impressora nova = new Impressora();
            nova.Show();
        }
        private void pictureBox1_Click_3(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imagemCliente_MouseEnter(object sender, EventArgs e)
        {
            imagemCliente.Width = imagemCliente.Width + 24;
            imagemCliente.Height = imagemCliente.Height + 24;
            imagemCliente.Left = imagemCliente.Left - 12;
            imagemCliente.Top = imagemCliente.Top - 12;
        }

        private void imagemCliente_MouseLeave(object sender, EventArgs e)
        {
            imagemCliente.Width = 104;
            imagemCliente.Height = 99;
            imagemCliente.Left = 22;
            imagemCliente.Top = 64;
        }

        private void imagemProduto_MouseEnter(object sender, EventArgs e)
        {
            imagemProduto.Width = imagemProduto.Width + 24;
            imagemProduto.Height = imagemProduto.Height + 24;
            imagemProduto.Left = imagemProduto.Left - 12;
            imagemProduto.Top = imagemProduto.Top - 12;
        }

        private void imagemProduto_MouseLeave(object sender, EventArgs e)
        {
            imagemProduto.Width = 104;
            imagemProduto.Height = 99;
            imagemProduto.Left = 207;
            imagemProduto.Top = 64;
        }

        private void imagemTaxa_MouseEnter(object sender, EventArgs e)
        {
            imagemTaxa.Width = imagemTaxa.Width + 24;
            imagemTaxa.Height = imagemTaxa.Height + 24;
            imagemTaxa.Left = imagemTaxa.Left - 12;
            imagemTaxa.Top = imagemTaxa.Top - 12;
        }

        private void imagemTaxa_MouseLeave(object sender, EventArgs e)
        {
            imagemTaxa.Width = 104;
            imagemTaxa.Height = 99;
            imagemTaxa.Left = 396;
            imagemTaxa.Top = 64;
        }

        private void btRelatorio_MouseEnter(object sender, EventArgs e)
        {
            btRelatorio.Width = btRelatorio.Width + 24;
            btRelatorio.Height = btRelatorio.Height + 24;
            btRelatorio.Left = btRelatorio.Left - 12;
            btRelatorio.Top = btRelatorio.Top - 12;
        }

        private void btRelatorio_MouseLeave(object sender, EventArgs e)
        {
            btRelatorio.Width = 104;
            btRelatorio.Height = 99;
            btRelatorio.Left = 22;
            btRelatorio.Top = 364;
        }

        private void btMotoboy_MouseEnter(object sender, EventArgs e)
        {
            btMotoboy.Width = btMotoboy.Width + 24;
            btMotoboy.Height = btMotoboy.Height + 24;
            btMotoboy.Left = btMotoboy.Left - 12;
            btMotoboy.Top = btMotoboy.Top - 12;
        }

        private void btMotoboy_MouseLeave(object sender, EventArgs e)
        {
            btMotoboy.Width = 104;
            btMotoboy.Height = 99;
            btMotoboy.Left = 396;
            btMotoboy.Top = 217;
        }

        private void imagemPedido_MouseEnter(object sender, EventArgs e)
        {
            imagemPedido.Width = imagemPedido.Width + 24;
            imagemPedido.Height = imagemPedido.Height + 24;
            imagemPedido.Left = imagemPedido.Left - 12;
            imagemPedido.Top = imagemPedido.Top - 12;
        }

        private void imagemPedido_MouseLeave(object sender, EventArgs e)
        {
            imagemPedido.Width = 104;
            imagemPedido.Height = 99;
            imagemPedido.Left = 22;
            imagemPedido.Top = 217;
        }

        private void btLancamento_MouseEnter(object sender, EventArgs e)
        {
            btLancamento.Width = btLancamento.Width + 24;
            btLancamento.Height = btLancamento.Height + 24;
            btLancamento.Left = btLancamento.Left - 12;
            btLancamento.Top = btLancamento.Top - 12;
        }

        private void btLancamento_MouseLeave(object sender, EventArgs e)
        {
            btLancamento.Width = 104;
            btLancamento.Height = 99;
            btLancamento.Left = 207;
            btLancamento.Top = 217;
        }

        private void btApp_MouseEnter(object sender, EventArgs e)
        {
            btApp.Width = btApp.Width + 24;
            btApp.Height = btApp.Height + 24;
            btApp.Left = btApp.Left - 12;
            btApp.Top = btApp.Top - 12;
        }

        private void btApp_MouseLeave(object sender, EventArgs e)
        {
            btApp.Width = 104;
            btApp.Height = 99;
            btApp.Left = 390;
            btApp.Top = 364;
        }
        public void voltaBtsAoNormal()
        {
            imagemCliente.Width = 104;
            imagemCliente.Height = 99;
            imagemCliente.Left = 22;
            imagemCliente.Top = 64;

            imagemProduto.Width = 104;
            imagemProduto.Height = 99;
            imagemProduto.Left = 207;
            imagemProduto.Top = 64;

            imagemTaxa.Width = 104;
            imagemTaxa.Height = 99;
            imagemTaxa.Left = 396;
            imagemTaxa.Top = 64;

            btRelatorio.Width = 104;
            btRelatorio.Height = 99;
            btRelatorio.Left = 22;
            btRelatorio.Top = 364;

            btMotoboy.Width = 104;
            btMotoboy.Height = 99;
            btMotoboy.Left = 396;
            btMotoboy.Top = 217;

            imagemPedido.Width = 104;
            imagemPedido.Height = 99;
            imagemPedido.Left = 22;
            imagemPedido.Top = 217;

            btLancamento.Width = 104;
            btLancamento.Height = 99;
            btLancamento.Left = 207;
            btLancamento.Top = 217;

            btAdicionarItemPedido.Width = 104;
            btAdicionarItemPedido.Height = 99;
            btAdicionarItemPedido.Left = 207;
            btAdicionarItemPedido.Top = 364;

            btApp.Width = 104;
            btApp.Height = 99;
            btApp.Left = 390;
            btApp.Top = 364;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PedidoAvulso nova = new PedidoAvulso();
            int status = AcessoFB.fb_verificaStatusPedidoAvulso();
            if(status == 1)
            {
                MessageBox.Show("No momento, existe outro usuário informando itens à um pedido\nNão é possível acessar esta função.\nEspere o outro usuário finalizar as alterações e tente novamente.", "Alerta");
                return;
            }
            else
            {
                nova.Show();
            }
        }

        private void btAdicionarItemPedido_MouseEnter(object sender, EventArgs e)
        {
            btAdicionarItemPedido.Width = btAdicionarItemPedido.Width + 24;
            btAdicionarItemPedido.Height = btAdicionarItemPedido.Height + 24;
            btAdicionarItemPedido.Left = btAdicionarItemPedido.Left - 12;
            btAdicionarItemPedido.Top = btAdicionarItemPedido.Top - 12;
        }

        private void btAdicionarItemPedido_MouseLeave(object sender, EventArgs e)
        {
            btAdicionarItemPedido.Width = 104;
            btAdicionarItemPedido.Height = 99;
            btAdicionarItemPedido.Left = 207;
            btAdicionarItemPedido.Top = 364;
        }

        private void icSenha_Click(object sender, EventArgs e)
        {
            SenhasPrincipal nova = new SenhasPrincipal();
            nova.Show();   
        }

        private void icConfig_Click(object sender, EventArgs e)
        {
            Configuracoes nova = new Configuracoes();
            nova.ShowDialog();
            int parametroSincronizarAntigo = nova.parametroSincronizacaoAntigo;
            int parametroSincronizarNovo = nova.parametroSincronizarNovo;
            if(parametroSincronizarAntigo == 0 && parametroSincronizarNovo == 1)
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
                String atual = DateTime.Now.ToString();
                String data = atual.Substring(0, 10);
                AcessoFB.limpaMonitorPedidosApp(data);
                limpaPedidosAntigosApp();
                criaListenerPedidosApp();
                criaListeneAndamentosApp();
            }
        }

        //##############FUNÇÕES-FIREBASE##################
        public List<Itens_Pedido_Firebase> recuperaItensPedidoFirebase(IFirebaseConfig config, IFirebaseClient client, String idPedido)
        {
            List<Itens_Pedido_Firebase> listaRecuperada = new List<Itens_Pedido_Firebase>();
            FirebaseResponse responseItens = client.Get(@"pedido-itens/" + idPedido);
            Dictionary<string, Itens_Pedido_Firebase> getItensPedido = JsonConvert.DeserializeObject<Dictionary<string, Itens_Pedido_Firebase>>(responseItens.Body.ToString());
            foreach (var itemPedido in getItensPedido)
            {
                Itens_Pedido_Firebase inserir = new Itens_Pedido_Firebase();
                inserir.adicionais_item = RemoverAcentos(itemPedido.Value.adicionais_item).Trim().ToUpper();
                inserir.desc_item = RemoverAcentos(itemPedido.Value.desc_item).Trim().ToUpper();
                inserir.grupo_item = itemPedido.Value.grupo_item;
                inserir.id_item = itemPedido.Value.id_item;
                inserir.id_pedido = RemoverAcentos(itemPedido.Value.id_pedido).Trim().ToUpper();
                inserir.obs_item = RemoverAcentos(itemPedido.Value.obs_item).Trim().ToUpper();
                inserir.qtd_item = itemPedido.Value.qtd_item;
                inserir.valor_item = itemPedido.Value.valor_item;

                listaRecuperada.Add(inserir);
            }
            return listaRecuperada;
        }

        private SoundPlayer soundPlayer;
        public MonitorAplicativo form = new MonitorAplicativo();
        public void inserePedidoNoBanco(PedidoFirebase pedidoNovo, List<Itens_Pedido_Firebase> listaItens)
        {
            //FORMATAMOS O CELULAR PARA PESQUISAR ESTE CLIENTE NO BANCO
            String celularFormatado = pedidoNovo.clt_celular.Replace("(", "");
            celularFormatado = celularFormatado.Replace(")", "");
            celularFormatado = celularFormatado.Remove(2, 1);
            celularFormatado = celularFormatado.Insert(2, " ");

            int idClientePedido = 0;
            String celularCliente = celularFormatado;
            if (pedidoNovo.tipo.Trim() == "ENTREGA")
            {
                int respostaBanco = AcessoFB.fb_pesquisaClientePorCelularNumeroCasoBairro(celularFormatado.Trim(), pedidoNovo.clt_numero.Trim(), pedidoNovo.clt_bairro.Trim().ToUpper());
                idClientePedido = respostaBanco;
                if (respostaBanco == -1)//CLIENTE NÃO EXISTE NO BANCO - INSERIMOS
                {
                    Clientes novo = new Clientes();
                    novo.Nome = RemoverAcentos(pedidoNovo.clt_nome.ToString());
                    novo.Nome.Replace("'", " ").Trim().ToUpper();
                    novo.Celular = celularFormatado.Trim();
                    novo.Rua = RemoverAcentos(pedidoNovo.clt_rua.ToString());
                    novo.Rua.Replace("'", " ").Trim().ToUpper();
                    novo.Numero = RemoverAcentos(pedidoNovo.clt_numero.ToString());
                    novo.Numero.Replace("'", " ").Trim().ToUpper();
                    novo.Bairro = RemoverAcentos(pedidoNovo.clt_bairro.ToString());
                    novo.Bairro.Replace("'", " ").Trim().ToUpper();
                    novo.Referencia = RemoverAcentos(pedidoNovo.clt_referencia.ToString());
                    novo.Referencia.Replace("'", " ").Trim().ToUpper();
                    novo.Id = AcessoFB.fb_verificaUltIdCliente() + 1;
                    idClientePedido = novo.Id;
                    AcessoFB.fb_adicionarCliente(novo);
                }
            }
            else
            {
                idClientePedido = 0;
            }

            Pedidos inserir = new Pedidos();
            inserir.Id = AcessoFB.fb_verificaUltIdPedido() + 1;
            String data = DateTime.Now.ToString();
            data = data.Substring(0, 10);
            inserir.Senha = AcessoFB.fb_verificaSenhaPedido(data) + 1;//consultar senha do dia.
            //1 - ENTREGA | 2 - RETIRADA | 3 - CONSUMIR NO LOCAL (somente vindo do app)
            if (pedidoNovo.tipo.Trim() == "ENTREGA")
            {
                inserir.Tipo = 1;
                inserir.Id_Cliente = idClientePedido;
            }   
            if (pedidoNovo.tipo.Trim() == "RETIRADA")
            {
                inserir.Tipo = 2;
                inserir.Id_Cliente = 0;
            }   
            if (pedidoNovo.tipo.Trim() == "CONSUMIR NO LOCAL")
            {
                inserir.Tipo = 3;
                inserir.Id_Cliente = 0;
            }

            inserir.Nome_Cliente = RemoverAcentos(pedidoNovo.clt_nome.Replace("'", " ")).Trim().ToUpper();
            inserir.Valor = Convert.ToDecimal(pedidoNovo.valor);
            inserir.Data = pedidoNovo.data;
            inserir.Observacao = RemoverAcentos(pedidoNovo.observacao.Replace("'", " ")).Trim().ToUpper();
            
            if (pedidoNovo.pagamento.Trim() == "DINHEIRO")
                inserir.Pagamento = 1;
            if (pedidoNovo.pagamento.Trim() == "CARTÃO")
                inserir.Pagamento = 2;
            if (pedidoNovo.pagamento.Trim() == "PIX")
                inserir.Pagamento = 3;

            inserir.Desconto = Convert.ToDecimal(pedidoNovo.desconto.Replace(".", ","));
            AcessoFB.fb_adicionaNovoPedido(inserir); //PEDIDO ADICIONADO

            //INSERIR ITENS DO PEDIDO
            AcessoFB.fb_inserirItensFirebaseNoPedido(listaItens, inserir.Id);
            //SE FOR ENTREGA, INSERIMOS NOVA ENTREGA PARA O MOTOBOY
            if (inserir.Tipo == 1)
            {
                Entregas novaEnt = new Entregas();
                novaEnt.Id = AcessoFB.fb_verificaUltIdEntrega() + 1;
                novaEnt.Pedido = inserir.Id;
                novaEnt.Senha = inserir.Senha;
                novaEnt.Cliente = RemoverAcentos(inserir.Nome_Cliente).Trim().ToUpper();
                novaEnt.Total = inserir.Valor;
                novaEnt.Data = inserir.Data.Substring(0,10);
                novaEnt.Pagamento = inserir.Pagamento;
                novaEnt.Lancamento = 0;
                Taxas taxaBanco = AcessoFB.fb_pesquisaTaxa(RemoverAcentos(pedidoNovo.clt_bairro).Trim().ToUpper());
                novaEnt.Taxa = Convert.ToDecimal(taxaBanco.Valor);
                novaEnt.Entregador = 0;
                //Verifica se o parametro para unico motoboy está ativo
                Parametros parametros = AcessoFB.fb_recuperaParametrosSistema();
                int parametroUnicoMotoboy = parametros.motoboy;
                if (parametroUnicoMotoboy == 1)
                {
                    int entregador = AcessoFB.fb_buscaIdUnicoMotoboy();
                    novaEnt.Entregador = entregador;
                }
                else
                {
                    novaEnt.Entregador = 0;
                }
                AcessoFB.fb_adicionaNovaEntrega(novaEnt);
            }
            //INSERIMOS O PEDIDO NO MONITOR
            PedidoMonitor novoPM = new PedidoMonitor();
            novoPM.Id = AcessoFB.fb_verificaUltIdMonitor() + 1;
            novoPM.Senha = inserir.Senha;
            novoPM.Identificador = pedidoNovo.id;
            novoPM.Nome = RemoverAcentos(inserir.Nome_Cliente).Trim().ToUpper();
            novoPM.Celular = RemoverAcentos(celularCliente).Trim().ToUpper();
            novoPM.Tipo = inserir.Tipo;
            novoPM.Valor = inserir.Valor;
            novoPM.Data = inserir.Data.Substring(0, 10);
            novoPM.Status = 0;
            AcessoFB.fb_adicionarPedidoMonitor(novoPM);
            //INSERIMOS NOVO LANCAMENTO
            Lancamentos novoLanc = new Lancamentos();
            novoLanc.Id = AcessoFB.fb_verificaUltIdLanc() + 1;
            novoLanc.Data = data;
            novoLanc.Valor = inserir.Valor;
            novoLanc.Pagamento = inserir.Pagamento;
            novoLanc.Tipo = inserir.Tipo;
            novoLanc.Pedido = inserir.Id;
            AcessoFB.fb_adicionarLanc(novoLanc);
            //ABRIMOS O MONITOR E IMPRIMIMOS O PEDIDO
            abrirTelaMonitorNovoPedido();
            //IMPRIMIMOS O PEDIDO
            insereDadosImpressao(inserir, idClientePedido, celularCliente);
            AcessoFB.fb_limpaTabelasImpressao();
        }

        public void abrirTelaMonitorNovoPedido()
        {
            if (soundPlayer == null)
            {
                soundPlayer = new SoundPlayer(@"C:\Program Files (x86)\SSoft\Sandra Foods\novo_pedido.wav");
            }
            soundPlayer.Play();
            FormCollection formsAbertos = Application.OpenForms;
            foreach (var frm in formsAbertos)
            {
                form = new MonitorAplicativo();
                if (Application.OpenForms[form.Name] == null)
                {
                    //TELA ESTÁ FECHADA - ABRIMOS ELA
                    form.Close();
                    MonitorAplicativo tela = new MonitorAplicativo();
                    this.Invoke((MethodInvoker)delegate () {
                        tela.Show();
                        Application.OpenForms[tela.Name].Focus();
                        Application.OpenForms[tela.Name].Activate();
                    });  
                    break;
                }
                else
                {
                    //TELA ESTÁ ABERTA
                    MonitorAplicativo nova = new MonitorAplicativo();
                    if(InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate () {
                            Application.OpenForms[nova.Name].Close();
                            nova.Show();
                            Application.OpenForms[nova.Name].Focus();
                            Application.OpenForms[nova.Name].Activate();
                        });
                    }
                    else
                    {
                        nova.carregaDataGridView();
                        Application.OpenForms[nova.Name].Close();
                        nova.Show();
                        Application.OpenForms[nova.Name].Focus();
                        Application.OpenForms[nova.Name].Activate();
                    }
                    break;
                }
            }
        }
        public void insereDadosImpressao(Pedidos inserir, int idClientePedido, String celularCliente)
        {
            Clientes clientePedido = AcessoFB.fb_pesquisaClientePorId(idClientePedido);
            int id_pedido = inserir.Id;
            int senha = inserir.Senha;
            String atual = inserir.Data;
            String data = atual.Substring(0, 10);
            String hora = atual.Substring(11, 8);
            String cliente = RemoverAcentos(inserir.Nome_Cliente.Replace("'", " ")).Trim().ToUpper();
            if (cliente.Length > 30)
                cliente = cliente.Remove(30);
            String celular, rua, numero, bairro, referencia, taxa;
            if (idClientePedido == 0)
            {
                celular = celularCliente;
                rua = "-";
                numero = "-";
                bairro = "-";
                referencia = "-";
                taxa = "-";
            }
            else
            {
                celular = celularCliente;
                rua = RemoverAcentos(clientePedido.Rua.Trim()).ToUpper();
                if (rua.Length > 50)
                    rua = rua.Remove(50);
                numero = RemoverAcentos(clientePedido.Numero.Trim()).ToUpper();
                bairro = RemoverAcentos(clientePedido.Bairro.Trim().ToUpper());
                referencia = RemoverAcentos(clientePedido.Referencia.Trim()).ToUpper();
                if (referencia.Length > 100)
                    referencia = referencia.Remove(100);
                Taxas taxaBanco = AcessoFB.fb_pesquisaTaxa(RemoverAcentos(clientePedido.Bairro).ToUpper().Trim());
                Decimal valorTaxa = taxaBanco.Valor;
                taxa = valorTaxa.ToString("C", CultureInfo.CurrentCulture);
            }
            String total = inserir.Valor.ToString("C", CultureInfo.CurrentCulture);
            String obs = RemoverAcentos(inserir.Observacao.Trim()).ToUpper();
            if (obs.Length > 100)
                obs = obs.Remove(100);
            String pagamento = "";
            if (inserir.Pagamento == 0)
            {
                pagamento = "DINHEIRO";
            }
            if (inserir.Pagamento == 1)
            {
                pagamento = "CARTAO";
            }
            if (inserir.Pagamento == 2)
            {
                pagamento = "PIX";
            }
            String desc = inserir.Desconto.ToString("C", CultureInfo.CurrentCulture); ;

            AcessoFB.insereDadosImpressao(senha, data, hora, cliente, celular, rua, numero, bairro, referencia, taxa, total, obs, desc, pagamento);
            AcessoFB.insereItensFirebaseImpressao(inserir.Id);

            if (inserir.Tipo == 1)
            {
                imprimirPedidoEntrega();
            }
            if (inserir.Tipo == 2 || inserir.Tipo == 3)
            {
                imprimirPedidoBalcao();
            }
        }
        public void imprimirPedidoBalcao()
        {
            ImpressaoBalcao nova = new ImpressaoBalcao();
            nova.ShowDialog();
        }
        public void imprimirPedidoEntrega()
        {
            ImpressaoEntrega nova = new ImpressaoEntrega();
            nova.ShowDialog();

            AcessoFB.fb_limpaTabelasImpressao();
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
    }
}
