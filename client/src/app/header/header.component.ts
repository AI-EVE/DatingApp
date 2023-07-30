import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { LoginResponse } from '../_models/LoginResponse.model';
import { LoginModel } from '../_models/login.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  loginForm!: FormGroup;

  isLogin: boolean = false;

  currentUsername: string | null = null;

  checkLoginSubscription: any;

  constructor(public accountService: AccountService) {}

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl(''),
      password: new FormControl(''),
    });

    this.checkLoginSubscription = this.accountService.propagateUser.subscribe({
      next: (loginResponse: LoginResponse | null) => {
        this.updateUserState();
      },
    });

    this.accountService.checkLogin();
  }

  onLogin(event: Event) {
    event.preventDefault();

    if (this.isLogin) {
      this.logout();
      return;
    }

    this.login(
      new LoginModel(
        this.loginForm.value.username,
        this.loginForm.value.password
      )
    );
  }

  login(loginResponse: LoginModel) {
    this.accountService.login(this.loginForm.value).subscribe({
      next: (response) => {
        console.log(response);
        this.loginForm.reset();
      },
      complete: () => console.log('done'),
    });
  }

  logout() {
    this.accountService.logout();
  }

  updateUserState() {
    this.currentUsername = this.accountService.currentUsername;
    this.isLogin = this.accountService.isLogin;
  }

  ngOnDestroy() {
    this.checkLoginSubscription.unsubscribe();
  }
}
