namespace Shopbridge.Framework.Service
{
    using Shopbridge.Framework.ORM.UnitOfWork;
    using Shopbridge.Framework.Utils.Grid;
    using Shopbridge.Framework.CQRS.Results;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Shopbridge.Framework.Domain;
    using Shopbridge.Framework.Repository;

    public abstract class DomainService<TId, TDomain, TEntity> : IDomainService<TId, TDomain, TEntity> where TDomain : Domain<TId> where TEntity : Entity<TId>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<TEntity> _repository;

        public DomainService(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public abstract Task<IResult<TId>> AddAsync(TDomain domain);
        public abstract Task<IResult> DeactivateAsync(TId id);
        public abstract Task<IResult> DeleteAsync(TId id);
        public abstract Task<TDomain> GetAsync(TId id);
        public abstract Task<Grid<TDomain>> GridAsync(GridParameters parameters);
        public abstract Task<IEnumerable<TDomain>> ListAsync();
        public abstract Task<IResult> UpdateAsync(TDomain domain);
    }
}