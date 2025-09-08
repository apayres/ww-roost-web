using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.Services
{
    public interface IOrderService
    {
        Task AddToOrderAsync(string upc, int quantity, List<OptionModel> options);
        Task<OrderModel> FetchOrderAsync();
        Task RemoveFromOrderAsync(Guid orderItemId);
        Task SubmitOrderAsync(OrderModel order);
    }
}