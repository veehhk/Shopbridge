namespace Shopbridge.Framework.ORM.UnitOfWork
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}