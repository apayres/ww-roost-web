using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using Roost.Web.Server.Models;
using Roost.Web.Server.Repositories.Configuration;

namespace Roost.Web.Server.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _connectionString;

        public ItemRepository(IOptions<RepoOptions> options)
        {
            _connectionString = options.Value.CosmosConnectionString;
        }

        public async Task<List<Item>> GetAll()
        {
            var items = new List<Item>();

            using (var cosmos = new CosmosClient(_connectionString))
            {
                var container = cosmos.GetContainer("roost-db", "ItemCatalog");
                using (var iterator = container.GetItemQueryIterator<Item>())
                {
                    while (iterator.HasMoreResults)
                    {
                        var response = await iterator.ReadNextAsync().ConfigureAwait(false);
                        items.AddRange(response.ToList());
                    }
                }
            }

            return items;
        }
    }
}
