namespace Dormamu.Web.Models
{
    public class ItemPedido
    {
        public long ID { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public long ProdutoID { get; set; }
        public Pedido Pedido { get; set; }
        public long PedidoID { get; set; }
    }
}