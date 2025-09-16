using Roost.Web.Server.Models;
using Roost.Web.Server.Repositories;

namespace Roost.Web.Server.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Item>> GetItems()
        {
            var items = await _itemRepository.GetAll();
            return items;
        }
    }
}
