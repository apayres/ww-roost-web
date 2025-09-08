using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.ViewComponents.Bag
{
    public class PlaceOrderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
