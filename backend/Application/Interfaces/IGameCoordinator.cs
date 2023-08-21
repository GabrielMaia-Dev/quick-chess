namespace Application;

public interface IGameCoordinator
{
    IGameBridge? Get(User user);
    IGameBridge Assign(User user);
    void Drop(User user);
}
