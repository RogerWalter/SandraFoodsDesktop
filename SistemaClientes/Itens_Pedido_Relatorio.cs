using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Itens_Pedido_Relatorio
    {
        public int Id { get; set; }
        public int Id_Pedido { get; set; }
        public int Id_Produto { get; set; }
        public String Nome { get; set; }
        public String Obs { get; set; }
        public Decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public int Grupo { get; set; }
    }
}
