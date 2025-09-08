using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.Services
{
    public interface IMenuService
    {
        Task<MenuModel> LoadMenuAsync();
        Task<MenuModel> LoadRetailMenuAsync();
    }
}