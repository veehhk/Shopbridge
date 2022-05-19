namespace Shopbridge.Framework.CQRS.Validation
{
    using Shopbridge.Framework.CQRS.Results;
    using System.Threading.Tasks;
    using FluentValidation;
    
    public static class Extensions
    {
        public static async Task<IResult> ValidationAsync<T>(this IValidator<T> validator, T instance)
        {
            if (instance is null)
            {
                return await Result.FailAsync().ConfigureAwait(false);
            }

            var result = await validator.ValidateAsync(instance).ConfigureAwait(false);

            return result.IsValid ? await Result.SuccessAsync() : await Result.FailAsync(result.ToString());
        }
    }
}