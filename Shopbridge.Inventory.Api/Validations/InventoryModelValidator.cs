namespace Shopbridge.Inventory.Api.Validations
{
    using FluentValidation;
    using Shopbridge.Inventory.Api.Models;

    public class InventoryModelValidator : AbstractValidator<InventoryModel>
    {
        public void Id() => RuleFor(Inventory => Inventory.Id).GreaterThan(-1);

        public void Name() => RuleFor(Inventory => Inventory.Name).NotEmpty();

        public void Price() => RuleFor(Inventory => Inventory.Price).GreaterThan(0).NotNull();
    }
}
