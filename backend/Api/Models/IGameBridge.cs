namespace Api;


public interface IGameBridge
{
    string Id { get; }
    bool CanJoin { get; }
    bool IsEmpty { get; }
    object GetState();
    void Join(User user);
    void Remove(User user);
}