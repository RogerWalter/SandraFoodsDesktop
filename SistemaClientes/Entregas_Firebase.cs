using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Entregas_Firebase
    {
        public String cliente { get; set; }
        public Decimal total { get; set; }
        public Decimal taxa { get; set; }
        public int pagamento { get; set; }
    }
}
