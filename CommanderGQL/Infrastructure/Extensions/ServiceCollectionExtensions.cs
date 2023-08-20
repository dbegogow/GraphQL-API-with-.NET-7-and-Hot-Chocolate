using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<AppDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("CommandConStr")));
}
