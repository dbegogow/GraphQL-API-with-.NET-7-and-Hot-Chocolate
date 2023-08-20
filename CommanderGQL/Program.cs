using CommanderGQL.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration);

var app = builder.Build();

app.Run();