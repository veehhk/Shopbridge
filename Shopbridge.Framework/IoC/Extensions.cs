namespace Shopbridge.Framework.IoC
{
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Scrutor;

    public static class Extensions
    {
        public static void AddClassesInterfaces(this IServiceCollection services, params Assembly[] assemblies) => 
        services.Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());

        public static string GetConnectionString(this IServiceCollection services, string name) => 
        services
                .BuildServiceProvider()
                .GetRequiredService<IConfiguration>()
                .GetConnectionString(name);
    }
}