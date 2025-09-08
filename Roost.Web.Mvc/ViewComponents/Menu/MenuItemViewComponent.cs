using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.ViewComponents.Menu
{
    public class MenuItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ItemModel item)
        {
            return View(item);
        }
    }
}
