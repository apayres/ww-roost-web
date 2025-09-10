using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.Services
{
    public interface IItemService
    {
        Task<ItemModel?> GetItemAsync(string upc);
        Task<List<ItemModel>> GetItemsAsync();
    }
}