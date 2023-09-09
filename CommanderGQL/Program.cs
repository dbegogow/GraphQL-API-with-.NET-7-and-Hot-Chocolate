using CommanderGQL.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddGraphQL();

var app = builder.Build();

app.MapGraphQL();
app.UseGraphQLVoyager();
app.UseWebSockets();

app.Run();