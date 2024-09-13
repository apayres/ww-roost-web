using Roost.Web.Server.Models;

namespace Roost.Web.Server.Services
{
    public interface IOrderService
    {
        Order AddItemToOrder(Item item, int quantity);
        Order GetOrder();
        Order UpdateOrderItem(Guid id, Item item, int quantity);
        void ResetOrder();
    }
}