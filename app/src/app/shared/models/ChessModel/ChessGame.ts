import { ChessAction, ChessBoard } from "./ChessModel";
import { UserModel } from "../UserModel";
import { HubConnection } from "@microsoft/signalr";
import { GameConnection } from "./GameConnection";
import { NotificationService } from "../../services/notification.service";
import { from, map, switchMap } from "rxjs";

type GameState = {
    board: string ,
    blackPlayer: UserModel,
    whitePlayer: UserModel 
};

export class ChessGame {
    public board: ChessBoard;
    public blackPlayer?: UserModel;
    public whitePlayer?: UserModel;

    constructor(private _connection: GameConnection, private _notification: NotificationService) {
        _connection.notify = (args) => this.notify(args);
        _connection.onUpdateState = (args) => this.onUpdateState(args);
        
        this.board = new ChessBoard();
        
        this.board.actionCallback = (action) => this.sendAction(action);
    }

    sendAction(action: ChessAction) {
        this._connection.send({ $type: 'chess-action', action });
    }

    start() {
        return from(this._connection.connect().then(() => this));
    }

    quit() {
        this._connection.disconnect();
    }

    onUpdateState(arg: GameState) {
        this.board.load(arg.board);
        this.blackPlayer = arg.blackPlayer;
        this.whitePlayer = arg.whitePlayer;
    };

    notify(message: string) {
        this._notification.notify({ type: 'danger', message: message });
    }
  } 
  