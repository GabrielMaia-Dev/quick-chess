using System.Collections.Generic;
using System.Linq;

namespace Application;

public class GameCoordinator : IGameCoordinator
{
    private readonly HashSet<User> _users = new();
    private readonly HashSet<IGameBridge> _games = new();
    private readonly Dictionary<User, IGameBridge> _userGameMap = new();
    private readonly IGameBridgeFactory _factory;

    public GameCoordinator(IGameBridgeFactory factory)
    {
        this._factory = factory;
    }

    public IGameBridge Assign(User user, string gameType)
    {
        _users.Add(user);

        var game = _games.FirstOrDefault(g => g.CanJoin);
        
        if(game is null)
        {
            game = _factory.Create(gameType);
            _games.Add(game);
        }

        game.Join(user);
        _userGameMap.Add(user, game);

        return game;
    }

    public void Drop(User user)
    {
        if(!_userGameMap.ContainsKey(user)) return;

        var game = _userGameMap[user];
        game.Remove(user);
        _users.Remove(user);
        _userGameMap.Remove(user);
        
        if(game.IsEmpty)
        {
            _games.Remove(game);
        }
    }

    public IGameBridge? Get(User user)
    {
        if(!_userGameMap.ContainsKey(user)) return null;
        return _userGameMap[user];
    }
}
