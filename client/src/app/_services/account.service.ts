import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel } from '../_models/login.model';
import { Subject, map } from 'rxjs';
import { User } from '../_models/user.model';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';

  propagateUser = new Subject<User | null>();

  isLogin: boolean = false;

  currentUsername: string | null = null;

  constructor(private httpClient: HttpClient) {}

  checkLogin() {
    const user: User | null = JSON.parse(localStorage.getItem('user')!);
    if (user) {
      this.isLogin = true;
      this.currentUsername = user.username;
      this.propagateUser.next(user);
    }
  }

  login(model: LoginModel) {
    return this.httpClient
      .post<User>(`${this.baseUrl}account/login`, model)
      .pipe(
        map((response: User) => {
          const user = response;
          if (user) {
            this.assertLogin(user);
          }

          return user;
        })
      );
  }

  logout() {
    localStorage.removeItem('user');
    this.isLogin = false;
    this.currentUsername = null;
    this.propagateUser.next(null);
  }

  setCurrentUser(user: User) {
    this.propagateUser.next(user);
  }

  assertLogin(user: User) {
    this.isLogin = true;
    this.currentUsername = user.username;
    localStorage.setItem('user', JSON.stringify(user));
    this.propagateUser.next(user);
  }
}
