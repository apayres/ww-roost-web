using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.ViewComponents.Retail
{
    public class RetailItemViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke(ItemModel item)
        {
            return View(item);
        }
    }
}
