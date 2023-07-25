import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  isLogin: boolean = false;
  isRegister: boolean = false;
  registerForm!: FormGroup;
  propagateUserSubscription: any;

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.propagateUserSubscription =
      this.accountService.propagateUser.subscribe({
        next: () => {
          this.updateUserState();
        },
      });

    this.registerForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required]),
    });

    this.updateUserState();
  }

  updateUserState() {
    this.isLogin = this.accountService.isLogin;
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
