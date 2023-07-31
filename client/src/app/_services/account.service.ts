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
    this.propagateUser.next(null);
    this.router.navigateByUrl('/');
  }

  setCurrentUser(user: LoginResponse) {
    this.propagateUser.next(user);
  }

  assertLogin(loginResponse: LoginResponse) {
    this.isLogin = true;
    this.currentUsername = loginResponse.username;
    this.token = loginResponse.token;
    this.propagateUser.next(loginResponse);
  }
}
