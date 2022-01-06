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
    public partial class ConverterPedido : Form
    {
        public ConverterPedido()
        {
            InitializeComponent();
        }

        int idPedido = 0;
        int idCodCliente = 0;
        int tipoPedido = 0;
        public void recebeValorIdPedido(int recebido)
        {
            idPedido = recebido;
        }

        public void recebeCodCliente(int codClie)
        {
            if (codClie == 0)
            {
                MessageBox.Show("Seleção cancelada", "Erro");
                return;
            }
            Clientes buscado = AcessoFB.fb_pesquisaClientePorId(codClie);
            idCodCliente = buscado.Id;
            tbNome.Text = buscado.Nome;
            tbCelular.Text = buscado.Celular;
            tbRua.Text = buscado.Rua;
            tbNum.Text = buscado.Numero;
            tbBairro.Text = buscado.Bairro;
            tbReferencia.Text = buscado.Referencia;
        }
        private void ConverterPedido_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            Pedidos recuperado = AcessoFB.fb_pesquisaPedidoPorId(idPedido);
            labSenha.Text = recuperado.Senha.ToString();
            if(recuperado.Tipo == 1)
            {
                tipoPedido = 1;
                labDe.Text = "ENTREGA";
                labPara.Text = "BALCÃO";
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
            }
            if(recuperado.Tipo == 2 || recuperado.Tipo == 3)
            {
                tipoPedido = 2;
                labDe.Text = "BALCÃO";
                labPara.Text = "ENTREGA";
                groupBox3.Enabled = true;
            }
        }

        private void tbCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Clientes buscado = new Clientes();
                String numeroCelular = tbCodigo.Text.ToString();
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
                            tbCodigo_KeyUp(sender, e);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        idCodCliente = buscado.Id;
                        tbNome.Text = buscado.Nome;
                        tbCelular.Text = buscado.Celular;
                        tbRua.Text = buscado.Rua;
                        tbNum.Text = buscado.Numero;
                        tbBairro.Text = buscado.Bairro;
                        tbReferencia.Text = buscado.Referencia;
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
                    buscado = AcessoFB.fb_pesquisaClientePorId(codigoCliente);
                    if (buscado.Nome == "VAZIO")
                    {
                        MessageBox.Show("Não foi possível localizar o cliente. \nInforme um numero de telefone para cadastrá-lo", "Não encontrado");
                        return;
                    }
                    else
                    {
                        idCodCliente = buscado.Id;
                        tbNome.Text = buscado.Nome;
                        tbCelular.Text = buscado.Celular;
                        tbRua.Text = buscado.Rua;
                        tbNum.Text = buscado.Numero;
                        tbBairro.Text = buscado.Bairro;
                        tbReferencia.Text = buscado.Referencia;
                    }
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if(tipoPedido == 2 || tipoPedido == 3)
            {
                if (idCodCliente == 0)
                {
                    MessageBox.Show("Não foi informado cliente para converter este pedido para entrega.\nVerifique e tente novamente.", "Erro");
                    tbCodigo.Focus();
                    tbCodigo.Select();
                    return;
                }
                var result = MessageBox.Show(this, "O pedido será convertido. Deseja confimar?", "Confirmação", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    //CONVERTEMOS DE BALCÃO PARA ENTREGA
                    Pedidos recuperado = AcessoFB.fb_pesquisaPedidoPorId(idPedido);
                    Pedidos atualizar = new Pedidos();
                    atualizar.Id = idPedido;
                    atualizar.Senha = recuperado.Senha;
                    atualizar.Id_Cliente = idCodCliente;
                    atualizar.Nome_Cliente = tbNome.Text.Trim().ToString();
                    Taxas taxaRecuperada = AcessoFB.fb_pesquisaTaxa(tbBairro.Text.Trim());
                    Decimal novoValor = taxaRecuperada.Valor + recuperado.Valor;
                    atualizar.Valor = novoValor;
                    atualizar.Data = recuperado.Data;
                    atualizar.Observacao = recuperado.Observacao;
                    atualizar.Pagamento = recuperado.Pagamento;
                    atualizar.Tipo = 1;
                    atualizar.Desconto = recuperado.Desconto;

                    AcessoFB.fb_atualizaPedidoConverter(atualizar);

                    Lancamentos atualizarLanc = new Lancamentos();
                    atualizarLanc.Pedido = atualizar.Id;
                    atualizarLanc.Valor = atualizar.Valor;
                    atualizarLanc.Tipo = atualizar.Tipo;

                    AcessoFB.fb_atualizaLancamentoPedido(atualizarLanc);


                    Entregas novaEnt = new Entregas();
                    novaEnt.Id = AcessoFB.fb_verificaUltIdEntrega() + 1;
                    novaEnt.Pedido = atualizar.Id;
                    novaEnt.Senha = atualizar.Senha;
                    novaEnt.Cliente = tbNome.Text.ToString();
                    novaEnt.Total = atualizar.Valor;
                    novaEnt.Data = atualizar.Data.Substring(0,10);
                    novaEnt.Pagamento = atualizar.Pagamento;
                    novaEnt.Lancamento = 0;
                    novaEnt.Taxa = taxaRecuperada.Valor;
                    novaEnt.Entregador = 0;
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
                    //IMPRIMIMOS
                    imprimirPedidoEditado(atualizar.Senha, atualizar.Id);
                    this.Close();
                }
            }
            if (tipoPedido == 1)
            {
                var result = MessageBox.Show(this, "O pedido será convertido. Deseja confimar?", "Confirmação", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    //CONVERTEMOS DE ENTREGA PARA BALCÃO
                    Pedidos recuperado = AcessoFB.fb_pesquisaPedidoPorId(idPedido);
                    Pedidos atualizar = new Pedidos();
                    Clientes clienteRecuperado = AcessoFB.fb_pesquisaClientePorId(recuperado.Id_Cliente);
                    atualizar.Id = idPedido;
                    atualizar.Senha = recuperado.Senha;
                    atualizar.Id_Cliente = 0;
                    atualizar.Nome_Cliente = recuperado.Nome_Cliente;
                    Taxas taxaRecuperada = AcessoFB.fb_pesquisaTaxa(clienteRecuperado.Bairro.Trim());
                    Decimal novoValor = recuperado.Valor - taxaRecuperada.Valor;
                    atualizar.Valor = novoValor;
                    atualizar.Data = recuperado.Data;
                    atualizar.Observacao = recuperado.Observacao;
                    atualizar.Pagamento = recuperado.Pagamento;
                    atualizar.Tipo = 2;
                    atualizar.Desconto = recuperado.Desconto;

                    AcessoFB.fb_atualizaPedidoConverter(atualizar);

                    Lancamentos atualizarLanc = new Lancamentos();
                    atualizarLanc.Pedido = atualizar.Id;
                    atualizarLanc.Valor = atualizar.Valor;
                    atualizarLanc.Tipo = atualizar.Tipo;

                    AcessoFB.fb_atualizaLancamentoPedido(atualizarLanc);

                    //EXCLUIMOS A ENTREGA
                    AcessoFB.fb_excluirEntregaConverter(atualizar.Id);

                    //IMPRIMIMOS
                    imprimirPedidoEditado(atualizar.Senha, atualizar.Id);
                    this.Close();
                }
            }
        }

        private void imprimirPedidoEditado(int senha,  int idPedido)
        {
            insereDadosImpressao(senha, idPedido);
            AcessoFB.fb_limpaTabelasImpressao();
            AcessoFB.fb_limparItemPedidoTemp(idPedido);
        }

        public void insereDadosImpressao(int senha, int idParaImpressao)
        {
            var result = MessageBox.Show(this, "Deseja reimprimir este pedido?", "Confirmação", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            else
            {
                Pedidos recuperado = AcessoFB.fb_pesquisaPedidoPorId(idParaImpressao);
                Clientes clientePedido = AcessoFB.fb_pesquisaClientePorId(recuperado.Id_Cliente);
                Taxas taxaRecuperada = AcessoFB.fb_pesquisaTaxa(clientePedido.Bairro);
                int id_pedido = Convert.ToInt32(recuperado.Id);
                String atual = DateTime.Now.ToString();
                String data = atual.Substring(0, 10);
                String hora = atual.Substring(11, 8);
                String cliente = RemoverAcentos(recuperado.Nome_Cliente).Trim();
                cliente.Replace("'", " ");
                String celular, rua, numero, bairro, referencia, taxa;
                if (recuperado.Tipo == 1)
                {
                    celular = clientePedido.Celular.ToString().Trim();
                    rua = clientePedido.Rua.ToString().Trim();
                    numero = clientePedido.Numero.ToString().Trim();
                    bairro = clientePedido.Bairro.ToString().Trim();
                    referencia = clientePedido.Referencia.ToString().Trim();
                    Decimal valorTaxa = taxaRecuperada.Valor;
                    taxa = valorTaxa.ToString("C", CultureInfo.CurrentCulture);
                }
                else
                {
                    celular = "-";
                    rua = "-";
                    numero = "-";
                    bairro = "-";
                    referencia = "-";
                    taxa = "-";
                }
                Decimal valorTotal = recuperado.Valor;
                String total = valorTotal.ToString("C", CultureInfo.CurrentCulture);
                String obs = recuperado.Observacao.ToString().Trim();
                String pagamento = "";
                if (recuperado.Pagamento == 0)
                {
                    pagamento = "DINHEIRO";
                }
                if (recuperado.Pagamento == 1)
                {
                    pagamento = "CARTAO";
                }
                if (recuperado.Pagamento == 3)
                {
                    pagamento = "PIX";
                }
                obs.Replace("'", " ");
                String desc;
                if (recuperado.Desconto == 0)
                {
                    desc = "R$0,00";
                }
                else
                {
                    Decimal desconto = recuperado.Desconto;
                    desc = desconto.ToString("C", CultureInfo.CurrentCulture);
                }

                AcessoFB.insereDadosImpressao(senha, data, hora, cliente, celular, rua, numero, bairro, referencia, taxa, total, obs, desc, pagamento);
                AcessoFB.insereItensImpressao(idParaImpressao);

                if (recuperado.Tipo == 1)
                {
                    imprimirPedidoEntrega();
                }
                if (recuperado.Tipo == 2 || recuperado.Tipo == 3)
                {
                    imprimirPedidoBalcao();
                }
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
