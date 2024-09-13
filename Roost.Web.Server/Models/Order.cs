namespace Roost.Web.Server.Models
{
    public class Order
    {
        public List<OrderItem>? orderItems { set; get; }

        public decimal? SubTotal { get; set; }

        public decimal? Total { get; set; }

        public decimal? SalesTax { get; set; }
    }
}
