using Roost.Web.Server.Models;

namespace Roost.Web.Server.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipe(Guid itemId);
    }
}