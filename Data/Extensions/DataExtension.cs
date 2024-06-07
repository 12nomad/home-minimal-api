using HomeMinimalApi.ListingsModule.Interfaces;
using HomeMinimalApi.ListingsModule.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HomeMinimalApi.Data.Extensions;

public static class DataExtension {
    public static async Task ApplyMigrations(this IServiceProvider service) {
        using var scope = service.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<EfCoreDbContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRespositories(this IServiceCollection services, IConfiguration configuration) {
        services.AddSqlServer<EfCoreDbContext>(configuration.GetConnectionString("HomeDbContext"))
                .AddScoped<IListingRepository, EfListingRepository>();
        return services;
    }
}