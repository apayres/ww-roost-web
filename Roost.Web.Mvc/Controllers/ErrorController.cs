using Microsoft.AspNetCore.Mvc;

namespace Roost.Web.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
