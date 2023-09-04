using System;

namespace Application;


public class GameBridgeFactory : IGameBridgeFactory
{
    public IGameBridge Create(string game)
    {
        return game switch {
            "chess" => new ChessBridge(),
            _ => throw new Exception("Unkown game time.")
        };
    }
}