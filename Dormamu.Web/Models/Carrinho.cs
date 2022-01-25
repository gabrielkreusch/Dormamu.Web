using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormamu.Web.Models
{
    public class Carrinho
    {
        public long ID { get; set; }
        public Pessoa Pessoa { get; set; }
        public long PessoaID { get; set; }
        public List<ItemCarrinho> ItensCarrinho { get; set; }
    }
}
