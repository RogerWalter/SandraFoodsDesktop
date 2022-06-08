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
    public partial class Pedido : Form
    {
        public Pedido()
        {
            InitializeComponent();
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

        int parametroExistePedidoSendoFeito = 0; //USADO PARA VERIFICAR SE UM PEDIDO ESTÁ SENDO FEITO OU NÃO, PARA QUE A ALTERAÇÃO DE ENTREGA PARA BALCÃO POSSA OCORRER
        int idClienteNoPedido = 0; //É USADO PARA MANTER O PEDIDO, MESMO SE TROCARMOS DE BALCÃO PARA ENTREGA, OU VICE E VERSA
        int codClienteSelecionadoDialogo = 0; //codigo retornado pelo dialogo para mais de um endereço
        public void recebeCodCliente(int codClie)
        {
            if(codClie == 0)
            {
                MessageBox.Show("Seleção cancelada", "Erro");
                return;
            }
            Clientes buscado = AcessoFB.fb_pesquisaClientePorId(codClie);
            preencheTB(buscado);
            idClienteNoPedido = codClie;
            parametroExistePedidoSendoFeito = 1;
            idClienteMemoria = buscado.Id;
        }

        public void recebeCodPreencheCampo(int codClie)
        {
            if (codClie == 0)
            {
                return;
            }
            Clientes buscado = AcessoFB.fb_pesquisaClientePorId(codClie);
            preencheTB(buscado);
            idClienteNoPedido = codClie;
            parametroExistePedidoSendoFeito = 1;
            idClienteMemoria = buscado.Id;
        }

        public void recebeValorConsulta(int nPed)
        {
            if (nPed == 0)
            {
                limpaCampos();
                desmarcaRB();
                desabilitaGroupBox();
                btAdd.Enabled = true;
                btPesquisar.Enabled = true;
                labelCliente.Text = "Celular";
                btConsultaCliente.Enabled = true;
            }
            else
            {
                Pedidos busca = new Pedidos();

                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10);

                busca = AcessoFB.fb_pesquisaPedido(Convert.ToInt32(nPed), data);
                if (busca.Id == -1)
                {
                    MessageBox.Show("Não foi possível localizar o pedido \nNenhum pedido foi selecionado.", "Não encontrado");
                    return;
                }
                else
                {
                    tbCodigo.Text = busca.Id.ToString();
                    idClienteNoPedido = busca.Id_Cliente;
                    if(busca.Id_Cliente == 0)
                    {
                        habilitaBotoes();
                        labelCliente.Text = "Cliente:";
                        tbCliente.Enabled = false;
                        groupBox1.Enabled = true;
                        tbCliente.Text = busca.Nome_Cliente;
                        tbCelular.Text = "-";
                        tbRua.Text = "-";
                        tbNum.Text = "-";
                        tbBairro.Text = "-";
                        tbReferencia.Text = "-";
                        tbTaxa.Text = "R$0.00";
                    }
                    else
                    {
                        tbClienteEnterPressionado();
                        Clientes buscado = new Clientes();
                        buscado = AcessoFB.fb_pesquisaClientePorId(busca.Id_Cliente);
                        preencheTB(buscado);
                        String buscar = buscado.Bairro;
                        Taxas buscador = new Taxas();
                        buscador = AcessoFB.fb_pesquisaTaxa(buscar);
                        preencheTaxa(buscador);
                    }

                    tbTotal.Text = busca.Valor.ToString("C", CultureInfo.CurrentCulture);

                    if (busca.Pagamento == 1)
                    {
                        rbDin.Checked = true;
                        
                    }
                    if (busca.Pagamento == 2)
                    {
                        rbCart.Checked = true;

                    }
                    if (busca.Pagamento == 3)
                    {
                        rbPix.Checked = true;

                    }

                    if (busca.Tipo == 1)
                    {
                        rbEnt.Checked = true;
                        tipoPedido = 1;
                    }
                    if (busca.Tipo == 2)
                    {
                        rbBalc.Checked = true;
                        tipoPedido = 2;
                    }
                    
                    tbObs.Text = busca.Observacao.Trim(); 
                    RecarregaDadosConsulta(busca.Id);
                    btPesquisar.Enabled = false;
                }
                
                tbNum.Enabled = false;
                tbCliente.Enabled = false;
                tbRua.Enabled = false;
                tbBairro.Enabled = false;
                tbCelular.Enabled = false;
                tbReferencia.Enabled = false;
                tbCodigo.Enabled = false;
                tbTaxa.Enabled = false;
                tbObs.Enabled = true;

                rbCart.Enabled = true;
                rbDin.Enabled = true;

                btAddItem.Enabled = true;
                btRemItem.Enabled = true;
                btCancelar.Enabled = true;
                btConfirmar.Enabled = true;
                tbDesconto.Enabled = true;

                idTbCodigo = Convert.ToInt32(tbCodigo.Text);
            }
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

        public void RecarregaDados( int id)
        {
            dataGridView1.DataSource = null;

            BindingSource bindingSource1 = new BindingSource();
            DataTable itensPedido = new DataTable("Itens_Pedido");
            DataSet dsFinal = new DataSet();
            itensPedido = AcessoFB.fb_buscaItensPedidoTemp(id);
            dsFinal.Tables.Add(itensPedido);
            bindingSource1.DataSource = itensPedido;
            dataGridView1.DataSource = bindingSource1;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void RecarregaDadosConsulta(int id)
        {
            dataGridView1.DataSource = null;

            BindingSource bindingSource1 = new BindingSource();
            DataTable itensPedido = new DataTable("Itens_Pedido");
            DataSet dsFinal = new DataSet();
            AcessoFB.fb_buscaItensPedido(id);
            AcessoFB.fb_buscaItensPedAtualizar(id);
            itensPedido = AcessoFB.fb_buscaItensPedidoTemp(id);
            dsFinal.Tables.Add(itensPedido);
            bindingSource1.DataSource = itensPedido;
            dataGridView1.DataSource = bindingSource1;

        }

        //int contPedAberto = 0;

        private void Pedido_Load(object sender, EventArgs e)
        {
            //contPedAberto = 0;
            rbEnt.Checked = false;
            rbBalc.Checked = false;
            //AcessoFB.fb_limparItemPedidoTemp();
            groupBox1.Enabled = false;
            btAdd.Enabled = true;
            btPesquisar.Enabled = true;
            tbTotal.Enabled = false;

            rbDin.Checked = true;

            this.KeyDown += new KeyEventHandler(Pedido_KeyDown);

            int parametroErroAtual = AcessoFB.fb_recuperaTabelaErro();
            int novoParametro = parametroErroAtual + 1;
            AcessoFB.fb_atualizaTabelaErro(novoParametro);
        }

        public void habilitaBotoes()
        {
            btCancelar.Enabled = true;
            
            btConfirmar.Enabled = true;
        }

        int idPedEditando = 0;

        public Pedidos pedidoEmAndamento = new Pedidos();

        public void novoPedido()
        {
            limpaCampos();
            desmarcaRB();
            btAdd.Enabled = false;
            btPesquisar.Enabled = false;
            btConsultaCliente.Enabled = true;
            rbDin.Enabled = true;
            rbCart.Enabled = true;
            rbDin.Checked = true;

            Pedidos novo = new Pedidos();

            if(parametroExistePedidoSendoFeito == 0)
            {
                idPedEditando = AcessoFB.fb_verificaUltIdPedidoEditando();
                if (idPedEditando == -1)
                {
                    int inserirID = AcessoFB.fb_verificaUltIdPedido() + 1;
                    AcessoFB.fb_inserPedidoEditando(inserirID);
                    novo.Id = inserirID;
                }
                if (idPedEditando == 0)
                {
                    int atualizarID = AcessoFB.fb_verificaUltIdPedido() + 1;
                    AcessoFB.fb_atualizaPedidoEditando(atualizarID);
                    novo.Id = atualizarID;
                }
                else
                {
                    novo.Id = idPedEditando + 1;
                    AcessoFB.fb_atualizaPedidoEditando(novo.Id);
                }
            }
            else
            {
                novo.Id = Convert.ToInt32(tbCodigo.Text);
            }
            tbCodigo.Text = novo.Id.ToString();
            idExcluirPedTemp = Convert.ToInt32(tbCodigo.Text);
            tbCodigo.Enabled = false;
            groupBox1.Enabled = true;
            habilitaBotoes();
            if(parametroExistePedidoSendoFeito == 0 || idClienteNoPedido == 0)
            {
                tbCliente.Enabled = true;
                tbCliente.Select();
                tbCliente.Focus();
                tbObs.Enabled = true;
            }
            else
            {
                if(tipoPedido == 1)
                {
                    recebeCodPreencheCampo(idClienteNoPedido);
                    if (idClienteNoPedido != 0)
                    {
                        Clientes buscado = AcessoFB.fb_pesquisaClientePorId(idClienteNoPedido);
                        verificaTaxa(buscado.Bairro);
                    }
                    tbCliente.Enabled = false;
                    tbCliente.Select();
                    tbCliente.Focus();
                    tbObs.Enabled = true;
                }
                else
                {
                    if(idClienteNoPedido != 0)
                    {
                        Clientes buscado = AcessoFB.fb_pesquisaClientePorId(idClienteNoPedido);
                        tbCliente.Text = buscado.Nome.Trim();
                    }
                    else
                        tbCliente.Text = "";
                    tbCelular.Text = "-";
                    tbRua.Text = "-";
                    tbNum.Text = "-";
                    tbBairro.Text = "-";
                    tbReferencia.Text = "-";
                    tbTaxa.Text = "R$0.00";
                }
            }
            idTbCodigo = Convert.ToInt32(tbCodigo.Text);
        }

        public void tipoPedidoEntrega()
        {
            //AcessoFB.fb_limparItemPedidoTemp();
            limpaCampos();
            desmarcaRB();
            btAdd.Enabled = false;
            btPesquisar.Enabled = false;
            if(parametroExistePedidoSendoFeito == 0)
            {
                btConsultaCliente.Enabled = true;
                rbDin.Enabled = true;
                rbCart.Enabled = true;
                rbDin.Checked = true;
                Pedidos novo = new Pedidos();

                idPedEditando = AcessoFB.fb_verificaUltIdPedidoEditando();
                if (idPedEditando == -1)
                {
                    int inserirID = AcessoFB.fb_verificaUltIdPedido() + 1;
                    AcessoFB.fb_inserPedidoEditando(inserirID);
                    novo.Id = inserirID;
                }
                if (idPedEditando == 0)
                {
                    int atualizarID = AcessoFB.fb_verificaUltIdPedido() + 1;
                    AcessoFB.fb_atualizaPedidoEditando(atualizarID);
                    novo.Id = atualizarID;
                }
                else
                {
                    novo.Id = idPedEditando + 1;
                    AcessoFB.fb_atualizaPedidoEditando(novo.Id);
                }
                tbCodigo.Text = novo.Id.ToString();
                idExcluirPedTemp = Convert.ToInt32(tbCodigo.Text);
                tbCodigo.Enabled = false;
                groupBox1.Enabled = true;
                habilitaBotoes();
                tbCliente.Enabled = true;
                tbCliente.Select();
                tbCliente.Focus();
                tbObs.Enabled = true;

                idTbCodigo = Convert.ToInt32(tbCodigo.Text);
            }
            else
            {
                if(idClienteNoPedido != 0)
                {
                    tbCliente.Text = idClienteNoPedido.ToString();
                    recebeCodCliente(idClienteNoPedido);
                    btConsultaCliente.Enabled = true;
                    rbDin.Enabled = true;
                    rbCart.Enabled = true;
                    rbDin.Checked = true;
                    Pedidos novo = new Pedidos();

                }
                else
                {
                    btConsultaCliente.Enabled = true;
                    rbDin.Enabled = true;
                    rbCart.Enabled = true;
                    rbDin.Checked = true;
                    Pedidos novo = new Pedidos();

                    idPedEditando = AcessoFB.fb_verificaUltIdPedidoEditando();
                    if (idPedEditando == -1)
                    {
                        int inserirID = AcessoFB.fb_verificaUltIdPedido() + 1;
                        AcessoFB.fb_inserPedidoEditando(inserirID);
                        novo.Id = inserirID;
                    }
                    if (idPedEditando == 0)
                    {
                        int atualizarID = AcessoFB.fb_verificaUltIdPedido() + 1;
                        AcessoFB.fb_atualizaPedidoEditando(atualizarID);
                        novo.Id = atualizarID;
                    }
                    else
                    {
                        novo.Id = idPedEditando + 1;
                        AcessoFB.fb_atualizaPedidoEditando(novo.Id);
                    }
                    tbCodigo.Text = novo.Id.ToString();
                    idExcluirPedTemp = Convert.ToInt32(tbCodigo.Text);
                    tbCodigo.Enabled = false;
                    groupBox1.Enabled = true;
                    habilitaBotoes();
                    tbCliente.Enabled = true;
                    tbCliente.Select();
                    tbCliente.Focus();
                    tbObs.Enabled = true;

                    idTbCodigo = Convert.ToInt32(tbCodigo.Text);
                }
            }
        }

        public void tipoPedidoBalcao()
        {
            //AcessoFB.fb_limparItemPedidoTemp();
            limpaCampos();
            desmarcaRB();
            btAdd.Enabled = true;
            btPesquisar.Enabled = false;
            btConsultaCliente.Enabled = false;
            rbDin.Enabled = true;
            rbCart.Enabled = true;
            rbDin.Checked = true;
            Pedidos novo = new Pedidos();
            //novo.Id = AcessoFB.fb_verificaUltIdPedido() + 1;

            //valida qual pedido está sendo editado
            idPedEditando = AcessoFB.fb_verificaUltIdPedidoEditando();
            if (idPedEditando == -1)
            {
                int inserirID = AcessoFB.fb_verificaUltIdPedido() + 1;
                AcessoFB.fb_inserPedidoEditando(inserirID);
                novo.Id = inserirID;
            }
            if (idPedEditando == 0)
            {
                int atualizarID = AcessoFB.fb_verificaUltIdPedido() + 1;
                AcessoFB.fb_atualizaPedidoEditando(atualizarID);
                novo.Id = atualizarID;
            }
            else
            {
                novo.Id = idPedEditando + 1;
                AcessoFB.fb_atualizaPedidoEditando(novo.Id);
            }

            tbCodigo.Text = novo.Id.ToString();
            idExcluirPedTemp = Convert.ToInt32(tbCodigo.Text);
            tbCodigo.Enabled = false;
            groupBox1.Enabled = true;
            habilitaBotoes();
            tbCliente.Enabled = true;
            tbCliente.Select();
            tbCliente.Focus();
            tbObs.Enabled = true;

            tbCelular.Text = "-";
            tbRua.Text = "-";
            tbNum.Text = "-";
            tbBairro.Text = "-";
            tbReferencia.Text = "-";
            tbTaxa.Text = "R$0.00";

            idTbCodigo = Convert.ToInt32(tbCodigo.Text);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            ultbotPress = 1;
            btAdd.Enabled = false;
            btPesquisar.Enabled = false;
            rbEnt.Checked = false;
            rbBalc.Checked = false;
            rbBalc.Enabled = true;
            rbEnt.Enabled = true;
        }

        public void preencheTB(Clientes buscado)
        {
            habilitaBotoes();
            labelCliente.Text = "Cliente";
            tbCliente.Enabled = false;
            groupBox1.Enabled = true;
            tbCliente.Text = buscado.Nome.Trim();
            tbCelular.Text = buscado.Celular.Trim();
            tbRua.Text = buscado.Rua.Trim();
            tbNum.Text = buscado.Numero;
            tbBairro.Text = buscado.Bairro.Trim();
            tbReferencia.Text = buscado.Referencia.Trim();
            verificaTaxa(buscado.Bairro);
        }

        public Decimal valorTaxa = 0;
        public void preencheTaxa(Taxas buscado)
        {
            valorTaxa = buscado.Valor;
            tbTaxa.Text = buscado.Valor.ToString("C", CultureInfo.CurrentCulture);
        }

        public int verificaTaxa(String bairro)
        {
            String buscar;
            buscar = bairro;

            Taxas buscado = new Taxas();
            buscado = AcessoFB.fb_pesquisaTaxa(buscar);
            if (buscado.Local == "VAZIO")
            {
                MessageBox.Show("Não foi possível localizar a taxa \nVerifique se existe taxa cadastrada para este bairro e tente novamente.", "Não encontrada");
                return 1;
            }
            else
            {
                preencheTaxa(buscado);
                tbTotal.Text = buscado.Valor.ToString("C", CultureInfo.CurrentCulture);
                return 2;
            }
        }

        public void limpaCampos()
        {
            if(parametroExistePedidoSendoFeito == 0)
                tbCodigo.Text = "";
            if(idClienteNoPedido == 0)
                tbCliente.Text = "";
            tbCelular.Text = "";
            tbRua.Text = "";
            tbNum.Text = "";
            tbBairro.Text = "";
            tbReferencia.Text = "";
            tbTaxa.Text = "";
            tbObs.Text = "";
            tbTotal.Text = "";

            if(parametroExistePedidoSendoFeito == 0)
                dataGridView1.DataSource = null;
        }
        private void tbCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbClienteEnterPressionado();
            }
            if (e.KeyCode == Keys.F2)
            {
                btConsultaCliente_Click(sender, e);
            }
        }

        public void tbClienteEnterPressionado()
        {
            parametroTbCliente = 1;
            if (tipoPedido == 1)
            {
                Clientes buscado = new Clientes();

                String numeroCelular = tbCliente.Text.ToString();

                if (numeroCelular.Contains("-") || numeroCelular.Length > 7)
                {
                    int qtdCadastros = AcessoFB.fb_contaQtdCadastrosCliente(numeroCelular);
                    if (qtdCadastros > 1)
                    {
                        //MAIS DE UM CADASTRO PARA ESTE CELULAR
                        SelecionarClienteParaPedido escolher = new SelecionarClienteParaPedido();
                        escolher.recebeCelularCliente(numeroCelular);
                        escolher.ShowDialog();
                        recebeCodCliente(escolher.enviaCodCliente());
                        return;
                    }
                    buscado = AcessoFB.fb_pesquisaClientePorCelular(numeroCelular.ToString());
                    if (buscado.Nome == "VAZIO")
                    {
                        Pedido_Add_Cliente nova = new Pedido_Add_Cliente();
                        if (nova.ShowDialog() == DialogResult.OK)
                        {
                            Cliente addCli = new Cliente();
                            addCli.recebeParametro(1);
                            addCli.recebeNovoCel(numeroCelular.ToString());
                            addCli.ShowDialog();
                            tbClienteEnterPressionado();
                        }
                        else
                        {
                            return;
                        }
                        //MessageBox.Show("Não foi possível localizar o cliente \nVerifique se informou o nome corretamente.", "Não encontrado");
                        //return;
                    }
                    else
                    {
                        if (verificaTaxa(buscado.Bairro) == 1)
                        {
                            limpaCampos();
                        }
                        else
                        {
                            String mensagemTotal = "Temos o seguinte endereço cadastrado para este celular:\r\n" + buscado.Rua + "\r\nNº " + buscado.Numero + "\r\nBAIRRO " + buscado.Bairro + "\r\n" + buscado.Referencia + "\r\nDevemos entregar neste endereço?";
                            Clipboard.SetText(mensagemTotal.ToString().Trim());

                            preencheTB(buscado);
                            idClienteMemoria = buscado.Id;
                            idClienteNoPedido = buscado.Id;
                            parametroExistePedidoSendoFeito = 1;
                        }

                    }
                }
                else
                {
                    int codigoCliente = 0;
                    try
                    {
                        codigoCliente = Convert.ToInt32(numeroCelular);
                    }
                    catch (Exception r)
                    {
                        MessageBox.Show("Informe o código ou o celular do cliente.\nSe não souber o código, utilize a lupa ao lado do campo para localizar o cliente", "Alerta");
                        return;
                    }
                    //int codigoCliente = Convert.ToInt32(numeroCelular);
                    buscado = AcessoFB.fb_pesquisaClientePorId(codigoCliente);
                    if (buscado.Nome == "VAZIO")
                    {
                        MessageBox.Show("Não foi possível localizar o cliente. \nInforme um numero de telefone para cadastrá-lo", "Não encontrado");
                        return;
                    }
                    else
                    {
                        if (verificaTaxa(buscado.Bairro) == 1)
                        {
                            limpaCampos();
                        }
                        else
                        {
                            preencheTB(buscado);
                            idClienteMemoria = buscado.Id;
                            idClienteNoPedido = buscado.Id;
                            parametroExistePedidoSendoFeito = 1;
                            String mensagemTotal = "Temos o seguinte endereço cadastrado para este celular:\r\n" + buscado.Rua + "\r\nNº " + buscado.Numero + "\r\nBAIRRO " + buscado.Bairro + "\r\n" + buscado.Referencia + "\r\nDevemos entregar neste endereço?";
                            Clipboard.SetText(mensagemTotal.ToString().Trim());
                        }
                    }
                }
            }
            if (tipoPedido == 2)
            {
                try
                {
                    int codigoCliente = Convert.ToInt32(tbCliente.Text.ToString().Trim());
                    if (codigoCliente > 0)
                    {
                        Clientes buscado = AcessoFB.fb_pesquisaClientePorId(codigoCliente);
                        if (buscado.Nome == "VAZIO")
                            tbCliente.Text = "";
                        else
                        {
                            tbCliente.Text = buscado.Nome.Trim();
                            idClienteNoPedido = buscado.Id;
                            parametroExistePedidoSendoFeito = 1;
                        }
                        tbTotal.Text = tbTaxa.Text;
                        habilitaBotoes();
                        tbCelular.Text = "-";
                        tbRua.Text = "-";
                        tbNum.Text = "-";
                        tbBairro.Text = "-";
                        tbReferencia.Text = "-";
                        tbTaxa.Text = "R$0.00";
                        btAddItem.Select();
                        btAddItem.Focus();
                    }
                }
                catch
                {
                    idClienteNoPedido = 0;
                    tbTotal.Text = tbTaxa.Text;
                    habilitaBotoes();
                    tbCelular.Text = "-";
                    tbRua.Text = "-";
                    tbNum.Text = "-";
                    tbBairro.Text = "-";
                    tbReferencia.Text = "-";
                    tbTaxa.Text = "R$0.00";
                    btAddItem.Select();
                    btAddItem.Focus();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(tbCliente.Text == "")
            {
                MessageBox.Show("Cliente não informado!", "Alerta");
                tbCliente.Focus();
                tbCliente.Select();
                return;
            }
            else
            {
                if(ultbotPress == 1)
                {
                    Adicionar nova = new Adicionar();
                    nova.RecebeNumPedido(Convert.ToInt32(tbCodigo.Text));
                    nova.ShowDialog();
                    RecarregaDados(Convert.ToInt32(tbCodigo.Text));
                    RecalculaTotal();
                }
                else
                {
                    Adicionar nova = new Adicionar();
                    nova.RecebeNumPedido(Convert.ToInt32(tbCodigo.Text));
                    nova.ShowDialog();
                    RecarregaDados(Convert.ToInt32(tbCodigo.Text));
                    RecalculaTotal();
                }
            }
            
        }

        int idExcluir = 1;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idExcluir = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                //MessageBox.Show("Não é ordenar a coluna por nome. Altere o tipo de pesquisa!", "Erro");
            }

        }

        private void tbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        public void desabilitaTB()
        {
            tbNum.Enabled = false;
            tbCliente.Enabled = false;
            tbRua.Enabled = false;
            tbBairro.Enabled = false;
            tbCelular.Enabled = false;
            tbReferencia.Enabled = false;
            tbCodigo.Enabled = false;
            tbTaxa.Enabled = false;
            tbObs.Enabled = false;
            rbCart.Enabled = false;
            rbDin.Enabled = false;
        }

        private void tbPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.Enter)
            {
                Pedidos busca = new Pedidos();
                busca = AcessoFB.fb_pesquisaPedido(Convert.ToInt32(tbPesquisa.Text));
                if (busca.Id == -1)
                {
                    MessageBox.Show("Não foi possível localizar o pedido \nVerifique se informou o código corretamente.", "Não encontrado");
                    return;
                }
                else
                {


                    Clientes buscado = new Clientes();
                    buscado = AcessoFB.fb_pesquisaClientePorId(busca.Id_Cliente);
                    preencheTB(buscado);
                    String buscar = buscado.Bairro;
                    Taxas buscador = new Taxas();
                    buscador = AcessoFB.fb_pesquisaTaxa(buscar);
                    preencheTaxa(buscador);
                    tbTotal.Text = busca.Valor.ToString("C", CultureInfo.CurrentCulture);
                    if(busca.Pagamento == 1)
                    {
                        rbDin.Checked = true;
                        rbCart.Checked = false;
                    }
                    if (busca.Pagamento == 2)
                    {
                        rbCart.Checked = true;
                        rbDin.Checked = false;
                    }

                }

                desabilitaTB();
                btCancelar.Enabled = true;
                btExcluir.Enabled = true;
                
            }*/
        }

        int ultbotPress = 0;
        int idClienteMemoria = 0;
        private void btPesquisar_Click(object sender, EventArgs e)
        {
            ultbotPress = 2;
            ConsultarPedido nova = new ConsultarPedido();
            nova.ShowDialog();
            recebeValorConsulta(nova.enviaCodPed());
        }
        int idExcluirPedTemp = 0;
        int idTbCodigo = 0;
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if(parametroTbCliente == 0)
            {
                tbClienteEnterPressionado();
            }

            idTbCodigo = Convert.ToInt32(tbCodigo.Text);
            int idParaImpressao = 0;

            String testarA = tbTotal.Text.ToString();
            Decimal novoTotalA = 0;

            Decimal taxaA;
            String restoA;
            int tamanhoA = 0;
            tamanhoA = tbTaxa.Text.Length;
            restoA = tbTaxa.Text.Substring(2, tamanhoA - 2);
            taxaA = Convert.ToDecimal(restoA);

            Decimal descontoA;
            String restoDescA;
            int tamA = 0;
            if (tbDesconto.Text == "")
            {
                descontoA = 0;
            }
            else
            {
                if (tbDesconto.Text.Contains("R$"))
                {
                    tamA = tbDesconto.Text.Length;
                    restoDescA = tbDesconto.Text.Substring(2, tamA - 2);
                    descontoA = Convert.ToDecimal(restoDescA);
                }
                else
                {
                    descontoA = Convert.ToDecimal(tbDesconto.Text);
                }
            }


            Decimal totalItensA = AcessoFB.fb_totalizaItensNoPedido(Convert.ToInt32(tbCodigo.Text));
            novoTotalA = (taxaA + totalItensA) - descontoA;
            if (novoTotalA < 0)
            {
                MessageBox.Show("Não é possível inserir um desconto maior do que o total do pedido", "Erro");
                tbDesconto.Text = "";
                tbDesconto.Select();
                tbDesconto.Focus();
                return;
            }
            else
            {
                tbTotal.Text = novoTotalA.ToString("C", CultureInfo.CurrentCulture);
            }
            

            if (ultbotPress == 1) // insere pedido
            {
                if(tbCliente.Text.Trim() == "" )
                {
                    MessageBox.Show("Não foi informado um cliente", "Erro");
                    return;
                }
                else
                {
                    if (metPag == -1)
                    {
                        MessageBox.Show("Não foi informado um método de pagamento.", "Erro");
                        return;
                    }
                    else
                    {
                        if (AcessoFB.fb_verificaUltIdItemPedidoTemp(Convert.ToInt32(tbCodigo.Text)) == 0)
                        {
                            MessageBox.Show("Não é possivel inserir um pedido sem itens", "Erro");
                            return;
                        }
                        else
                        {
                            RecalculaTotal();
                            Pedidos novo = new Pedidos();
                            novo.Id = AcessoFB.fb_verificaUltIdPedido() + 1;

                            //verificar senha do pedido

                            String data = DateTime.Now.ToString();
                            data = data.Substring(0, 10);
                            novo.Senha = AcessoFB.fb_verificaSenhaPedido(data) + 1;//consultar senha do dia.

                            if (tipoPedido == 1)
                            {
                                novo.Id_Cliente = idClienteMemoria;
                            }
                            if (tipoPedido == 2)
                            {
                                novo.Id_Cliente = 0;
                            }

                            Decimal total;
                            String resto;
                            int tamanho = 0;
                            tamanho = tbTotal.Text.Length;
                            resto = tbTotal.Text.Substring(2, tamanho - 2);
                            total = Convert.ToDecimal(resto);
                            novo.Tipo = tipoPedido;
                            novo.Valor = total;
                            novo.Data = DateTime.Now.ToString();
                            novo.Observacao = RemoverAcentos(tbObs.Text.ToString());
                            novo.Observacao.Replace("'", " ");
                            novo.Pagamento = metPag;
                            novo.Nome_Cliente = RemoverAcentos(tbCliente.Text);

                            if (tbDesconto.Text == "")
                            {
                                novo.Desconto = 0;
                            }
                            else
                            {
                                if (tbDesconto.Text.Contains("R$"))
                                {
                                    Decimal desconto;
                                    String resto1;
                                    int tamanho1 = 0;
                                    tamanho1 = tbDesconto.Text.Length;
                                    resto1 = tbDesconto.Text.Substring(2, tamanho1 - 2);
                                    desconto = Convert.ToDecimal(resto1);
                                    novo.Desconto = desconto;
                                }
                                else
                                {
                                    novo.Desconto = Convert.ToDecimal(tbDesconto.Text);
                                }
                            }
                            AcessoFB.fb_adicionaNovoPedido(novo);

                            //ADICIONAMOS UM NOVO LANCAMENTO PARA OS RELATORIOS
                            Lancamentos novoLanc = new Lancamentos();
                            novoLanc.Id = AcessoFB.fb_verificaUltIdLanc() + 1;
                            novoLanc.Data = data;
                            novoLanc.Valor = novo.Valor;
                            novoLanc.Pagamento = novo.Pagamento;
                            novoLanc.Tipo = novo.Tipo;
                            novoLanc.Pedido = novo.Id;
                            AcessoFB.fb_adicionarLanc(novoLanc);
                            //AcessoFB.fb_adicionaItemPedido(novo.Id);

                            int verificaUltimoIdPedido = novo.Id;
                            int verificaIdPedidoItemTemp = Convert.ToInt32(tbCodigo.Text);

                            if (verificaUltimoIdPedido != verificaIdPedidoItemTemp)
                            {
                                //update id_pedido do item_temp para o id certo do pedido
                                AcessoFB.fb_atualizaItemTempPedidoEditando(verificaIdPedidoItemTemp, verificaUltimoIdPedido);
                                idParaImpressao = verificaUltimoIdPedido;
                                AcessoFB.fb_adicionaItemPedido(verificaUltimoIdPedido);
                                // AcessoFB.fb_limparItemPedidoTemp(verificaUltimoIdPedido);
                            }
                            else
                            {
                                AcessoFB.fb_adicionaItemPedido(Convert.ToInt32(tbCodigo.Text));
                                idParaImpressao = Convert.ToInt32(tbCodigo.Text);
                                //AcessoFB.fb_limparItemPedidoTemp(idExcluirPedTemp);
                            }

                            if (novo.Tipo == 1)
                            {
                                Entregas novaEnt = new Entregas();
                                novaEnt.Id = AcessoFB.fb_verificaUltIdEntrega() + 1;
                                novaEnt.Pedido = novo.Id;
                                novaEnt.Senha = novo.Senha;
                                novaEnt.Cliente = tbCliente.Text.ToString();
                                /*if (metPag == 0)
                                    novaEnt.Cliente = "DINHEIRO";
                                if (metPag == 1)
                                    novaEnt.Cliente = "CARTAO";
                                if (metPag == 2)
                                    novaEnt.Cliente = "PIX";*/
                                novaEnt.Total = total;
                                novaEnt.Data = data;
                                novaEnt.Pagamento = metPag;
                                novaEnt.Lancamento = 0;

                                Decimal taxa;
                                String restoTaxa;
                                int tamanhoTaxa = 0;
                                tamanhoTaxa = tbTaxa.Text.Length;
                                restoTaxa = tbTaxa.Text.Substring(2, tamanhoTaxa - 2);
                                taxa = Convert.ToDecimal(restoTaxa);

                                novaEnt.Taxa = taxa;

                                novaEnt.Entregador = 0;
                                //Verifica se o parametro para unico motoboy está ativo
                                Parametros parametros = AcessoFB.fb_recuperaParametrosSistema();
                                int parametroUnicoMotoboy = parametros.motoboy;
                                if(parametroUnicoMotoboy == 1)
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

                            if (cbImprimeOuNao.Checked == false)
                            {
                                insereDadosImpressao(novo.Senha, idParaImpressao);
                            }
                            AcessoFB.fb_limpaTabelasImpressao();
                            AcessoFB.fb_limparItemPedidoTemp(novo.Id);

                            //GERAR MENSAGEM NA AREA DE TRANSFERÊNCIA PARA ENVIAR AO CLIENTE
                            if(novo.Tipo == 1)
                            {
                                String valorPedido = tbTotal.Text;
                                Parametros prazo = AcessoFB.fb_recuperaParametrosSistema();
                                String prazoEntrega = prazo.entrega.ToString();
                                String mensagemTotal = "O valor total de seu pedido é de *" + valorPedido + "*.\r\nA entrega será realizada em no máximo *" + prazoEntrega + " minutos*.\r\nMuito obrigada e uma excelente noite!!!";
                                Clipboard.SetText(mensagemTotal.ToString().Trim());
                            }

                            if (novo.Tipo == 2)
                            {
                                String valorPedido = tbTotal.Text;
                                Parametros prazo = AcessoFB.fb_recuperaParametrosSistema();
                                String prazoRetirada = prazo.retirada.ToString();
                                String mensagemTotal = "O valor total de seu pedido é de *" + valorPedido + "*.\r\nEstará pronto para retirada em no máximo *" + prazoRetirada + " minutos*.\r\nMuito obrigada e uma excelente noite!!!";
                                Clipboard.SetText(mensagemTotal.ToString().Trim());
                            }

                            limpaCampos();
                            desmarcaRB();
                            desabilitaGroupBox();
                            btAdd.Enabled = true;
                            btPesquisar.Enabled = true;

                            mostraTelaConfirmacao();
                            //deletaPdf();
                            labelCliente.Text = "Celular";
                            btConsultaCliente.Enabled = true;
                            //AcessoFB.fb_atualizaPedidoEditando(0);
                            this.Close();
                        }
                    }
                }
                
            }

            if (ultbotPress == 2) // atualiza pedido
            {
                if (AcessoFB.fb_verificaUltIdItemPedidoTemp(Convert.ToInt32(tbCodigo.Text)) == 0)
                {
                    MessageBox.Show("Não é possivel atualizar um pedido e deixá-lo sem itens", "Erro");
                    return;
                }
                else
                {
                    Pedidos atualiza = new Pedidos();
                    atualiza.Id = Convert.ToInt32(tbCodigo.Text);

                    Decimal total;
                    String resto;
                    int tamanho = 0;
                    tamanho = tbTotal.Text.Length;
                    resto = tbTotal.Text.Substring(2, tamanho - 2);
                    total = Convert.ToDecimal(resto);
                    atualiza.Valor = total;

                    if (rbEnt.Checked == true)
                        atualiza.Tipo = 1;
                    if (rbBalc.Checked == true)
                        atualiza.Tipo = 2;

                    if (tbDesconto.Text == "")
                    {
                        atualiza.Desconto = 0;
                    }
                    else
                    {
                        if (tbDesconto.Text.Contains("R$"))
                        {
                            Decimal desconto;
                            String resto1;
                            int tamanho1 = 0;
                            tamanho1 = tbDesconto.Text.Length;
                            resto1 = tbDesconto.Text.Substring(2, tamanho1 - 2);
                            desconto = Convert.ToDecimal(resto1);
                            atualiza.Desconto = desconto;
                        }
                        else
                        {
                            atualiza.Desconto = Convert.ToDecimal(tbDesconto.Text);
                        }
                    }

                    atualiza.Pagamento = metPag;
                    atualiza.Observacao = RemoverAcentos(tbObs.Text.ToString());
                    atualiza.Observacao.Replace("'", " ");
                    atualiza.Observacao.Trim();


                    AcessoFB.fb_atualizaPedido(atualiza);

                    Lancamentos atualizarLanc = new Lancamentos();
                    atualizarLanc.Pedido = atualiza.Id;
                    atualizarLanc.Valor = atualiza.Valor;
                    atualizarLanc.Pagamento = atualiza.Pagamento;
                    atualizarLanc.Tipo = atualiza.Tipo;

                    AcessoFB.fb_atualizaLancamentoPedido(atualizarLanc);

                    AcessoFB.fb_atualizaEntregaDoPedido(atualiza.Id, atualiza.Valor, atualiza.Pagamento);
                    AcessoFB.fb_apagaItensPedido(atualiza.Id);
                    AcessoFB.fb_adicionaItemPedido(atualiza.Id);

                    atualiza.Senha = AcessoFB.fb_verificaSenhaDoPedido(atualiza.Id);
                    
                    if (cbImprimeOuNao.Checked == false)
                    {
                        insereDadosImpressao(atualiza.Senha, atualiza.Id);
                    }

                    AcessoFB.fb_limparItemPedidoTemp(atualiza.Id);
                    AcessoFB.fb_limpaTabelasImpressao();

                    //GERAR MENSAGEM NA AREA DE TRANSFERÊNCIA PARA ENVIAR AO CLIENTE
                    if (tipoPedido == 1)
                    {
                        String valorPedido = tbTotal.Text;
                        Parametros prazo = AcessoFB.fb_recuperaParametrosSistema();
                        String prazoEntrega = prazo.entrega.ToString();
                        String mensagemTotal = "O valor total de seu pedido é de *" + valorPedido + "*.\r\nA entrega será realizada em no máximo *" + prazoEntrega + " minutos*.\r\nMuito obrigada e uma excelente noite!!!";
                        Clipboard.SetText(mensagemTotal.ToString().Trim());
                    }

                    if (tipoPedido == 2)
                    {
                        String valorPedido = tbTotal.Text;
                        Parametros prazo = AcessoFB.fb_recuperaParametrosSistema();
                        String prazoRetirada = prazo.retirada.ToString();
                        String mensagemTotal = "O valor total de seu pedido é de *" + valorPedido + "*.\r\nEstará pronto para retirada em no máximo *" + prazoRetirada + " minutos*.\r\nMuito obrigada e uma excelente noite!!!";
                        Clipboard.SetText(mensagemTotal.ToString().Trim());
                    }

                    limpaCampos();
                    desmarcaRB();
                    desabilitaGroupBox();
                    btAdd.Enabled = true;
                    btPesquisar.Enabled = true;

                    mostraTelaConfirmacao();
                    labelCliente.Text = "Celular";
                    btConsultaCliente.Enabled = true;
                    this.Close();
                }
            }
            focaForm();
        }

        public void mostraTelaConfirmacao()
        {
            TelaConfirmado nova = new TelaConfirmado();
            nova.ShowDialog();
            nova.WindowState = FormWindowState.Normal;
            nova.BringToFront();
            nova.TopMost = true;
            nova.Focus();
        }

        public void RecalculaTotal()
        {
            String testar = tbTotal.Text.ToString();
            Decimal novoTotal = 0;

            Decimal taxa;
            String resto;
            int tamanho = 0;
            if(tbTaxa.Text == "")
            {
                taxa = 0;
            }
            else
            {
                tamanho = tbTaxa.Text.Length;
                resto = tbTaxa.Text.Substring(2, tamanho - 2);
                taxa = Convert.ToDecimal(resto);
            }
            

            Decimal desconto;
            String restoDesc;
            int tam = 0;
            if (tbDesconto.Text == "")
            {
                desconto = 0;
            }
            else
            {
                if (tbDesconto.Text.Contains("R$"))
                {
                    tam = tbDesconto.Text.Length;
                    restoDesc = tbDesconto.Text.Substring(2, tam - 2);
                    desconto = Convert.ToDecimal(restoDesc);
                }
                else
                {
                    desconto = Convert.ToDecimal(tbDesconto.Text);
                }
            }


            Decimal totalItens = AcessoFB.fb_totalizaItensNoPedido(Convert.ToInt32(tbCodigo.Text));
            novoTotal = (taxa + totalItens) - desconto;
            if(novoTotal < 0)
            {
                MessageBox.Show("Não é possível inserir um desconto maior do que o total do pedido", "Erro");
                tbDesconto.Text = "";
                tbDesconto.Select();
                tbDesconto.Focus();
                return;
            }
            else
            {
                tbTotal.Text = novoTotal.ToString("C", CultureInfo.CurrentCulture);
            }
            
        }

        int metPag = 0;

        private void btRemItem_Click(object sender, EventArgs e)
        {
            int id_pedido = 0;
            id_pedido = Convert.ToInt32(tbCodigo.Text);
            AcessoFB.fb_excluirItemPedidoTemp(idExcluir);
            AcessoFB.fb_atualizaIdItemTemp(id_pedido);
            RecarregaDados(id_pedido);
            RecalculaTotal();
        }

        private void rbDin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDin.Checked == true)
            {
                metPag = 0;
            }
        }

        private void rbCart_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCart.Checked == true)
            {
                metPag = 1;
            }
        }
        private void rbPix_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPix.Checked == true)
            {
                metPag = 2;
            }
        }
        private void Pedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                AcessoFB.fb_limparItemPedidoTemp(idTbCodigo);
            //AcessoFB.fb_atualizaPedidoEditando(0);

            int parametroErroAtual = AcessoFB.fb_recuperaTabelaErro();
            int novoParametro = parametroErroAtual - 1;
            AcessoFB.fb_atualizaTabelaErro(novoParametro);
        }

        public void desmarcaRB()
        {
            rbCart.Checked = false;
            rbDin.Checked = false;
        }

        public void desabilitaGroupBox()
        {
            groupBox1.Enabled = false;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Deseja realmente cancelar o pedido atual?", "Confirmação", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            else
            {       
                idClienteNoPedido = 0;
                AcessoFB.fb_limparItemPedidoTemp(Convert.ToInt32(tbCodigo.Text));
                //AcessoFB.fb_atualizaPedidoEditando(0);
                limpaCampos();
                desmarcaRB();
                rbEnt.Checked = false;
                rbBalc.Checked = false;
                rbEnt.Enabled = false;
                rbBalc.Enabled = false;
                desabilitaGroupBox();
                btAdd.Enabled = true;
                btPesquisar.Enabled = true;
                btConsultaCliente.Enabled = false;
                tbCodigo.Text = "";
                dataGridView1.DataSource = null;
                parametroExistePedidoSendoFeito = 0;
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Deseja realmente excluir o pedido atual?", "Confirmação", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            else
            {
                parametroExistePedidoSendoFeito = 0;
                idClienteNoPedido = 0;

                int idExcluir = Convert.ToInt32(tbCodigo.Text);
                AcessoFB.fb_excluirPedido(idExcluir);
                mostraTelaConfirmacao();

                AcessoFB.fb_limparItemPedidoTemp(Convert.ToInt32(tbCodigo.Text));
                limpaCampos();
                desmarcaRB();
                desabilitaGroupBox();
                dataGridView1.DataSource = null;
                btAdd.Enabled = true;
                btPesquisar.Enabled = true;
            }
        }


        public void insereDadosImpressao(int senha, int idParaImpressao)
        {
            int id_pedido = Convert.ToInt32(tbCodigo.Text);
            String atual = DateTime.Now.ToString();
            String data = atual.Substring(0, 10);
            String hora = atual.Substring(11, 8);
            String cliente = RemoverAcentos(tbCliente.Text.ToString()).Trim();
            cliente.Replace("'", " ");
            String celular = tbCelular.Text.ToString().Trim();
            String rua = tbRua.Text.ToString().Trim();
            String numero = tbNum.Text.ToString().Trim();
            String bairro = tbBairro.Text.ToString().Trim();
            String referencia = tbReferencia.Text.ToString().Trim();
            String taxa = tbTaxa.Text.ToString();
            String total = tbTotal.Text.ToString();
            String obs = tbObs.Text.ToString().Trim();

            String pagamento = "";
            if(rbDin.Checked == true)
            {
                pagamento = "DINHEIRO";
            }
            if (rbCart.Checked == true)
            {
                pagamento = "CARTAO";
            }
            if(rbPix.Checked == true)
            {
                pagamento = "PIX";
            }

            obs.Replace("'", " ");
            String desc;
            if (tbDesconto.Text == "")
            {
                desc = "R$0,00";
            }
            else
            {
                desc = tbDesconto.Text.ToString();
            }

            AcessoFB.insereDadosImpressao(senha, data, hora, cliente, celular, rua, numero, bairro, referencia, taxa, total, obs, desc, pagamento);
            AcessoFB.insereItensImpressao(idParaImpressao);

            
            //VERIFICA SE O PEDIDO POSSUI PASTEL
            if (AcessoFB.fb_verificaPastelPedido(idParaImpressao) == 1)
            {
                //POSSUI PASTEL
                var result = MessageBox.Show(this, "Deseja imprimir o sabor dos pastéis do pedido para grampear nos pacotes?", "Pedido de Pastel:", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //IMPRIMIMOS OS SABORES DE PASTÉIS

                    List<Itens_Pedido> listaPasteis = new List<Itens_Pedido>();
                    listaPasteis = AcessoFB.recuperaPasteisInseridos(idParaImpressao);

                    for (int i = 0; i < listaPasteis.Count; i++)
                    {
                        Itens_Pedido item = listaPasteis[i];
                        int qtdImpressao = item.Quantidade;
                        if (qtdImpressao > 1)
                        {
                            for (int j = 0; j < qtdImpressao; j++)
                            {
                                ImpressoraImprimir nova = new ImpressoraImprimir();
                                if (item.Obs.Trim() == "" || item.Obs == null) //NÃO POSSUI OBS/ADD
                                    nova.recebeTextos("PEDIDO: " + senha + "\n------------------", item.Nome.Trim(), "------------------");
                                else
                                    nova.recebeTextos("PEDIDO: " + senha + "\n------------------", item.Nome.Trim() + "\n\n" + item.Obs.Trim().Replace("-", "+"), "------------------"); ;
                                nova.ShowDialog();
                            }
                        }
                        else
                        {
                            ImpressoraImprimir nova = new ImpressoraImprimir();
                            if (item.Obs.Trim() == "" || item.Obs == null) //NÃO POSSUI OBS/ADD
                                nova.recebeTextos("PEDIDO: " + senha + "\n------------------", item.Nome.Trim(), "------------------");
                            else
                                nova.recebeTextos("PEDIDO: " + senha + "\n------------------", item.Nome.Trim() + "\n\n" + item.Obs.Trim().Replace("-", "+"), "------------------"); ;
                            nova.ShowDialog();
                        }
                    }
                }
            }

            if (tipoPedido == 1)
            {
                imprimirPedidoEntrega();
            }
            if (tipoPedido == 2)
            {
                imprimirPedidoBalcao();
                if (cbSenha.Checked == true)
                    imprimirSenha(senha, data);
            }
        }

        public void imprimirPedidoBalcao()
        {
            ImpressaoBalcao nova = new ImpressaoBalcao();
            nova.ShowDialog();            
        }
        public void imprimirSenha(int senha, String data)
        {
            ImpressaoBalcaoSenha nova = new ImpressaoBalcaoSenha();
            nova.recebeDados(senha, data);
            nova.ShowDialog();

        }

        public void imprimirPedidoEntrega()
        {
            ImpressaoEntrega nova = new ImpressaoEntrega();
            nova.ShowDialog();

            AcessoFB.fb_limpaTabelasImpressao();
        }

        int tipoPedido = 0; // 1 - Entrega | 2 - Balcão
        private void rbEnt_CheckedChanged(object sender, EventArgs e)
        {
            if(ultbotPress == 2)
            {
                if (rbEnt.Checked == true)
                {
                    rbBalc.Checked = false;
                    tipoPedido = 1;
                    labelCliente.Text = "Cliente:";
                    cbSenha.Enabled = false;
                    cbSenha.Checked = false;
                    rbDin.Checked = true;
                    parametroExistePedidoSendoFeito = 1;
                }
                if (rbEnt.Checked == false)
                {
                    rbBalc.Checked = true;
                    tipoPedido = 2;
                    labelCliente.Text = "Cliente:";
                    cbSenha.Enabled = false;
                    cbSenha.Checked = false;
                    rbDin.Checked = true;
                    parametroExistePedidoSendoFeito = 1;
                }
            }
            else
            {
                if (rbEnt.Checked == true)
                {
                    rbBalc.Checked = false;
                    tipoPedido = 1;
                    //tipoPedidoEntrega();
                    novoPedido();
                    labelCliente.Text = "Cliente:";
                    cbSenha.Enabled = false;
                    cbSenha.Checked = false;
                    rbDin.Checked = true;
                    parametroExistePedidoSendoFeito = 1;
                }
                if (rbEnt.Checked == false)
                {
                    rbBalc.Checked = true;
                    tipoPedido = 2;
                    //tipoPedidoBalcao();
                    novoPedido();
                    labelCliente.Text = "Cliente:";
                    cbSenha.Enabled = true;
                    cbSenha.Checked = false;
                    rbDin.Checked = true;
                    parametroExistePedidoSendoFeito = 1;
                }
                RecalculaTotal();
            }
            
        }

        private void rbBalc_CheckedChanged(object sender, EventArgs e)
        {
            if(ultbotPress == 2)
            {
                if (rbBalc.Checked == true)
                {
                    rbEnt.Checked = false;
                    tipoPedido = 2;
                    labelCliente.Text = "Cliente:";
                    cbSenha.Enabled = true;
                    parametroExistePedidoSendoFeito = 1;
                }
                if (rbBalc.Checked == false)
                {
                    rbEnt.Checked = true;
                    tipoPedido = 1;
                    labelCliente.Text = "Cliente:";
                    cbSenha.Enabled = false;
                    cbSenha.Checked = false;
                    parametroExistePedidoSendoFeito = 1;
                }
            }
            else
            {
                if (rbBalc.Checked == true)
                {
                    rbBalc.Checked = true;
                    tipoPedido = 2;
                    //tipoPedidoBalcao();
                    novoPedido();
                    labelCliente.Text = "Cliente:";
                    cbSenha.Enabled = true;
                    cbSenha.Checked = false;
                    rbDin.Checked = true;
                    parametroExistePedidoSendoFeito = 1;
                }
                if (rbBalc.Checked == false)
                {
                    rbBalc.Checked = false;
                    tipoPedido = 1;
                    //tipoPedidoEntrega();
                    novoPedido();
                    labelCliente.Text = "Cliente:";
                    cbSenha.Enabled = false;
                    cbSenha.Checked = false;
                    rbDin.Checked = true;
                    parametroExistePedidoSendoFeito = 1;
                }
                RecalculaTotal();
            }
            
        }

        private void rbEnt_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void Pedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (tbCliente.Text == "")
                {
                    MessageBox.Show("Cliente não informado!", "Alerta");
                    tbCliente.Focus();
                    tbCliente.Select();
                    return;
                }
                else
                {
                    Adicionar nova = new Adicionar();
                    nova.RecebeNumPedido(Convert.ToInt32(tbCodigo.Text));
                    nova.ShowDialog();
                    RecarregaDados(Convert.ToInt32(tbCodigo.Text));
                    RecalculaTotal();
                }
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        private void Pedido_KeyDown(object sender, KeyEventArgs e)
        {         

        }

        private void labelCliente_Click(object sender, EventArgs e)
        {

        }


        private void tbTotal_Enter(object sender, EventArgs e)
        {
            Decimal total;
            String resto;
            int tamanho = 0;
            tamanho = tbTotal.Text.Length;
            resto = tbTotal.Text.Substring(2, tamanho - 2);
            total = Convert.ToDecimal(resto);
            tbTotal.Text = total.ToString();
        }

        private void tbTotal_Leave(object sender, EventArgs e)
        {
            Decimal ajuste = 0;
            ajuste = Convert.ToDecimal(tbTotal.Text);
            tbTotal.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
        }

        public void recebeValorConsultaCliente(int nProd)
        {
            if (nProd == 0)
            {
                tbCliente.Text = "";
                tbCelular.Text = "";
                tbRua.Text = "";
                tbNum.Text = "";
                tbBairro.Text = "";
                tbReferencia.Text = "";
                tbTaxa.Text = "";
                tbObs.Text = "";
                tbTotal.Text = "";
                dataGridView1.DataSource = null;
                tbCliente.Enabled = true;
                tbCliente.Select();
                tbCliente.Focus();
            }
            else
            {
                Clientes buscado = new Clientes();
                buscado = AcessoFB.fb_pesquisaClientePorId(nProd);

                if (buscado.Nome == "VAZIO")
                {
                    MessageBox.Show("Não foi localizado o cliente \nNada foi selecionado.", "Não encontrado");
                    return;
                }
                else
                {
                    //preencheTB(buscado);
                    if (verificaTaxa(buscado.Bairro) == 1)
                    {
                        limpaCampos();
                    }
                    else
                    {
                        preencheTB(buscado);
                        idClienteMemoria = buscado.Id;

                        String mensagemTotal = "Temos o seguinte endereço cadastrado para este celular:\r\n" + buscado.Rua + "\r\nNº " + buscado.Numero + "\r\nBAIRRO " + buscado.Bairro + "\r\n" + buscado.Referencia + "\r\nDevemos entregar neste endereço?";
                        Clipboard.SetText(mensagemTotal.ToString().Trim());
                    }
                }
            }


        }

        private void btConsultaCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente nova = new ConsultarCliente();
            nova.ShowDialog();
            int parametro = nova.enviaCodCli();
            recebeValorConsultaCliente(nova.enviaCodCli());
            //groupBox1.Enabled = false;
            if (parametro == 0)
                return;
            else
            {
                tbNum.Enabled = false;
                tbCliente.Enabled = false;
                tbRua.Enabled = false;
                tbBairro.Enabled = false;
                tbCelular.Enabled = false;
                tbReferencia.Enabled = false;
                tbCodigo.Enabled = false;
                tbTaxa.Enabled = false;
                habilitaBotoes();
            }        
        }

        private void tbDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (tbDesconto.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void tbDesconto_Enter(object sender, EventArgs e)
        {
            enterJaFoiPress = 0;
            if (tbDesconto.Text == "")
            {
                return;
            }
            else
            {
                Decimal total;
                String resto;
                int tamanho = 0;
                tamanho = tbDesconto.Text.Length;
                resto = tbDesconto.Text.Substring(2, tamanho - 2);
                total = Convert.ToDecimal(resto);
                tbDesconto.Text = total.ToString();
            }     
        }

        private void tbDesconto_Leave(object sender, EventArgs e)
        {
            if(enterJaFoiPress == 1)
            {
                return;
            }
            else
            {
                if (tbDesconto.Text == "")
                {
                    return;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbDesconto.Text);
                    tbDesconto.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                    RecalculaTotal();
                }
            }
        }

        int enterJaFoiPress = 0;
        private void tbDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enterJaFoiPress = 1;
                if (tbDesconto.Text == "")
                {
                    return;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbDesconto.Text);
                    tbDesconto.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                    RecalculaTotal();
                }
            }
        }

        private void btVisPed_Click(object sender, EventArgs e)
        {
            if (AcessoFB.fb_verificaUltIdItemPedidoTemp(Convert.ToInt32(tbCodigo.Text)) == 0)
            {
                MessageBox.Show("Não existe itens para este pedido", "Erro");
                return;
            }
            else
            {
                VisualizarPedido nova = new VisualizarPedido();
                nova.recebeNumPedido(Convert.ToInt32(tbCodigo.Text));
                nova.ShowDialog();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {

        }
        int imprimeOuNao = 0;
        private void cbImprimeOuNao_CheckedChanged(object sender, EventArgs e)
        {
            if(cbImprimeOuNao.Checked == true)
            {
                imprimeOuNao = 1; //não imprime
            }
            else
            {
                imprimeOuNao = 0;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void btEditItemPedido_Click(object sender, EventArgs e)
        {
            //Recuperar ID_PEDIDO, ID_ITEM
            int id_item = 0, id_pedido = 0, de_onde_vem = 0; //0-erro | 1-ajuste de item| 2-add item
            try
            {
                id_item = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                id_pedido = Convert.ToInt32(tbCodigo.Text);
            }
            catch
            {
                MessageBox.Show("Erro ao verificar o código do item", "Erro");
            }

            Console.WriteLine("Codigo do item: " + id_item + "\nCodigo pedido: " + id_pedido);

            if (id_item != 0 && id_pedido != 0)
            {
                Adicionar update_item = new Adicionar();
                update_item.recebeParametro(2);
                update_item.recebeItemNumPedido(id_item, id_pedido);
                update_item.ShowDialog();
                RecarregaDados(Convert.ToInt32(tbCodigo.Text));
                RecalculaTotal();
            }
            else
            {
                MessageBox.Show("Erro ao recuperar codigo do item.", "Alerta");
                return;
            }
        }

        private void tbCliente_Layout(object sender, LayoutEventArgs e)
        {

        }

        int parametroTbCliente = 0;
        private void tbCliente_Enter(object sender, EventArgs e)
        {
            parametroTbCliente = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*public void deletaPdf()
{
if (System.IO.File.Exists(@"C:\Program Files (x86)\StizSoftware\Crepe_da_Sandra\Pedido.pdf"))
{
// Use a try block to catch IOExceptions, to
// handle the case of the file already being
// opened by another process.
try
{
System.IO.File.Delete(@"C:\Program Files (x86)\StizSoftware\Crepe_da_Sandra\Pedido.pdf");
}
catch (System.IO.IOException f)
{
MessageBox.Show(f.Message, "Erro");
return;
}
}
}*/
    }
}
