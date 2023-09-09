using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.GraphQL.Commands;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddPooledDbContextFactory<AppDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("CommandConStr")));

    public static IServiceCollection AddGraphQL(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddSubscriptionType<Subscription>()
            .AddType<PlatformType>()
            .AddType<CommandType>()
            .AddFiltering()
            .AddSorting()
            .AddInMemorySubscriptions()
            .AddProjections();

        return services;
    }

}
