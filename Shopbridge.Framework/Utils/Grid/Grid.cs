namespace Shopbridge.Framework.Utils.Grid
{
    using Shopbridge.Framework.Extensions;
    using System.Collections.Generic;
    using System.Linq;

    public class Grid<T>
    {
        public Grid(IQueryable<T> queryable, GridParameters parameters)
        {
            Parameters = parameters;

            if (queryable is null || parameters is null)
            {
                return;
            }

            queryable = Filter(queryable, parameters.Filters);

            Count = queryable.LongCount();

            queryable = Order(queryable, parameters.sort);

            queryable = Page(queryable, parameters.Page);

            List = queryable.AsEnumerable();
        }

        public long Count { get; }

        public IEnumerable<T> List { get; }

        public GridParameters Parameters { get; }

        private static IQueryable<T> Filter(IQueryable<T> queryable, Filters filters)
        {
            if (filters is null)
            {
                return queryable;
            }

            foreach (Filter filter in filters)
            {
                queryable = queryable.Filter(filter.Property, filter.Comparison, filter.Value);
            }

            return queryable;
        }

        private static IQueryable<T> Order(IQueryable<T> queryable, Sort sort) => sort is null ? queryable : queryable.Order(sort.Property, sort.Ascending);

        private static IQueryable<T> Page(IQueryable<T> queryable, Page page) => page is null ? queryable : queryable.Page(page.Index, page.Size);
    }
}