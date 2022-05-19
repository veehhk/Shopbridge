namespace Shopbridge.Framework.CQRS
{
    using System;
    using System.Threading.Tasks;
    using Shopbridge.Framework.CQRS.Results;

    public interface IMediator
    {
        Task<IResult> HandleAsync<TRequest>(TRequest request);

        Task<IResult<TResponse>> HandleAsync<TRequest, TResponse>(TRequest request);
    }

}
