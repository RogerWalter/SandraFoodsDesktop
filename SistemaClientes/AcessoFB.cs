using System;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Globalization;
using FireSharp.Interfaces;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SistemaClientes
{
    public class AcessoFB
    {
        private static readonly AcessoFB instanciaFireBird = new AcessoFB();
        private AcessoFB() { }

        public static AcessoFB getInstancia()
        {
            return instanciaFireBird;
        }

        public FbConnection getConexao()
        {
            string conn = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();
            return new FbConnection(conn);
        }

        public static int fb_verificaUltIdCliente()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from CLIENTE where ID = (select max(ID) from CLIENTE)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionarCliente(Clientes novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into CLIENTE (ID, NOME, CELULAR, RUA, NUMERO, BAIRRO, REFERENCIA) values (" + novo.Id + ", '" + novo.Nome.Trim() + "', '" + novo.Celular.Trim() + "', '" + novo.Rua.Trim() + "', '" + novo.Numero.Trim() + "', '" + novo.Bairro.Trim() + "', '" + novo.Referencia.Replace("'", " ").Trim() + "')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar o cliente do aplicativo automaticamente no sistema.\nFunção: fb_adicionarCliente()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Clientes fb_pesquisaClientePorNome(String cliente)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from CLIENTE where NOME like '%" + cliente + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Clientes resultado = new Clientes();
                    resultado.Nome = "VAZIO";
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = dr[1].ToString();
                        resultado.Celular = dr[2].ToString();
                        resultado.Rua = dr[3].ToString();
                        resultado.Numero = dr[4].ToString();
                        resultado.Bairro = dr[5].ToString();
                        resultado.Referencia = dr[6].ToString();
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static Clientes fb_pesquisaClientePorId(int idCli)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from CLIENTE where ID = " + idCli;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Clientes resultado = new Clientes();
                    resultado.Nome = "VAZIO";
                    resultado.Rua = "VAZIO";
                    resultado.Numero = "VAZIO";
                    resultado.Bairro = "VAZIO";
                    resultado.Referencia = "VAZIO";
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = dr[1].ToString().Trim();
                        resultado.Celular = dr[2].ToString().Trim();
                        resultado.Rua = dr[3].ToString().Trim();
                        resultado.Numero = dr[4].ToString().Trim();
                        resultado.Bairro = dr[5].ToString().Trim();
                        resultado.Referencia = dr[6].ToString().Trim();
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_pesquisaIdClientePorNome(String nome)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID from CLIENTE where NOME = '" + nome + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = -1;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Clientes fb_pesquisaClientePorCelular(String cliente)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from CLIENTE where CELULAR like '%" + cliente + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Clientes resultado = new Clientes();
                    resultado.Nome = "VAZIO";
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = dr[1].ToString();
                        resultado.Celular = dr[2].ToString();
                        resultado.Rua = dr[3].ToString();
                        resultado.Numero = dr[4].ToString();
                        resultado.Bairro = dr[5].ToString();
                        resultado.Referencia = dr[6].ToString();
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_pesquisaClientePorCelularNumeroCasoBairro(String celular, String numero, String bairro)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from CLIENTE where CELULAR = '" + celular + "' and NUMERO = '"+ numero +"' and BAIRRO = '"+ bairro +"'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Clientes resultado = new Clientes();
                    resultado.Nome = "VAZIO";
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = dr[1].ToString();
                        resultado.Celular = dr[2].ToString();
                        resultado.Rua = dr[3].ToString();
                        resultado.Numero = dr[4].ToString();
                        resultado.Bairro = dr[5].ToString();
                        resultado.Referencia = dr[6].ToString();
                    }
                    if(resultado.Nome == "VAZIO")
                        return -1;
                    else
                        return resultado.Id;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static void fb_atualizaCliente(Clientes atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update CLIENTE set NOME = '" + atualizar.Nome + "', CELULAR = '" + atualizar.Celular + "', RUA = '" + atualizar.Rua + "', NUMERO = '" + atualizar.Numero + "', BAIRRO = '" + atualizar.Bairro + "', REFERENCIA = '" + atualizar.Referencia + "' where ID = " + atualizar.Id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirCliente(int idCliente)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM CLIENTE WHERE ID = " + idCliente;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //###############################################PRODUTOS##################################################

        public static int fb_verificaUltIdProduto()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PRODUTO where ID = (select max(ID) from PRODUTO)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }



        public static void fb_adicionarProduto(Itens novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if(novo.Valor.ToString().Contains(","))
                    {
                        addValor = novo.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.Valor.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "insert into PRODUTO (ID, DESCRICAO, VALOR, INFORMACOES, TIPO, GRUPO, APP) values (" + novo.Id + ", '" + novo.Nome + "', " + addValor + ", '" + novo.Descricao + "', " + novo.Tipo + ", " + novo.Grupo + ", " + novo.App + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static void fb_atualizaProduto(Itens atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (atualizar.Valor.ToString().Contains(","))
                    {
                        addValor = atualizar.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = atualizar.Valor.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "update PRODUTO set DESCRICAO = '" + atualizar.Nome + "', VALOR = " + addValor + ", INFORMACOES = '" + atualizar.Descricao + "', TIPO = " + atualizar.Tipo + ", GRUPO = " + atualizar.Grupo + ", APP = " + atualizar.App + " where ID = " + atualizar.Id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Itens fb_pesquisaProdutoPorCodigo(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from PRODUTO where ID = " + cod;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens resultado = new Itens();
                    resultado.Nome = "VAZIO";
                    resultado.Descricao = "VAZIO";
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = dr[1].ToString();
                        resultado.Valor = Convert.ToDecimal(dr[2]);
                        resultado.Descricao = dr[3].ToString();
                        resultado.Tipo = Convert.ToInt32(dr[4]);
                        resultado.Grupo = Convert.ToInt32(dr[5]);
                        resultado.App = Convert.ToInt32(dr[6]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Itens fb_pesquisaProdutoPorNome(String descricao)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from PRODUTO where DESCRICAO = '" + descricao.Trim() + "' AND GRUPO != 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens resultado = new Itens();
                    resultado.Nome = "VAZIO";
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = dr[1].ToString();
                        resultado.Valor = Convert.ToDecimal(dr[2]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_pesquisaProdutoPorNomeRetornaCod(String descricao)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID from PRODUTO where DESCRICAO = '" + descricao.Trim() + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int codigo = 0;
                    while (dr.Read())
                    {
                        codigo = Convert.ToInt32(dr[0]);
                    }
                    return codigo;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirProduto(int idProduto)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM PRODUTO WHERE ID = " + idProduto;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_zerarTabelaProduto()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM PRODUTO";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_zerarTabelaTaxa()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM TAXA";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionarProdutoTodosFirebase(List<Itens_Firebase> listaDeProdutos)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    for (int i = 0; i < listaDeProdutos.Count; i++)
                    {
                        Itens_Firebase novo = new Itens_Firebase();
                        novo = listaDeProdutos[i];
                        String addValor;
                        if (novo.valor.ToString().Contains(","))
                        {
                            addValor = novo.valor.ToString().Replace(",", ".");
                        }
                        else
                        {
                            addValor = novo.valor.ToString();
                        }                   
                        string mSQL = "insert into PRODUTO (ID, DESCRICAO, VALOR, INFORMACOES, TIPO, GRUPO) values (" + novo.id + ", '" + novo.nome + "', " + addValor + ", '" + novo.descricao + "', " + novo.tipo + ", " + novo.grupo + ")";
                        FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                        cmd.ExecuteNonQuery();
                    }              
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionarTaxasTodasFirebase(List<TaxasFirebase> listaTaxas)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    for (int i = 0; i < listaTaxas.Count; i++)
                    {
                        TaxasFirebase novo = new TaxasFirebase();
                        novo = listaTaxas[i];
                        String addValor;
                        if (novo.valor.ToString().Contains(","))
                        {
                            addValor = novo.valor.ToString().Replace(",", ".");
                        }
                        else
                        {
                            addValor = novo.valor.ToString();
                        }
                        string mSQL = "insert into TAXA (ID, LOCAL, VALOR) values (" + novo.id + ", '" + novo.bairro + "', " + addValor + ")";
                        FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<Grupo_Produto> fb_recuperaGruposProduto()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from PRODUTO_GRUPO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Grupo_Produto> resultado = new List<Grupo_Produto>();
                    while (dr.Read())
                    {
                        Grupo_Produto retorno = new Grupo_Produto();
                        retorno.Id = Convert.ToInt32(dr[0]);
                        retorno.Grupo = dr[1].ToString();
                        resultado.Add(retorno);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_recuperaIdGruposProduto(String nome)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID from PRODUTO_GRUPO where GRUPO = '" + nome + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int retorno = -1;
                    while (dr.Read())
                    {
                        retorno = Convert.ToInt32(dr[0]);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<Tipo_Produto> fb_recuperaTiposProduto()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from PRODUTO_TIPO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Tipo_Produto> resultado = new List<Tipo_Produto>();
                    while (dr.Read())
                    {
                        Tipo_Produto retorno = new Tipo_Produto();
                        retorno.Id = Convert.ToInt32(dr[0]);
                        retorno.Tipo = dr[1].ToString();
                        resultado.Add(retorno);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //###############################################TAXAS##################################################

        public static int fb_verificaUltIdTaxa()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from TAXA where ID = (select max(ID) from TAXA)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }



        public static void fb_adicionarTaxa(Taxas novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (novo.Valor.ToString().Contains(","))
                    {
                        addValor = novo.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.Valor.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "insert into TAXA (ID, LOCAL, VALOR) values (" + novo.Id + ", '" + novo.Local + "', " + addValor + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static void fb_atualizaTaxa(Taxas atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (atualizar.Valor.ToString().Contains(","))
                    {
                        addValor = atualizar.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = atualizar.Valor.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "update TAXA set LOCAL = '" + atualizar.Local + "', VALOR = " + addValor + " where ID = " + atualizar.Id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirTaxa(int idTaxa)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM TAXA WHERE ID = " + idTaxa;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Taxas fb_pesquisaTaxa(String descricao)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from TAXA where LOCAL like '%" + descricao + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Taxas resultado = new Taxas();
                    resultado.Local = "VAZIO";
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Local = dr[1].ToString();
                        resultado.Valor = Convert.ToDecimal(dr[2]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Taxas fb_pesquisaTaxaPorId(int id)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from TAXA where ID = " + id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Taxas resultado = new Taxas();
                    resultado.Local = "VAZIO";
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Local = dr[1].ToString();
                        resultado.Valor = Convert.ToDecimal(dr[2]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static DataTable fb_buscaTaxasConsulta()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, LOCAL, VALOR from TAXA";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";
                    String resultado2 = "VAZIA";


                    DataTable dt = new DataTable("Produtos");
                    DataColumn coluna, coluna0, coluna1;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "CODIGO";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "LOCAL";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "VALOR";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    Decimal ajuste;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = dr[1].ToString().Trim();

                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;


                        linha["CODIGO"] = resultado;
                        linha["LOCAL"] = resultado1;
                        linha["VALOR"] = resultado2;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        //###############################################PEDIDOS##################################################


        public static int fb_verificaUltIdPedido()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where ID = (select max(ID) from PEDIDO) order by ID ASC";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_verificaSenhaPedido(String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select max(SENHA) from PEDIDO where DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        if (dr[0] == DBNull.Value)
                            ultId = 0;
                        else
                            ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_verificaUltIdItemPedido()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from ITEM_PEDIDO where ID = (select max(ID) from ITEM_PEDIDO)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdItemPedidoTemp(int id_pedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select max(ID_TEMP) from ITEM_PEDIDO_TEMP  where ID_PEDIDO =" + id_pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = 0;
                    while (dr.Read())
                    {
                        if (dr[0] == DBNull.Value)
                            ultId = 0;
                        else
                            ultId = Convert.ToInt32(dr[0]); 

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaSenhaDoPedido(int pedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select SENHA from PEDIDO where ID = " + pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int senha = 0;
                    while (dr.Read())
                    {
                        senha = Convert.ToInt32(dr[0]);
                    }
                    return senha;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionarItemPedido(Itens_Pedido novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (novo.Valor.ToString().Contains(","))
                    {
                        addValor = novo.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.Valor.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "insert into ITEM_PEDIDO (ID, ID_PEDIDO, PRODUTO, VALOR, QUANTIDADE) values (" + novo.Id + ", " + novo.Id_Pedido + ", '" + novo.Nome + "', " + addValor + ", " + novo.Quantidade + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static Itens_Pedido fb_verificaItemPedidoTempDuplicado(int id, int id_pedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID_TEMP, PRODUTO, OBS, QUANTIDADE from ITEM_PEDIDO_TEMP WHERE ID_TEMP = " + id + " AND ID_PEDIDO = " + id_pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido retorno = new Itens_Pedido();
                    int i = 0;
                    while (dr.Read())
                    {
                        retorno.Id = Convert.ToInt32(dr[0]);
                        retorno.Nome = Convert.ToString(dr[1]).Trim();
                        retorno.Obs = Convert.ToString(dr[2]).Trim();
                        retorno.Quantidade = Convert.ToInt32(dr[3]);
                        i++;
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        /*
        public static Itens_Pedido[] fb_verificaItemPedidoTempDuplicado(int qtdItens)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID_TEMP, PRODUTO, OBS, QUANTIDADE from ITEM_PEDIDO_TEMP";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido[] retorno = new Itens_Pedido[qtdItens];
                    int i = 0;
                    while (dr.Read())
                    {
                        retorno[i].Id = Convert.ToInt32(dr[0]);
                        retorno[i].Nome = Convert.ToString(dr[1]).Trim();
                        retorno[i].Obs = Convert.ToString(dr[2]).Trim();
                        retorno[i].Quantidade = Convert.ToInt32(dr[3]);
                        i++;
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }*/
        public static void fb_atualizaItemPedidoDuplicado(int id, int nova_qtd, int id_pedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update ITEM_PEDIDO_TEMP set QUANTIDADE = " + nova_qtd + " where ID_TEMP = " + id + " and ID_PEDIDO = " + id_pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionarItemPedidoTemp(Itens_Pedido novo, int id_final)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (novo.Valor.ToString().Contains(","))
                    {
                        addValor = novo.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.Valor.ToString();
                    }

                    if (novo.Nome.Length > 30)
                        novo.Nome = novo.Nome.Remove(30, novo.Nome.Length - 30);

                    conexaoFireBird.Open();
                    string mSQL = "insert into ITEM_PEDIDO_TEMP (ID_TEMP, ID_FINAL, ID_PEDIDO, PRODUTO, OBS, VALOR, QUANTIDADE) values (" + novo.Id + ", " + id_final + ", " + novo.Id_Pedido + ", '" + novo.Nome + "', '" + novo.Obs + "', " + addValor + ", " + novo.Quantidade + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaItensPedidoTemp(int pedidoAtual)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID_TEMP, PRODUTO, QUANTIDADE, VALOR from ITEM_PEDIDO_TEMP where ID_PEDIDO = " + pedidoAtual + " order by ID_TEMP";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";
                    int resultado1 = 0;
                    int resultado0 = 0;
                    String resultado2;


                    DataTable dt = new DataTable("Itens_Pedido");
                    DataColumn coluna, coluna0, coluna1, coluna2;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "ITEM";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "PRODUTO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "QTD";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "VALOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    Decimal ajuste;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado0 = Convert.ToInt32(dr[0]);
                        resultado = dr[1].ToString();
                        resultado1 = Convert.ToInt32(dr[2]);


                        ajuste = Convert.ToDecimal(dr[3]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;


                        linha["ITEM"] = resultado0;
                        linha["PRODUTO"] = resultado.Trim();
                        linha["QTD"] = resultado1;
                        linha["VALOR"] = resultado2;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_contaItemPedTemp(int id_pedido)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID_TEMP from ITEM_PEDIDO_TEMP where ID_PEDIDO = " + id_pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static String[] fb_buscaItensPedTempListar (int qtd, int numPed)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select QUANTIDADE, PRODUTO, OBS from ITEM_PEDIDO_TEMP where ID_PEDIDO = " + numPed;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();

                    String[] resultado = new string[qtd];

                    String aux1 = "";
                    String aux2 = "";
                    String aux3 = "";

                    int cont = 0;
                    while (dr.Read())
                    {

                        aux1 = dr[0].ToString();
                        aux2 = dr[1].ToString();
                        aux3 = dr[2].ToString();
                        if(aux3.Trim() == "" || aux3 is null)
                        {
                            resultado[cont] = aux1.Trim() + " x " + aux2.Trim();
                            cont++;
                        }
                        else
                        {
                            resultado[cont] = aux1.Trim() + " x " + aux2.Trim() + " (" + aux3.Trim() + ")";
                            cont++;
                        }
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_buscaItensPedAtualizar(int id_pedido)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from ITEM_PEDIDO where ID_PEDIDO = " + id_pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido novo = new Itens_Pedido();
                    String aux = "";
                    while (dr.Read())
                    {
                        novo.Id = Convert.ToInt32(dr[0]);
                        novo.Id_Pedido = Convert.ToInt32(dr[1]);
                        aux = Convert.ToString(dr[2]);
                        novo.Obs = Convert.ToString(dr[3]);
                        novo.Valor = Convert.ToDecimal(dr[4]);
                        novo.Quantidade = Convert.ToInt32(dr[5]);

                        int id_temp = AcessoFB.fb_verificaUltIdItemPedidoTemp(novo.Id_Pedido) + 1;

                        String addValor;
                        if (novo.Valor.ToString().Contains(","))
                        {
                            addValor = novo.Valor.ToString().Replace(",", ".");
                        }
                        else
                        {
                            addValor = novo.Valor.ToString();
                        }

                        string mSQL1 = "insert into ITEM_PEDIDO_TEMP (ID_TEMP, ID_FINAL, ID_PEDIDO, PRODUTO, OBS, VALOR, QUANTIDADE) values (" + id_temp + ", " + novo.Id + ", " + novo.Id_Pedido + ", '" + aux.Replace("  ", "") + "', '" + novo.Obs.Replace("  ", "") + "', " + addValor + ", " + novo.Quantidade + ")";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaItensPedido(int pedidoAtual)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select PRODUTO, QUANTIDADE, VALOR from ITEM_PEDIDO where ID_PEDIDO = " + pedidoAtual;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";
                    int resultado1 = 0;
                    String resultado2;


                    DataTable dt = new DataTable("Itens_Pedido");
                    DataColumn coluna, coluna1, coluna2;


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "PRODUTO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "QTD";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "VALOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    Decimal ajuste;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = dr[0].ToString();
                        resultado1 = Convert.ToInt32(dr[1]);


                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;

                        linha["PRODUTO"] = resultado;
                        linha["QTD"] = resultado1;
                        linha["VALOR"] = resultado2;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Pedidos fb_pesquisaPedido(int cod, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, SENHA, ID_CLIENTE, NOME_CLIENTE, VALOR, OBSERVACAO, PAGAMENTO, TIPO from PEDIDO where SENHA = " + cod + " and DATA LIKE '"+ data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Pedidos resultado = new Pedidos();
                    resultado.Id = -1;
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Senha  = Convert.ToInt32(dr[1]);
                        resultado.Id_Cliente = Convert.ToInt32(dr[2]);
                        resultado.Nome_Cliente = Convert.ToString(dr[3]);
                        resultado.Valor = Convert.ToDecimal(dr[4]);
                        resultado.Observacao = Convert.ToString(dr[5]);
                        resultado.Pagamento = Convert.ToInt32(dr[6]);
                        resultado.Tipo = Convert.ToInt32(dr[7]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_totalizaItensNoPedido(int ped)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR, QUANTIDADE from ITEM_PEDIDO_TEMP where ID_PEDIDO = " + ped; 
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal valor = 0;
                    int qtd = 0;
                    Decimal totParc = 0;
                    Decimal total = 0;
                    while (dr.Read())
                    {
                        valor = Convert.ToDecimal(dr[0]);
                        qtd = Convert.ToInt32(dr[1]);
                        totParc = valor * qtd;
                        total = total + totParc;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirItemPedidoTemp(int idTaxa)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM ITEM_PEDIDO_TEMP WHERE ID_TEMP = " + idTaxa;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirItemPedidoTempIdPedido(int idPedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM ITEM_PEDIDO_TEMP WHERE ID_PEDIDO = " + idPedido;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_limparItemPedidoTemp(int id_pedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM ITEM_PEDIDO_TEMP WHERE ID_PEDIDO = " + id_pedido;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_resetItemPedidoTemp()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM ITEM_PEDIDO_TEMP";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_apagaItensPedido(int id_pedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM ITEM_PEDIDO where ID_PEDIDO = " + id_pedido;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaIdItemTemp(int ped)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID_TEMP, ID_FINAL from ITEM_PEDIDO_TEMP where ID_PEDIDO = " + ped;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int id_temp = 0;
                    int id_final = 0;
                    int cont = 1;
                    while (dr.Read())
                    {
                        id_temp = Convert.ToInt32(dr[0]);
                        id_final = Convert.ToInt32(dr[1]);

                        string mSQL1 = "update ITEM_PEDIDO_TEMP set ID_TEMP = " + cont + " where ID_FINAL = " + id_final;
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                        cont++;
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaPedido(Pedidos atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    String addValor;
                    if (atualizar.Valor.ToString().Contains(","))
                    {
                        addValor = atualizar.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = atualizar.Valor.ToString();
                    }

                    String addDesconto;
                    if (atualizar.Desconto.ToString().Contains(","))
                    {
                        addDesconto = atualizar.Desconto.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addDesconto = atualizar.Desconto.ToString();
                    }

                    string mSQL = "update PEDIDO set VALOR = " + addValor + ", DESCONTO = " + addDesconto + ", PAGAMENTO = " + atualizar.Pagamento + ", OBSERVACAO = '" + atualizar.Observacao + "' where ID = " + atualizar.Id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaPedidoConverter(Pedidos atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    String addValor;
                    if (atualizar.Valor.ToString().Contains(","))
                    {
                        addValor = atualizar.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = atualizar.Valor.ToString();
                    }

                    String addDesconto;
                    if (atualizar.Desconto.ToString().Contains(","))
                    {
                        addDesconto = atualizar.Desconto.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addDesconto = atualizar.Desconto.ToString();
                    }

                    string mSQL = "update PEDIDO set " +
                        "ID_CLIENTE = " + atualizar.Id_Cliente + ", " +
                        "VALOR = " + addValor + ", " +
                        "NOME_CLIENTE = '" + atualizar.Nome_Cliente + "', " +
                        "PAGAMENTO = " + atualizar.Pagamento + ", " +
                        "TIPO = " + atualizar.Tipo + ", " +
                        "DESCONTO = " + addDesconto + " " +
                        "where ID = " + atualizar.Id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionaNovoPedido(Pedidos novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (novo.Valor.ToString().Contains(","))
                    {
                        addValor = novo.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.Valor.ToString();
                    }

                    String addDesconto;
                    if (novo.Desconto.ToString().Contains(","))
                    {
                        addDesconto = novo.Desconto.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addDesconto = novo.Desconto.ToString();
                    }
                    if (novo.Observacao.Length > 100)
                        novo.Observacao = novo.Observacao.Remove(100); 

                    conexaoFireBird.Open();
                    string mSQL = "insert into PEDIDO (ID, SENHA, ID_CLIENTE, NOME_CLIENTE, VALOR, DATA, OBSERVACAO, PAGAMENTO, TIPO, DESCONTO) values (" + novo.Id + ", " + novo.Senha + ", " + novo.Id_Cliente + ", '" + novo.Nome_Cliente.Trim() + "', " + addValor + ", '" + novo.Data + "', '" + novo.Observacao + "', '" + novo.Pagamento + "', " + novo.Tipo + ", " + addDesconto + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar um novo pedido vindo do aplicativo.\nFunção: fb_adicionaNovoPedido()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_verificaGrupoItemComanda(String nome)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select GRUPO from PRODUTO where DESCRICAO = '" + nome.Trim() + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int grupo = 0;
                    while (dr.Read())
                    {
                        grupo = Convert.ToInt32(dr[0]);

                    }
                    return grupo;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static Decimal fb_verificaParcialComanda(String id_chave)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select TOTAL from COMANDA where ID_CHAVE = '" + id_chave + "' AND TIPO_FECHAMENTO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    while (dr.Read())
                    {
                        total = Convert.ToDecimal(dr[0]);

                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_adicionaNovaComanda(Comanda novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (novo.total.ToString().Contains(","))
                    {
                        addValor = novo.total.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.total.ToString();
                    }
                    conexaoFireBird.Open();
                    string mSQL = "insert into COMANDA (ID, ID_CHAVE, DATA, MESA, TOTAL, PAGAMENTO, TIPO_FECHAMENTO) values ("+ fb_verificaUltIdComanda() + ",'" + novo.id + "', '" + novo.data + "', " + novo.mesa + ", " + addValor + ", " + novo.pagamento + ", " + novo.fechamento + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar um novo pedido vindo do aplicativo.\nFunção: fb_adicionaNovoPedido()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_adicionaItemComanda(ItemComanda inserir)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    String addValor;
                    if (inserir.valor.ToString().Contains(","))
                    {
                        addValor = inserir.valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = inserir.valor.ToString();
                    }
                    string mSQL1 = "insert into ITEM_COMANDA (ID, ID_CHAVE, MESA, DATA, NOME, VALOR, QTD, GRUPO) values ("+ fb_verificaUltIdItemComanda() + ",'" + inserir.id + "', " + inserir.mesa + ", '" + inserir.data + "', '" + inserir.nome + "', " + addValor + ", " + inserir.qtd + ", " + inserir.grupo + ")";
                    FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                    cmd1.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_verificaUltIdComanda()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from COMANDA where ID = (select max(ID) from COMANDA)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId + 1;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdItemComanda()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from ITEM_COMANDA where ID = (select max(ID) from ITEM_COMANDA)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId + 1;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionaItemPedido(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID_FINAL, ID_PEDIDO, PRODUTO, OBS, VALOR, QUANTIDADE from ITEM_PEDIDO_TEMP where ID_PEDIDO = " + cod;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido resultado = new Itens_Pedido();
                    resultado.Id = -1;
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Id = fb_verificaUltIdItemPedido() + 1;
                        resultado.Id_Pedido = Convert.ToInt32(dr[1]);
                        resultado.Nome = Convert.ToString(dr[2]);
                        resultado.Obs = Convert.ToString(dr[3]);
                        resultado.Valor = Convert.ToDecimal(dr[4]);
                        resultado.Quantidade = Convert.ToInt32(dr[5]);

                        String addValor;
                        if (resultado.Valor.ToString().Contains(","))
                        {
                            addValor = resultado.Valor.ToString().Replace(",", ".");
                        }
                        else
                        {
                            addValor = resultado.Valor.ToString();
                        }

                        string mSQL1 = "insert into ITEM_PEDIDO (ID, ID_PEDIDO, PRODUTO, OBS, VALOR, QUANTIDADE) values (" + resultado.Id + ", " + resultado.Id_Pedido + ", '" + resultado.Nome + "', '" + resultado.Obs + "', " + addValor + ", " + resultado.Quantidade + ")";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirPedido(int idPedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM PEDIDO WHERE ID = " + idPedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();

                    string mSQL1 = "DELETE FROM ITEM_PEDIDO WHERE ID_PEDIDO = " + idPedido;
                    FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                    cmd1.ExecuteNonQuery();

                    string mSQL2 = "DELETE FROM ENTREGA WHERE ID_PEDIDO = " + idPedido;
                    FbCommand cmd2 = new FbCommand(mSQL2, conexaoFireBird);
                    cmd2.ExecuteNonQuery();

                    string mSQL3 = "DELETE FROM LANCAMENTO WHERE PEDIDO = " + idPedido;
                    FbCommand cmd3 = new FbCommand(mSQL3, conexaoFireBird);
                    cmd3.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirPedidoMonitor(PedidoMonitor item)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM PEDIDO_MONITOR WHERE IDENTIFICADOR = '" + item.Identificador + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();

                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }



        public static void fb_excluirEntregaConverter(int idPedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL2 = "DELETE FROM ENTREGA WHERE ID_PEDIDO = " + idPedido;
                    FbCommand cmd2 = new FbCommand(mSQL2, conexaoFireBird);
                    cmd2.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void insereDadosImpressao(int senha, String data, String hora, String cliente, String celular, String rua, String numero, String bairro, String referencia, String taxa, String total, String obs, String desc, String pagamento)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into IMPRESSAO_DADOS (SENHA, DATA, HORA, CLIENTE, CELULAR, RUA, NUMERO, BAIRRO, REFERENCIA, TAXA, TOTAL, OBS, DESCONTO, PAGAMENTO) values (" + senha + ", '" + data + "', '" + hora + "', '" + cliente + "', '" + celular + "', '" + rua + "', '" + numero + "', '" + bairro + "', '" + referencia + "', '" + taxa + "', '" + total + "', '" + obs + "', '" + desc + "', '" + pagamento + "')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar os dados para a impressão de um pedido.\nFunção: insereDadosImpressao()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static void insereItensImpressao(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID_TEMP, PRODUTO, OBS, VALOR, QUANTIDADE from ITEM_PEDIDO_TEMP where ID_PEDIDO = " + cod + "ORDER BY PRODUTO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido resultado = new Itens_Pedido();
                    resultado.Id = -1;
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = Convert.ToString(dr[1]);
                        resultado.Obs = Convert.ToString(dr[2]);
                        resultado.Valor = Convert.ToDecimal(dr[3]);
                        resultado.Quantidade = Convert.ToInt32(dr[4]);

                        Decimal totalItemQtd = resultado.Quantidade * resultado.Valor;

                        String addValor = totalItemQtd.ToString("C", CultureInfo.CurrentCulture);
                        addValor = addValor.Substring(2, (addValor.Length - 2));

                        resultado.Nome = RemoverAcentos(resultado.Nome.Trim());
                        resultado.Obs = RemoverAcentos(resultado.Obs.Trim());

                        string mSQL1 = "insert into IMPRESSAO_ITENS (ITEM, NOME, OBS, QTD, VALOR) values (" + resultado.Id + ", '" + resultado.Nome.Trim() + "', '" + resultado.Obs.Trim() + "',  " + resultado.Quantidade + ", '" + addValor + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaPastelPedidoAplicativo(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, PRODUTO, OBS, VALOR, QUANTIDADE from ITEM_PEDIDO where ID_PEDIDO = " + cod + "ORDER BY PRODUTO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido resultado = new Itens_Pedido();
                    int parametro = 0;
                    resultado.Id = -1;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = Convert.ToString(dr[1]);
                        resultado.Obs = Convert.ToString(dr[2]);
                        resultado.Valor = Convert.ToDecimal(dr[3]);
                        resultado.Quantidade = Convert.ToInt32(dr[4]);

                        if (resultado.Nome.Contains("PASTEL"))
                        {
                            cont++;
                            if (cont > 1)
                            {
                                parametro = 1;
                                return 1;
                            }
                        }

                    }
                    return parametro;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static int fb_verificaPastelPedido(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID_TEMP, PRODUTO, OBS, VALOR, QUANTIDADE from ITEM_PEDIDO_TEMP where ID_PEDIDO = " + cod + "ORDER BY PRODUTO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido resultado = new Itens_Pedido();
                    int parametro = 0;
                    resultado.Id = -1;
                    int cont = 0; 
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = Convert.ToString(dr[1]);
                        resultado.Obs = Convert.ToString(dr[2]);
                        resultado.Valor = Convert.ToDecimal(dr[3]);
                        resultado.Quantidade = Convert.ToInt32(dr[4]);

                        if (resultado.Nome.Contains("PASTEL"))
                        {
                            cont++;
                            if(cont > 1)
                            {
                                parametro = 1;
                                return 1;
                            }
                        }
                            
                    }
                    return parametro;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<Itens_Pedido> recuperaPasteisInseridos(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID_TEMP, PRODUTO, OBS, VALOR, QUANTIDADE from ITEM_PEDIDO_TEMP where ID_PEDIDO = " + cod + "ORDER BY PRODUTO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Itens_Pedido> lista = new List<Itens_Pedido>();
                    while (dr.Read())
                    {
                        Itens_Pedido resultado = new Itens_Pedido();
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = Convert.ToString(dr[1]);
                        resultado.Obs = Convert.ToString(dr[2]);
                        resultado.Valor = Convert.ToDecimal(dr[3]);
                        resultado.Quantidade = Convert.ToInt32(dr[4]);

                        if (resultado.Nome.Contains("PASTEL"))
                            lista.Add(resultado);
                    }
                    return lista;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<Itens_Pedido> recuperaPasteisInseridosAplicativo(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, PRODUTO, OBS, VALOR, QUANTIDADE from ITEM_PEDIDO where ID_PEDIDO = " + cod + "ORDER BY PRODUTO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Itens_Pedido> lista = new List<Itens_Pedido>();
                    while (dr.Read())
                    {
                        Itens_Pedido resultado = new Itens_Pedido();
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = Convert.ToString(dr[1]);
                        resultado.Obs = Convert.ToString(dr[2]);
                        resultado.Valor = Convert.ToDecimal(dr[3]);
                        resultado.Quantidade = Convert.ToInt32(dr[4]);

                        if (resultado.Nome.Contains("PASTEL"))
                            lista.Add(resultado);
                    }
                    return lista;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static void fb_limpaTabelasImpressao()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM IMPRESSAO_DADOS";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();

                    string mSQL1 = "DELETE FROM IMPRESSAO_ITENS";
                    FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                    cmd1.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DadosImpressao fb_buscaDadosImpressa()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from IMPRESSAO_DADOS";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    DadosImpressao  resultado = new DadosImpressao();
                    while (dr.Read())
                    {
                        resultado.senha = Convert.ToString(dr[0]);
                        resultado.data = Convert.ToString(dr[1]);
                        resultado.hora = Convert.ToString(dr[2]);
                        resultado.cliente = Convert.ToString(dr[3]);
                        resultado.celular = Convert.ToString(dr[4]);
                        resultado.rua = Convert.ToString(dr[5]);
                        resultado.numero = Convert.ToString(dr[6]);
                        resultado.bairro = Convert.ToString(dr[7]);
                        resultado.referencia = Convert.ToString(dr[8]);
                        resultado.taxa = Convert.ToString(dr[9]);
                        resultado.total = Convert.ToString(dr[10]);
                        resultado.obs = Convert.ToString(dr[11]);
                        resultado.desc = Convert.ToString(dr[12]);
                        resultado.pagamento = Convert.ToString(dr[13]);

                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaItensPedidoImpressao()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from IMPRESSAO_ITENS";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int col1 = 0, col3 = 0;
                    String col2 = "VAZIA", col4 = "VAZIA", col5 = "VAZIA";

                    DataTable dt = new DataTable("IMPRESSAO");
                    DataColumn coluna1, coluna2, coluna3, coluna4, coluna5;

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "ITEM";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "NOME";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna5 = new DataColumn();
                    coluna5.DataType = System.Type.GetType("System.String");
                    coluna5.ColumnName = "OBS";
                    coluna5.ReadOnly = false;
                    coluna5.Unique = false;
                    dt.Columns.Add(coluna5);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.Int32");
                    coluna3.ColumnName = "QTD";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    coluna4 = new DataColumn();
                    coluna4.DataType = System.Type.GetType("System.String");
                    coluna4.ColumnName = "VALOR";
                    coluna4.ReadOnly = false;
                    coluna4.Unique = false;
                    dt.Columns.Add(coluna4);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        col1 = Convert.ToInt32(dr[0]);
                        col2 = dr[1].ToString();
                        col5 = dr[2].ToString();
                        col3 =Convert.ToInt32(dr[3]);
                        col4 = dr[4].ToString();

                        linha["ITEM"] = col1;
                        linha["NOME"] = col2;
                        linha["OBS"] = col5;
                        linha["QTD"] = col3;
                        linha["VALOR"] = col4;

                        dt.Rows.Add(linha);

                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaClientesConsulta()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, NOME, CELULAR from CLIENTE order by NOME";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";
                    String resultado2 = "VAZIA";


                    DataTable dt = new DataTable("Clientes");
                    DataColumn coluna, coluna0, coluna1;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "CODIGO";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "NOME";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "CELULAR";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);
                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = dr[1].ToString().Trim();
                        resultado2 = dr[2].ToString().Trim();



                        linha["CODIGO"] = resultado;
                        linha["NOME"] = resultado1;
                        linha["CELULAR"] = resultado2;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaItensConsulta()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, DESCRICAO, VALOR, TIPO, GRUPO from PRODUTO order by DESCRICAO asc";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int resultado3 = 0;
                    int resultado4 = 0;
                    String resultado1 = "VAZIA";
                    String resultado2 = "VAZIA";


                    DataTable dt = new DataTable("Produtos");
                    DataColumn coluna, coluna0, coluna1, coluna2, coluna3;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "CODIGO";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "DESCRICAO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "VALOR";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    /*coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.Int32");
                    coluna2.ColumnName = "TIPO";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.Int32");
                    coluna3.ColumnName = "GRUPO";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);*/

                    Decimal ajuste;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = dr[1].ToString().Trim();

                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor.Trim();

                        resultado3 = Convert.ToInt32(dr[3]);
                        resultado4 = Convert.ToInt32(dr[4]);

                        if (resultado4 == 0 && resultado3 == 9)
                            resultado1 = "+" + resultado1.Trim();

                        if (resultado4 == 0 && resultado3 == 8)
                            resultado1 = "-" + resultado1.Trim();

                        if (resultado4 == 0 && resultado3 == 7)
                            resultado1 = "++" + resultado1.Trim();

                        linha["CODIGO"] = resultado;
                        linha["DESCRICAO"] = resultado1;
                        linha["VALOR"] = resultado2;
                        //linha["TIPO"] = resultado3;
                        //linha["GRUPO"] = resultado4;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //ANTES DA ALTERACAO
        /*
        public static DataTable fb_buscaItensConsulta()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, DESCRICAO, VALOR from PRODUTO order by DESCRICAO asc";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";
                    String resultado2 = "VAZIA";


                    DataTable dt = new DataTable("Produtos");
                    DataColumn coluna, coluna0, coluna1;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "CODIGO";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "DESCRICAO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "VALOR";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    Decimal ajuste;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = dr[1].ToString().Trim();

                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor.Trim();


                        linha["CODIGO"] = resultado;
                        linha["DESCRICAO"] = resultado1;
                        linha["VALOR"] = resultado2;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }*/


        public static DataTable fb_buscaPedidosConsulta(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select senha as SENHA, NOME_CLIENTE as CLIENTE, VALOR as VALOR from PEDIDO where data like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";
                    String resultado3 = "VAZIA";


                    DataTable dt = new DataTable("Pedidos");
                    DataColumn coluna, coluna0, coluna2;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "SENHA";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "CLIENTE";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "VALOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    Decimal ajuste;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = dr[1].ToString().Trim();
                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado3 = valor;


                        linha["SENHA"] = resultado;
                        linha["CLIENTE"] = resultado1;
                        linha["VALOR"] = resultado3;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        

        public static int fb_preencheRelatorioDia()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10);

                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select SENHA, VALOR, PAGAMENTO, TIPO from PEDIDO where DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Relatorios resultado = new Relatorios();

                    Decimal temp1 = 0;
                    int temp2 = 0, temp3 = 0;

                    int cont = 1;

                    while (dr.Read())
                    {
                        resultado.Senha = Convert.ToInt32(dr[0]);
                        resultado.Senha = cont;

                        temp1 = Convert.ToInt32(dr[1]);
                        resultado.Valor = temp1.ToString("C", CultureInfo.CurrentCulture);
                        temp2 = Convert.ToInt32(dr[2]);
                        if (temp2 == 1)
                            resultado.Pagamento = "DINHEIRO";
                        if (temp2 == 2)
                            resultado.Pagamento = "CARTAO";
                        temp3 = Convert.ToInt32(dr[3]);
                        if (temp3 == 1)
                            resultado.Venda = "ENTREGA";
                        if (temp3 == 2)
                            resultado.Venda = "BALCAO";

                        string mSQL1 = "INSERT INTO RELATORIO (SENHA, VALOR, PAGAMENTO, VENDA) VALUES ("+ resultado.Senha +", '"+ resultado.Valor + "', '" + resultado.Pagamento + "', '" + resultado.Venda + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();
                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_preencheRelatorioMes()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                String mes = DateTime.Now.ToString();
                mes = mes.Substring(3, 7);

                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select SENHA, VALOR, PAGAMENTO, TIPO from PEDIDO where DATA like '%" + mes + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Relatorios resultado = new Relatorios();

                    Decimal temp1 = 0;
                    int temp2 = 0, temp3 = 0;

                    int contador = 1;

                    while (dr.Read())
                    {
                        resultado.Senha = Convert.ToInt32(dr[0]);
                        resultado.Senha = contador;

                        temp1 = Convert.ToInt32(dr[1]);
                        resultado.Valor = temp1.ToString("C", CultureInfo.CurrentCulture);
                        temp2 = Convert.ToInt32(dr[2]);
                        if (temp2 == 1)
                            resultado.Pagamento = "DINHEIRO";
                        if (temp2 == 2)
                            resultado.Pagamento = "CARTAO";
                        temp3 = Convert.ToInt32(dr[3]);
                        if (temp3 == 1)
                            resultado.Venda = "ENTREGA";
                        if (temp3 == 2)
                            resultado.Venda = "BALCAO";

                        string mSQL1 = "INSERT INTO RELATORIO (SENHA, VALOR, PAGAMENTO, VENDA) VALUES (" + resultado.Senha + ", '" + resultado.Valor + "', '" + resultado.Pagamento + "', '" + resultado.Venda + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                        contador++;
                    }
                    return contador;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_preencheRelatorioPeriodo(String dtIni, String dtFin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select SENHA, VALOR, PAGAMENTO, TIPO from pedido where cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + dtIni.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + dtFin.Replace("/", ".") + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Relatorios resultado = new Relatorios();

                    Decimal temp1 = 0;
                    int temp2 = 0, temp3 = 0;

                    int cont = 1;

                    while (dr.Read())
                    {
                        resultado.Senha = Convert.ToInt32(dr[0]);
                        resultado.Senha = cont;

                        temp1 = Convert.ToInt32(dr[1]);
                        resultado.Valor = temp1.ToString("C", CultureInfo.CurrentCulture);
                        temp2 = Convert.ToInt32(dr[2]);
                        if (temp2 == 1)
                            resultado.Pagamento = "DINHEIRO";
                        if (temp2 == 2)
                            resultado.Pagamento = "CARTAO";
                        temp3 = Convert.ToInt32(dr[3]);
                        if (temp3 == 1)
                            resultado.Venda = "ENTREGA";
                        if (temp3 == 2)
                            resultado.Venda = "BALCAO";

                        string mSQL1 = "INSERT INTO RELATORIO (SENHA, VALOR, PAGAMENTO, VENDA) VALUES (" + resultado.Senha + ", '" + resultado.Valor + "', '" + resultado.Pagamento + "', '" + resultado.Venda + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();
                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_preencheRelatorioLancamentosDia(int UltSenha)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                String data = DateTime.Now.ToString();
                data = data.Substring(0, 10);

                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID, VALOR, PAGAMENTO from LANCAMENTO where DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Relatorios resultado = new Relatorios();

                    Decimal temp1 = 0;
                    int temp2 = 0;
                    int cont = UltSenha;

                    while (dr.Read())
                    {
                        
                        resultado.Senha = Convert.ToInt32(dr[0]);
                        resultado.Senha = cont;

                        temp1 = Convert.ToInt32(dr[1]);
                        resultado.Valor = temp1.ToString("C", CultureInfo.CurrentCulture);

                        temp2 = Convert.ToInt32(dr[2]);
                        if (temp2 == 1)
                            resultado.Pagamento = "DINHEIRO";
                        if (temp2 == 2)
                            resultado.Pagamento = "CARTAO";

                        resultado.Venda = "NO LOCAL";


                        string mSQL1 = "INSERT INTO RELATORIO (SENHA, VALOR, PAGAMENTO, VENDA) VALUES (" + resultado.Senha + ", '" + resultado.Valor + "', '" + resultado.Pagamento + "', '" + resultado.Venda + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();
                        cont++;
                    }   
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_preencheRelatorioLancamentosMes(int UltSenha)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                String mes = DateTime.Now.ToString();
                mes = mes.Substring(3, 7);

                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID, VALOR, PAGAMENTO from LANCAMENTO where DATA like '%" + mes + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Relatorios resultado = new Relatorios();

                    Decimal temp1 = 0;
                    int temp2 = 0;
                    int cont = UltSenha;

                    while (dr.Read())
                    {
                        resultado.Senha = Convert.ToInt32(dr[0]);
                        resultado.Senha = cont;

                        temp1 = Convert.ToInt32(dr[1]);
                        resultado.Valor = temp1.ToString("C", CultureInfo.CurrentCulture);

                        temp2 = Convert.ToInt32(dr[2]);
                        if (temp2 == 1)
                            resultado.Pagamento = "DINHEIRO";
                        if (temp2 == 2)
                            resultado.Pagamento = "CARTAO";

                        resultado.Venda = "NO LOCAL";


                        string mSQL1 = "INSERT INTO RELATORIO (SENHA, VALOR, PAGAMENTO, VENDA) VALUES (" + resultado.Senha + ", '" + resultado.Valor + "', '" + resultado.Pagamento + "', '" + resultado.Venda + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();
                        cont++;
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_preencheRelatorioLancamentosPeriodo(String dtIni, String dtFin, int ultSenha)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {

                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID, VALOR, PAGAMENTO from LANCAMENTO where cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + dtIni.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + dtFin.Replace("/", ".") + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Relatorios resultado = new Relatorios();

                    Decimal temp1 = 0;
                    int temp2 = 0;
                    int cont = ultSenha;

                    while (dr.Read())
                    {
                        cont++;
                        resultado.Senha = Convert.ToInt32(dr[0]);
                        resultado.Senha = cont;

                        temp1 = Convert.ToInt32(dr[1]);
                        resultado.Valor = temp1.ToString("C", CultureInfo.CurrentCulture);

                        temp2 = Convert.ToInt32(dr[2]);
                        if (temp2 == 1)
                            resultado.Pagamento = "DINHEIRO";
                        if (temp2 == 2)
                            resultado.Pagamento = "CARTAO";

                        resultado.Venda = "NO LOCAL";


                        string mSQL1 = "INSERT INTO RELATORIO (SENHA, VALOR, PAGAMENTO, VENDA) VALUES (" + resultado.Senha + ", '" + resultado.Valor + "', '" + resultado.Pagamento + "', '" + resultado.Venda + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_limpaRelatorio()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM RELATORIO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaPedidos(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaPedidosMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where DATA like '%" + mes + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaPedidosPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalDia(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '%" + mes + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdDinheiro(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where DATA like '" + data + "%' AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdDinheiroMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where DATA like '%" + mes + "%' AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdDinheiroPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdCartao(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where DATA like '" + data + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdCartaoMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where DATA like '%" + mes + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdCartaoPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdEntrega(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '" + data + "%' AND TIPO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdEntregaMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '%" + mes + "%' AND TIPO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdEntregaPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND TIPO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdBalcao(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '" + data + "%' AND TIPO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdBalcaoMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '%" + mes + "%' AND TIPO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdBalcaoPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND TIPO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalDiaDinheiro(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from PEDIDO where DATA like '" + data + "%' AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalDiaDinheiroMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '%" + mes + "%' AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalDiaDinheiroPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static Decimal fb_somaTotalDiaCartao(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from PEDIDO where DATA like '" + data + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalDiaCartaoMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from PEDIDO where DATA like '%" + mes + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalDiaCartaoPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalEntregaDia(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '" + data + "%' AND TIPO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalEntregaMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '%" + mes + "%' AND TIPO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalEntregaPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND TIPO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalBalcaoDia(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '" + data + "%' AND TIPO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalBalcaoMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '%" + mes + "%' AND TIPO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalBalcaoPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND TIPO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //#############################################LANCAMENTO#############################
        public static int fb_verificaUltIdLanc()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where ID = (select max(ID) from LANCAMENTO)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }



        public static void fb_adicionarLanc(Lancamentos inserir)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (inserir.Valor.ToString().Contains(","))
                    {
                        addValor = inserir.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = inserir.Valor.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "insert into LANCAMENTO (ID, DATA, VALOR, PAGAMENTO, TIPO, PEDIDO) values (" + inserir.Id + ", '" + inserir.Data + "', " + addValor + ", " + inserir.Pagamento + ", " + inserir.Tipo + ", " + inserir.Pedido + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar um novo lançamento de um pedido vindo do aplicativo.\nFunção: fb_adicionarLanc()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalLancamentosDia(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '" + data + "%' AND TIPO = 3";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalLancamentosDiaOutrosApps(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '" + data + "%' AND TIPO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalLancamentosDiaOutrosAppsPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "' AND TIPO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalLancamentosDiaOutrosAppsMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '%" + mes + "%' AND TIPO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalLancamentosMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '%" + mes + "%' AND TIPO = 3";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaTotalLancamentosPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where TIPO = 3 AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaLancamentosLocal(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '" + data + "%' AND TIPO = 3";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaLancamentosLocalMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '" + mes + "%' AND TIPO = 3";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaLancamentos(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaLancamentosMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '%" + mes + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaLancamentosOutrosApps(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '" + data + "%' AND TIPO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaLancamentosOutrosAppsPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "' AND TIPO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaLancamentosOutrosAppsMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '%" + mes + "%' AND TIPO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaLancamentosPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where TIPO = 3 AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaLancDinheiro(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '" + data + "%' AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaLancPix(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '" + data + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaLancPixMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '%" + mes + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaLancPixPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static Decimal fb_somaLancDinheiroMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '%" + mes + "%' AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaLancDinheiroPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaLancCartao(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '" + data + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaLancCartaoMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where DATA like '%" + mes + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_somaLancCartaoPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_qtdLancamentoDinheiro(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '" + data + "%' AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdLancamentoPix(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '" + data + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdLancamentoPixMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '%" + mes + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdLancamentoPixPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_qtdLancamentoDinheiroMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '%" + mes + "%' AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdLancamentoDinheiroPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 1";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdLancamentoCartao(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '" + data + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdLancamentoCartaoMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where DATA like '%" + mes + "%' AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_qtdLancamentoCartaoPeriodo(String ini, String fin)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini.Replace("/", ".") + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fin.Replace("/", ".") + "') AND PAGAMENTO = 2";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static List<Itens_Pedido_Relatorio> fb_recuperaListaItemPedido(List<int> listaPedidos)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from ITEM_PEDIDO where ID_PEDIDO >= " + listaPedidos[0] + " AND ID_PEDIDO <= " + listaPedidos[listaPedidos.Count - 1] ;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido_Relatorio resultado = new Itens_Pedido_Relatorio();
                    List<Itens_Pedido_Relatorio> retorno = new List<Itens_Pedido_Relatorio>();
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Id_Pedido = Convert.ToInt32(dr[1]);
                        resultado.Nome = Convert.ToString(dr[2]);
                        resultado.Obs = Convert.ToString(dr[3]);
                        resultado.Valor = Convert.ToDecimal(dr[4]);
                        resultado.Quantidade = Convert.ToInt32(dr[5]);
                        resultado.Grupo = fb_verificaGrupoItemComanda(resultado.Nome);

                        retorno.Add(resultado);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static List<int> fb_recuperaListaPedidos(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<int> retorno = new List<int>();
                    int id_adc = 0;
                    while (dr.Read())
                    {
                        id_adc = Convert.ToInt32(dr[0]);
                        retorno.Add(id_adc);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static List<int> fb_recuperaListaPedidosMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where DATA like '%" + mes + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<int> retorno = new List<int>();
                    int id_adc = 0;
                    while (dr.Read())
                    {
                        id_adc = Convert.ToInt32(dr[0]);
                        retorno.Add(id_adc);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static List<int> fb_recuperaListaPedidosPeriodo(String ini, String fim)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fim + "')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<int> retorno = new List<int>();
                    int id_adc = 0;
                    while (dr.Read())
                    {
                        id_adc = Convert.ToInt32(dr[0]);
                        retorno.Add(id_adc);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<Lancamentos> fb_recuperaListaLancamentos(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from LANCAMENTO where DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Lancamentos> retorno = new List<Lancamentos>();
                    while (dr.Read())
                    {
                        Lancamentos novoLanc = new Lancamentos();
                        novoLanc.Id = Convert.ToInt32(dr[0]);
                        novoLanc.Data = dr[1].ToString().Trim();
                        novoLanc.Valor = Convert.ToDecimal(dr[2]);
                        novoLanc.Pagamento = Convert.ToInt32(dr[3]);
                        novoLanc.Tipo = Convert.ToInt32(dr[4]);
                        novoLanc.Pedido = Convert.ToInt32(dr[5]);

                        retorno.Add(novoLanc);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static List<Lancamentos> fb_recuperaListaLancamentosMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from LANCAMENTO where DATA like '%" + mes + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Lancamentos> retorno = new List<Lancamentos>();
                    while (dr.Read())
                    {
                        Lancamentos novoLanc = new Lancamentos();
                        novoLanc.Id = Convert.ToInt32(dr[0]);
                        novoLanc.Data = dr[1].ToString().Trim();
                        novoLanc.Valor = Convert.ToDecimal(dr[2]);
                        novoLanc.Pagamento = Convert.ToInt32(dr[3]);
                        novoLanc.Tipo = Convert.ToInt32(dr[4]);
                        novoLanc.Pedido = Convert.ToInt32(dr[5]);

                        retorno.Add(novoLanc);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static List<Lancamentos> fb_recuperaListaLancamentosPeriodo(String ini, String fim)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from LANCAMENTO where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fim + "')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Lancamentos> retorno = new List<Lancamentos>();
                    while (dr.Read())
                    {
                        Lancamentos novoLanc = new Lancamentos();
                        novoLanc.Id = Convert.ToInt32(dr[0]);
                        novoLanc.Data = dr[1].ToString().Trim();
                        novoLanc.Valor = Convert.ToDecimal(dr[2]);
                        novoLanc.Pagamento = Convert.ToInt32(dr[3]);
                        novoLanc.Tipo = Convert.ToInt32(dr[4]);
                        novoLanc.Pedido = Convert.ToInt32(dr[5]);

                        retorno.Add(novoLanc);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        /*public static List<Comanda> fb_recuperaListaComandas(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from COMANDA where DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Comanda> retorno = new List<Comanda>();
                    while (dr.Read())
                    {
                        Comanda ins = new Comanda();
                        int id = Convert.ToInt32(dr[0]);
                        ins.id = dr[1].ToString().Trim();
                        ins.data = dr[2].ToString().Trim();
                        ins.mesa = Convert.ToInt32(dr[3]);
                        ins.total = Convert.ToDecimal(dr[4]);
                        ins.pagamento = Convert.ToInt32(dr[5]);
                        ins.fechamento = Convert.ToInt32(dr[6]);

                        retorno.Add(ins);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }*/
        public static List<Comanda> fb_recuperaListaComandasMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from COMANDA where DATA like '%" + mes + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Comanda> retorno = new List<Comanda>();
                    while (dr.Read())
                    {
                        Comanda ins = new Comanda();
                        int id = Convert.ToInt32(dr[0]);
                        ins.id = dr[1].ToString().Trim();
                        ins.data = dr[2].ToString().Trim();
                        ins.mesa = Convert.ToInt32(dr[3]);
                        ins.total = Convert.ToDecimal(dr[4]);
                        ins.pagamento = Convert.ToInt32(dr[5]);
                        ins.fechamento = Convert.ToInt32(dr[6]);

                        retorno.Add(ins);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static List<Comanda> fb_recuperaListaComandasPeriodo(String ini, String fim)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from COMANDA where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fim + "')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Comanda> retorno = new List<Comanda>();
                    while (dr.Read())
                    {
                        Comanda ins = new Comanda();
                        int id = Convert.ToInt32(dr[0]);
                        ins.id = dr[1].ToString().Trim();
                        ins.data = dr[2].ToString().Trim();
                        ins.mesa = Convert.ToInt32(dr[3]);
                        ins.total = Convert.ToDecimal(dr[4]);
                        ins.pagamento = Convert.ToInt32(dr[5]);
                        ins.fechamento = Convert.ToInt32(dr[6]);

                        retorno.Add(ins);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<ItemComanda> fb_recuperaListaItemComandas(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from ITEM_COMANDA where DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<ItemComanda> retorno = new List<ItemComanda>();
                    while (dr.Read())
                    {
                        ItemComanda ins = new ItemComanda();
                        int id = Convert.ToInt32(dr[0]);
                        ins.id = dr[1].ToString().Trim();
                        ins.mesa = Convert.ToInt32(dr[2]);
                        ins.data = dr[3].ToString().Trim();
                        ins.nome = dr[4].ToString().Trim();
                        ins.valor = Convert.ToDecimal(dr[5]);
                        ins.qtd = Convert.ToInt32(dr[6]);
                        ins.grupo = Convert.ToInt32(dr[7]);

                        retorno.Add(ins);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<ItemComanda> fb_recuperaListaItemComandasMes(String mes)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from ITEM_COMANDA where DATA like '%" + mes + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<ItemComanda> retorno = new List<ItemComanda>();
                    while (dr.Read())
                    {
                        ItemComanda ins = new ItemComanda();
                        int id = Convert.ToInt32(dr[0]);
                        ins.id = dr[1].ToString().Trim();
                        ins.mesa = Convert.ToInt32(dr[2]);
                        ins.data = dr[3].ToString().Trim();
                        ins.nome = dr[4].ToString().Trim();
                        ins.valor = Convert.ToDecimal(dr[5]);
                        ins.qtd = Convert.ToInt32(dr[6]);
                        ins.grupo = Convert.ToInt32(dr[7]);

                        retorno.Add(ins);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<ItemComanda> fb_recuperaListaItemComandasPeriodo(String ini, String fim)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from ITEM_COMANDA where (cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) >= '" + ini + "' AND cast(overlay(replace(data, '/', '.') placing '' from 11 for 50) as date) <= '" + fim + "')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<ItemComanda> retorno = new List<ItemComanda>();
                    while (dr.Read())
                    {
                        ItemComanda ins = new ItemComanda();
                        int id = Convert.ToInt32(dr[0]);
                        ins.id = dr[1].ToString().Trim();
                        ins.mesa = Convert.ToInt32(dr[2]);
                        ins.data = dr[3].ToString().Trim();
                        ins.nome = dr[4].ToString().Trim();
                        ins.valor = Convert.ToDecimal(dr[5]);
                        ins.qtd = Convert.ToInt32(dr[6]);
                        ins.grupo = Convert.ToInt32(dr[7]);

                        retorno.Add(ins);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //###############################################MOTOBOYS##################################################

        public static int fb_verificaUltIdMotoboy()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from MOTOBOY where ID = (select max(ID) from MOTOBOY)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_buscaIdUnicoMotoboy()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from MOTOBOY";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static void fb_adicionarMotoboy(Motoboys novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into MOTOBOY (ID, NOME) values (" + novo.Id + ", '" + novo.Nome + "')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static void fb_atualizaMotoboy(Motoboys atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update MOTOBOY set NOME = '" + atualizar.Nome + "' where ID = " + atualizar.Id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Motoboys fb_pesquisaMotoboyPorCodigo(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from MOTOBOY where ID = " + cod;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Motoboys resultado = new Motoboys();
                    resultado.Nome = "VAZIO";
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = dr[1].ToString();
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirMotoboy(int id)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM MOTOBOY WHERE ID = " + id;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaMotoboysConsulta()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, NOME from MOTOBOY";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";


                    DataTable dt = new DataTable("Motoboys");
                    DataColumn coluna, coluna0;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "CODIGO";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "NOME";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = dr[1].ToString().Trim();

                        linha["CODIGO"] = resultado;
                        linha["NOME"] = resultado1;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_contaQtdEntregadores()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from MOTOBOY";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static String[] fb_buscaNomesEntregadoresListar(int qtd)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select NOME from MOTOBOY";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();

                    String[] resultado = new string[qtd];

                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado[cont] = dr[0].ToString().Trim();
                        cont++;
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_pesquisaIdMotoboyPorNome(String nome)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID from MOTOBOY where NOME = '" + nome + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = -1;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //###############################################ENTREGAS##################################################

        public static int fb_verificaUltIdEntrega()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from ENTREGA where ID = (select max(ID) from ENTREGA)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_adicionaNovaEntrega(Entregas novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (novo.Total.ToString().Contains(","))
                    {
                        addValor = novo.Total.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.Total.ToString();
                    }

                    String addTaxa;
                    if (novo.Taxa.ToString().Contains(","))
                    {
                        addTaxa = novo.Taxa.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTaxa = novo.Taxa.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "insert into ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO, LANCAMENTO) values (" + novo.Id + ", " + novo.Pedido + ", " + novo.Senha + ", '" + novo.Cliente + "', " + addValor + ", " + addTaxa + ", " + novo.Entregador + ", '" + novo.Data + "', " + novo.Pagamento + ", " + novo.Lancamento + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar uma nova entrega de um novo pedido vindo do aplicativo.\nFunção: fb_adicionaNovaEntrega()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static DataTable fb_buscaEntregasPainel(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select senha, cliente, total, entregador from entrega where data like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";
                    String resultado2 = "VAZIA";
                    String resultado3 = "VAZIA";


                    DataTable dt = new DataTable("Entregas");
                    DataColumn coluna, coluna0, coluna1, coluna2;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "SENHA";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "CLIENTE";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "TOTAL";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "ENTREGADOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    Decimal ajuste;
                    int testar = -1;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = dr[1].ToString().Replace("  ", "");

                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;

                        testar = Convert.ToInt32(dr[3]);
                        if (testar == 0 || testar == -1)
                        {
                            resultado3 = "-----";
                        }
                        else
                        {
                            Motoboys buscado = new Motoboys();
                            buscado = fb_pesquisaMotoboyPorCodigo(testar);
                            resultado3 = buscado.Nome.Trim();
                        }

                        linha["SENHA"] = resultado;
                        linha["CLIENTE"] = resultado1.Trim();
                        linha["TOTAL"] = resultado2;
                        linha["ENTREGADOR"] = resultado3.Trim();

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaEntregasPainelPorNome(String data, int cod)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select senha, cliente, total, entregador from entrega where data like '" + data + "%' and entregador = " + cod;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";
                    String resultado2 = "VAZIA";
                    String resultado3 = "VAZIA";


                    DataTable dt = new DataTable("Entregas");
                    DataColumn coluna, coluna0, coluna1, coluna2;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "SENHA";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "CLIENTE";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "TOTAL";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "ENTREGADOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    Decimal ajuste;
                    int testar = -1;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = dr[1].ToString().Replace("  ", "");

                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;

                        testar = Convert.ToInt32(dr[3]);
                        if (testar == 0 || testar == -1)
                        {
                            resultado3 = "-----";
                        }
                        else
                        {
                            Motoboys buscado = new Motoboys();
                            buscado = fb_pesquisaMotoboyPorCodigo(testar);
                            resultado3 = buscado.Nome.Trim();
                        }

                        linha["SENHA"] = resultado;
                        linha["CLIENTE"] = resultado1;
                        linha["TOTAL"] = resultado2;
                        linha["ENTREGADOR"] = resultado3;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaEntregasSemMotoboy(String data, int cod)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select senha, cliente, total from entrega where data like '" + data + "%' and entregador = " + cod;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";
                    String resultado2 = "VAZIA";


                    DataTable dt = new DataTable("Entregas");
                    DataColumn coluna, coluna0, coluna1, coluna2;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "SENHA";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "CLIENTE";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "TOTAL";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    Decimal ajuste;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        resultado1 = dr[1].ToString().Trim();

                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;

                        linha["SENHA"] = resultado;
                        linha["CLIENTE"] = resultado1.Trim();
                        linha["TOTAL"] = resultado2;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaEntregasEditarMotoboy(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select a.senha, a.cliente, a.total, b.nome from entrega a join motoboy b on a.entregador = b.id where data like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";
                    String resultado2 = "VAZIA";
                    String resultado3 = "VAZIA";


                    DataTable dt = new DataTable("Entregas");
                    DataColumn coluna, coluna0, coluna1, coluna2;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "SENHA";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);

                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "CLIENTE";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "TOTAL";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "MOTOBOY";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    Decimal ajuste;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);
                        
                        resultado1 = dr[1].ToString().Trim();
                        
                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;

                        resultado3 = dr[3].ToString().Trim();

                        linha["SENHA"] = resultado;
                        linha["CLIENTE"] = resultado1.Trim();
                        linha["TOTAL"] = resultado2;
                        linha["MOTOBOY"] = resultado3.Trim();

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //#####################################TROCO#######################################

        public static Decimal fb_buscaTrocoMotoboy(int idMot, String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select TROCO from FECHAMENTO where DATA like '" + data + "%' AND ID_MOTOBOY = " + idMot;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    while (dr.Read())
                    {
                        total = Convert.ToDecimal(dr[0]);
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaTrocoMotoboy(int id, String data, Decimal novoTroco)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (novoTroco.ToString().Contains(","))
                    {
                        addValor = novoTroco.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novoTroco.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "update FECHAMENTO set TROCO = " + addValor + " where ID_MOTOBOY = " + id + " AND DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        //#####################################FECHAMENTO######################################

        public static int fb_verificaUltIdFechamento()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from FECHAMENTO where ID = (select max(ID) from FECHAMENTO)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verficaFechamento(int cod, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID from FECHAMENTO where ID_MOTOBOY = " + cod + " AND DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = -1;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);
                        
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_adicionaNovoFechamento(Fechamento novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addTroco;
                    if (novo.Troco.ToString().Contains(","))
                    {
                        addTroco = novo.Troco.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTroco = novo.Troco.ToString();
                    }

                    String addTaxa;
                    if (novo.Taxa.ToString().Contains(","))
                    {
                        addTaxa = novo.Taxa.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTaxa = novo.Taxa.ToString();
                    }

                    String addTotal;

                    if (novo.Total.ToString().Contains(","))
                    {
                        addTotal = novo.Total.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTotal = novo.Total.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "insert into FECHAMENTO (ID, ID_MOTOBOY, TROCO, TAXA, TOTAL, ENTREGA, DATA) values (" + novo.Id + ", " + novo.Motoboy + ", " + addTroco + ", " + addTaxa + ", " + addTotal + ", " + novo.Entrega + ", '" + novo.Data + "')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaEntregaMotoboy(int senha, int motoboy, String data, String nome)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update ENTREGA set ENTREGADOR = " + motoboy + " where SENHA = " + senha + " AND DATA LIKE '" + data + "%' AND CLIENTE LIKE '" + nome + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaEntregaMotoboyOutrosApps(int senha, int motoboy, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update ENTREGA set ENTREGADOR = " + motoboy + " where ID_PEDIDO = 0 AND SENHA = " + senha + " AND DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_pesquisaIdPedido(int senha, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID from PEDIDO where SENHA = " + senha + " and DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);  
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_verificaSeEntregaTemMotoboy(int senha, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ENTREGADOR from ENTREGA where SENHA = " + senha + " AND DATA LIKE '" + data + "%' AND CLIENTE LIKE 'PEDIDOS 10%' AND ID_PEDIDO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaEntregaOutrosApps(Entregas atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addTotal;
                    if (atualizar.Total.ToString().Contains(","))
                    {
                        addTotal = atualizar.Total.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTotal = atualizar.Total.ToString();
                    }

                    String addTaxa;
                    if (atualizar.Taxa.ToString().Contains(","))
                    {
                        addTaxa = atualizar.Taxa.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTaxa = atualizar.Taxa.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "update ENTREGA set TOTAL = " + addTotal + ", TAXA = " + addTaxa + ", PAGAMENTO = " + atualizar.Pagamento + " where SENHA = " + atualizar.Senha + " AND DATA LIKE '" + atualizar.Data + "%' AND CLIENTE LIKE 'PEDIDOS 10%' AND ID_PEDIDO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_excluirPedidoOutrosApps(int idEntrega, int idLancamento)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "delete from ENTREGA where ID = " + idEntrega + ";";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();

                    string mSQL1 = "delete from LANCAMENTO where ID = " + idLancamento + ";";
                    FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                    cmd1.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaLancamento(Entregas atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addTotal;
                    if (atualizar.Total.ToString().Contains(","))
                    {
                        addTotal = atualizar.Total.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTotal = atualizar.Total.ToString();
                    }
                    conexaoFireBird.Open();
                    string mSQL = "update LANCAMENTO set VALOR = " + addTotal + ", PAGAMENTO = " + atualizar.Pagamento + " where ID = " + atualizar.Lancamento;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaLancamentoPedido(Lancamentos atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addTotal;
                    if (atualizar.Valor.ToString().Contains(","))
                    {
                        addTotal = atualizar.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTotal = atualizar.Valor.ToString();
                    }
                    conexaoFireBird.Open();
                    string mSQL = "update LANCAMENTO set VALOR = " + addTotal + ", PAGAMENTO = " + atualizar.Pagamento + ", TIPO = " + atualizar.Pagamento + " where PEDIDO = " + atualizar.Pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaMetodoPagOutrosApps(int senha, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select PAGAMENTO from ENTREGA where SENHA = " + senha + " AND DATA LIKE '" + data + "%' AND CLIENTE LIKE 'PEDIDOS 10%' AND ID_PEDIDO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_buscaIdEntregaExclusaoOutrosApps(int senha, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from ENTREGA where SENHA = " + senha + " AND DATA LIKE '" + data + "%' AND CLIENTE LIKE 'PEDIDOS 10%' AND ID_PEDIDO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaIdEntregaLancamento(int senha, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select LANCAMENTO from ENTREGA where SENHA = " + senha + " AND DATA LIKE '" + data + "%' AND CLIENTE LIKE 'PEDIDOS 10%' AND ID_PEDIDO = 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaEntregasOutrosApps(String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select senha, cliente, total, taxa from entrega where data like '" + data + "%' and id_pedido = 0 and senha != 0";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    String resultado1 = "VAZIA";
                    String resultado2 = "VAZIA";
                    String resultado3 = "VAZIA";


                    DataTable dt = new DataTable("Entregas");
                    DataColumn  coluna0, coluna1, coluna2;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "SENHA";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "TOTAL";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "TAXA";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    Decimal ajuste, ajuste1;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado = Convert.ToInt32(dr[0]);

                        ajuste = Convert.ToDecimal(dr[2]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;

                        ajuste1 = Convert.ToDecimal(dr[3]);
                        string valor1 = ajuste1.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado3 = valor1;

                        linha["SENHA"] = resultado;
                        linha["TOTAL"] = resultado2;
                        linha["TAXA"] = resultado3;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //####################################FECHAMENTO##################################################
        public static int fb_contaEntregasMotoboy(int id, String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from ENTREGA where ENTREGADOR = " + id + " AND DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void insereFechamentoImpressaoEntregas(int cod, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select SENHA, CLIENTE, TOTAL, TAXA from ENTREGA where ENTREGADOR = " + cod + " AND DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int senha = 0;
                    String cliente = "";
                    Decimal valor = 0;
                    Decimal taxa = 0;
                    while (dr.Read())
                    {
                        senha = Convert.ToInt32(dr[0]);
                        cliente = Convert.ToString(dr[1]);
                        cliente = cliente.Substring(0, 20);
                        valor = Convert.ToDecimal(dr[2]);
                        taxa = Convert.ToDecimal(dr[3]);

                        String addTotal;
                        if (valor.ToString().Contains(","))
                        {
                            addTotal = valor.ToString().Replace(",", ".");
                        }
                        else
                        {
                            addTotal = valor.ToString();
                        }

                        String addTaxa;
                        if (taxa.ToString().Contains(","))
                        {
                            addTaxa = taxa.ToString().Replace(",", ".");
                        }
                        else
                        {
                            addTaxa = taxa.ToString();
                        }
                        string mSQL1 = "insert into IMPRESSAO_FECHAMENTO (SENHA, CLIENTE, TOTAL, TAXA) values (" + senha + ", '" + cliente.Trim() + "', '" + addTotal + "', '" + addTaxa + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaQtdEntregaFechamento(int total, int motoboy, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update FECHAMENTO set ENTREGA = " + total + " where ID_MOTOBOY = " + motoboy + " AND DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static Decimal fb_somaTotalTaxaFechamento(int id, String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select TAXA from ENTREGA where ENTREGADOR = " + id + " AND DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaTotalTaxaFechamento(Decimal total, int motoboy, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    String addTotal;
                    if (total.ToString().Contains(","))
                    {
                        addTotal = total.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTotal = total.ToString();
                    }

                    string mSQL = "update FECHAMENTO set TAXA = '" + total + "' where ID_MOTOBOY = " + motoboy + " AND DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static Decimal fb_somaTotalTotalFechamento(int id, String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select TOTAL from ENTREGA where ENTREGADOR = " + id + " AND DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal total = 0;
                    Decimal aux = 0;
                    while (dr.Read())
                    {
                        aux = Convert.ToDecimal(dr[0]);
                        total = total + aux;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaTotalTotalFechamento(Decimal total, int motoboy, String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    String addTotal;
                    if (total.ToString().Contains(","))
                    {
                        addTotal = total.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTotal = total.ToString();
                    }

                    string mSQL = "update FECHAMENTO set TOTAL = '" + addTotal + "' where ID_MOTOBOY = " + motoboy + " AND DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_limpaImpFechamento()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM IMPRESSAO_FECHAMENTO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Fechamento fb_buscaDadosImpressaoFechamento(int id, String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from FECHAMENTO WHERE ID_MOTOBOY = " + id + " AND DATA LIKE '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Fechamento resultado = new Fechamento();
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Motoboy = Convert.ToInt32(dr[1]);
                        resultado.Troco = Convert.ToDecimal(dr[2]);
                        resultado.Taxa = Convert.ToDecimal(dr[3]);
                        resultado.Total = Convert.ToDecimal(dr[4]);
                        resultado.Entrega = Convert.ToInt32(dr[5]);
                        resultado.Data = Convert.ToString(dr[6]);

                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaEntregaDoPedido(int id_pedido, Decimal total,  int pag)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    String addTotal;
                    if (total.ToString().Contains(","))
                    {
                        addTotal = total.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addTotal = total.ToString();
                    }

                    string mSQL = "update ENTREGA set TOTAL = '" + addTotal + "' , PAGAMENTO = " + pag + " where ID_PEDIDO = " + id_pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        //########################TABELA DE ERRO#########################
        public static int fb_recuperaTabelaErro()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select PARAMETRO from ERRO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = -1;
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaTabelaErro(int parametro)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update ERRO set PARAMETRO = " + parametro;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //####################################PEDIDO-SIMULTANEO###############################
        public static int fb_verificaUltIdPedidoEditando()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select PEDIDO from PEDIDO_EDITANDO where PEDIDO = (select max(PEDIDO) from PEDIDO_EDITANDO) order by PEDIDO ASC";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = -1;
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_inserPedidoEditando(int id_pedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "insert into PEDIDO_EDITANDO (PEDIDO) values (" + id_pedido + ")" ;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaPedidoEditando(int id_pedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update PEDIDO_EDITANDO set PEDIDO = " + id_pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaItemTempPedidoEditando(int id_pedido_antigo, int id_pedido_novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update ITEM_PEDIDO_TEMP set ID_PEDIDO = " + id_pedido_novo + " where ID_PEDIDO = " + id_pedido_antigo;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdPedidoItemTemp()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select max(ID_PEDIDO) from ITEM_PEDIDO_TEMP";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = -1;
                    while (dr.Read())
                    {
                        if (dr[0] == DBNull.Value)
                            ultId = 0;
                        else
                            ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        //#######################################ITEM-AVULSO##############################
        public static int fb_verificaUltIdItemAvulso(int senha)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select max(ID_TEMP) from ITEM_PEDIDO_AVULSO  where SENHA_PEDIDO =" + senha;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = 0;
                    while (dr.Read())
                    {
                        if (dr[0] == DBNull.Value)
                            ultId = 0;
                        else
                            ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_contaItemPedAvulso(int senha)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID_TEMP from ITEM_PEDIDO_AVULSO where SENHA_PEDIDO = " + senha;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionarItemAvulso(Itens_Pedido novo, int id_final)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor;
                    if (novo.Valor.ToString().Contains(","))
                    {
                        addValor = novo.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.Valor.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "insert into ITEM_PEDIDO_AVULSO (ID_TEMP, SENHA_PEDIDO, PRODUTO, OBS, VALOR, QTD) values (" + novo.Id + ", " + novo.Id_Pedido + ", '" + novo.Nome + "', '" + novo.Obs + "', " + addValor + ", " + novo.Quantidade + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Itens_Pedido fb_verificaItemAvulsoDuplicado(int id, int senha)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID_TEMP, PRODUTO, OBS, QTD from ITEM_PEDIDO_AVULSO WHERE ID_TEMP = " + id + " AND SENHA_PEDIDO = " + senha;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido retorno = new Itens_Pedido();
                    int i = 0;
                    while (dr.Read())
                    {
                        retorno.Id = Convert.ToInt32(dr[0]);
                        retorno.Nome = Convert.ToString(dr[1]).Trim();
                        retorno.Obs = Convert.ToString(dr[2]).Trim();
                        retorno.Quantidade = Convert.ToInt32(dr[3]);
                        i++;
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaItemAvulsoDuplicado(int id, int nova_qtd, int senha)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update ITEM_PEDIDO_AVULSO set QTD = " + nova_qtd + " where ID_TEMP = " + id + " and SENHA_PEDIDO = " + senha;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static DataTable fb_buscaItensAvulsos(int senha)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID_TEMP, PRODUTO, QTD, VALOR from ITEM_PEDIDO_AVULSO where SENHA_PEDIDO = " + senha + " order by ID_TEMP";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";
                    int resultado1 = 0;
                    int resultado0 = 0;
                    String resultado2;


                    DataTable dt = new DataTable("Itens_Pedido");
                    DataColumn coluna, coluna0, coluna1, coluna2;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "ITEM";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "PRODUTO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "QTD";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "VALOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    Decimal ajuste;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado0 = Convert.ToInt32(dr[0]);
                        resultado = dr[1].ToString();
                        resultado1 = Convert.ToInt32(dr[2]);


                        ajuste = Convert.ToDecimal(dr[3]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;


                        linha["ITEM"] = resultado0;
                        linha["PRODUTO"] = resultado;
                        linha["QTD"] = resultado1;
                        linha["VALOR"] = resultado2;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Decimal fb_totalizaItensAvulsos(int senha)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select VALOR, QTD from ITEM_PEDIDO_AVULSO where SENHA_PEDIDO = " + senha;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal valor = 0;
                    int qtd = 0;
                    Decimal totParc = 0;
                    Decimal total = 0;
                    while (dr.Read())
                    {
                        valor = Convert.ToDecimal(dr[0]);
                        qtd = Convert.ToInt32(dr[1]);
                        totParc = valor * qtd;
                        total = total + totParc;
                    }
                    return total;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaPedidoUsandoSenhaData(int senha, String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO where DATA like '" + data + "%' AND SENHA = " + senha;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int pedido = 0;
                    while (dr.Read())
                    {
                        if (dr[0] == DBNull.Value)
                            pedido = 0;
                        else
                            pedido = Convert.ToInt32(dr[0]);

                    }
                    return pedido;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_buscaTipoPedidoUsandoSenhaData(int senha, String data)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select TIPO from PEDIDO where DATA like '" + data + "%' AND SENHA = " + senha;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int pedido = 0;
                    while (dr.Read())
                    {
                        if (dr[0] == DBNull.Value)
                            pedido = 0;
                        else
                            pedido = Convert.ToInt32(dr[0]);

                    }
                    return pedido;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_excluirItemAvulso(int id_temp)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM ITEM_PEDIDO_AVULSO WHERE ID_TEMP = " + id_temp;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizaIdItemAvulso(int senha)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID_TEMP from ITEM_PEDIDO_AVULSO where SENHA_PEDIDO = " + senha;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int id_temp = 0;
                    int id_final = 0;
                    int cont = 1;
                    while (dr.Read())
                    {
                        id_temp = Convert.ToInt32(dr[0]);
                        id_final = 100;

                        string mSQL1 = "update ITEM_PEDIDO_AVULSO set ID_TEMP = " + cont + "where ID_TEMP = " + id_temp;//" where ID_TEMP = (" + id_temp + " + " + id_final + ")";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                        cont++;
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_limparItemAvulso()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM ITEM_PEDIDO_AVULSO";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaAvulsoEditando(int parametro)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "UPDATE AVULSO_EDITANDO SET EDITANDO = " + parametro;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_adicionaItemAvulsoAoPedido(int idPedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID_TEMP, SENHA_PEDIDO, PRODUTO, OBS, VALOR, QTD from ITEM_PEDIDO_AVULSO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido resultado = new Itens_Pedido();
                    resultado.Id = -1;
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Id = fb_verificaUltIdItemPedido() + 1;
                        resultado.Id_Pedido = Convert.ToInt32(dr[1]);
                        resultado.Id_Pedido = idPedido;
                        resultado.Nome = Convert.ToString(dr[2]);
                        resultado.Obs = Convert.ToString(dr[3]);
                        resultado.Valor = Convert.ToDecimal(dr[4]);
                        resultado.Quantidade = Convert.ToInt32(dr[5]);

                        String addValor;
                        if (resultado.Valor.ToString().Contains(","))
                        {
                            addValor = resultado.Valor.ToString().Replace(",", ".");
                        }
                        else
                        {
                            addValor = resultado.Valor.ToString();
                        }

                        string mSQL1 = "insert into ITEM_PEDIDO (ID, ID_PEDIDO, PRODUTO, OBS, VALOR, QUANTIDADE) values (" + resultado.Id + ", " + resultado.Id_Pedido + ", '" + resultado.Nome + "', '" + resultado.Obs + "', " + addValor + ", " + resultado.Quantidade + ")";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaValorTotalDoPedido(int idPedido, Decimal acrescentar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select VALOR from PEDIDO where ID = " + idPedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Decimal totalFinal = 0;
                    Decimal valorPedidoAtual = 0;
                    while (dr.Read())
                    {
                        valorPedidoAtual = Convert.ToDecimal(dr[0]);
                        totalFinal = valorPedidoAtual + acrescentar;

                        String addValor;
                        if (totalFinal.ToString().Contains(","))
                        {
                            addValor = totalFinal.ToString().Replace(",", ".");
                        }
                        else
                        {
                            addValor = totalFinal.ToString();
                        }

                        string mSQL1 = "UPDATE PEDIDO SET VALOR = " + addValor + " WHERE ID = " + idPedido;
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);

                        string mSQL2 = "UPDATE LANCAMENTO SET VALOR = " + addValor + " WHERE PEDIDO = " + idPedido;
                        FbCommand cmd2 = new FbCommand(mSQL2, conexaoFireBird);

                        cmd1.ExecuteNonQuery();
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static String fb_pesquisaNomeClienteDoPedido(int idPedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select NOME_CLIENTE from PEDIDO where id = " + idPedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String nome = "";
                    while (dr.Read())
                    {
                        nome = dr[0].ToString();
                    }
                    return nome;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void insereItensImpressaoAvulso(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID_TEMP, PRODUTO, OBS, VALOR, QTD from ITEM_PEDIDO_AVULSO where SENHA_PEDIDO = " + cod + "ORDER BY PRODUTO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido resultado = new Itens_Pedido();
                    resultado.Id = -1;
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Nome = Convert.ToString(dr[1]);
                        resultado.Obs = Convert.ToString(dr[2]);
                        resultado.Valor = Convert.ToDecimal(dr[3]);
                        resultado.Quantidade = Convert.ToInt32(dr[4]);

                        String addValor = resultado.Valor.ToString("C", CultureInfo.CurrentCulture);

                        string mSQL1 = "insert into IMPRESSAO_ITENS (ITEM, NOME, OBS, QTD, VALOR) values (" + resultado.Id + ", '" + resultado.Nome.Replace("  ", "") + "', '" + resultado.Obs.Replace("  ", "") + "',  " + resultado.Quantidade + ", '" + addValor + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static DataTable fb_buscaItensPedidoConsultarSenha(int idPedido)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, PRODUTO, QUANTIDADE, VALOR from ITEM_PEDIDO where ID_PEDIDO = " + idPedido + " order by PRODUTO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    String resultado = "VAZIA";
                    int resultado1 = 0;
                    int resultado0 = 0;
                    String resultado2;


                    DataTable dt = new DataTable("Itens_Pedido");
                    DataColumn coluna, coluna0, coluna1, coluna2;

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "ITEM";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.String");
                    coluna.ColumnName = "PRODUTO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.Int32");
                    coluna1.ColumnName = "QTD";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "VALOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    Decimal ajuste;
                    int ordem = 1;

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        resultado0 = Convert.ToInt32(dr[0]);
                        resultado0 = ordem;

                        resultado = dr[1].ToString();
                        resultado1 = Convert.ToInt32(dr[2]);


                        ajuste = Convert.ToDecimal(dr[3]);
                        string valor = ajuste.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        resultado2 = valor;


                        linha["ITEM"] = resultado0;
                        linha["PRODUTO"] = resultado;
                        linha["QTD"] = resultado1;
                        linha["VALOR"] = resultado2;

                        dt.Rows.Add(linha);

                        ordem++;
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_verificaStatusPedidoAvulso()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select EDITANDO from AVULSO_EDITANDO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int status = 0;
                    while (dr.Read())
                    {
                        status = Convert.ToInt32(dr[0]);
                    }
                    return status;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static Pedidos fb_pesquisaPedidoPorId(int idPedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from PEDIDO where ID = " + idPedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Pedidos resultado = new Pedidos();
                    resultado.Id = -1;
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Senha = Convert.ToInt32(dr[1]);
                        resultado.Id_Cliente = Convert.ToInt32(dr[2]);
                        resultado.Nome_Cliente = Convert.ToString(dr[3]).Trim();
                        resultado.Valor = Convert.ToDecimal(dr[4]);
                        resultado.Data = Convert.ToString(dr[5]).Trim();
                        resultado.Observacao = Convert.ToString(dr[6]).Trim();
                        resultado.Pagamento = Convert.ToInt32(dr[7]);
                        resultado.Tipo = Convert.ToInt32(dr[8]);
                        resultado.Desconto = Convert.ToDecimal(dr[9]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static Pedidos fb_pesquisaPedidoPorIdSenhas(int idPedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, SENHA, ID_CLIENTE, NOME_CLIENTE, VALOR, OBSERVACAO, PAGAMENTO, TIPO from PEDIDO where ID = " + idPedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Pedidos resultado = new Pedidos();
                    resultado.Id = -1;
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Senha = Convert.ToInt32(dr[1]);
                        resultado.Id_Cliente = Convert.ToInt32(dr[2]);
                        resultado.Nome_Cliente = Convert.ToString(dr[3]).Trim();
                        resultado.Valor = Convert.ToDecimal(dr[4]);
                        resultado.Observacao = Convert.ToString(dr[5]).Trim();
                        resultado.Pagamento = Convert.ToInt32(dr[6]);
                        resultado.Tipo = Convert.ToInt32(dr[7]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //######################PARAMETROS##############################
        public static Parametros fb_recuperaParametrosSistema()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from CONFIGURACAO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Parametros parametros = new Parametros();
                    while (dr.Read())
                    {
                        parametros.motoboy = Convert.ToInt32(dr[0]);
                        parametros.retirada = Convert.ToInt32(dr[1]);
                        parametros.entrega = Convert.ToInt32(dr[2]);
                        parametros.inicio = Convert.ToString(dr[3]);
                        parametros.fim = Convert.ToString(dr[4]);
                        parametros.seg = Convert.ToInt32(dr[5]);
                        parametros.ter = Convert.ToInt32(dr[6]);
                        parametros.qua = Convert.ToInt32(dr[7]);
                        parametros.qui = Convert.ToInt32(dr[8]);
                        parametros.sex = Convert.ToInt32(dr[9]);
                        parametros.sab = Convert.ToInt32(dr[10]);
                        parametros.dom = Convert.ToInt32(dr[11]);
                        parametros.dom = Convert.ToInt32(dr[11]);
                        parametros.sincronizar = Convert.ToInt32(dr[12]);
                        parametros.manutencao = Convert.ToInt32(dr[13]);
                    }
                    return parametros;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizarParametrosSistema(Parametros parametros)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "UPDATE CONFIGURACAO SET PAR_MOTOBOY_UNICO = " + parametros.motoboy + ", " +
                        "TEMPO_RETIRADA = " + parametros.retirada + ", " +
                        "TEMPO_ENTREGA = " + parametros.entrega + ", " +
                        "HORARIO_INICIO = '" + parametros.inicio + "', " +
                        "HORARIO_FIM = '" + parametros.fim + "', " +
                        "DIA_SEGUNDA = " + parametros.seg + ", " +
                        "DIA_TERCA = " + parametros.ter + ", " +
                        "DIA_QUARTA = " + parametros.qua  + ", " +
                        "DIA_QUINTA = " + parametros.qui + ", " +
                        "DIA_SEXTA = " + parametros.sex + ", " +
                        "DIA_SABADO = " + parametros.sab + ", " +
                        "DIA_DOMINGO = " + parametros.dom + ", " +
                        "PAR_SINCRONIZAR = " + parametros.sincronizar + ", " +
                        "PAR_MANUTENCAO = " + parametros.manutencao;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        //#########################FIREBASE#########################################

        public static void sincronizaCardapioFirebirdComFirebase(IFirebaseConfig config, IFirebaseClient client)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    var delete = client.Delete(@"cardapio/");


                    conexaoFireBird.Open();
                    string mSQL = "Select * from PRODUTO order by GRUPO ASC, TIPO ASC";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int identificadorFB = 0;
                    while (dr.Read())
                    {
                        identificadorFB++;
                        Itens_Firebase inserir = new Itens_Firebase();
                        inserir.id = identificadorFB;
                        inserir.nome = dr[1].ToString().Trim();
                        inserir.valor = Convert.ToDecimal(dr[2]);
                        inserir.descricao = dr[3].ToString().Trim();
                        inserir.tipo = Convert.ToInt32(dr[4]);
                        inserir.grupo = Convert.ToInt32(dr[5]);

                        int parametroApp = Convert.ToInt32(dr[6]);

                        if(parametroApp == 1)
                        {
                            String chaveOndeAdicionar = inserir.id.ToString().PadLeft(5, '0');
                            var set = client.Set(@"cardapio/" + chaveOndeAdicionar, inserir);
                        }
                
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void sincronizaCardapioFirebirdComGarcom(IFirebaseConfig config, IFirebaseClient client)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    var delete = client.Delete(@"itens/");


                    conexaoFireBird.Open();
                    string mSQL = "Select * from PRODUTO order by GRUPO ASC, TIPO ASC";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int identificadorFB = 0;
                    while (dr.Read())
                    {
                        identificadorFB++;
                        Itens_Firebase inserir = new Itens_Firebase();
                        inserir.id = identificadorFB;
                        inserir.nome = dr[1].ToString().Trim();
                        inserir.valor = Convert.ToDecimal(dr[2]);
                        inserir.descricao = dr[3].ToString().Trim();
                        inserir.tipo = Convert.ToInt32(dr[4]);
                        inserir.grupo = Convert.ToInt32(dr[5]);

                        int parametroApp = Convert.ToInt32(dr[6]);

                        String chaveOndeAdicionar = inserir.id.ToString().PadLeft(5, '0');
                        var set = client.Set(@"itens/" + chaveOndeAdicionar, inserir);

                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void sincronizaTaxasFirebirdComFirebase(IFirebaseConfig config, IFirebaseClient client)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    var delete = client.Delete(@"taxa/");

                    conexaoFireBird.Open();
                    string mSQL = "Select * from TAXA";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        TaxasFirebase inserir = new TaxasFirebase();
                        inserir.id = Convert.ToInt32(dr[0]);
                        inserir.bairro = dr[1].ToString().Trim();
                        inserir.valor = Convert.ToDecimal(dr[2]);

                        String chaveOndeAdicionar = inserir.id.ToString().PadLeft(5, '0');
                        var set = client.Set(@"taxa/" + chaveOndeAdicionar, inserir);
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<PedidoMonitor> fb_recuperaListaPedidosMonitor()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from PEDIDO_MONITOR";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<PedidoMonitor> resultado = new List<PedidoMonitor>();
                    while (dr.Read())
                    {
                        PedidoMonitor retorno = new PedidoMonitor();
                        retorno.Id = Convert.ToInt32(dr[0]);
                        retorno.Identificador = RemoverAcentos(dr[1].ToString());
                        retorno.Nome = dr[2].ToString();
                        retorno.Celular = dr[3].ToString();
                        retorno.Tipo = Convert.ToInt32(dr[4]);
                        retorno.Valor = Convert.ToDecimal(dr[5]);
                        retorno.Data = dr[6].ToString();
                        retorno.Status = Convert.ToInt32(dr[7]);
                        retorno.Senha = Convert.ToInt32(dr[8]);

                        resultado.Add(retorno);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao recuperar a lista de pedidos do monitor de pedidos.\nFunção: fb_recuperaListaPedidosMonitor()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<Comanda> fb_recuperaListaComandas(String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from COMANDA where data like '"+ data.Replace("/","-") +"%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Comanda> resultado = new List<Comanda>();
                    while (dr.Read())
                    {
                        Comanda retorno = new Comanda();
                        int id = Convert.ToInt32(dr[0]);
                        retorno.id = dr[1].ToString().Trim();
                        retorno.data = RemoverAcentos(dr[2].ToString());
                        retorno.mesa = Convert.ToInt32(dr[3]);
                        retorno.total = Convert.ToDecimal(dr[4]);
                        retorno.pagamento = Convert.ToInt32(dr[5]);
                        retorno.fechamento = Convert.ToInt32(dr[6]);

                        resultado.Add(retorno);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao recuperar a lista de pedidos do monitor de pedidos.\nFunção: fb_recuperaListaPedidosMonitor()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static List<Entregas> fb_recuperaListaEntregas(String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from ENTREGA WHERE DATA like '" + data + "%'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    List<Entregas> resultado = new List<Entregas>();
                    while (dr.Read())
                    {
                        Entregas retorno = new Entregas();
                        retorno.Id = Convert.ToInt32(dr[0]);
                        retorno.Pedido = Convert.ToInt32(dr[1]);
                        retorno.Senha = Convert.ToInt32(dr[2]);
                        retorno.Cliente = RemoverAcentos(dr[3].ToString());
                        retorno.Total = Convert.ToDecimal(dr[4]);
                        retorno.Taxa = Convert.ToDecimal(dr[5]);
                        retorno.Entregador = Convert.ToInt32(dr[6]);
                        retorno.Data = dr[7].ToString();
                        retorno.Pagamento = Convert.ToInt32(dr[8]);
                        retorno.Lancamento = Convert.ToInt32(dr[9]);

                        resultado.Add(retorno);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao recuperar a lista de pedidos do monitor de pedidos.\nFunção: fb_recuperaListaPedidosMonitor()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
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
        public static void fb_inserirItensFirebaseNoPedido(List<Itens_Pedido_Firebase> listaItens, int idPedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    for(int i = 0; i < listaItens.Count; i++)
                    {
                        Itens_Pedido_Firebase itemLista = listaItens[i];
                        Itens_Pedido inserir = new Itens_Pedido();

                        inserir.Id = fb_verificaUltIdItemPedido() + 1;
                        inserir.Id_Pedido = idPedido;
                        inserir.Nome = itemLista.desc_item.Replace("'", " ").Trim();
                        if (inserir.Nome.Length > 40)
                            inserir.Nome = inserir.Nome.Remove(40, inserir.Nome.Length - 40);
                        //inserir.Obs = itemLista.adicionais_item.Trim() + RemoverAcentos(itemLista.obs_item.Replace("'", " ").Trim().ToUpper());
                        inserir.Obs = itemLista.adicionais_item.Trim() + "\n" + RemoverAcentos(itemLista.obs_item.Replace("'", " ").Trim().ToUpper());
                        if (inserir.Obs.Length > 100)
                            inserir.Obs = inserir.Obs.Remove(100, inserir.Nome.Length - 100);
                        inserir.Valor = Convert.ToDecimal(itemLista.valor_item);
                        inserir.Quantidade = itemLista.qtd_item;

                        String addValor;
                        if (inserir.Valor.ToString().Contains(","))
                        {
                            addValor = inserir.Valor.ToString().Replace(",", ".");
                        }
                        else
                        {
                            addValor = inserir.Valor.ToString();
                        }

                        string mSQL1 = "insert into ITEM_PEDIDO (ID, ID_PEDIDO, PRODUTO, OBS, VALOR, QUANTIDADE) values (" + inserir.Id + ", " + inserir.Id_Pedido + ", '" + inserir.Nome + "', '" + inserir.Obs + "', " + addValor + ", " + inserir.Quantidade + ")";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();
                    }
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar um item de um novo pedido vindo do aplicativo.\nFunção: fb_inserirItensFirebaseNoPedido()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void insereItensFirebaseImpressao(int cod)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select PRODUTO, OBS, VALOR, QUANTIDADE from ITEM_PEDIDO where ID_PEDIDO = " + cod + "ORDER BY PRODUTO";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido resultado = new Itens_Pedido();
                    resultado.Id = -1;
                    int cont = 0;
                    while (dr.Read())
                    {
                        cont++;
                        resultado.Id = cont;
                        resultado.Nome = Convert.ToString(dr[0]).Trim();
                        resultado.Obs = Convert.ToString(dr[1]).Trim();
                        resultado.Valor = Convert.ToDecimal(dr[2]);
                        resultado.Quantidade = Convert.ToInt32(dr[3]);

                        String addValor = resultado.Valor.ToString("C", CultureInfo.CurrentCulture);
                        addValor = addValor.Substring(2, (addValor.Length - 2));

                        resultado.Nome = RemoverAcentos(resultado.Nome);
                        if (resultado.Nome.Length > 50)
                            resultado.Nome = resultado.Nome.Remove(50);
                        resultado.Obs = RemoverAcentos(resultado.Obs);
                        if (resultado.Obs.Length > 100)
                            resultado.Obs = resultado.Obs.Remove(100);

                        string mSQL1 = "insert into IMPRESSAO_ITENS (ITEM, NOME, OBS, QTD, VALOR) values (" + resultado.Id + ", '" + resultado.Nome.Trim() + "', '" + resultado.Obs.Trim() + "',  " + resultado.Quantidade + ", '" + addValor + "')";
                        FbCommand cmd1 = new FbCommand(mSQL1, conexaoFireBird);
                        cmd1.ExecuteNonQuery();

                    }
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar os itens vindos do app para a impressão de um pedido.\nFunção: insereItensFirebaseImpressao()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdMonitor()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from PEDIDO_MONITOR where ID = (select max(ID) from PEDIDO_MONITOR)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionarPedidoMonitor(PedidoMonitor novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    String addValor;
                    if (novo.Valor.ToString().Contains(","))
                    {
                        addValor = novo.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.Valor.ToString();
                    }

                    string mSQL = "insert into PEDIDO_MONITOR (ID, IDENTIFICADOR, NOME, CELULAR, TIPO, VALOR, DATA, STATUS, SENHA) " +
                        "values (" + novo.Id + "," +
                        " '" + novo.Identificador.Trim() + "'," +
                        " '" + novo.Nome.Trim() + "'," +
                        " '" + novo.Celular.Trim() + "'," +
                        " " + novo.Tipo + "," +
                        " " + addValor + ", " +
                        "'" + novo.Data.Trim() + "'," +
                        " " + novo.Status + ", " +
                        " " + novo.Senha + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar um novo pedido no monitor do aplicativo.\nFunção: fb_adicionarPedidoMonitor()\n\nErro:\n\n" + fbex.ToString(), "Erro");
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void limpaMonitorPedidosApp(String data)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM PEDIDO_MONITOR WHERE DATA != '" + data + "'";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaPedidosMonitor()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, SENHA, NOME, VALOR, TIPO, STATUS from PEDIDO_MONITOR";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int id = 0;
                    int senha = 0;
                    String nome = "VAZIA";
                    Decimal valorDec = 0;
                    String valorStr = "VAZIA";
                    int tipoInt = 0;
                    String tipoString = "VAZIA";
                    int statusInt = 0;
                    String statusStr = "VAZIA";


                    DataTable dt = new DataTable("Pedidos");
                    DataColumn coluna, coluna0, coluna1, coluna2, coluna3, coluna4;

                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.Int32");
                    coluna.ColumnName = "CODIGO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);

                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.Int32");
                    coluna0.ColumnName = "SENHA";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);


                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "CLIENTE";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "VALOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    coluna3 = new DataColumn();
                    coluna3.DataType = System.Type.GetType("System.String");
                    coluna3.ColumnName = "TIPO";
                    coluna3.ReadOnly = false;
                    coluna3.Unique = false;
                    dt.Columns.Add(coluna3);

                    coluna4 = new DataColumn();
                    coluna4.DataType = System.Type.GetType("System.String");
                    coluna4.ColumnName = "STATUS";
                    coluna4.ReadOnly = false;
                    coluna4.Unique = false;
                    dt.Columns.Add(coluna4);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        id = Convert.ToInt32(dr[0]);
                        senha = Convert.ToInt32(dr[1]);
                        nome = dr[2].ToString().Trim();
                        
                        valorDec = Convert.ToDecimal(dr[3]);
                        valorStr = valorDec.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        
                        tipoInt = Convert.ToInt32(dr[4]);
                        if (tipoInt == 1)
                            tipoString = "ENTREGA";
                        if (tipoInt == 2)
                            tipoString = "RETIRADA";
                        if (tipoInt == 3)
                            tipoString = "CONSUMO NO LOCAL";

                        statusInt = Convert.ToInt32(dr[5]);
                        if (statusInt == 0)
                            statusStr = "EM PREPARAÇÃO";
                        if (statusInt == 1)
                            statusStr = "SAIU PARA ENTREGA";
                        if (statusInt == 2)
                            statusStr = "PRONTO";
                        if (statusInt == 3)
                            statusStr = "FINALIZADO";

                        linha["CODIGO"] = id;
                        linha["SENHA"] = senha;
                        linha["CLIENTE"] = nome;
                        linha["VALOR"] = valorStr;
                        linha["TIPO"] = tipoString;
                        linha["STATUS"] = statusStr;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static PedidoMonitor fb_pesquisPedidoMonitorPorId(int idMonitor)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from PEDIDO_MONITOR where ID = " + idMonitor;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    PedidoMonitor resultado = new PedidoMonitor();
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Identificador = dr[1].ToString().Trim();
                        resultado.Nome = dr[2].ToString().Trim();
                        resultado.Celular = dr[3].ToString().Trim();
                        resultado.Tipo = Convert.ToInt32(dr[4]);
                        resultado.Valor = Convert.ToDecimal(dr[5]);
                        resultado.Data = dr[6].ToString().Trim();
                        resultado.Status = Convert.ToInt32(dr[7]);
                        resultado.Senha = Convert.ToInt32(dr[8]);

                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaStatusPedido(int idAtualizar, int novoStatus)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "update PEDIDO_MONITOR set STATUS = " + novoStatus + " where ID = " + idAtualizar;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static DataTable fb_buscaCuponsConsulta()
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, DESCRICAO, TIPO, VALOR from CUPOM";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int id = 0;
                    String descricao = "VAZIA";
                    int tipoInt = 0;
                    String tipoStr = "VAZIA";
                    Decimal valorDec = 0;
                    String valorStr = "VAZIA";


                    DataTable dt = new DataTable("Cupons");
                    DataColumn coluna, coluna0, coluna1, coluna2;

                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.Int32");
                    coluna.ColumnName = "CODIGO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);


                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.String");
                    coluna0.ColumnName = "DESCRICAO";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "TIPO";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "VALOR";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        id = Convert.ToInt32(dr[0]);
                        descricao = dr[1].ToString().Trim();

                        tipoInt = Convert.ToInt32(dr[2]);
                        if (tipoInt == 1)
                            tipoStr = "PORCENTAGEM";
                        else
                            tipoStr = "VALOR EM R$";

                        valorDec = Convert.ToDecimal(dr[3]);
                        valorStr = valorDec.ToString("C", CultureInfo.CurrentCulture); //Faz a conversão para R$
                        if(tipoInt == 1)
                            valorStr = valorStr.Replace("R$", "") + "%";


                        linha["CODIGO"] = id;
                        linha["DESCRICAO"] = descricao;
                        linha["TIPO"] = tipoStr;
                        linha["VALOR"] = valorStr;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static Cupom fb_pesquisaCupomPorId(int id)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from CUPOM where ID = " + id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Cupom resultado = new Cupom();
                    while (dr.Read())
                    {
                        resultado.Id = Convert.ToInt32(dr[0]);
                        resultado.Descricao = dr[1].ToString().Trim();
                        resultado.Validade = dr[2].ToString().Trim();
                        resultado.Minimo = Convert.ToDecimal(dr[3]);
                        resultado.Tipo = Convert.ToInt32(dr[4]);
                        resultado.Valor = Convert.ToDecimal(dr[5]);
                        resultado.cupomUnico = Convert.ToInt32(dr[6]);
                    }
                    return resultado;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_excluirCupom(int idCupom)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "DELETE FROM CUPOM WHERE ID = " + idCupom;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void sincronizaCuponsFirebirdComFirebase(IFirebaseConfig config, IFirebaseClient client)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    var delete = client.Delete(@"cupom/");

                    conexaoFireBird.Open();
                    string mSQL = "Select * from CUPOM";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        CupomFirebase inserir = new CupomFirebase();
                        inserir.id = Convert.ToInt32(dr[0]);
                        inserir.descricao = dr[1].ToString().Trim();
                        inserir.validade = dr[2].ToString().Trim();
                        inserir.minimo = Convert.ToDecimal(dr[3]);
                        inserir.tipo = Convert.ToInt32(dr[4]);
                        inserir.valor = Convert.ToDecimal(dr[5]);
                        inserir.cupomUnico = Convert.ToInt32(dr[6]);

                        String chaveOndeAdicionar = inserir.id.ToString().PadLeft(5, '0');
                        var set = client.Set(@"cupom/" + chaveOndeAdicionar, inserir);
                    }
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static int fb_verificaUltIdCupom()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from CUPOM where ID = (select max(ID) from CUPOM)";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int ultId = new int();
                    while (dr.Read())
                    {
                        ultId = Convert.ToInt32(dr[0]);

                    }
                    return ultId;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_adicionarCupom(Cupom novo)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor, addValor1;
                    if (novo.Valor.ToString().Contains(","))
                    {
                        addValor = novo.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = novo.Valor.ToString();
                    }
                    if (novo.Minimo.ToString().Contains(","))
                    {
                        addValor1 = novo.Minimo.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor1 = novo.Minimo.ToString();
                    }

                    conexaoFireBird.Open();
                    string mSQL = "insert into CUPOM (ID, DESCRICAO, VALIDADE, MINIMO, TIPO, VALOR, UNICO) values " +
                        "(" + novo.Id + ", " +
                        "'" + novo.Descricao + "', " +
                        "'" + novo.Validade + "', " +
                        "" + addValor1 + ", " +
                        "" + novo.Tipo + "," +
                        "" + addValor + "," +
                        "" + novo.cupomUnico + ")";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_atualizaCupom(Cupom atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    String addValor, addValor1;
                    if (atualizar.Valor.ToString().Contains(","))
                    {
                        addValor = atualizar.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = atualizar.Valor.ToString();
                    }
                    if (atualizar.Minimo.ToString().Contains(","))
                    {
                        addValor1 = atualizar.Minimo.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor1 = atualizar.Minimo.ToString();
                    }
                    conexaoFireBird.Open();
                    string mSQL = "UPDATE CUPOM SET " +
                        "DESCRICAO = '" + atualizar.Descricao + "', " +
                        "VALIDADE = '" + atualizar.Validade + "', " +
                        "MINIMO = " + addValor1 + ", " +
                        "TIPO = " + atualizar.Tipo + ", " +
                        "VALOR = " + addValor + ", " +
                        "UNICO = " + atualizar.cupomUnico +
                        " WHERE ID = " + atualizar.Id;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }

        }

        public static Itens_Pedido fb_recuperaItemPedidoTemp(int idItem, int idPedido)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select * from ITEM_PEDIDO_TEMP WHERE ID_TEMP = " + idItem + " AND ID_PEDIDO = " + idPedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Itens_Pedido retorno = new Itens_Pedido();
                    while (dr.Read())
                    {
                        retorno.Id = Convert.ToInt32(dr[0]);
                        retorno.Id_Produto = Convert.ToInt32(dr[1]);
                        retorno.Id_Pedido = Convert.ToInt32(dr[2]);
                        retorno.Nome = Convert.ToString(dr[3]).Trim();

                        int id_produto = AcessoFB.fb_pesquisaProdutoPorNomeRetornaCod(retorno.Nome.Trim());

                        retorno.Id_Produto = id_produto;

                        retorno.Obs = Convert.ToString(dr[4]);
                        retorno.Valor = Convert.ToDecimal(dr[5]);
                        retorno.Quantidade = Convert.ToInt32(dr[6]);
                    }
                    return retorno;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_atualizarItemPedidoTemp(Itens_Pedido atualizar)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    String addValor;
                    if (atualizar.Valor.ToString().Contains(","))
                    {
                        addValor = atualizar.Valor.ToString().Replace(",", ".");
                    }
                    else
                    {
                        addValor = atualizar.Valor.ToString();
                    }
                    string mSQL = "UPDATE ITEM_PEDIDO_TEMP SET " +
                        "OBS = '" + atualizar.Obs + "', " +
                        "VALOR = " + addValor + ", " +
                        "QUANTIDADE = " + atualizar.Quantidade + " " +
                        "WHERE ID_TEMP = " + atualizar.Id + " " +
                        "AND ID_PEDIDO = " + atualizar.Id_Pedido;
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }


        public static DataTable fb_buscaEnderecosConsulta(String celular)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select ID, RUA, NUMERO, BAIRRO from CLIENTE WHERE CELULAR = '" + celular + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int id = 0;
                    String rua = "VAZIA";
                    String numero = "VAZIA";
                    String bairro = "VAZIA";


                    DataTable dt = new DataTable("Enderecos");
                    DataColumn coluna, coluna0, coluna1, coluna2;

                    coluna = new DataColumn();
                    coluna.DataType = System.Type.GetType("System.Int32");
                    coluna.ColumnName = "CODIGO";
                    coluna.ReadOnly = false;
                    coluna.Unique = false;
                    dt.Columns.Add(coluna);


                    coluna0 = new DataColumn();
                    coluna0.DataType = System.Type.GetType("System.String");
                    coluna0.ColumnName = "RUA";
                    coluna0.ReadOnly = false;
                    coluna0.Unique = false;
                    dt.Columns.Add(coluna0);

                    coluna1 = new DataColumn();
                    coluna1.DataType = System.Type.GetType("System.String");
                    coluna1.ColumnName = "Nº";
                    coluna1.ReadOnly = false;
                    coluna1.Unique = false;
                    dt.Columns.Add(coluna1);

                    coluna2 = new DataColumn();
                    coluna2.DataType = System.Type.GetType("System.String");
                    coluna2.ColumnName = "BAIRRO";
                    coluna2.ReadOnly = false;
                    coluna2.Unique = false;
                    dt.Columns.Add(coluna2);

                    while (dr.Read())
                    {
                        DataRow linha;
                        linha = dt.NewRow();

                        id = Convert.ToInt32(dr[0]);
                        rua = dr[1].ToString().Trim();
                        numero = dr[2].ToString().Trim();
                        bairro = dr[3].ToString().Trim();

                        linha["CODIGO"] = id;
                        linha["RUA"] = rua;
                        linha["Nº"] = numero;
                        linha["BAIRRO"] = bairro;

                        dt.Rows.Add(linha);
                    }
                    return dt;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static int fb_contaQtdCadastrosCliente(String numCelular)
        {

            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "select ID from CLIENTE WHERE CELULAR = '" + numCelular + "'";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    int resultado = 0;
                    int cont = 0;
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr[0]);

                        cont++;
                    }
                    return cont;
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
    }
}
