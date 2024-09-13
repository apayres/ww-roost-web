﻿using Newtonsoft.Json;

namespace Roost.Web.Server.Models
{
    public class Item
    {
        public string Upc { set; get; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public double UnitQuantity { set; get; }

        public List<ItemAttribute>? Attributes { get; set; }

        public string Category { get; set; }

        public string CategoryDescription { get; set; }

        public string? ParentCategory { get; set; }

        public string? ParentCategoryDescription { get; set; }

        public UnitOfMeasure? UnitOfMeasure { get; set; }

        public List<ItemImage>? Images { get; set; }
    }
}
