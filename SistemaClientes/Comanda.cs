using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Comanda
    {
        public String id { get; set; }
        public String data { get; set; }
        public int mesa { get; set; }
        public Decimal total { get; set; }
        public int pagamento { get; set; } //0 - DINHEIRO | 1 - CARTÃO | 2 - PIX
        public int fechamento { get; set; } //0 - PARCIAL | 1 - TOTAL
    }
}
