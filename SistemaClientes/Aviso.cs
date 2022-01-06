using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public class Aviso
    {
        public int aviso; // 0 - NÃO POSSUI | 1 - POSSUI
        public String data; //data de validade do aviso
        public String imagem;

        public Aviso(int aviso, String data, String imagem)
        {
            this.aviso = aviso;
            this.data = data;
            this.imagem = imagem;
        }

        public Aviso()
        {

        } 
    }
}
