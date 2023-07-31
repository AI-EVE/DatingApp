import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { AppUser } from 'src/app/_models/appUser.model';
import { AppUserUpdateData } from 'src/app/_models/appUserUpdateData.model';
import { AccountService } from 'src/app/_services/account.service';
import { AppUsersService } from 'src/app/_services/app-users.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css'],
})
export class MemberEditComponent {
  isLoading: boolean = false;
  appUser: AppUser | undefined;
  username: string | null = null;
  form: FormGroup = new FormGroup({
    introduction: new FormControl('', []),
    lookingFor: new FormControl('', []),
    interests: new FormControl('', []),
    city: new FormControl('', []),
    country: new FormControl('', []),
  });

  constructor(
    private accountService: AccountService,
    private memberService: AppUsersService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.username = this.accountService.currentUsername;
    this.loadAppUser();
  }

  loadAppUser() {
    if (!this.username) {
      this.router.navigateByUrl('/members');
      return;
    }
    this.memberService
      .getUser(this.username)
      .pipe(take(1))
      .subscribe({
        next: (appUser) => {
          this.appUser = appUser;
          this.populateForm();
        },
        error: (error) => {
          this.toastr.error(error.error);
          this.router.navigateByUrl('/members');
        },
      });
  }

  populateForm() {
    if (!this.appUser) return;
    this.form.setValue({
      introduction: this.appUser.introduction,
      lookingFor: this.appUser.lookingFor,
      interests: this.appUser.interests,
      city: this.appUser.city,
      country: this.appUser.country,
    });
  }

  updateAppUser() {
    if (!this.username) return;
    this.isLoading = true;
    this.memberService
      .updateUser({ ...this.form.value } as AppUserUpdateData)
      .subscribe({
        next: () => {
          this.toastr.success('Profile updated successfully');
          // this.router.navigateByUrl(`/members/${this.username}`);
          this.appUser = { ...this.appUser, ...this.form.value };
          console.log(this.appUser);
          this.form.reset(this.appUser);
          this.isLoading = false;
        },
        error: (error) => {
          this.toastr.error(error.error);
          this.isLoading = false;
        },
      });
  }
}
