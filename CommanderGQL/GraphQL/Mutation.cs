using CommanderGQL.Data;
using CommanderGQL.Models;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.GraphQL.Commands;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL;

public class Mutation
{
    public async Task<AddPlatformPayload> AddPlatformAsync(
        AddPlatformInput input,
        AppDbContext context,
        ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        var platform = new Platform
        {
            Name = input.Name
        };

        context.Platforms.Add(platform);
        await context.SaveChangesAsync();

        await eventSender.SendAsync(
            nameof(Subscription.OnPlatformAdded),
            platform,
            cancellationToken);

        return new AddPlatformPayload(platform);
    }

    public async Task<AddCommandPayload> AddCommandAsync(
        AddCommandInput input,
        AppDbContext context)
    {
        var command = new Command
        {
            HowTo = input.HowTo,
            CommandLine = input.CommandLine,
            PlatformId = input.PlatformId,
        };

        context.Commands.Add(command);
        await context.SaveChangesAsync();

        return new AddCommandPayload(command);
    }

}
