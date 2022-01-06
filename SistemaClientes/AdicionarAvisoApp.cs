using Firebase.Storage;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class AdicionarAvisoApp : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "tJVQSamSvHRtZguzUcn0h3YfPGFoEjl37nI2uNDD",
            BasePath = "https://sandra-foods-34d79-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
        public AdicionarAvisoApp()
        {
            InitializeComponent();
        }

        private void AdicionarAvisoApp_Load(object sender, EventArgs e)
        {
            btConfirmar.Enabled = false;
            btCancelar.Enabled = false;
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar ao Firebase.\nVerifique sua conexão com a internet e tente acessar esta tela novamente.", "Erro");
                this.Close();
            }
        }

        String diretorioImagem;
        private void btAdd_Click(object sender, EventArgs e)
        {
            btAdd.Enabled = false;
            btExcluir.Enabled = false;
            btConfirmar.Enabled = true;
            btCancelar.Enabled = true;
            tbValidade.Enabled = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Escolha a imagem para o aviso";
            ofd.Filter = "Image Files (*.png; *.jpg; *.jpeg) | *.png; *.jpg; *.jpeg"; ;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                diretorioImagem = ofd.FileName;
                using (var img = new Bitmap(diretorioImagem))
                {
                    imagemSelecionada.Image = new Bitmap(img);
                }
                tbValidade.Focus();
                tbValidade.Select();
            }

            else
            {
                btConfirmar.Enabled = false;
                btCancelar.Enabled = false;
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta ação removerá o aviso antigo do aplicativo, se houver. \n Continuar?", "Remover Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("Deseja realmente continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //limpar aviso existente no App
                    Aviso novo = new Aviso(0, "01/01/2001", "xxxxx");
                    try
                    {
                        var set = client.Set(@"aviso/", novo);
                    }
                    catch
                    {
                        MessageBox.Show("Ocorreu um problema ao excluir o aviso do Aplicativo.\nTente novamente.", "Erro");
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
            btAdd.Enabled = true;
            btExcluir.Enabled = true;
            btConfirmar.Enabled = false;
            btCancelar.Enabled = false;
        }

        String downloadLink;
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            String dataValidade = tbValidade.Text.ToString();
            DateTime dataValidadeFinal;
            if (!DateTime.TryParse(dataValidade, out dataValidadeFinal))
            {
                MessageBox.Show("Data de validade é inválida.\nVerifique e tente novamente.", "Aviso");
                tbValidade.Focus();
                tbValidade.Select();
                return;
            }
            dataValidade = dataValidadeFinal.ToString();
            //SALVAMOS NO FIREBASE OS DADOS
            UploadFiles(dataValidade);
        }

        private async void UploadFiles(String dataValidade)
        {
            lbProgressoDesc.Visible = true;
            labelPorcentagem.Visible = true;
            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.Open(diretorioImagem, FileMode.Open);
            //authentication
            //var auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyBDIIgK7hZ1IarMO9b8rjL2LkCBg84ZaEQ"));
            //var a = await auth.SignInWithEmailAndPasswordAsync("roger.walter.ssoft@gmail.com", "DoDg3123");

            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage(
                "sandra-foods-34d79.appspot.com"/*,
                 new FirebaseStorageOptions
                 {
                     AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                     ThrowOnCancel = true,
                 }*/)
                .Child("aviso")
                .Child("aviso.png")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => labelPorcentagem.Text = $"{e.Percentage}%";
            // await the task to wait until upload completes and get the download url
            try
            {
                downloadLink = await task;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Aviso novo = new Aviso();
            novo.aviso = 1;
            novo.data = dataValidade.Substring(0, 10);
            novo.imagem = downloadLink;
            var set = client.Set(@"aviso/", novo);
            lbProgressoDesc.Visible = false;
            labelPorcentagem.Visible = false;
            MessageBox.Show("Aviso inserido com sucesso!", "Concluído");
            //utilizacao do link gerado anteriormente           
            diretorioImagem = null;
            imagemSelecionada.Image = null;
            tbValidade.Text = "";
            tbValidade.Enabled = false;

            btAdd.Enabled = true;
            btExcluir.Enabled = true;
            btConfirmar.Enabled = false;
            btCancelar.Enabled = false;

            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            lbProgressoDesc.Visible = false;
            labelPorcentagem.Visible = false;
            diretorioImagem = null;
            imagemSelecionada.Image = null;
            tbValidade.Text = "";
            tbValidade.Enabled = false;
            btConfirmar.Enabled = false;
            btCancelar.Enabled = false;
            btAdd.Enabled = true;
            btExcluir.Enabled = true;
        }
    }
}
