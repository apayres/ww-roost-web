using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.Services
{
    public class MenuService : IMenuService
    {
        private readonly HttpClient _httpClient;
        private readonly IItemService _itemService;

        public MenuService(IHttpClientFactory httpClientFactory, IItemService itemService)
        {
            _httpClient = httpClientFactory.CreateClient("Api");
            _itemService = itemService;
        }

        public async Task<MenuModel> LoadMenuAsync()
        {
            var model = new MenuModel()
            {
                Sections = new List<MenuSectionModel>()
            };

            var items = await _itemService.GetItemsAsync();

            foreach (var category in items.Where(x => x.ParentCategory != "Retail").Select(x => x.Category).Distinct())
            {
                model.Sections.Add(new MenuSectionModel()
                {
                    Category = category,
                    Items = items.Where(x => x.Category == category).ToList()
                });
            }

            return model;
        }

        public async Task<MenuModel> LoadRetailMenuAsync()
        {
            var model = new MenuModel()
            {
                Sections = new List<MenuSectionModel>()
            };

            var items = await _itemService.GetItemsAsync();

            foreach (var category in items.Where(x => x.ParentCategory == "Retail").Select(x => x.Category).Distinct())
            {
                model.Sections.Add(new MenuSectionModel()
                {
                    Category = category,
                    Items = items.Where(x => x.Category == category).ToList()
                });
            }

            return model;
        }


    }
}
