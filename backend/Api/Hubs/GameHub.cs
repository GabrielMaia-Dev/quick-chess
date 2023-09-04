using System;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.SignalR;

namespace Api;

public sealed class GameHub : Hub
{
    private readonly IGameCoordinator coordinator;
    public User Usuario { get => Context.GetHttpContext()!.GetUsuario(); }

    public GameHub(IGameCoordinator coordinator)
    {
        this.coordinator = coordinator;
    }

    public override async Task OnConnectedAsync()
    {
        if(!Context.GetHttpContext()!.Request.Query.ContainsKey("game"))
        {
            Context.Abort();
        }

        string gameType = Context.GetHttpContext()!.Request.Query["game"]!;

        var game = coordinator.Assign(Usuario, gameType);
        await Groups.AddToGroupAsync(Context.ConnectionId, game.Id.ToString());
        await SyncState(game);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var game = GetBridge(Usuario);
        coordinator.Drop(Usuario);
        await SyncState(game);
    } 

    public async Task GameAction(GameAction action) 
    {
        var game = GetBridge(Usuario);

        try
        {
            action.Do(Usuario, game);
        }
        catch(GameException e)
        {
            await NotifyCaller(e.Message);
        }

        await SyncState(game);
    }

    private Task NotifyCaller(string message)
    {
        return Clients.Caller.SendAsync("Notify", message);
    }

    private async Task SyncState(IGameBridge game)
    {
        await Clients.Group(game.Id.ToString()).SendAsync("GameState", game.GetState());
    }

    private IGameBridge GetBridge(User user)
    {
        return coordinator.Get(user) ?? throw new Exception();
    }
}
