namespace Roost.Web.Mvc.Models
{
    public class OrderItemModel
    {
        public Guid? OrderItemId { get; set; }

        public ItemModel? Item { set; get; }

        public int Quantity { get; set; }

        public decimal? Price { get; set; }

        public List<OptionModel> Options { set; get; } = new List<OptionModel>();
    }
}
