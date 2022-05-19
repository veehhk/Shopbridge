﻿namespace Shopbridge.Framework.ORM
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Shopbridge.Framework.ORM.UnitOfWork;

    public static class Extensions
    {
        public static void AddContext<T>(this IServiceCollection services, Action<DbContextOptionsBuilder> options) where T : DbContext
        {
            services.AddDbContextPool<T>(options);

            services.BuildServiceProvider().GetRequiredService<T>().Database.Migrate();
        }

        public static void AddUnitOfWork<T>(this IServiceCollection services) where T : DbContext => services.AddScoped<IUnitOfWork, UnitOfWork<T>>();

        public static DbSet<T> CommandSet<T>(this DbContext context) where T : class => context.DetectChangesLazyLoading(true).Set<T>();

        public static DbContext DetectChangesLazyLoading(this DbContext context, bool enabled)
        {
            context.ChangeTracker.AutoDetectChangesEnabled = enabled;

            context.ChangeTracker.LazyLoadingEnabled = enabled;

            context.ChangeTracker.QueryTrackingBehavior = enabled ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;

            return context;
        }

        public static IQueryable<T> QuerySet<T>(this DbContext context) where T : class => context.DetectChangesLazyLoading(false).Set<T>().AsNoTracking();
    }
}