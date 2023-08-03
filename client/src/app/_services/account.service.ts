import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel } from '../_models/login.model';
import { Subject, map } from 'rxjs';
import { LoginResponse } from '../_models/LoginResponse.model';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;

  propagateUser = new Subject<LoginResponse | null>();

  isLogin: boolean = false;

  currentUsername: string | null = null;

  token: string | null = null;

  photoUrl: string | null = null;

  constructor(private httpClient: HttpClient, private router: Router) {}

  checkLogin() {
    const user: LoginResponse | null = JSON.parse(
      localStorage.getItem('loginResponse')!
    );
    if (user) {
      this.assertLogin(user);
    }
  }

  login(model: LoginModel) {
    return this.httpClient
      .post<LoginResponse>(`${this.baseUrl}account/login`, model)
      .pipe(
        map((response: LoginResponse) => {
          const loginResponse = response;
          if (loginResponse) {
            localStorage.setItem(
              'loginResponse',
              JSON.stringify(loginResponse)
            );
            this.assertLogin(loginResponse);
            this.router.navigateByUrl('/members');
          }

          return loginResponse;
        })
      );
  }

  logout() {
    localStorage.removeItem('loginResponse');
    this.isLogin = false;
    this.currentUsername = null;
    this.token = null;
    this.photoUrl = null;
    this.propagateUser.next(null);
    this.router.navigateByUrl('/');
  }

  setCurrentUser(user: LoginResponse) {
    this.propagateUser.next(user);
  }

  updateLoginResponse() {
    const loginResponse: LoginResponse | null = JSON.parse(
      localStorage.getItem('loginResponse')!
    );

    console.log(loginResponse);

    if (!loginResponse) {
      this.isLogin = false;
      this.currentUsername = null;
      this.token = null;
      this.photoUrl = null;
      this.propagateUser.next(null);
      return;
    }

    loginResponse.token = this.token!;
    loginResponse.photoUrl = this.photoUrl!;
    loginResponse.username = this.currentUsername!;
    localStorage.setItem('loginResponse', JSON.stringify(loginResponse));

    this.propagateUser.next(loginResponse);
  }

  assertLogin(loginResponse: LoginResponse) {
    this.isLogin = true;
    this.currentUsername = loginResponse.username;
    this.token = loginResponse.token;
    this.photoUrl = loginResponse.photoUrl;
    this.propagateUser.next(loginResponse);
  }

  register(model: any) {
    return this.httpClient
      .post<LoginResponse>(`${this.baseUrl}account/register`, model)
      .pipe(
        map((response) => {
          const loginResponse = response;
          if (loginResponse) {
            localStorage.setItem(
              'loginResponse',
              JSON.stringify(loginResponse)
            );
            this.assertLogin(loginResponse);
          }

          return loginResponse;
        })
      );
  }
}
