using Newtonsoft.Json;
using Roost.Web.Server.Models;

namespace Roost.Web.Server.Services
{
    public class OrderService : IOrderService
    {
        private const decimal TAX_RATE = 0.0925m;
        private const string ORDER_SESSION_KEY = "ORDER_SESSSION_KEY";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Order GetOrder()
        {
            var sessionValue = _httpContextAccessor?.HttpContext?.Session.GetString(ORDER_SESSION_KEY);
            var orderInSession = JsonConvert.DeserializeObject<Order?>(sessionValue ?? string.Empty);
            if (orderInSession == null)
            {
                orderInSession = new Order();
                orderInSession.orderItems = new List<OrderItem>();
            }

            CalculateTotals(orderInSession);

            return orderInSession;
        }

        public Order AddItemToOrder(Item item, int quantity, List<Option> options)
        {
            var orderInSession = GetOrder();
            if (orderInSession == null)
            {
                orderInSession = new Order();
                orderInSession.orderItems = new List<OrderItem>();
            }

            orderInSession.orderItems.Add(new OrderItem()
            {
                OrderItemId = Guid.NewGuid(),
                Item = item,
                Quantity = quantity,
                Options = options,
                Price = item.ItemAttributes?.Price
            });

            _httpContextAccessor?.HttpContext?.Session.SetString(ORDER_SESSION_KEY, JsonConvert.SerializeObject(orderInSession));

            CalculateTotals(orderInSession);
            return orderInSession;
        }

        public Order UpdateOrderItem(Guid id, Item item, int quantity)
        {
            var orderInSession = GetOrder();
            if (orderInSession == null)
            {
                return new Order();
            }

            var orderItem = orderInSession.orderItems.FirstOrDefault(x => x.OrderItemId == id);
            if (orderItem == null)
            {
                return new Order();
            }

            if (quantity == 0)
            {
                orderInSession.orderItems.Remove(orderItem);
            }
            else
            {
                orderItem.Quantity = quantity;
                orderItem.Item = item;
            }

            _httpContextAccessor?.HttpContext?.Session.SetString(ORDER_SESSION_KEY, JsonConvert.SerializeObject(orderInSession));

            CalculateTotals(orderInSession);
            return orderInSession;
        }

        public void ResetOrder()
        {
            _httpContextAccessor?.HttpContext?.Session.Remove(ORDER_SESSION_KEY);
        }

        private void CalculateTotals(Order order)
        {
            order.SubTotal = decimal.Round(order.orderItems.Sum(x => x.Quantity * x.Price).GetValueOrDefault(), 2);
            order.SalesTax = decimal.Round(order.SubTotal.GetValueOrDefault() * TAX_RATE, 2);
            order.Total = decimal.Round(order.SubTotal.GetValueOrDefault() + order.SalesTax.GetValueOrDefault(), 2);
        }
    }
}
