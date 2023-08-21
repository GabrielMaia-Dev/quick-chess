using System;
using System.Collections.Generic;
using Chess;

namespace Application;

public record ChessSessionState(
    ChessBoard Board,
    User? BlackPlayer,
    User? WhitePlayer
);


/// <summary>
/// Declara uma interface para se comunicar com uma Ponte para um Jogo
/// <summary>
public interface IGameBridge
{
    /// <summary> Id da Ponte </summary>
    Guid Id { get; }
    /// <summary> Flag indicando vagas neste jogo. </summary>
    bool CanJoin { get; }
    /// <summary> Verdadeiro se este jogo nao contem jogadores. </summary>
    bool IsEmpty { get; }
    /// <summary> Obtem um objeto que representa o estado do jogo. </summary>
    object GetState();
    /// <summary> Adiciona um usuaario ao jogo. </summary>
    void Join(User user);
    /// <summary> Remove um determinado usuario do jogo. </summary>
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
