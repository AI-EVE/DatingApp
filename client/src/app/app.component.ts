import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title: string = 'client';
  users: any;

  constructor(
    private httpClient: HttpClient,
    private accountService: AccountService
  ) {}

  ngOnInit() {
    this.httpClient.get('https://localhost:5001/api/users').subscribe({
      next: (response) => {
        this.users = response;
        console.log(response);
        console.log(this.users);
      },
      error: (err) => console.log(err),
      complete: () => console.log('done'),
    });

    this.accountService.checkLogin();
  }
}
