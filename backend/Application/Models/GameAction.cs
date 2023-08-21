using System.Text.Json.Serialization;

namespace Application;


/// <summary> Representa uma ação de um jogo qualquer. </summary>
public abstract class GameAction
{
    /// <summary>
    /// Executa a Ação em uma Ponte
    /// <param name="user">Usuario que esta executando a açao</param>
    /// <param name="target">Em qual Ponte que a ação é executada</param>
    /// </summary>
    public abstract void Do(User user, IGameBridge target);
}

/// <summary>
/// Versão fortemente tipada de GameAction.
/// Sendo T o tipo da Ponte que esta action espera ser invocada.
/// </summary>
public abstract class GameAction<T> : GameAction where T :IGameBridge
{
    /// <summary> Ação a ser executada. </summary>
    public abstract void Execute(User user, T target);

    public override void Do(User user, IGameBridge target)
    {
        if(target is T) Execute(user, (T) target);
    }
}