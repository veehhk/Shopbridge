namespace Shopbridge.Inventory.Api.Entities
{
    using Shopbridge.Framework.Domain;

    public class Inventory : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
