import { Injectable } from '@angular/core';
import { HttpTransportType, HubConnection, HubConnectionBuilder } from '@microsoft/signalr'
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';
import { GameConnection } from '../models/ChessModel/GameConnection';

@Injectable({
  providedIn: 'root'
})
export class GameConnectionFactory {

  constructor(private _auth: AuthService) { }

  public build() {
      const connection = new HubConnectionBuilder()
      .withUrl(`${environment.chessHubUrl}`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets,
        accessTokenFactory: () => this._auth.token || ''
      })
      .build();

    return new GameConnection(connection);
  }
}