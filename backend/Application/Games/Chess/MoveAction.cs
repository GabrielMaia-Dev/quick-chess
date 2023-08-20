using Chess;

namespace Application;


public class MoveAction : GameAction<ChessBridge>
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;

    public override void Execute(User user, ChessBridge target)
    {
        if(user == target.BlackPlayer && target.Game.Turn != PieceColor.Black
        || user == target.WhitePlayer && target.Game.Turn != PieceColor.White)
        {
            throw new GameException("Its anothers players turn.");
        }

        var move = new Move(From, To);
        if(!target.Game.IsValidMove(move))
        {
            throw new GameException("Invalid move.");
        }

        target.Game.Move(move);
    }
}