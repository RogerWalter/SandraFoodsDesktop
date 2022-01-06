using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Itens_Firebase
    {
        public int id { get; set; }
        public String nome { get; set; }
        public Decimal valor { get; set; }
        public String descricao { get; set; }
        public int tipo { get; set; }
        public int grupo { get; set; }
    }
}
