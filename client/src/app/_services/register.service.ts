import { Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { HttpClient } from '@angular/common/http';
import { RegisterModel } from '../_models/registerModel.model';
import { map } from 'rxjs';
import { LoginModel } from '../_models/login.model';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  constructor(
    private accountService: AccountService,
    private httpClient: HttpClient
  ) {}

  register(registerModel: RegisterModel) {
    return this.httpClient
      .post('https://localhost:5001/api/account/register', {
        username: registerModel.username,
        password: registerModel.password,
      })
      .pipe(
        map((response) => {
          console.log(response);
          if (response) {
            this.accountService
              .login(
                new LoginModel(registerModel.username, registerModel.password)
              )
              .subscribe();
          }

          return response;
        })
      );
  }

  getUsers() {
    return this.httpClient.get<any>('https://localhost:5001/api/users');
  }
}
