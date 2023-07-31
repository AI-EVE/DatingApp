import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { AppUser } from '../_models/appUser.model';
import { AppUserUpdateData } from '../_models/appUserUpdateData.model';
import { map, of } from 'rxjs';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root',
})
export class AppUsersService {
  baseUrl = environment.apiUrl;
  appUsers: AppUser[] = [];

  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {}

  getUsers() {
    if (this.appUsers.length > 0) return of(this.appUsers);
    return this.http.get<AppUser[]>(this.baseUrl + 'users').pipe(
      map((appUsers) => {
        this.appUsers = appUsers;
        return appUsers;
      })
    );
  }

  getUser(username: string) {
    if (this.appUsers.length > 0) {
      const user = this.appUsers.find((x) => x.userName === username);
      if (user) return of(user);
    }
    return this.http.get<AppUser>(this.baseUrl + 'users/' + username);
  }

  updateUser(updateData: AppUserUpdateData) {
    return this.http.put(this.baseUrl + 'users', updateData).pipe(
      map((response) => {
        let appUser = this.appUsers.find(
          (x) => x.userName == this.accountService.currentUsername
        );
        appUser!.interests = updateData.interests;
        appUser!.lookingFor = updateData.lookingFor;
        appUser!.introduction = updateData.introduction;
        appUser!.city = updateData.city;
        appUser!.country = updateData.country;

        return response;
      })
    );
  }

  // getHttpOptions() {
  //   const userString = localStorage.getItem('user');
  //   if (!userString) return;

  //   const token = JSON.parse(userString).token;
  //   return {
  //     headers: {
  //       Authorization: 'Bearer ' + token,
  //     },
  //   };
  // }
}
