import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModel } from '../models/UserModel';
import { EMPTY, of, switchMap, tap } from 'rxjs';

type LoginRequest = { name: string; }

type LoginResponse = {
  token: string;
  user: {
    id: string; name: string; token: string;
   }
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly _url = 'http://localhost:5101/auth';
  private _user?: UserModel;
  private _token?: string;

  get user() {
    if(!this._user) this.restoreSession();
    return this._user;
  }
  
  get token() {
    if(!this._token) this.restoreSession();
    return this._token;
  }

  constructor(private _http : HttpClient) { }

  public login(request: LoginRequest) {
    return this._http.post<LoginResponse>(this._url, request).pipe(
      tap(this.setSession),
    );
  }

  private setSession(resp: LoginResponse) {
    sessionStorage.setItem('user', JSON.stringify(resp));
    this._user = resp.user;
    this._token = resp.token;
  }

  private restoreSession() {
    const sessionData = sessionStorage.getItem('user');
    if(!sessionData) return;
    const data = JSON.parse(sessionData) as LoginResponse;
    this._user = data.user;
    this._token = data.token;
  }
}
