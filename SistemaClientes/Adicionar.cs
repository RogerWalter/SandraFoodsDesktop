using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;

namespace SistemaClientes
{
    public partial class Adicionar : Form
    {
        public Adicionar()
        {
            InitializeComponent();
        }
        int id_pedido = 0;
        public void RecebeNumPedido(int num)
        {
            id_pedido = num;
        }

        int deOndeVem = 0; // 0 - Pedido || 1 - Item avulso para a comanda || 2 - Atualizar item do pedido
        int senha = 0; // senha para inserir o item individual no pedido

        public void recebeParametro(int num)
        {
            deOndeVem = num;
        }

        int item_atualizar_adicionar = 0; //item recebido do grid do pedido
        int ped_atualizar_adicionar = 0; // cod do pedido que estamos atualizando o item
        public void recebeItemNumPedido(int item_atualizar, int pedido_atualizar)
        {
            item_atualizar_adicionar = item_atualizar;
            ped_atualizar_adicionar = pedido_atualizar;
        }

        public void recebeSenha(int sen)
        {
            senha = sen;
        }

        public void recebeValorConsulta(int nProd)
        {
            if (nProd == 0)
            {
                tbCodigo.Text = "";
                tbCodigo.Enabled = true;
                tbValor.Text = "";
                tbValor.Enabled = true;
                tbDesc.Text = "";
                tbDesc.Enabled = true;
                tbCodigo.Focus();
                tbCodigo.Select();
            }
            else
            {
                tbCodigo.Text = nProd.ToString();

                Itens buscado = new Itens();
                buscado = AcessoFB.fb_pesquisaProdutoPorCodigo(Convert.ToInt32(tbCodigo.Text));
                if (buscado.Nome == "VAZIO")
                {
                    MessageBox.Show("Não foi possível localizar o produto \nVerifique se informou o código corretamente.", "Não encontrado");
                    return;
                }
                else
                {
                    preencheTB(buscado);
                }
            }


        }


        private void label3_Click(object sender, EventArgs e)
        {

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

        List<Itens> adicionais = new List<Itens>();
        List<Itens> descricoes = new List<Itens>();

        int idAlteracao = 0;
        int idPedidoAlteracao = 0;
        private void Adicionar_Load(object sender, EventArgs e)
        {
            //Preenche o autocomplete dos adicionais

            using (FbConnection conn = new FbConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ConnectionString;
                using (FbCommand cmd = new FbCommand())
                {
                    cmd.CommandText = "SELECT DESCRICAO, VALOR, TIPO FROM PRODUTO WHERE GRUPO = 0 AND (TIPO = 9 or TIPO = 8 or TIPO = 7)";
                    //cmd.Parameters.AddWithValue("@Texto", prefixo);
                    cmd.Connection = conn;
                    conn.Open();

                    using (FbDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Itens adicionar = new Itens();
                            adicionar.Nome = sdr[0].ToString().Trim();
                            adicionar.Valor = Convert.ToDecimal(sdr[1]);
                            adicionar.Tipo = Convert.ToInt32(sdr[2]);

                            if (adicionar.Tipo == 9)
                                adicionar.Nome = "+" + adicionar.Nome;
                            if (adicionar.Tipo == 8)
                                adicionar.Nome = "-" + adicionar.Nome;
                            if (adicionar.Tipo == 7)
                                adicionar.Nome = "++" + adicionar.Nome;

                            adicionais.Add(adicionar);
                        }
                    }
                    conn.Close();
                }
            }
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();

            foreach (Itens adicionar in adicionais)
            {
                source.Add(adicionar.Nome);
            }

            tbObs.AutoCompleteCustomSource = source;
            tbObs2.AutoCompleteCustomSource = source;
            tbObs3.AutoCompleteCustomSource = source;

            //Preenche o autocomplete das descrições dos produtos

            using (FbConnection conn = new FbConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ConnectionString;
                using (FbCommand cmd = new FbCommand())
                {
                    cmd.CommandText = "SELECT ID, DESCRICAO, VALOR FROM PRODUTO WHERE GRUPO != 0";
                    //cmd.Parameters.AddWithValue("@Texto", prefixo);
                    cmd.Connection = conn;
                    conn.Open();

                    using (FbDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Itens desc = new Itens();
                            desc.Id = Convert.ToInt32(sdr[0]);
                            desc.Nome = sdr[1].ToString().Trim();
                            desc.Valor = Convert.ToDecimal(sdr[2]);
                            descricoes.Add(desc);
                        }
                    }
                    conn.Close();
                }
            }
            AutoCompleteStringCollection sourceDesc = new AutoCompleteStringCollection();
            foreach (Itens add in descricoes)
            {
                sourceDesc.Add(add.Nome);
            }
            tbDesc.AutoCompleteCustomSource = sourceDesc;

