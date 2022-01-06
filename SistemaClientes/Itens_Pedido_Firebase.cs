using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Itens_Pedido_Firebase
    {
        public String adicionais_item { get; set; }
        public String desc_item { get; set; }
        public int grupo_item { get; set; }
        public int id_item { get; set; }
        public String id_pedido { get; set; }
        public String obs_item { get; set; }
        public int qtd_item { get; set; }
        public Decimal valor_item { get; set; }
    }
}
