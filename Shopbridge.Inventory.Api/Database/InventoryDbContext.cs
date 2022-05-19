namespace Shopbridge.Inventory.Api.Database
{
    using System.Threading;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.ValueGeneration;
    using Shopbridge.Inventory.Api.Entities;

    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
        { }
        public DbSet<Inventory> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(inventory =>
            {
                inventory.Property(p => p.Id).HasValueGenerator<InventoryIdValueGenerator>();
            });

            base.OnModelCreating(modelBuilder);
        }
    }

    public class InventoryIdValueGenerator : ValueGenerator<int>
    {
        private int _current;

        public override bool GeneratesTemporaryValues => false;

        public override int Next(EntityEntry entry) => Interlocked.Increment(ref _current);
    }
}
