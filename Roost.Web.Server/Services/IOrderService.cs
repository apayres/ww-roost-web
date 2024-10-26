using Roost.Web.Server.Models;

namespace Roost.Web.Server.Services
{
    public interface IOrderService
    {
        Order AddItemToOrder(Item item, int quantity, List<Option> options);
        Order GetOrder();
        Order UpdateOrderItem(Guid id, Item item, int quantity);
        void ResetOrder();

    }
}