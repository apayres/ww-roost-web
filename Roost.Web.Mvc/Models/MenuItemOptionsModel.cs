using Microsoft.AspNetCore.Mvc.Rendering;

namespace Roost.Web.Mvc.Models
{
    public class MenuItemOptionsModel
    {
        public string Upc { get; set; }

        public int Quantity { get; set; }

        public List<OptionModel> Options { get; set; }

        public List<SelectListItem> Quantities { get; set; }

        public double BaseCalories { get; set; }

        public int PigeonMilkCalories { get; set; }

        public int SugarCalories { get; set; }

        public decimal Price { get; set; }
    }
}
