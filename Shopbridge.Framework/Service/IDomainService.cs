namespace Shopbridge.Framework.Service
{
    using Shopbridge.Framework.Utils.Grid;
    using Shopbridge.Framework.CQRS.Results;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Shopbridge.Framework.Domain;

    public interface IDomainService<TId, TDomain, TEntity> where TDomain : Domain<TId> where TEntity : Entity<TId>
    {
        Task<IResult<TId>> AddAsync(TDomain domain);

        Task<IResult> DeactivateAsync(TId id);

        Task<IResult> DeleteAsync(TId id);

        Task<TDomain> GetAsync(TId id);

        Task<Grid<TDomain>> GridAsync(GridParameters parameters);

        Task<IEnumerable<TDomain>> ListAsync();

        Task<IResult> UpdateAsync(TDomain domain);
    }
}