namespace Shopbridge.Inventory.Api.Infrastructure
{
    using Shopbridge.Framework.Repository;
    using Shopbridge.Framework.Utils.Grid;
    using Shopbridge.Inventory.Api.Entities;
    using Shopbridge.Inventory.Api.Domains;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<InventoryDomain> GetModelAsync(int id);

        Task<Grid<InventoryDomain>> GridAsync(GridParameters parameters);

        Task DeactivateAsync(Inventory entity);

        Task<IEnumerable<InventoryDomain>> ListModelAsync();
    }
}