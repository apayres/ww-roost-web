using Microsoft.AspNetCore.Mvc;
using Roost.Web.Server.Messaging;
using Roost.Web.Server.Models;
using Roost.Web.Server.Services;

namespace Roost.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IOrderService _orderService;
        private readonly IServiceBusMessageSender _messageSender;
        public OrderController(ILogger<ItemsController> logger, IOrderService orderService, IServiceBusMessageSender messageSender)
        {
            _logger = logger;
            _orderService = orderService;
            _messageSender = messageSender;
        }

        [HttpGet]
        public ActionResult<Order> Get()
        {
            try
            {
                _logger.LogInformation("Getting order");
                return _orderService.GetOrder();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not get order: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public ActionResult<Order> Post(OrderItem orderItem)
        {
            try
            {
                _logger.LogInformation("Adding item to order");
                return _orderService.AddItemToOrder(orderItem.Item, orderItem.Quantity, orderItem.Options);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not add item to order: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        [Route("submit")]
        public ActionResult Submit(Order order)
        {
            try
            {
                _logger.LogInformation("Sending order");
                _messageSender.SendOrder(order);
                _orderService.ResetOrder();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not submit order: {ex.Message}");
                throw;
            }
        }

        [HttpPut]
        public ActionResult<Order> Put(Guid id, Item item, int quantity)
        {
            try
            {
                _logger.LogInformation("Updating order item");
                return _orderService.UpdateOrderItem(id, item, quantity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not udpate order: {ex.Message}");
                throw;
            }
        }

        [HttpDelete]
        public ActionResult<Order> Delete(Guid id)
        {
            try
            {
                _logger.LogInformation("Deleting order item");
                return _orderService.UpdateOrderItem(id, null, 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not remove item from order: {ex.Message}");
                throw;
            }
        }
    }
}
