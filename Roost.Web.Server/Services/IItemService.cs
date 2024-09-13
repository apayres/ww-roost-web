using Roost.Web.Server.Models;

namespace Roost.Web.Server.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetItems();
    }
}