            //ADICIONAR ITEM
            if (deOndeVem != 2)
            {
                tbDesc.Select();
                tbDesc.Focus();
                this.KeyDown += new KeyEventHandler(Adicionar_KeyDown);
            }
            //EDITAR ITEM
            else
            {
                //o item será atualizado
                if(item_atualizar_adicionar == 0 || ped_atualizar_adicionar == 0)
                {
                    MessageBox.Show("Erro ao recuperar identificador do item do pedido. \nEsta janela de atualização de item será fechada", "Erro");
                    this.Close();
                }
                else
                {
                    //RECUPERAMOS O ITEM DO PEDIDO NO BANCO
                    Itens_Pedido recuperado = new Itens_Pedido();
                    recuperado = AcessoFB.fb_recuperaItemPedidoTemp(item_atualizar_adicionar, ped_atualizar_adicionar);
                    idAlteracao = recuperado.Id;
                    idPedidoAlteracao = recuperado.Id_Pedido;
                    //PREENCHEMOS OS CAMPOS PRINCIPAIS
                    tbCodigo.Text = recuperado.Id.ToString().Trim();
                    tbCodigo.Enabled = false;
                    tbDesc.Text = recuperado.Nome.Trim(); ;
                    tbDesc.Enabled = false;
                    tbQtd.Text = "1";
                    //CALCULAMOS O VALOR DO ADICIONAL
                    Itens buscarValor = AcessoFB.fb_pesquisaProdutoPorCodigo(recuperado.Id_Produto);
                    Decimal valorAcrescimo = recuperado.Valor - buscarValor.Valor;
                    if (valorAcrescimo > 0)
                    {
                        tbAcrescimo.Text = valorAcrescimo.ToString("C", CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        tbAcrescimo.Text = "";
                    }
                    valorTotal = buscarValor.Valor;
                    tbValor.Text = recuperado.Valor.ToString("C", CultureInfo.CurrentCulture);
                    tbValor.Enabled = false;
                    tbQtd.Text = recuperado.Quantidade.ToString();
                    //DESMEMBRAMOS OS ADICIONAIS
                    if (recuperado.Obs != "" && recuperado.Obs != null)
                    {/*
                        String grupoSelecionado = comboBoxGrupo.SelectedItem.ToString().Trim();
                        Grupo_Produto buscaNaLista = listaGrupos.Find(item => item.Grupo.Trim() == grupoSelecionado.Trim());
                        novo.Grupo = buscaNaLista.Id;*/

                        string s = recuperado.Obs.Trim();
                        int primeiraQuebra = s.IndexOf("\n");
                        if(primeiraQuebra < 0)
                        {
                            //SÓ EXISTE OBSERVAÇÃO EM UM CAMPO E NÃO É NECESSÁRIO SEGUIR COM AS QUEBRAS
                            tbObs.Text = s;
                            return;
                        }
                        int tamanhoTotal = s.Length;
                        string resto = "";
                        if (primeiraQuebra >= 0)
                        {
                            string primeiroAdicional = s.Substring(0, primeiraQuebra);
                            int tamanhoObs1 = primeiroAdicional.Length;
                            resto = s.Remove(0, tamanhoObs1 + 1);

                            tbObs.Text = primeiroAdicional.Trim();
                            campoObs1 = primeiroAdicional.Trim();

                            if (resto.Length > 0)
                            {
                                string r = resto;
                                int segundaQuebra = resto.IndexOf("\n");
                                if(segundaQuebra > 0)
                                {
                                    string resto1 = r; 
                                    string segundoAdicional = resto1.Substring(0, segundaQuebra);

                                    tbObs2.Text = segundoAdicional.Trim();
                                    campoObs2 = segundoAdicional.Trim();

                                    int tamanhoObs2 = segundoAdicional.Length;
                                    string teceiroAdicional = resto1.Remove(0, tamanhoObs2 + 1);

                                    if(teceiroAdicional.Length > 0)
                                    {
                                        tbObs3.Text = teceiroAdicional.Trim();
                                        campoObs3 = teceiroAdicional.Trim();
                                    } 
                                }
                            }
                        }
                    }
                }
            }
        }

        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        Decimal valorTotal = 0;

