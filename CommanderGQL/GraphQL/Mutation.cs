using CommanderGQL.Data;
using CommanderGQL.Models;
using CommanderGQL.GraphQL.Platforms;

namespace CommanderGQL.GraphQL;

public class Mutation
{
    public async Task<AddPlatformPayload> AddPlatformAsync(
        AddPlatformInput input,
        AppDbContext context)
    {
        var platform = new Platform
        {
            Name = input.Name
        };

        context.Platforms.Add(platform);
        await context.SaveChangesAsync();

        return new AddPlatformPayload(platform);
    }
}
