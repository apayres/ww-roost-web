using Microsoft.AspNetCore.Mvc;
using Roost.Web.Mvc.Services;

namespace Roost.Web.Mvc.Controllers;

public class MenuController : Controller
{
    private readonly ILogger<MenuController> _logger;
    private readonly IMenuService _menuService;


    public MenuController(ILogger<MenuController> logger, IMenuService menuService)
    {
        _logger = logger;
        _menuService = menuService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var model = await _menuService.LoadMenuAsync();
            return View(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Problem loading menu: {ex.Message}");
            throw;
        }
    }

}
