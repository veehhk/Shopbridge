﻿namespace Shopbridge.Framework.Repository
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.Generic;

    public interface ICommandRepository<T> where T : class
    {
        void Add(T item);

        Task AddAsync(T item);

        void AddRange(IEnumerable<T> items);

        Task AddRangeAsync(IEnumerable<T> items);

        void Delete(object key);

        void Delete(Expression<Func<T, bool>> where);

        Task DeleteAsync(object key);

        Task DeleteAsync(Expression<Func<T, bool>> where);

        void Update(object key, T item);

        Task UpdateAsync(object key, T item);

        void UpdatePartial(object key, object item);

        Task UpdatePartialAsync(object key, object item);

        void UpdateRange(IEnumerable<T> items);

        Task UpdateRangeAsync(IEnumerable<T> items);
    }
}