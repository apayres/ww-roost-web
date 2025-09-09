using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.ViewComponents.Retail
{
    public class RetailOptionsViewComponent : ViewComponent 
    {
        public IViewComponentResult Invoke(ItemModel item)
        {
            var model = new RetailItemOptionsModel()
            {
                Upc = item.Upc,
                Options = new List<OptionModel>(),
                Quantity = 1
            };

            model.Options.Add(new OptionModel()
            {
                Name = "Size",
                Value = "Small"
            });

            model.Quantities = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Small",
                    Value = "Small"
                },
                new SelectListItem
                {
                    Text = "Medium",
                    Value = "Medium"
                },
                new SelectListItem
                {
                    Text = "Large",
                    Value = "Large"
                },
                new SelectListItem
                {
                    Text = "XL Large",
                    Value = "XL Large"
                },
                new SelectListItem
                {
                    Text = "2XL Large",
                    Value = "2XL Large"
                },
                new SelectListItem
                {
                    Text = "3XL Large",
                    Value = "3XL Large"
                }
            };

            model.ShowOptions = item.Category.Trim() == "Apparel";

            foreach (var attribute in item.Attributes)
            {
                if (attribute.Name == "Price")
                {
                    model.Price = decimal.Parse(attribute.Value.ToString());
                    continue;
                }
            }

            return View(model);
        }
    }
}
