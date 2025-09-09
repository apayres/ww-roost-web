using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.ViewComponents.Menu
{
    public class OptionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ItemModel item)
        {
            var model = new MenuItemOptionsModel()
            {
                Upc = item.Upc,
                Options = new List<OptionModel>(),
                Quantity = 1
            };

            model.Options.Add(new OptionModel()
            {
                Name = "Pigeon Milk",
                Value = "0"
            });

            model.Options.Add(new OptionModel()
            {
                Name = "Sugars",
                Value = "0"
            });

            model.Quantities = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "0",
                    Value = "0"
                },
                new SelectListItem
                {
                    Text = "1",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "2",
                    Value = "2"
                },
                new SelectListItem
                {
                    Text = "3",
                    Value = "3"
                },
                new SelectListItem
                {
                    Text = "4",
                    Value = "4"
                }
            };

            foreach(var attribute in item.Attributes)
            {
                if(attribute.Name == "Calories")
                {
                    model.BaseCalories = double.Parse(attribute.Value.ToString());
                    continue;
                }

                if(attribute.Name == "Price")
                {
                    model.Price = decimal.Parse(attribute.Value.ToString());
                    continue;
                }
            }

            model.PigeonMilkCalories = 10;
            model.SugarCalories = 5;

            return View(model);
        }
    }
}
