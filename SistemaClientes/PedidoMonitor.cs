using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class PedidoMonitor
    {
        public int Id { get; set; }
        public int Senha { get; set; }
        public String Identificador { get; set; }
        public String Nome { get; set; }
        public String Celular { get; set; }
        public int Tipo { get; set; } //1 - ENTREGA | 2 - RETIRADA | 3 - CONSUMO NO LOCAL
        public Decimal Valor { get; set; }
        public String Data { get; set; }
        public int Status { get; set; } //0 - EM PREPARACAO # 1 - SAIU PARA ENTREGA # 2 - PRONTO PARA RETIRADA/CONSUMO # 3 - FINALIZADO
    }
}
