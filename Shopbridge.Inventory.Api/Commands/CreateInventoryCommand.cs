namespace Shopbridge.Inventory.Api.Commands
{
    using Shopbridge.Framework.CQRS;
    using Shopbridge.Inventory.Api.Models;

    public class CreateInventoryCommand : Command<InventoryModel, int>
    {
    }
}
