using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class PedidoFirebase
    {
        public String clt_nome { get; set; }
        public String clt_celular { get; set; }
        public String tipo { get; set; }
        public Decimal valor { get; set; }
        public String clt_bairro { get; set; }
        public String clt_numero { get; set; }
        public String clt_referencia { get; set; }
        public String clt_rua { get; set; }
        public String data { get; set; }
        public String desconto { get; set; }
        public String id { get; set; }
        public String observacao { get; set; }
        public String pagamento { get; set; }
        public String troco { get; set; }
    }   
}
