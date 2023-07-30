import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel } from '../_models/login.model';
import { Subject, map } from 'rxjs';
import { LoginResponse } from '../_models/LoginResponse.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';

  propagateUser = new Subject<LoginResponse | null>();

  isLogin: boolean = false;

  currentUsername: string | null = null;

  constructor(private httpClient: HttpClient, private router: Router) {}

  checkLogin() {
    const user: LoginResponse | null = JSON.parse(
      localStorage.getItem('user')!
    );
    if (user) {
      this.isLogin = true;
      this.currentUsername = user.username;
      this.propagateUser.next(user);

      this.router.navigateByUrl('/members');
    }
  }

  login(model: LoginModel) {
    return this.httpClient
      .post<LoginResponse>(`${this.baseUrl}account/login`, model)
      .pipe(
        map((response: LoginResponse) => {
          const loginResponse = response;
          if (loginResponse) {
            this.assertLogin(loginResponse);
            this.router.navigateByUrl('/members');
          }

          return loginResponse;
        })
      );
  }

  logout() {
    localStorage.removeItem('user');
    this.isLogin = false;
    this.currentUsername = null;
    this.propagateUser.next(null);
    this.router.navigateByUrl('/');
  }

  setCurrentUser(user: LoginResponse) {
    this.propagateUser.next(user);
  }

  assertLogin(loginResponse: LoginResponse) {
    this.isLogin = true;
    this.currentUsername = loginResponse.username;
    localStorage.setItem('user', JSON.stringify(loginResponse));
    this.propagateUser.next(loginResponse);
  }
}
