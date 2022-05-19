namespace Shopbridge.Framework.Utils.Grid
{
    using System.Linq;
    using System.Threading.Tasks;

    public static class GridExtensions
    {
        public static Grid<T> Grid<T>(this IQueryable<T> queryable, GridParameters parameters) => new Grid<T>(queryable, parameters);

        public static Task<Grid<T>> GridAsync<T>(this IQueryable<T> queryable, GridParameters parameters) => Task.FromResult(new Grid<T>(queryable, parameters));
    }
}