namespace Shopbridge.Inventory.Api.Models
{
    using Shopbridge.Framework.Domain;

    public class InventoryModel : Model<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
