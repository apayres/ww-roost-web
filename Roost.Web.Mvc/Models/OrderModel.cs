namespace Roost.Web.Mvc.Models
{
    public class OrderModel
    {
        public string Name { get; set; } = string.Empty;

        public List<OrderItemModel>? OrderItems { set; get; }

        public decimal? SubTotal { get; set; }

        public decimal? Total { get; set; }

        public decimal? SalesTax { get; set; }
    }
}
