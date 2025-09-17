using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using Roost.Web.Server.Models;
using Roost.Web.Server.Repositories.Configuration;

namespace Roost.Web.Server.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string _connectionString;

        public RecipeRepository(IOptions<RepoOptions> options)
        {
            _connectionString = options.Value.CosmosConnectionString;
        }

        public async Task<Recipe> GetRecipe(Guid itemId)
        {
            Recipe recipe = null;

            using (var cosmos = new CosmosClient(_connectionString))
            {
                var container = cosmos.GetContainer("roost-db", "ItemRecipes");

                using (var iterator = container.GetItemQueryIterator<Recipe>($"SELECT * FROM c WHERE c.ItemId = '{itemId.ToString()}'"))
                {
                    while (iterator.HasMoreResults)
                    {
                        var result = await iterator.ReadNextAsync();
                        recipe = result.FirstOrDefault();
                    }
                }
            }

            return recipe;
        }
    }
}
