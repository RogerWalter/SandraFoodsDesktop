using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Entregas
    {
        public int Id { get; set; }
        public int Pedido { get; set; }
        public int Senha { get; set; }
        public String Cliente { get; set; }
        public Decimal Total { get; set; }
        public Decimal Taxa { get; set; }
        public int Entregador { get; set; }
        public String Data { get; set; }
        public int Pagamento { get; set; }

        public int Lancamento { get; set; }
    }
}
