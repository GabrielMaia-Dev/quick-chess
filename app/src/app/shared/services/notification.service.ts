import { Injectable } from '@angular/core';
import { Observable, Subject, scan } from 'rxjs';

export type Notification = {
  type: 'success' | 'danger',
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private _subject = new Subject<Notification>();
  private _obs = this._subject.asObservable();

  constructor() { }

  public getMessages() {
    return this._obs;
  }

  public notify(message: Notification) {
    this._subject.next(message);
  }

}
