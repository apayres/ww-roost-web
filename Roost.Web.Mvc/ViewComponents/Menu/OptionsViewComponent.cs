using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Roost.Web.Mvc.Models;

namespace Roost.Web.Mvc.ViewComponents.Menu
{
    public class OptionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ItemModel item)
        {
            var model = new AddItemToOrderModel()
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

            return View(model);
        }
    }
}
