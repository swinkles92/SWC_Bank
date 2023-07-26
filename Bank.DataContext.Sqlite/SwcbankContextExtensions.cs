using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Bank;

public static class SwcbankContextExtensions
{
    public static IServiceCollection AddSwcbankContext(
        this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "swcbank.db");

        services.AddDbContext<SwcbankContext>(options =>
        {
            options.UseSqlite($"Data Source={databasePath}");
            options.LogTo(WriteLine, // Console
                new[] { Microsoft.EntityFrameworkCore
                .Diagnostics.RelationalEventId.CommandExecuting });
        });

        return services;
    }
}