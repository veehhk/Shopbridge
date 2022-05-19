namespace Shopbridge.Inventory.Api.Expressions
{
    using System;
    using System.Linq.Expressions;
    using Shopbridge.Inventory.Api.Domains;
    using Shopbridge.Inventory.Api.Models;
    using Shopbridge.Inventory.Api.Entities;

    public static class InventoryExpression
    {
        public static Expression<Func<Inventory, InventoryDomain>> EntityToDomain => entity => new InventoryDomain
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            Status = entity.Status,
        };

        public static Expression<Func<InventoryDomain, InventoryModel>> DomainToModel => domain => new InventoryModel
        {
            Id = domain.Id,
            Name = domain.Name,
            Description = domain.Description,
            Price = domain.Price,
            Status = domain.Status,
        };

        public static InventoryModel ToModel(this InventoryDomain domain)
        {
            return new InventoryModel
            {
                Id = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Price = domain.Price,
                Status = domain.Status,
            };
        }

        public static Inventory ToEntity(this InventoryDomain domain)
        {
            return new Inventory
            {
                Id = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Price = domain.Price,
                Status = domain.Status,
            };
        }

        public static Expression<Func<InventoryModel, InventoryDomain>> ModelToDomain => model => new InventoryDomain
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Status = model.Status,
        };

        public static InventoryDomain ToDomain(this InventoryModel model) => new InventoryDomain
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Status = model.Status,
        };

        public static InventoryDomain ToDomain(this Inventory entity) => new InventoryDomain
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            Status = entity.Status,
        };

        public static Expression<Func<Inventory, bool>> Id(int id) => entity => entity.Id == id;
    }
}