using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL;

public class Query
{
    // [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Platform> GetPlatform(AppDbContext context)
        => context.Platforms;

    // [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Command> GetCommand(AppDbContext context)
        => context.Commands;
}
