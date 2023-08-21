using System;

namespace Application;

/// <summary> Um erro relacionado a um jogo. </summary>
public class GameException : Exception
{
    public GameException() { }
    public GameException(string message) : base(message) { }
}