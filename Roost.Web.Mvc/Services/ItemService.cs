using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Api");
        }

        public async Task<List<ItemModel>> GetItemsAsync()
        {
            var response = await _httpClient.GetAsync("items");
            response.EnsureSuccessStatusCode();

            var items = await response.Content.ReadFromJsonAsync<List<ItemModel>>();
            return items;
        }

        public async Task<ItemModel> GetItemAsync(string upc)
        {
            var response = await _httpClient.GetAsync("items");
            response.EnsureSuccessStatusCode();

            var items = await response.Content.ReadFromJsonAsync<List<ItemModel>>();
            return items.FirstOrDefault(x => x.Upc == upc);
        }
    }
}
