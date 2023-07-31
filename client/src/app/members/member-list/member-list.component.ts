import { Component } from '@angular/core';
import { AppUser } from 'src/app/_models/appUser.model';
import { AppUsersService } from 'src/app/_services/app-users.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css'],
})
export class MemberListComponent {
  appUsers: AppUser[] = [];

  constructor(private appUsersService: AppUsersService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.appUsersService.getUsers().subscribe({
      next: (appUsers) => {
        this.appUsers = appUsers;
      },
    });
  }
}
