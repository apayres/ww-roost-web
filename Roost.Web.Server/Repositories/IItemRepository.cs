using Roost.Web.Server.Models;

namespace Roost.Web.Server.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAll();
    }
}