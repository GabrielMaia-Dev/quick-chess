import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MainView } from './views/main-view/main-view.component';
import { HttpClientModule } from "@angular/common/http";
import { ChessSessionView } from './views/chess-session-view/chess-session-view.component';
import { ChessBoardComponent } from './components/chess-board/chess-board.component';
import { UserTabComponent } from './components/user-tab/user-tab.component';
import { GameButtonComponent } from './components/game-button/game-button.component';
import { NotificationMessageComponent } from './components/notification/notification-message.component';
import { NotificationContainerComponent } from './components/notification/notification-container.component';


@NgModule({
  declarations: [
    MainView,
    ChessSessionView,
    ChessBoardComponent,
    UserTabComponent,
    GameButtonComponent,
    NotificationContainerComponent,
    NotificationMessageComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  exports: [
    NotificationContainerComponent,
    FormsModule
  ]
})
export class SharedModule { }
