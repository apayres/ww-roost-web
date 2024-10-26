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
            return _orderService.GetOrder();
        }

        [HttpPost]
        public ActionResult<Order> Post(OrderItem orderItem)
        {
           return _orderService.AddItemToOrder(orderItem.Item, orderItem.Quantity, orderItem.Options);
        }

        [HttpPost]
        [Route("submit")]
        public ActionResult Submit(Order order)
        {
            try
            {
                _messageSender.SendOrder(order);
                _orderService.ResetOrder();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpPut]
        public ActionResult<Order> Put(Guid id, Item item, int quantity)
        {
            return _orderService.UpdateOrderItem(id, item, quantity);
        }

        [HttpDelete]
        public ActionResult<Order> Delete(Guid id)
        {
            return _orderService.UpdateOrderItem(id, null, 0);
        }
    }
}
