import { Component, Input } from '@angular/core';
import { AppUser } from 'src/app/_models/appUser.model';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css'],
})
export class MemberCardComponent {
  @Input() appUser: AppUser | undefined;
}
