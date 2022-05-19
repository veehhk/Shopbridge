namespace Shopbridge.Inventory.Api.Validations
{
    public class AddInventoryModelValidator : InventoryModelValidator
    {
        public AddInventoryModelValidator()
        {
            Id(); Name(); Price();
        }
    }
}
