namespace Roost.Web.Mvc.Models
{
    public class ItemAttributeModel
    {
        public string Name { get; set; }

        public string Description { set; get; }

        public object Value { get; set; }

        public int DisplayOrder { get; set; }
    }
}
