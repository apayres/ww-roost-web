using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Models;
using Roost.Web.Mvc.Services;

namespace Roost.Web.Mvc.Controllers
{
    public class RetailController : Controller
    {
        private readonly ILogger<RetailController> _logger;
        private readonly IMenuService _menuService;
        private readonly IOrderService _orderService;


        public RetailController(ILogger<RetailController> logger, IMenuService menuService, IOrderService orderService)
        {
            _logger = logger;
            _menuService = menuService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index(bool? addedSuccessfully)
        {
            var model = await _menuService.LoadRetailMenuAsync();

            if (addedSuccessfully.HasValue && addedSuccessfully.Value)
            {
                TempData["Message"] = new MessageModel()
                {
                    MessageText = "Item added to bag successfully!",
                    MessageType = "success"
                };
            }

            return View(model);
        }

        public async Task<IActionResult> AddItemToOrder(AddItemToOrderModel model)
        {
            await _orderService.AddToOrderAsync(model.Upc, model.Quantity, model.Options);


            return RedirectToAction("Index", new {addedSuccessfully = true});
        }
    }
}
