using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Lancamentos
    {
        public int Id { get; set; }
        public int Tipo { get; set; } // 0 - OUTROS APPS | 1 - ENTREGA | 2 - BALCAO | 3 - LOCAL | 9 - ATENDIMENTO GARÇOM
        public int Pagamento { get; set; }
        public Decimal Valor { get; set; }
        public String Data { get; set; }
        public int Pedido { get; set; }
    }
}
