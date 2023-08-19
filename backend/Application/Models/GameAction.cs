using System.Text.Json.Serialization;

namespace Application;


public abstract class GameAction
{
    public abstract void Do(User user, IGameBridge target);
}

public abstract class GameAction<T> : GameAction where T :IGameBridge
{
    public abstract void Execute(User user, T target);

    public override void Do(User user, IGameBridge target)
    {
        if(target is T) Execute(user, (T) target);
    }
}