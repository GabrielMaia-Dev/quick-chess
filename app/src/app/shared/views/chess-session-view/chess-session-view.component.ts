import { Component } from '@angular/core';
import { GameConnectionFactory } from '../../services/gamehub.service';
import { Observable, from, map } from 'rxjs';
import { ChessGame } from '../../models/ChessModel/ChessGame';
import { NotificationService } from '../../services/notification.service';
import { NavigationStart, Router } from '@angular/router';
import { GameConnection } from '../../models/ChessModel/GameConnection';

@Component({
  selector: 'app-chess-session-view',
  templateUrl: './chess-session-view.component.html',
  styleUrls: ['./chess-session-view.component.scss']
})
export class ChessSessionView {
  public game$: Observable<ChessGame>;
  private _gameConnection: GameConnection;

  constructor(private _factory: GameConnectionFactory,
              notification: NotificationService,
              router: Router) {
                
    this._gameConnection = _factory.build();
    const game = new ChessGame(this._gameConnection, notification);
    this.game$ = game.start();
    router.events.subscribe(route => {
      if(route instanceof NavigationStart) {
        game.quit();
      }
    })
  }
}

