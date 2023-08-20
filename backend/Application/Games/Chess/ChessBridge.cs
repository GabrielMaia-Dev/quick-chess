using Chess;

namespace Application;

public class ChessBridge : GameBridge
{
    public ChessBoard Game { get; }
    public User? BlackPlayer { get; set; }
    public User? WhitePlayer { get; set; }
    public override bool CanJoin => BlackPlayer is null || WhitePlayer is null;

    public override bool IsEmpty => BlackPlayer is null && WhitePlayer is null;

    public ChessBridge()
    {
        Game = new ChessBoard();
    }

    public override object GetState()
    {
        return new ChessSessionState(
            Game,
            BlackPlayer,
            WhitePlayer
        );
    }

    public override void Join(User user)
    {
        if(WhitePlayer is null) WhitePlayer = user;
        else if(BlackPlayer is null) BlackPlayer = user;
        base.Join(user);
    }

    public override void Remove(User user)
    {
        if(WhitePlayer?.Id == user.Id) WhitePlayer = null;
        if(BlackPlayer?.Id == user.Id) WhitePlayer = null;
        base.Remove(user);
    }
}