using System;
using System.Collections.Generic;
using Chess;

namespace Application;

public record ChessSessionState(
    ChessBoard Board,
    User? BlackPlayer,
    User? WhitePlayer
);


public interface IGameBridge
{
    Guid Id { get; }
    bool CanJoin { get; }
    bool IsEmpty { get; }
    object GetState();
    void Join(User user);
    void Remove(User user);
}

public abstract class GameBridge : IGameBridge
{
    public Guid Id { get; }
    public HashSet<User> Users { get; set; }
    public abstract bool CanJoin { get; }
    public virtual bool IsEmpty { get => Users.Count == 0; }

    public GameBridge()
    {
        Id = Guid.NewGuid();
        Users = new();
    }

    public abstract object GetState();
    public virtual void Join(User user)
    {
        Users.Add(user);
    }
    public virtual void Remove(User user)
    {
        Users.Remove(user);
    }
}
