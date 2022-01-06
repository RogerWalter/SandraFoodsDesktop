using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes
{
    public class Itens
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public Decimal Valor { get; set; }
        public String Descricao { get; set; }
        public int Tipo { get; set; }
        public int Grupo { get; set; }
        public int App { get; set; }
    }
}
