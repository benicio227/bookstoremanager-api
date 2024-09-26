using BookStoreManager.Domain.Repositories;
using BookStoreManager.Domain.Repositories.Books;
using BookStoreManager.Infrastructure.DataAccess;
using BookStoreManager.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BookStoreManager.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBooksReadOnlyRepository, BooksRepository>();
        services.AddScoped<IBooksWriteOnlyRepository, BooksRepository>();
        services.AddScoped<IBookUpdateOnlyRepository, BooksRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var version = new Version(8, 0, 39);
        var serverVersion = new MySqlServerVersion(version);


       // optionsBuilder.UseMySql(connectionString, serverVersion);

        services.AddDbContext<BookStoreManagerDbContext>(config => config.UseMySql(connectionString, serverVersion));

    }
}
