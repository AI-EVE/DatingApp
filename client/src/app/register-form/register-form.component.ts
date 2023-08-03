import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { LoginResponse } from '../_models/LoginResponse.model';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css'],
})
export class RegisterFormComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({});
  @Output() cancelForm = new EventEmitter<void>();
  users: any;
  maxDate: Date = new Date();
  validationErrors: string[] | undefined;

  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private fBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);

    this.registerForm = this.fBuilder.group({
      gender: ['male'],
      username: ['', [Validators.required]],
      knownAs: ['', [Validators.required]],
      country: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      city: ['', [Validators.required]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(15),
        ],
      ],
      confirmPassword: [
        '',
        [Validators.required, this.confirmPasswordValidator.bind(this)],
      ],
      users: this.fBuilder.array([]),
    });

    this.registerForm.controls['password'].valueChanges.subscribe(() => {
      this.registerForm.controls['confirmPassword'].updateValueAndValidity();
    });
  }

  onCancel() {
    this.cancelForm.emit();
  }

  onRegister(event: Event) {
    event.preventDefault();
    this.registerForm.markAllAsTouched();
    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }
    if (
      this.registerForm.controls['password'].value !==
      this.registerForm.controls['confirmPassword'].value
    ) {
      this.toastr.error('Password not match');
      return;
    }
    const dateOfBirth = this.getDateOnly(
      this.registerForm.controls['dateOfBirth'].value
    );
    const values = { ...this.registerForm.value, dateOfBirth };
    console.log(values);
    this.accountService.register(values).subscribe({
      next: (_) => {
        this.router.navigateByUrl('/members');
      },
      error: (error) => {
        this.validationErrors = error;
      },
    });
  }

  confirmPasswordValidator() {
    if (
      this.registerForm.get('password')?.value !==
      this.registerForm.get('confirmPassword')?.value
    ) {
      console.log(this.registerForm.valid);
      console.log('password not match');
      return { notMatch: true };
    }
    return null;
  }

  private getDateOnly(date: string | undefined) {
    if (!date) return null;
    let dateObj = new Date(date);
    return new Date(
      dateObj.setMinutes(dateObj.getMinutes() - dateObj.getTimezoneOffset())
    )
      .toISOString()
      .slice(0, 10);
  }
}
