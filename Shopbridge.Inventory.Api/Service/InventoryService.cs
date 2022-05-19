namespace Shopbridge.Inventory.Api.Service
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Shopbridge.Framework.Service;
    using Shopbridge.Inventory.Api.Domains;
    using Shopbridge.Framework.CQRS.Results;
    using Shopbridge.Framework.Utils.Grid;
    using Shopbridge.Framework.ORM.UnitOfWork;
    using Shopbridge.Inventory.Api.Infrastructure;
    using Shopbridge.Inventory.Api.Expressions;
    using Shopbridge.Inventory.Api.Entities;
    using Shopbridge.Framework.Repository;

    public class InventoryService : DomainService<int, InventoryDomain, Inventory>, IInventoryService
    {
        public InventoryService(IUnitOfWork unitOfWork, IInventoryRepository repository) : base(unitOfWork, (IRepository<Inventory>)repository)
        {
        }

        public override async Task<IResult<int>> AddAsync(InventoryDomain domain)
        {
            Inventory entity = domain.ToEntity();
            await _repository.AddAsync(entity);
            int c = await _unitOfWork.SaveChangesAsync();
            return Result<int>.Success(entity.Id);
        }

        public override async Task<IResult> DeactivateAsync(int id)
        {
            Inventory entity = await _repository.GetAsync(id);

            if (entity is null)
            {
                return Result.Fail();
            }

            InventoryDomain domain = entity.ToDomain();

            domain.DeActivate();

            entity = domain.ToEntity();

            await _repository.UpdateAsync(entity.Id, entity);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public override async Task<IResult> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public override Task<InventoryDomain> GetAsync(int id) => (_repository as IInventoryRepository).GetModelAsync(id);

        public override Task<Grid<InventoryDomain>> GridAsync(GridParameters parameters) => (_repository as IInventoryRepository).GridAsync(parameters);

        public override async Task<IEnumerable<InventoryDomain>> ListAsync() => await (_repository as IInventoryRepository).ListModelAsync();

        public override async Task<IResult> UpdateAsync(InventoryDomain domain)
        {
            Inventory entity = await _repository.GetAsync(domain.Id);

            if (entity is null)
            {
                return Result.Fail();
            }

            entity = domain.ToEntity();

            await _repository.UpdateAsync(entity.Id, entity);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }

}