using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.ViewComponents.Bag
{
    public class OrderItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(OrderItemModel item)
        {
            return View(item);
        }
    }
}
