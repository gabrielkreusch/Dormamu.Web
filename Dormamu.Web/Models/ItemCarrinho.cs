using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormamu.Web.Models
{
    public class ItemCarrinho
    {
        public long ID { get; set; }
        public Carrinho Carrinho { get; set; }
        public long CarrinhoID { get; set; }
        public Produto Produto { get; set; }
        public long ProdutoID { get; set; }
        public int Quantidade { get; set; }
    }
}
