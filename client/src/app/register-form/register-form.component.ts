import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RegisterService } from '../_services/register.service';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css'],
})
export class RegisterFormComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({});

  @Output() cancelForm = new EventEmitter<void>();

  users: any;

  constructor(private registerService: RegisterService) {}

  ngOnInit() {
    this.registerForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [
        Validators.required,
        this.confirmPasswordValidator.bind(this),
      ]),
      users: new FormArray([]),
    });

    this.registerService.getUsers().subscribe({
      next: (users: any) => {
        users.forEach((user: any) => {
          (this.registerForm.get('users') as FormArray).push(
            new FormGroup({
              username: new FormControl(user.userName),
            })
          );
        });

        this.users = (this.registerForm.get('users') as FormArray).controls;

        console.log(this.users);
      },
    });
  }

  onCancel() {
    this.cancelForm.emit();
  }

  onRegister(event: Event) {
    event.preventDefault();
    if (
      this.registerForm.get('password')?.value !==
      this.registerForm.get('confirmPassword')?.value
    ) {
      console.log('password not match');
      return;
    }

    this.registerService.register(this.registerForm.value).subscribe({
      next: (response) => {
        console.log(response);
        this.registerForm.reset();
        this.cancelForm.emit();
      },
      error: (err) => console.log(err),
      complete: () => console.log('done'),
    });
  }

  confirmPasswordValidator() {
    if (
      this.registerForm.get('password')?.value !==
      this.registerForm.get('confirmPassword')?.value
    ) {
      console.log('password not match');
      return { notMatch: true };
    }
    return null;
  }
}
