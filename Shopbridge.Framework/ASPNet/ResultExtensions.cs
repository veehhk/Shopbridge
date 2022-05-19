namespace Shopbridge.Framework.AspNetCore
{
    using Shopbridge.Framework.CQRS.Results;
    using Shopbridge.Framework.Utils.Grid;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public static class ResultExtensions
    {
        public static async Task<IActionResult> ResultAsync<T>(this Task<IResult<T>> result)
        {
            return ApiResult.Create(await result.ConfigureAwait(false));
        }

        public static async Task<IActionResult> ResultAsync(this Task<IResult> result)
        {
            return ApiResult.Create(await result.ConfigureAwait(false));
        }

        public static async Task<IActionResult> ResultAsync<T>(this Task<T> result)
        {
            return ApiResult.Create(await result.ConfigureAwait(false));
        }

        public static async Task<IActionResult> ResultAsync<T>(this Task<Grid<T>> result)
        {
            return ApiResult.Create(await result.ConfigureAwait(false));
        }
    }
}