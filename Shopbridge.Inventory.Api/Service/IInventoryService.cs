namespace Shopbridge.Inventory.Api.Service
{
    using Shopbridge.Framework.Service;
    using Shopbridge.Inventory.Api.Domains;
    using Shopbridge.Inventory.Api.Entities;

    public interface IInventoryService : IDomainService<int, InventoryDomain, Inventory>
    {
    }

}