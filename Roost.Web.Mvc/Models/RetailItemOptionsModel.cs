using Microsoft.AspNetCore.Mvc.Rendering;

namespace Roost.Web.Mvc.Models
{
    public class RetailItemOptionsModel
    {
        public string Upc { get; set; }

        public int Quantity { get; set; }

        public List<OptionModel> Options { get; set; }

        public List<SelectListItem> Quantities { get; set; }

        public bool ShowOptions { get; set; }

        public decimal? Price { get; set; }
    }
}
