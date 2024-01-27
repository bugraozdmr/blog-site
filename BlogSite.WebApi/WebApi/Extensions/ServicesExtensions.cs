using DefaultNamespace;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
using Services;
using Services.Concrats;

namespace WebApi.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
        });
    }
    
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    
    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerService, LoggerManager>();

    public static void ConfigureActionFilters(this IServiceCollection services)
    {
        // bu ifadeye nerde ihtiyac varsa çağırılır -- bu iki class sayesinde filtrelenmiş hatalar alınacak
        services.AddScoped<ValidationFilterAttribute>();    // IoC
        services.AddSingleton<LogFilterAttribute>();
    }
    
    public static void ConfigureCors(this IServiceCollection services)
    {
        // gelen isteklerle bu header tüketilebilir artık
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination");
            });
        });
    }
    
    public static void ConfigureDataShaper(this IServiceCollection services)
    {
        // aynı örnek paylaşılır ancak farklı parametrelerle gönderince farklı örneklar oluşuyor -- singleton gibi değil
        services.AddScoped<IDataShaper<PostDto>, DataShaper<PostDto>>();
    }
}