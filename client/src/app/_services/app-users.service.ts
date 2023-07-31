import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { AppUser } from '../_models/appUser.model';

@Injectable({
  providedIn: 'root',
})
export class AppUsersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUsers() {
    return this.http.get<AppUser[]>(this.baseUrl + 'users');
  }

  getUser(username: string) {
    return this.http.get<AppUser>(this.baseUrl + 'users/' + username);
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
