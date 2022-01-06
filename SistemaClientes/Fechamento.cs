using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Fechamento
    {
        public int Id { get; set; }
        public int Motoboy { get; set; }
        public Decimal Troco { get; set; }
        public Decimal Taxa { get; set; }
        public Decimal Total { get; set; }
        public int Entrega { get; set; }
        public String Data { get; set; }
    }
}
