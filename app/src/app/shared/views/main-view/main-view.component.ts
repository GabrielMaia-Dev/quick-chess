import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-main-view',
  templateUrl: './main-view.component.html',
  styleUrls: ['./main-view.component.scss']
})
export class MainView {

  public model = {
    name: 'Guest'
  }

  constructor(private _auth: AuthService,
              private _router: Router,
              private _notification: NotificationService){ }

  submit(game: string) {
    this._auth.login(this.model).subscribe(() => {
      this._notification.notify({ type: 'success', message: 'Connected!' });
      this._router.navigate(['/session', game])
    },
    () => {
      this._notification.notify({ type: 'danger', message: 'Failed to connect.'})
    });
  }
}
