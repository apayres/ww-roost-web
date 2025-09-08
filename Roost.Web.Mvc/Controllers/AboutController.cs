using Microsoft.AspNetCore.Mvc;

namespace Roost.Web.Mvc.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
