import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainView } from './shared/views/main-view/main-view.component';
import { ChessSessionView } from './shared/views/chess-session-view/chess-session-view.component';

const routes: Routes = [
  { path: '', component: MainView },
  { path: 'session/chess', component: ChessSessionView }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
