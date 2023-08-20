namespace Application;


public class GameBridgeFactory : IGameBridgeFactory
{
    public IGameBridge Create()
    {
        return new ChessBridge();
    }
}