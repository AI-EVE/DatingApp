import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  isLogin: boolean = false;
  isRegister: boolean = false;
  propagateUserSubscription: any;

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.propagateUserSubscription =
      this.accountService.propagateUser.subscribe({
        next: () => {
          this.updateUserState();
        },
      });

    this.updateUserState();
  }

  updateUserState() {
    this.isLogin = this.accountService.isLogin;
    if (this.isLogin) this.isRegister = false;
  }

  onCancel() {
    this.isRegister = false;
  }

  registerMode() {
    this.isRegister = true;
  }

  ngOnDestroy() {
    this.propagateUserSubscription.unsubscribe();
  }
}