        public void preencheTB(Itens buscado)
        {
            tbCodigo.Text = buscado.Id.ToString().Trim();
            tbCodigo.Enabled = false;
            tbDesc.Text = buscado.Nome.Trim(); ;
            tbDesc.Enabled = false;
            valorTotal = buscado.Valor;
            tbValor.Text = buscado.Valor.ToString("C", CultureInfo.CurrentCulture);
            tbValor.Enabled = false;
            tbQtd.Text = "1";
            tbObs.Select();
            tbObs.Focus();
        }

        private void tbCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if(tbCodigo.Text == "")
            {
                tbDesc.Select();
                tbDesc.Focus();
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Itens buscado = new Itens();
                    buscado = AcessoFB.fb_pesquisaProdutoPorCodigo(Convert.ToInt32(tbCodigo.Text));
                    if (buscado.Nome == "VAZIO")
                    {
                        MessageBox.Show("Não foi possível localizar o produto \nVerifique se informou o código corretamente.", "Não encontrado");
                        return;
                    }
                    else
                    {
                        preencheTB(buscado);
                    }
                }
            }
            if(e.KeyCode == Keys.F1)
            {
                ConsultaItem nova = new ConsultaItem();
                nova.ShowDialog();
                recebeValorConsulta(nova.enviaCodProd());
            }
        }

        private void tbDesc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String buscar;
                buscar = tbDesc.Text;

                Itens buscado = new Itens();
                buscado = AcessoFB.fb_pesquisaProdutoPorNome(buscar);
                if (buscado.Nome == "VAZIO")
                {
                    MessageBox.Show("Não foi possível localizar o produto \nVerifique se informou a descrição corretamente.", "Não encontrado");
                    return;
                }
                else
                {
                    preencheTB(buscado);
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                ConsultaItem nova = new ConsultaItem();
                nova.ShowDialog();
                recebeValorConsulta(nova.enviaCodProd());
            }
        }

        private void tbQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        Itens adicionarProduto = new Itens();
        public void adicionaItem()
        {
            if(tbDesc.Text == "" || tbCodigo.Text == "" || tbQtd.Text == "")
            {
                MessageBox.Show("Existem campos sem preenchimento", "Erro");
                return;
            }
            else
            {   
                int id_final = 0;
                Itens_Pedido novo = new Itens_Pedido();
                id_final = (AcessoFB.fb_verificaUltIdItemPedido() + 1) + (AcessoFB.fb_verificaUltIdItemPedidoTemp(id_pedido) + 1) - 1;
                novo.Id = AcessoFB.fb_verificaUltIdItemPedidoTemp(id_pedido) + 1;
                novo.Id_Produto = Convert.ToInt32(tbCodigo.Text);
                novo.Id_Pedido = id_pedido;
                novo.Nome = tbDesc.Text.Trim();
                novo.Obs = RemoverAcentos(tbObs.Text).Trim() + " \n" + RemoverAcentos(tbObs2.Text).Trim() + " \n" + RemoverAcentos(tbObs3.Text).Trim();
                if(novo.Obs.Length > 120)
                {
                    novo.Obs = novo.Obs.Substring(0, 120);
                }
                Decimal valorAdd = 0;

                String testar = tbValor.Text.ToString();

                if (tbValor.Text.Length > 3)
                {
                    if (testar.Substring(0, 2) == "R$")
                    {
                        String resto;
                        int tamanho = 0;
                        tamanho = tbValor.Text.Length;
                        resto = tbValor.Text.Substring(2, tamanho - 2);
                        valorAdd = Convert.ToDecimal(resto);
                    }
                    else
                    {
                        valorAdd = Convert.ToDecimal(tbValor.Text);
                    }
                }
                else
                {
                    valorAdd = Convert.ToDecimal(tbValor.Text);
                }
                novo.Valor = valorAdd;
                novo.Quantidade = Convert.ToInt32(tbQtd.Text);

                //verificar se item já existe, se sim, somar ao outro.
                int qtdItens = AcessoFB.fb_contaItemPedTemp(id_pedido);
                if (qtdItens == 0)
                {
                    AcessoFB.fb_adicionarItemPedidoTemp(novo, id_final);
                }
                else
                {
                    Itens_Pedido comparar = new Itens_Pedido();
                    comparar = AcessoFB.fb_verificaItemPedidoTempDuplicado(qtdItens, id_pedido);
                    int parametro = 0;
                    for (int i = 0; i < qtdItens; i++)
                    {
                        comparar = AcessoFB.fb_verificaItemPedidoTempDuplicado(i + 1, id_pedido);
                        if (novo.Nome.Trim() == comparar.Nome.Trim() && novo.Obs.Trim() == comparar.Obs.Trim())
                        {
                            int nova_quantidade = novo.Quantidade + comparar.Quantidade;
                            AcessoFB.fb_atualizaItemPedidoDuplicado(comparar.Id, nova_quantidade, id_pedido);
                            parametro = 1;
                        }
                    }
                    if (parametro == 0)
                    {
                        AcessoFB.fb_adicionarItemPedidoTemp(novo, id_final);
                    }
                }
                this.Close();
            }
        }

        private void tbQtd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btConfirmar_Click(sender, e);
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            RecalculaTotal();
            if(deOndeVem == 0)
            {
                adicionaItem();
            }
            if(deOndeVem == 1)
            {
                adicionaItemAvulso();
            }
            if (deOndeVem == 2)
            {
                atualizaItemPedido();
            }
        }

        int adicionarEsteAdicional = 0; //se nao existir esse adicional, ele adiciona aos itens e salva
        //0 - NAO | 1 - SIM


        Decimal acres1 = 0;
        Decimal acres2 = 0;
        Decimal acres3 = 0;

        String campoObs1 = "";
        String campoObs2 = "";
        String campoObs3 = "";
        private void tbObs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acres1 = 0;
                if (tbObs.Text.Contains("+") || tbObs.Text.Contains("-"))
                { 
                    Itens buscado = new Itens();
                    buscado = adicionais.Find(item => item.Nome == tbObs.Text.Trim());
                    if (adicionais.Exists(item => item.Nome == tbObs.Text.Trim()) == false)
                    {
                        adicionarEsteAdicional = 1;
                        adicionarProduto.Nome = tbObs.Text.Trim();
                        
                        tbAcrescimo.Select();
                        tbAcrescimo.Focus();
                    }
                    else
                    {
                        adicionarEsteAdicional = 0;
                        valorAcrescimo = buscado.Valor;
                        somaAcrescimos = somaAcrescimos + buscado.Valor;
                        acres1 = buscado.Valor;
                        Decimal totalMostrar = acres1 + acres2 + acres3;
                        tbAcrescimo.Text = totalMostrar.ToString("C", CultureInfo.CurrentCulture);
                        RecalculaTotal();
                        tbObs2.Select();
                        tbObs2.Focus();
                    }    
                }
                else if (tbObs.Text == "")
                {
                    if(campoObs1 != "")
                    {
                        Itens buscado = new Itens();
                        buscado = adicionais.Find(item => item.Nome == campoObs1.Trim());
                        if (buscado.Valor > 0)
                        {
                            Decimal acrescimoAtual = Convert.ToDecimal(tbAcrescimo.Text.Replace("R$", ""));
                            Decimal novoAcrescimo = acrescimoAtual - buscado.Valor;
                            tbAcrescimo.Text = novoAcrescimo.ToString("C", CultureInfo.CurrentCulture);
                            RecalculaTotal();
                        }
                    }
                    tbQtd.Select();
                    tbQtd.Focus();
                }  
                else
                {
                    if (campoObs1 != "")
                    {
                        Itens buscado = new Itens();
                        buscado = adicionais.Find(item => item.Nome == campoObs1.Trim());
                        if (buscado.Valor > 0)
                        {
                            Decimal acrescimoAtual = Convert.ToDecimal(tbAcrescimo.Text.Replace("R$", ""));
                            Decimal novoAcrescimo = acrescimoAtual - buscado.Valor;
                            tbAcrescimo.Text = novoAcrescimo.ToString("C", CultureInfo.CurrentCulture);
                            RecalculaTotal();
                        }
                    }
                    tbObs2.Select();
                    tbObs2.Focus();
                }
            }   
        }

        Decimal somaAcrescimos = 0;

        private void tbObs2_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                acres2 = 0;
                if (tbObs2.Text.Contains("+") || tbObs2.Text.Contains("-"))
                {
                    Itens buscado = new Itens();
                    buscado = adicionais.Find(item => item.Nome == tbObs2.Text.Trim());
                    if (adicionais.Exists(item => item.Nome == tbObs2.Text.Trim()) == false)
                    {
                        adicionarEsteAdicional = 1;
                        adicionarProduto.Nome = tbObs2.Text.Trim();

                        tbAcrescimo.Select();
                        tbAcrescimo.Focus();
                    }
                    else
                    {
                        adicionarEsteAdicional = 0;
                        valorAcrescimo = buscado.Valor;
                        somaAcrescimos = somaAcrescimos + valorAcrescimo;
                        acres2 = buscado.Valor;
                        Decimal totalMostrar = acres1 + acres2 + acres3;
                        tbAcrescimo.Text = totalMostrar.ToString("C", CultureInfo.CurrentCulture);
                        RecalculaTotal();
                        tbObs3.Select();
                        tbObs3.Focus();
                    }
                }
                else if (tbObs2.Text == "")
                {
                    if (campoObs2 != "")
                    {
                        Itens buscado = new Itens();
                        buscado = adicionais.Find(item => item.Nome == campoObs2.Trim());
                        if (buscado.Valor > 0)
                        {
                            Decimal acrescimoAtual = Convert.ToDecimal(tbAcrescimo.Text.Replace("R$", ""));
                            Decimal novoAcrescimo = acrescimoAtual - buscado.Valor;
                            tbAcrescimo.Text = novoAcrescimo.ToString("C", CultureInfo.CurrentCulture);
                            RecalculaTotal();
                        }
                    }
                    tbQtd.Select();
                    tbQtd.Focus();
                }
                else
                {
                    if (campoObs2 != "")
                    {
                        Itens buscado = new Itens();
                        buscado = adicionais.Find(item => item.Nome == campoObs2.Trim());
                        if (buscado.Valor > 0)
                        {
                            Decimal acrescimoAtual = Convert.ToDecimal(tbAcrescimo.Text.Replace("R$", ""));
                            Decimal novoAcrescimo = acrescimoAtual - buscado.Valor;
                            tbAcrescimo.Text = novoAcrescimo.ToString("C", CultureInfo.CurrentCulture);
                            RecalculaTotal();
                        }
                    }
                    tbObs3.Select();
                    tbObs3.Focus();
                }
            }
        }

        private void tbObs3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acres3 = 0;
                if (tbObs3.Text.Contains("+") || tbObs3.Text.Contains("-"))
                {
                    Itens buscado = new Itens();
                    buscado = adicionais.Find(item => item.Nome == tbObs3.Text.Trim());
                    if (adicionais.Exists(item => item.Nome == tbObs3.Text.Trim()) == false)
                    {
                        adicionarEsteAdicional = 1;
                        adicionarProduto.Nome = tbObs3.Text.Trim();

                        tbAcrescimo.Select();
                        tbAcrescimo.Focus();
                    }
                    else
                    {
                        adicionarEsteAdicional = 0;
                        valorAcrescimo = buscado.Valor;
                        somaAcrescimos = somaAcrescimos + valorAcrescimo;
                        acres3 = buscado.Valor;
                        Decimal totalMostrar = acres1 + acres2 + acres3;
                        tbAcrescimo.Text = totalMostrar.ToString("C", CultureInfo.CurrentCulture);
                        RecalculaTotal();
                        tbQtd.Select();
                        tbQtd.Focus();
                    }
                }
                else if (tbObs3.Text == "")
                {
                    if (campoObs3 != "")
                    {
                        Itens buscado = new Itens();
                        buscado = adicionais.Find(item => item.Nome == campoObs3.Trim());
                        if (buscado.Valor > 0)
                        {
                            Decimal acrescimoAtual = Convert.ToDecimal(tbAcrescimo.Text.Replace("R$", ""));
                            Decimal novoAcrescimo = acrescimoAtual - buscado.Valor;
                            tbAcrescimo.Text = novoAcrescimo.ToString("C", CultureInfo.CurrentCulture);
                            RecalculaTotal();
                        }
                    }
                    tbQtd.Select();
                    tbQtd.Focus();
                }
                else
                {
                    if (campoObs3 != "")
                    {
                        Itens buscado = new Itens();
                        buscado = adicionais.Find(item => item.Nome == campoObs3.Trim());
                        if (buscado.Valor > 0)
                        {
                            Decimal acrescimoAtual = Convert.ToDecimal(tbAcrescimo.Text.Replace("R$", ""));
                            Decimal novoAcrescimo = acrescimoAtual - buscado.Valor;
                            tbAcrescimo.Text = novoAcrescimo.ToString("C", CultureInfo.CurrentCulture);
                            RecalculaTotal();
                        }
                    }
                    tbQtd.Select();
                    tbQtd.Focus();
                }
            }
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btConsulta_Click(object sender, EventArgs e)
        {
            ConsultaItem nova = new ConsultaItem();
            nova.ShowDialog();
            recebeValorConsulta(nova.enviaCodProd());

        }

        private void Adicionar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Adicionar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Adicionar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Produtos nova = new Produtos();
            nova.deOndeVem(1);
            nova.ShowDialog();
            tbCodigo.Text = nova.retornaCodigoProduto().ToString();
            Itens buscado = new Itens();
            buscado = AcessoFB.fb_pesquisaProdutoPorCodigo(Convert.ToInt32(tbCodigo.Text));
            if (buscado.Nome == "VAZIO")
            {
                MessageBox.Show("Não foi possível localizar o produto \nVerifique se informou o código corretamente.", "Não encontrado");
                return;
            }
            else
            {
                preencheTB(buscado);
            }
        }
        
        public void RecalculaTotal()
        {
            Decimal valorAcrescimoFinal = 0;
            if (tbAcrescimo.Text == "")
            {
                valorAcrescimoFinal = 0;
                return;
            }
            else
            {  
                if (tbAcrescimo.Text.Contains("R$"))
                {
                    Decimal total;
                    String resto;
                    int tamanho = 0;
                    tamanho = tbAcrescimo.Text.Length;
                    resto = tbAcrescimo.Text.Substring(2, tamanho - 2);
                    total = Convert.ToDecimal(resto);
                    valorAcrescimoFinal = total;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbAcrescimo.Text);
                    valorAcrescimoFinal = ajuste;
                }
            }
            Decimal totalDoItem = 0;
            totalDoItem = valorTotal + valorAcrescimoFinal;
            tbValor.Text = totalDoItem.ToString("C", CultureInfo.CurrentCulture);
        }
        Decimal valorAcrescimo = 0;
        private void tbAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (tbAcrescimo.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        int enterJaFoiPress = 0;
        private void tbAcrescimo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbAcrescimo.Text == "")
                {
                    tbQtd.Select();
                    tbQtd.Focus();
                    return;
                }
                else
                {
                    enterJaFoiPress = 1;
                    if (tbAcrescimo.Text.Contains("R$"))
                    {
                        Decimal total;
                        String resto;
                        int tamanho = 0;
                        tamanho = tbAcrescimo.Text.Length;
                        resto = tbAcrescimo.Text.Substring(2, tamanho - 2);
                        total = Convert.ToDecimal(resto);
                        valorAcrescimo = total;
                        RecalculaTotal();
                        tbQtd.Select();
                        tbQtd.Focus();
                    }
                    else
                    {
                        Decimal ajuste = 0;
                        ajuste = Convert.ToDecimal(tbAcrescimo.Text);
                        valorAcrescimo = ajuste;
                        tbAcrescimo.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                        RecalculaTotal();
                        tbQtd.Select();
                        tbQtd.Focus();
                    }
                }
            }
        }

        private void tbAcrescimo_Enter(object sender, EventArgs e)
        {
            
            if (tbAcrescimo.Text == "")
            {
                return;
            }
            else
            {
                if(tbAcrescimo.Text.Contains("R$"))
                {
                    Decimal total;
                    String resto;
                    int tamanho = 0;
                    tamanho = tbAcrescimo.Text.Length;
                    resto = tbAcrescimo.Text.Substring(2, tamanho - 2);
                    total = Convert.ToDecimal(resto);
                    valorAcrescimo = total;
                    tbAcrescimo.Text = total.ToString();
                }
                else
                {
                    return;
                }
            }
        }

        private void tbAcrescimo_Leave(object sender, EventArgs e)
        {
            if (tbAcrescimo.Text == "")
            {
                valorAcrescimo = 0;
                RecalculaTotal();
                return;
            }
            else
            {
                if (tbAcrescimo.Text.Contains("R$"))
                {
                    Decimal total;
                    String resto;
                    int tamanho = 0;
                    tamanho = tbAcrescimo.Text.Length;
                    resto = tbAcrescimo.Text.Substring(2, tamanho - 2);
                    total = Convert.ToDecimal(resto);
                    valorAcrescimo = total;
                    RecalculaTotal();
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbAcrescimo.Text);
                    valorAcrescimo = ajuste;
                    tbAcrescimo.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                    RecalculaTotal();
                }
            }
        }

        private void tbQtd_Enter(object sender, EventArgs e)
        {
            tbQtd.SelectAll();
            if (tbAcrescimo.Text == "")
            {
                return;
            }
            else
            {
                if (tbAcrescimo.Text.Contains("R$"))
                {
                    Decimal total;
                    String resto;
                    int tamanho = 0;
                    tamanho = tbAcrescimo.Text.Length;
                    resto = tbAcrescimo.Text.Substring(2, tamanho - 2);
                    total = Convert.ToDecimal(resto);
                    valorAcrescimo = total;
                }
                else
                {
                    Decimal ajuste = 0;
                    ajuste = Convert.ToDecimal(tbAcrescimo.Text);
                    valorAcrescimo = ajuste;
                    tbAcrescimo.Text = ajuste.ToString("C", CultureInfo.CurrentCulture);
                    RecalculaTotal();
                }
            }
        }

        public void adicionaItemAvulso()
        {
            if (tbDesc.Text == "" || tbCodigo.Text == "" || tbQtd.Text == "")
            {
                MessageBox.Show("Existem campos sem preenchimento", "Erro");
                return;
            }
            else
            {
                int id_final = 0;
                Itens_Pedido novo = new Itens_Pedido();
                id_final = (AcessoFB.fb_verificaUltIdItemPedido() + 1) + (AcessoFB.fb_verificaUltIdItemAvulso(senha) + 1) - 1;
                novo.Id = AcessoFB.fb_verificaUltIdItemAvulso(senha) + 1;
                novo.Id_Produto = Convert.ToInt32(tbCodigo.Text);
                novo.Id_Pedido = senha;
                novo.Nome = tbDesc.Text.Trim();
                novo.Obs = RemoverAcentos(tbObs.Text).Trim();

                Decimal valorAdd = 0;

                String testar = tbValor.Text.ToString();

                if (tbValor.Text.Length > 3)
                {
                    if (testar.Substring(0, 2) == "R$")
                    {
                        String resto;
                        int tamanho = 0;
                        tamanho = tbValor.Text.Length;
                        resto = tbValor.Text.Substring(2, tamanho - 2);
                        valorAdd = Convert.ToDecimal(resto);
                    }
                    else
                    {
                        valorAdd = Convert.ToDecimal(tbValor.Text);
                    }
                }
                else
                {
                    valorAdd = Convert.ToDecimal(tbValor.Text);
                }
                novo.Valor = valorAdd;
                novo.Quantidade = Convert.ToInt32(tbQtd.Text);

                //verificar se item já existe, se sim, somar ao outro.
                int qtdItens = AcessoFB.fb_contaItemPedAvulso(senha);
                if (qtdItens == 0)
                {
                    AcessoFB.fb_adicionarItemAvulso(novo, id_final);
                }
                else
                {
                    Itens_Pedido comparar = new Itens_Pedido();
                    comparar = AcessoFB.fb_verificaItemAvulsoDuplicado(qtdItens, senha);
                    int parametro = 0;
                    for (int i = 0; i < qtdItens; i++)
                    {
                        comparar = AcessoFB.fb_verificaItemAvulsoDuplicado(i + 1, senha);
                        if (novo.Nome.Trim() == comparar.Nome.Trim() && novo.Obs.Trim() == comparar.Obs.Trim())
                        {
                            int nova_quantidade = novo.Quantidade + comparar.Quantidade;
                            AcessoFB.fb_atualizaItemAvulsoDuplicado(comparar.Id, nova_quantidade, senha);
                            parametro = 1;
                        }
                    }
                    if (parametro == 0)
                    {
                        AcessoFB.fb_adicionarItemAvulso(novo, id_final);
                    }
                }
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            tbDesc.Enabled = true;
            tbCodigo.Enabled = true;
            tbCodigo.Text = "";
            tbDesc.Text = "";
            tbValor.Text = "";
            tbDesc.Select();
            tbDesc.Focus();
            
        }
        public void atualizaItemPedido()
        {
            if (tbQtd.Text == "" || Convert.ToInt32(tbQtd.Text) <= 0)
            {
                MessageBox.Show("Quantidade inválida", "Erro");
                return;
            }
            else
            {
                Itens_Pedido atualizar = new Itens_Pedido();
                atualizar.Quantidade = Convert.ToInt32(tbQtd.Text);
                atualizar.Obs = RemoverAcentos(tbObs.Text).Trim() + " \n" + RemoverAcentos(tbObs2.Text).Trim() + " \n" + RemoverAcentos(tbObs3.Text).Trim();
                if (atualizar.Obs.Length > 120)
                {
                    atualizar.Obs = atualizar.Obs.Substring(0, 120);
                }
                Decimal valorAdd = 0;
                String testar = tbValor.Text.ToString();
                if (tbValor.Text.Length > 3)
                {
                    if (testar.Substring(0, 2) == "R$")
                    {
                        String resto;
                        int tamanho = 0;
                        tamanho = tbValor.Text.Length;
                        resto = tbValor.Text.Substring(2, tamanho - 2);
                        valorAdd = Convert.ToDecimal(resto);
                    }
                    else
                    {
                        valorAdd = Convert.ToDecimal(tbValor.Text);
                    }
                }
                else
                {
                    valorAdd = Convert.ToDecimal(tbValor.Text);
                }
                atualizar.Valor = valorAdd;
                atualizar.Id = idAlteracao;
                atualizar.Id_Pedido = idPedidoAlteracao;
                AcessoFB.fb_atualizarItemPedidoTemp(atualizar);
                this.Close();
            }
        }
    }
}
