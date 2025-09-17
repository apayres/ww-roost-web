using Newtonsoft.Json;

namespace Roost.Web.Server.Models
{
    public class Recipe
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
}
