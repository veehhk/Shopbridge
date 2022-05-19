namespace Shopbridge.Framework.CQRS
{
    using System.Threading.Tasks;
    using Shopbridge.Framework.CQRS.Results;

    public interface IHandler<TRequest>
    {
        Task<IResult> HandleAsync(TRequest request);
    }

    public interface IHandler<TRequest, TResponse>
    {
        Task<IResult<TResponse>> HandleAsync(TRequest request);
    }
}