namespace Shopbridge.Framework.CQRS
{
    using Shopbridge.Framework.CQRS.Results;
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;

    public sealed class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IResult> HandleAsync<TRequest>(TRequest request)
        {
            var validation = await ValidateAsync(request).ConfigureAwait(false);

            if (validation.Failed)
            {
                return await Result.FailAsync(validation.Message).ConfigureAwait(false);
            }

            return await _serviceProvider.GetRequiredService<IHandler<TRequest>>().HandleAsync(request).ConfigureAwait(false);
        }

        public async Task<IResult<TResponse>> HandleAsync<TRequest, TResponse>(TRequest request)
        {
            var validation = await ValidateAsync(request).ConfigureAwait(false);

            if (validation.Failed)
            {
                return await Result<TResponse>.FailAsync(validation.Message).ConfigureAwait(false);
            }

            return await _serviceProvider.GetRequiredService<IHandler<TRequest, TResponse>>().HandleAsync(request).ConfigureAwait(false);
        }

        private async Task<IResult> ValidateAsync<TRequest>(TRequest request)
        {
            var validator = _serviceProvider.GetService<AbstractValidator<TRequest>>();

            if (validator is null)
            {
                return await Result.SuccessAsync().ConfigureAwait(false);
            }

            var validation = await validator.ValidateAsync(request).ConfigureAwait(false);

            return !validation.IsValid ? await Result.FailAsync(validation.ToString()).ConfigureAwait(false) : await Result.SuccessAsync().ConfigureAwait(false);
        }
    }
}