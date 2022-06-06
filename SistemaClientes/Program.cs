using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //NÃO PERMITIR QUE O PROGRAMA SEJA ABERTO DUAS VEZES NO PC:
            String thisprocessname = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
            //Application.Run(new PedidosNaNuvem());
            //Application.Run(new MonitorAplicativo());
            //Application.Run(new Pedido());
            //Application.Run(new ConsultarPedido());
        }
    }
}
