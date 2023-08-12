using System;
using System.Collections.Generic;
using Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IGameCoordinator, GameCoordinator>();
builder.Services.AddSingleton<IGameBridgeFactory, GameBridgeFactory>();
builder.Services.AddTransient<UserTokenMiddleware>();

builder.Services.AddSignalR()
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.Converters.Add(new ChessBoardConverter());
        options.PayloadSerializerOptions.Converters.Add(new GameActionJsonConverter(new Dictionary<string, Type>() { ["chess-action"] = typeof(MoveAction) }));
    });  

var app = builder.Build();

app.UseCors(conf => conf.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseRouting();

app.Map("/hub", conf =>
{
    conf.UseMiddleware<UserTokenMiddleware>();
    conf.UseEndpoints(ep => 
    {
        ep.MapHub<GameHub>("hub");
    });
});

app.MapControllers();

app.Run();
