using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class ItemComanda
    {
        public String id { get; set; }
        public int mesa { get; set; }
        public String data { get; set; }
        public String nome { get; set; }
        public Decimal valor { get; set; }
        public int qtd { get; set; }
        public int grupo { get; set; }
    }
}
