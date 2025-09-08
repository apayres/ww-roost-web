using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.ViewComponents.Shared
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = (MessageModel)TempData["Message"];

            return View(model);
        }
    }
}
