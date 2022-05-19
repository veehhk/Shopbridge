namespace Shopbridge.Inventory.Api.Commands
{
    using Shopbridge.Framework.CQRS;
    using Shopbridge.Framework.CQRS.Results;
    using System;
    using System.Threading.Tasks;

    public class CreateInventoryCommandHandler : IHandler<CreateInventoryCommand>
    {
        public Task<IResult> HandleAsync(CreateInventoryCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
