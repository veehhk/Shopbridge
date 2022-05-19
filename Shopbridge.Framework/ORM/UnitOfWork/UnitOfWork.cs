namespace Shopbridge.Framework.ORM.UnitOfWork
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public UnitOfWork(TDbContext context) => _context = context;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) => _context.SaveChangesAsync(cancellationToken);

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken)) => await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}