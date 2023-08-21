namespace Application;

/// <summary> Factory para criar jogos </summary>
public interface IGameBridgeFactory
{
    /// <summary> Cria um jogo </summary>
    IGameBridge Create();
}
