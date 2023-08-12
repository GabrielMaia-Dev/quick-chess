

using System;
using System.Text.Json;
using Api;
using Chess;

public record ChessSessionState(
    ChessBoard Board,
    User? BlackPlayer,
    User? WhitePlayer
);

public class ChessBridge : IGameBridge
{
    public string Id { get; }
    public ChessBoard Game { get; }
    public User? BlackPlayer { get; set; }
    public User? WhitePlayer { get; set; }
    public bool CanJoin => BlackPlayer is null || WhitePlayer is null;

    public bool IsEmpty => BlackPlayer is null && WhitePlayer is null;

    public ChessBridge()
    {
        Id = Guid.NewGuid().ToString();
        Game = new ChessBoard();
    }

    public object GetState()
    {
        return new ChessSessionState(
            Game,
            BlackPlayer,
            WhitePlayer
        );
    }

    public void Join(User user)
    {
        if(WhitePlayer is null) WhitePlayer = user;
        else if(BlackPlayer is null) BlackPlayer = user;
        // TODO else throw
    }

    public void Remove(User user)
    {
        if(WhitePlayer?.Id == user.Id) WhitePlayer = null;
        if(BlackPlayer?.Id == user.Id) WhitePlayer = null;
    }
}