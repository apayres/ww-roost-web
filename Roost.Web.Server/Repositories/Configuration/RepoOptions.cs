using Microsoft.Extensions.Options;

namespace Roost.Web.Server.Repositories.Configuration
{
    public class RepoOptions : IOptions<RepoOptions>
    {
        public string CosmosConnectionString { get; set; }

        public RepoOptions Value => this;
    }
}
