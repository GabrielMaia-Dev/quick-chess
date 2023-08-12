using System;
using System.Threading.Tasks;
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
        var game = coordinator.Assign(Usuario);
        await Groups.AddToGroupAsync(Context.ConnectionId, game.Id);
        await SyncState(game);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var game = coordinator.Get(Usuario);
        coordinator.Drop(Usuario);
        await SyncState(game);
    } 

    public async Task GameAction(GameAction action) 
    {
        var game = coordinator.Get(Usuario);

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
        await Clients.Group(game.Id).SendAsync("GameState", game.GetState());
    }
}
