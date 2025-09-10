using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.Services
{
    public class MenuService : IMenuService
    {
        private readonly IItemService _itemService;
        private const string RETAIL_CATEGORY_NAME = "Retail";

        public MenuService(IHttpClientFactory httpClientFactory, IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<MenuModel> LoadMenuAsync()
        {
            var model = new MenuModel();

            var items = await _itemService.GetItemsAsync();

            model.Sections = GetMenuSections(items.Where(x => x.ParentCategory != RETAIL_CATEGORY_NAME));

            return model;
        }

        public async Task<MenuModel> LoadRetailMenuAsync()
        {
            var model = new MenuModel();

            var items = await _itemService.GetItemsAsync();

            model.Sections = GetMenuSections(items.Where(x => x.ParentCategory == RETAIL_CATEGORY_NAME));

            return model;
        }

        private static List<MenuSectionModel> GetMenuSections(IEnumerable<ItemModel> items)
        {
            var sections = new List<MenuSectionModel>();
            
            foreach (var category in items.Select(x => x.Category).Distinct())
            {
                sections.Add(new MenuSectionModel()
                {
                    Category = category,
                    Items = items.Where(x => x.Category == category).ToList()
                });
            }

            return sections;
        }

    }
}
