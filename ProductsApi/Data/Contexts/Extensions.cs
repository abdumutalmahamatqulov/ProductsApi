using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsApi.Data.Entities;

namespace ProductsApi.Data.Contexts;

public static class Extensions
{

    public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IConfiguration>();
        var sqlConnectionString = configuration.GetConnectionString("Sql");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(sqlConnectionString);
        });

        return services;
    }


}
