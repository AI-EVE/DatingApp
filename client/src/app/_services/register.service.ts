import { Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { HttpClient } from '@angular/common/http';
import { RegisterModel } from '../_models/registerModel.model';
import { map } from 'rxjs';
import { LoginModel } from '../_models/login.model';
import { AppUser } from '../_models/appUser.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  url = environment.apiUrl;
  constructor(
    private accountService: AccountService,
    private httpClient: HttpClient
  ) {}

  register(registerModel: RegisterModel) {
    return this.httpClient
      .post(`${this.url}/account/register`, {
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
    return this.httpClient.get<AppUser[]>('https://localhost:5001/api/users');
  }
}
