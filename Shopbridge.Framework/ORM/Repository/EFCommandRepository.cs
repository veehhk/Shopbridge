namespace Shopbridge.Framework.ORM.Repository
{
    using Shopbridge.Framework.Repository;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class EFCommandRepository<T> : ICommandRepository<T> where T : class
    {
        private readonly DbContext _context;

        public EFCommandRepository(DbContext context) => _context = context;

        private DbSet<T> Set => _context.CommandSet<T>();

        public void Add(T item) => Set.Add(item);

        public Task AddAsync(T item) => Set.AddAsync(item).AsTask();

        public void AddRange(IEnumerable<T> items) => Set.AddRange(items);

        public Task AddRangeAsync(IEnumerable<T> items) => Set.AddRangeAsync(items);

        public void Delete(object key)
        {
            var item = Set.Find(key);

            if (item is null)
            {
                return;
            }

            Set.Remove(item);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IQueryable<T> items = Set.Where(where);

            if (!items.Any())
            {
                return;
            }

            Set.RemoveRange(items);
        }

        public Task DeleteAsync(object key) => Task.Run(() => Delete(key));

        public Task DeleteAsync(Expression<Func<T, bool>> where) => Task.Run(() => Delete(where));

        public void Update(object key, T item) => Set.Update(item);

        public Task UpdateAsync(object key, T item) => Task.Run(() => Update(key, item));

        public void UpdatePartial(object key, object item) => _context.Entry(Set.Find(key)).CurrentValues.SetValues(item);

        public Task UpdatePartialAsync(object key, object item) => Task.Run(() => UpdatePartial(key, item));

        public void UpdateRange(IEnumerable<T> items) => Set.UpdateRange(items);

        public Task UpdateRangeAsync(IEnumerable<T> items) => Task.Run(() => UpdateRange(items));
    }
}