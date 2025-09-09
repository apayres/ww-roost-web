using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Models;
using Roost.Web.Mvc.Services;

namespace Roost.Web.Mvc.Controllers
{
    public class BagController : Controller
    {
        private readonly ILogger<BagController> _logger;
        private readonly IOrderService _orderService;

        public BagController(ILogger<BagController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var order = await _orderService.FetchOrderAsync();
            return View(order);
        }

        [HttpPost]
        public async Task<JsonResult> AddToOrder([FromBody]AddItemToOrderModel model)
        {
            await _orderService.AddToOrderAsync(model.Upc, model.Quantity, model.Options);
            var order = await _orderService.FetchOrderAsync();

            return new JsonResult(order);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromOrder(Guid id)
        {
            await _orderService.RemoveFromOrderAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder(string name)
        {
            var order = await _orderService.FetchOrderAsync();
            order.Name = name;

            await _orderService.SubmitOrderAsync(order);
            return View(order);
        }
    }
}
