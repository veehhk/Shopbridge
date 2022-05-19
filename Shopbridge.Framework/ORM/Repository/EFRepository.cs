namespace Shopbridge.Framework.ORM.Repository
{
    using Shopbridge.Framework.Repository;
    using Microsoft.EntityFrameworkCore;

    public class EFRepository<T> : Repository<T> where T : class
    {
        public EFRepository(DbContext context) : base(new EFCommandRepository<T>(context), new EFQueryRepository<T>(context)) { }
    }
}