namespace Roost.Web.Mvc.Models
{
    public class ItemModel
    {
        public Guid Id { get; set; }

        public string Upc { set; get; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public double UnitQuantity { set; get; }

        public ItemAttributesModel ItemAttributes { get; set; }

        public string Category { get; set; }

        public string CategoryDescription { get; set; }

        public string? ParentCategory { get; set; }

        public string? ParentCategoryDescription { get; set; }

        public UnitOfMeasureModel? UnitOfMeasure { get; set; }

        public string ImageUrl { get; set; }
    }
}
