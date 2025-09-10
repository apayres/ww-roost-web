using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IItemService _itemService;

        public OrderService(IHttpClientFactory httpClientFactory, IItemService itemService)
        {
            _httpClient = httpClientFactory.CreateClient("Api");
            _itemService = itemService;
        }

        public async Task AddToOrderAsync(string upc, int quantity, List<OptionModel> options)
        {
            var item = await _itemService.GetItemAsync(upc);

            var orderItem = new OrderItemModel()
            {
                Item = item,
                Quantity = quantity,
                Options = options ?? new List<OptionModel>()
            };

            var response = await _httpClient.PostAsJsonAsync("order", orderItem);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveFromOrderAsync(Guid orderItemId)
        {
            var response = await _httpClient.DeleteAsync("order?id=" + orderItemId);
            response.EnsureSuccessStatusCode();
        }

        public async Task<OrderModel> FetchOrderAsync()
        {
            var response = await _httpClient.GetAsync("order");
            response.EnsureSuccessStatusCode();

            var model = await response.Content.ReadFromJsonAsync<OrderModel>();
            if(model == null)
            {
                model = new OrderModel();
            }

            return model;
        }

        public async Task SubmitOrderAsync(OrderModel order)
        {
            var response = await _httpClient.PostAsJsonAsync("order/submit", order);
            response.EnsureSuccessStatusCode();
        }

        
    }
}
