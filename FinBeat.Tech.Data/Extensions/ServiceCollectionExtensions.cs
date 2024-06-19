using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace FinBeat.Tech.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDataLayer(this IServiceCollection services)
    {
        services.AddSqlite<FbtDbContext>("Data Source=dictionary.db");

        using var context = services.BuildServiceProvider().GetService<FbtDbContext>();
        context?.Database.Migrate();
    }
}