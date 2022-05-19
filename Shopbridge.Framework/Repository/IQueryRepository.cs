namespace Shopbridge.Framework.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.Generic;

    public interface IQueryRepository<T> where T : class
    {
        IQueryable<T> Queryable { get; }

        bool Any();

        bool Any(Expression<Func<T, bool>> where);

        Task<bool> AnyAsync();

        Task<bool> AnyAsync(Expression<Func<T, bool>> where);

        long Count();

        long Count(Expression<Func<T, bool>> where);

        Task<long> CountAsync();

        Task<long> CountAsync(Expression<Func<T, bool>> where);

        T Get(object key);

        Task<T> GetAsync(object key);

        IEnumerable<T> List();

        Task<IEnumerable<T>> ListAsync();
    }
}