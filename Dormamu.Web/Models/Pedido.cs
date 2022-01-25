using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormamu.Web.Models
{
    public class Pedido
    {
        public long ID { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
        public Cliente Cliente { get; set; }
        public long ClienteId { get; set; }
        public string Observacao { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public StatusPedido Status { get; set; }
    }
}
