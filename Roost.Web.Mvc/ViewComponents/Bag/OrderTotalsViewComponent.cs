using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.ViewComponents.Bag
{
    public class OrderTotalsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(OrderModel order)
        {
            return View(order);
        }
    }
}