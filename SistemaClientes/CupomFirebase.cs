using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class CupomFirebase
    {
        public int id { get; set; }
        public String descricao { get; set; }
        public String validade { get; set; }
        public Decimal minimo { get; set; }
        public int tipo { get; set; } // 1 - PORCENTAGEM | 2 - VALOR EM REAIS
        public Decimal valor { get; set; }
        public int cupomUnico { get; set; } // 0 - NÃO | 1 - SIM
    }
}
