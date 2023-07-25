import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { User } from '../_models/user.model';
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

  constructor(private fb: FormBuilder, public accountService: AccountService) {}

  ngOnInit() {
    this.loginForm = this.fb.group({
      username: [''],
      password: [''],
    });

    this.checkLoginSubscription = this.accountService.propagateUser.subscribe({
      next: (user: User | null) => {
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

  login(user: LoginModel) {
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
