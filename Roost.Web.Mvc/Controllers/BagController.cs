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
            try
            {
                var order = await _orderService.FetchOrderAsync();
                return View(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Problem fetching order: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddToOrder([FromBody] AddItemToOrderModel model)
        {
            try
            {
                await _orderService.AddToOrderAsync(model.Upc, model.Quantity, model.Options);
                var order = await _orderService.FetchOrderAsync();

                return new JsonResult(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Problem adding item to order: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromOrder(Guid id)
        {
            try
            {
                await _orderService.RemoveFromOrderAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Problem removing item from order: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder(string name)
        {
            try
            {
                var order = await _orderService.FetchOrderAsync();
                order.Name = name;

                await _orderService.SubmitOrderAsync(order);
                return View(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Problem submitting order: {ex.Message}");
                throw;
            }
        }
    }
}
