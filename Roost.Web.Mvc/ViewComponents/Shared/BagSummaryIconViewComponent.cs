using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Models;
using Roost.Web.Mvc.Services;

namespace Roost.Web.Mvc.ViewComponents.Shared
{
    public class BagSummaryIconViewComponent : ViewComponent
    {
        private readonly IOrderService _orderService;

        public BagSummaryIconViewComponent(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var order = await _orderService.FetchOrderAsync();
            var model = new BagSummaryModel()
            {
                Items = order.OrderItems ?? new List<OrderItemModel>()
            };

            return View(model);
        }
    }
}
