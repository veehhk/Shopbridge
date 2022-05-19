namespace Shopbridge.Inventory.Api.Infrastructure
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Shopbridge.Framework.Utils.Grid;
    using Shopbridge.Framework.ORM.Repository;
    using Shopbridge.Inventory.Api.Entities;
    using Shopbridge.Inventory.Api.Domains;
    using Shopbridge.Inventory.Api.Expressions;
    using Shopbridge.Inventory.Api.Database;

    public class InventoryRepository : EFRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(InventoryDbContext context) : base(context) { }

        public Task DeactivateAsync(Inventory entity) => UpdateAsync(entity.Id, entity);
        
        public Task<InventoryDomain> GetModelAsync(int id) => Queryable.Where(InventoryExpression.Id(id)).Select(InventoryExpression.EntityToDomain).SingleOrDefaultAsync();

        public Task<Grid<InventoryDomain>> GridAsync(GridParameters parameters) => Queryable.Select(InventoryExpression.EntityToDomain).GridAsync(parameters);

        public async Task<IEnumerable<InventoryDomain>> ListModelAsync() => await Queryable.Select(InventoryExpression.EntityToDomain).ToListAsync();
    }
}