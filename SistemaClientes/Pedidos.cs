using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int Senha { get; set; }
        public int Id_Cliente { get; set; }
        public String Nome_Cliente { get; set; }
        public Decimal Valor { get; set; }
        public String Data { get; set; }
        public String Observacao { get; set; }
        public int Pagamento { get; set; } //0 - DINHEIRO | 1 - CARTÃO | 2 - PIX
        public int Tipo { get; set; } //1 - ENTREGA | 2 - BALCAO | 3 - CONSUMO NO LOCAL(SOMENTE VINDO DO APP)
        public Decimal Desconto { get; set; }
    }
}
