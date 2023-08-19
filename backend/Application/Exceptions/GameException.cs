using System;

namespace Application;

public class GameException : Exception
{
    public GameException() { }
    public GameException(string message) : base(message) { }
}