using Microsoft.AspNetCore.Mvc;
using Roost.Web.Server.Models;
using Roost.Web.Server.Services;

namespace Roost.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemService _itemService;

        public ItemsController(ILogger<ItemsController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            try
            {
                return await _itemService.GetItems();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not load items: {ex.Message}");
                throw;
            }
        }
    }
}
