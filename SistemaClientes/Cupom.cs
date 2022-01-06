using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Cupom
    {
        public int Id { get; set; }
        public String Descricao { get; set; }
        public String Validade { get; set; }
        public Decimal Minimo { get; set; }
        public int Tipo { get; set; } // 1 - PORCENTAGEM | 2 - VALOR EM REAIS
        public Decimal Valor { get; set; }
        public int cupomUnico { get; set; } // 0 - NÃO | 1 - SIM
    }
}
